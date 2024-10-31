using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMM
{
    public partial class MetaDataPatcher : Form
    {
        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        private bool mouseDown = false;
        private Point lastLocation;

        public MetaDataPatcher()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, string UEV)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
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

        private void MetaDataPatcher_Load(object sender, EventArgs e)
        {
            WLMMCurrentMetaData_TB.Clear();
            PatchMetaData_TB.Clear();
        }

        private void WLMMPathBrowse_Button_Click(object sender, EventArgs e)
        {
            WLMMCurrentMetaData_TB.Clear();
            openFileDialog1.Filter = ".wlmm files (*.wlmm)|*.wlmm";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".wlmm"))
                {
                    WLMMPath_TB.Text = openFileDialog1.FileName;
                    //Extract .wlmm
                    if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp"))
                    {
                        Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp", true);
                    }
                    Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
                    ZipFile.ExtractToDirectory(openFileDialog1.FileName, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");

                    //Read Metadata.dat
                    string[] MetaLines = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
                    foreach (string line in MetaLines)
                    {
                        WLMMCurrentMetaData_TB.Text += line + "\r\n";
                    }
                    WLMMCurrentMetaData_TB.Text = WLMMCurrentMetaData_TB.Text.TrimEnd();

                    ApplyPatch_Button.Enabled = true;
                }
            }
        }

        private void PasteData_Button_Click(object sender, EventArgs e)
        {
            PatchMetaData_TB.Clear();
            PatchMetaData_TB.Text = Clipboard.GetText();
        }

        private void ApplyPatch_Button_Click(object sender, EventArgs e)
        {
            if (PatchMetaData_TB.Text.Contains("ModName = ") && PatchMetaData_TB.Text.Contains("ModAuthor = ") && PatchMetaData_TB.Text.Contains("ModVersion = ") && PatchMetaData_TB.Text.Contains("SupportedWLVersions = ") && PatchMetaData_TB.Text.Contains("ModURL = ") && PatchMetaData_TB.Text.Contains("Categories = ") && PatchMetaData_TB.Text.Contains("Characters = "))
            {
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat") && PatchMetaData_TB.Text != "")
                {
                    //Write Metadata.dat
                    File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat", PatchMetaData_TB.Text);

                    //Delete original
                    if (File.Exists(WLMMPath_TB.Text))
                    {
                        File.Delete(WLMMPath_TB.Text);
                    }
                    //Zip up
                    ZipFile.CreateFromDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp", WLMMPath_TB.Text);

                    MessageBox.Show("Mod successfully patched.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    WLMMCurrentMetaData_TB.Text = PatchMetaData_TB.Text;
                    PatchMetaData_TB.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Metadata invalid.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WLMMPath_TB_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files[0].ToLower().EndsWith(".wlmm"))
            {
                WLMMCurrentMetaData_TB.Clear();
                WLMMPath_TB.Text = files[0];
                //Extract .wlmm
                if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp"))
                {
                    Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp", true);
                }
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
                ZipFile.ExtractToDirectory(files[0], Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");

                //Read Metadata.dat
                string[] MetaLines = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
                foreach (string line in MetaLines)
                {
                    WLMMCurrentMetaData_TB.Text += line + "\r\n";
                }
                WLMMCurrentMetaData_TB.Text = WLMMCurrentMetaData_TB.Text.TrimEnd();

                ApplyPatch_Button.Enabled = true;
            }
        }

        private void WLMMPath_TB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
