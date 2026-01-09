using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMM
{
    public partial class ModPackCreator : Form
    {

        private bool mouseDown = false;
        private Point lastLocation;

        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        public ModPackCreator()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public void TransferInfo(string Path, string Version, string UEV)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;

            LoadSupportedVersions();
            LoadActiveMods();
        }

        private void LoadSupportedVersions()
        {
            SupportedWLVersions_CLB.Items.Clear();
            SupportedWLVersions_CLB.Items.Add("UE5.4");
            if (File.Exists(Application.StartupPath + @"System\SupportedVersions.ini"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"System\SupportedVersions.ini"))
                {
                    SupportedWLVersions_CLB.Items.Add(GetSlice(line, "#", 0));
                }
            }
            SupportedWLVersions_CLB.Items.Add("All Versions");
        }

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            string[] TempArray = Txt.Split(Delimiter);
            return TempArray[slice].Trim();
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void TitlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_Button_MouseEnter(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void Close_Button_MouseLeave(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon;
        }

        private void LoadActiveMods()
        {
            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod") { continue; }
                //Check if mod is active
                if (File.Exists(ModPath + @"\Enabled.dat"))
                {
                    if (File.ReadAllText(ModPath + @"\Enabled.dat") == "Checked")
                    {
                        ModList_LB.Items.Add(ModName);

                        //Check mod supported version and add to checked listbox
                        string SupVers = string.Empty;
                        string[] MetaData = File.ReadAllLines(ModPath + @"\Metadata.dat");
                        foreach (string meta in MetaData)
                        {
                            if (meta.StartsWith("SupportedWLVersions"))
                            {
                                SupVers = GetSlice(meta, "=", 1);
                            }
                        }
                        if (SupVers.Contains(","))
                        {
                            string[] SplitSupVers = SupVers.Split(",");
                            foreach (string s in SplitSupVers)
                            {
                                string TrimmedS = s.Trim();
                                for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                                {
                                    if (SupportedWLVersions_CLB.Items[i].ToString() == TrimmedS)
                                    {
                                        SupportedWLVersions_CLB.SetItemChecked(i, true);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                            {
                                if (SupportedWLVersions_CLB.Items[i].ToString() == SupVers)
                                {
                                    SupportedWLVersions_CLB.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CreateModPack_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack");
                    string ModPackPath = folderBrowserDialog1.SelectedPath;
                    //Create metadata file
                    string SupportedVersions = "";
                    int i;
                    for (i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                    {
                        if (SupportedWLVersions_CLB.GetItemChecked(i))
                        {
                            SupportedVersions += SupportedWLVersions_CLB.Items[i].ToString() + ",";
                        }
                    }
                    SupportedVersions = SupportedVersions.TrimEnd(',');
                    string ModList = "";
                    foreach (string Mod in ModList_LB.Items)
                    {
                        ModList += Mod + ",";
                    }
                    ModList = ModList.TrimEnd(',');
                    ModDescription_TB.Text = ModDescription_TB.Text.Replace("\r\n", "(nl)");
                    string Metadata = "ModName = " + ModName_TB.Text + "\nModAuthor = " + ModAuthor_TB.Text +
                        "\nModDescription = " + ModDescription_TB.Text + "\nSupportedWLVersions = " + SupportedVersions +
                        "\nModList = " + ModList;
                    File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack\Metadata.dat", Metadata);
                    //Move active mods to temp folder
                    foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded", "*"))
                    {
                        string ModName = Path.GetFileName(ModPath);
                        if (ModName == "AutoMod") { continue; }
                        if (File.Exists(ModPath + @"\Enabled.dat"))
                        {
                            if (File.ReadAllText(ModPath + @"\Enabled.dat") == "Checked")
                            {
                                Directory.Move(ModPath, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack\" + ModName);
                            }
                        }
                    }
                    ZipFile.CreateFromDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack", folderBrowserDialog1.SelectedPath + @"\" + ModName_TB.Text + ".wlmp");
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack\Metadata.dat");
                    foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack", "*"))
                    {
                        string ModName = Path.GetFileName(ModPath);
                        Directory.Move(ModPath, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName);
                    }
                    Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\ModPack", true);
                    MessageBox.Show("Mod Pack Created Successfully!", "Mod Pack Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating modpack.\nEx: " + ex.Message.ToString(), "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModPackCreator_Load(object sender, EventArgs e)
        {

        }
    }
}
