using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMM
{
    public partial class ModCreator : Form
    {
        private bool mouseDown = false;
        private Point lastLocation;

        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;
        private Main ParentForm = null;

        string CurrentlyEditing_Path = string.Empty;

        public void TransferInfo(string Path, string Version, string UEV, Main main)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
            ParentForm = main;
        }

        public ModCreator()
        {
            InitializeComponent();
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

        private void ModCreator_Load(object sender, EventArgs e)
        {
            LoadSupportedVersions();

            ModIconPath_TB.Text = "Default";
            ModIcon_Preview.ImageLocation = Application.StartupPath + @"System\Default_Icon.png";
        }

        private void LoadSupportedVersions()
        {
            SupportedWLVersions_CLB.Items.Clear();
            if (File.Exists(Application.StartupPath + @"System\EngineVersions.ini"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"System\EngineVersions.ini"))
                {
                    SupportedWLVersions_CLB.Items.Add(GetSlice(line, "#", 0));
                }
            }
            if (File.Exists(Application.StartupPath + @"System\SupportedVersions.ini"))
            {
                SupportedWLVersions_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"System\SupportedVersions.ini"));
            }
        }

        private void ModIconBrowse_Button_Click(object sender, EventArgs e)
        {
            if (ParentForm.prevIconPath != string.Empty)
            {
                openFileDialog2.InitialDirectory = ParentForm.prevIconPath;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                ModIconPath_TB.Text = openFileDialog2.FileName;
                ModIcon_Preview.ImageLocation = ModIconPath_TB.Text;
                ParentForm.prevIconPath = Path.GetDirectoryName(openFileDialog2.FileName);
            }
        }

        private void AddPak_Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pak files (*.pak)|*.pak|All files (*.*)|*.*";
            if (ParentForm.prevPakPath != string.Empty)
            {
                openFileDialog1.InitialDirectory = ParentForm.prevPakPath;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] paks = openFileDialog1.FileNames;
                foreach (string pak in paks)
                {
                    PakList.Items.Add(Path.GetFileName(pak), 0);
                    PakList.Items[PakList.Items.Count - 1].Tag = pak;
                }
                ParentForm.prevPakPath = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        private void RemovePak_Button_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem LVI in PakList.SelectedItems)
            {
                LVI.Remove();
            }
        }

        public void AddToAutoModList(string AMPath)
        {
            ListViewItem FoundDupe = null;
            foreach (ListViewItem LVI in AutoModList.Items)
            {
                if (LVI.Text == Path.GetFileName(AMPath))
                {
                    FoundDupe = LVI;
                    break;
                }
            }
            if (FoundDupe != null)
            {
                AutoModList.Items.Remove(FoundDupe);
            }

            AutoModList.Items.Add(Path.GetFileName(AMPath), 1);
            AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMPath;
        }

        private void AddAutoMod_Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".txt files (*.txt)|*.txt| .collection files (*.collection)|*.collection|All files (*.*)|*.*";
            if (ParentForm.prevAutoModPath != string.Empty)
            {
                openFileDialog1.InitialDirectory = ParentForm.prevAutoModPath;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] automods = openFileDialog1.FileNames;
                foreach (string AMs in automods)
                {
                    if (Path.GetExtension(AMs) == ".txt")
                    {
                        AutoModList.Items.Add(Path.GetFileName(AMs), 1);
                        AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                    }
                    else if (Path.GetExtension(AMs) == ".collection")
                    {
                        AutoModList.Items.Add(Path.GetFileName(AMs), 2);
                        AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                    }
                    else
                    {
                        MessageBox.Show(AMs.ToString() + " is not a valid AutoMod file.");
                    }
                }
                ParentForm.prevAutoModPath = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        private void RemoveAutoMod_Button_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem LVI in AutoModList.SelectedItems)
            {
                LVI.Remove();
            }
        }

        private void CreateAutoMod_Button_Click(object sender, EventArgs e)
        {
            AutoModCreator AutoModCreator_Form = new AutoModCreator();
            AutoModCreator_Form.Show();
            AutoModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, this);
        }

        private void BuildMods_Button_Click(object sender, EventArgs e)
        {
            bool ModValid = true;
            string CharPool = @"=,\/:*?""<>|";
            // Validate Textfields
            if (ModName_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModName_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", ModName_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", ModName_TB, 3000);
            }

            if (ModAuthor_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModAuthor_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Author is empty or invalid character found =,\/:*?""<>|", ModAuthor_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Author is empty or invalid character found =,\/:*?""<>|", ModAuthor_TB, 3000);
            }

            if (ModVersion_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModVersion_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Version is empty or invalid character found =,\/:*?""<>|", ModVersion_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Version is empty or invalid character found =,\/:*?""<>|", ModVersion_TB, 3000);
            }

            if (ModURL_TB.Text == "")
            {
                ModURL_TB.Text = "None";
            }

            if (ModIconPath_TB.Text == "")
            {
                ModIconPath_TB.Text = "Default";
            }

            if (SupportedWLVersions_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No supported version selected.", SupportedWLVersions_CLB, 3000);
            }

            if (ModValid)
            {
                // Create a thread and call a background method
                Thread backgroundThread = new Thread(new ThreadStart(BuildMod));
                // Start thread
                backgroundThread.Start();
            }
        }

        private void PakList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void PakList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.EndsWith(".pak"))
                {
                    PakList.Items.Add(Path.GetFileName(file), 0);
                    PakList.Items[PakList.Items.Count - 1].Tag = file;
                }
            }
        }

        private void AutoModList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void AutoModList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".txt")
                {
                    AutoModList.Items.Add(Path.GetFileName(file), 1);
                    AutoModList.Items[AutoModList.Items.Count - 1].Tag = file;
                }
                else if (Path.GetExtension(file) == ".collection")
                {
                    AutoModList.Items.Add(Path.GetFileName(file), 2);
                    AutoModList.Items[AutoModList.Items.Count - 1].Tag = file;
                }
            }
        }

        private void ModIconPath_TB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void ModIconPath_TB_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files[0].ToLower().EndsWith(".png"))
            {
                ModIconPath_TB.Text = files[0];
                ModIcon_Preview.ImageLocation = ModIconPath_TB.Text;
            }
        }

        private void BuildMod()
        {
            //.zip / .wlmm
            //Paks
            //    .pak files

            //AutoMod
            //    .txt files

            //metadata
            //icon
            //enabled.dat
            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                BuildMods_Button.Hide();
                ProgressInfo_Label.Show();
                BuildModProgress_PB.Show();
                LoadMod_Button.Hide();
                OpenModFolder_Button.Hide();
                ProgressInfo_Label.Text = "Creating Staging Environment...";
            });

            Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging", true);

            Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\Paks");
            Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\AutoMod");

            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Copying .paks...";
                BuildModProgress_PB.Value = 1;
            });

            PakList.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                foreach (ListViewItem LV in PakList.Items)
                {
                    string CleanPakName = Path.GetFileNameWithoutExtension(LV.Tag.ToString());
                    if (CleanPakName.EndsWith("_P") == false)
                    {
                        CleanPakName += "_P";
                    }
                    if (File.Exists(LV.Tag.ToString()))
                    {
                        File.Copy(LV.Tag.ToString(), Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\Paks\" + CleanPakName + ".pak", true);
                    }
                    else
                    {
                        MessageBox.Show("File not found: " + LV.Tag.ToString() + "\nName in list: " + LV.Text + "\nAborting build.", "Wild Life Mod Manager");
                        return;
                    }
                }
            });

            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Copying AutoMod files...";
                BuildModProgress_PB.Value = 2;
            });
            AutoModList.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                foreach (ListViewItem LV in AutoModList.Items)
                {
                    if (File.Exists(LV.Tag.ToString()))
                    {
                        File.Copy(LV.Tag.ToString(), Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\AutoMod\" + LV.Text, true);
                    }
                    else
                    {
                        MessageBox.Show("File not found: " + LV.Tag.ToString() + "\nName in list: " + LV.Text + "\nAborting build.", "Wild Life Mod Manager");
                        return;
                    }
                }
            });

            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Writing MetaData...";
                BuildModProgress_PB.Value = 3;
            });
            string SupportedVersions = "";
            int i;
            for (i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
            {
                if (SupportedWLVersions_CLB.GetItemChecked(i))
                {
                    SupportedVersions += SupportedWLVersions_CLB.Items[i].ToString() + ",";
                }
            }
            if (SupportedVersions.Contains("All Versions"))
            {
                SupportedVersions = "All Versions";
            }
            else
            {
                SupportedVersions = SupportedVersions.TrimEnd(',');
            }

            string Metadata = "ModName = " + ModName_TB.Text + "\nModAuthor = " + ModAuthor_TB.Text +
                "\nModVersion = " + ModVersion_TB.Text + "\nSupportedWLVersions = " + SupportedVersions +
                "\nModURL = " + ModURL_TB.Text;
            File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\Metadata.dat", Metadata);
            File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\Enabled.dat", "Checked");
            if (ModIconPath_TB.Text != "Default")
            {
                if (File.Exists(ModIconPath_TB.Text))
                {
                    File.Copy(ModIconPath_TB.Text, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging\Icon.png", true);
                }
            }

            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Packaging...";
                BuildModProgress_PB.Value = 4;
            });

            if (CurrentlyEditing_Path == string.Empty)
            {
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\" + ModName_TB.Text + ".wlmm"))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\" + ModName_TB.Text + ".wlmm");
                }
                ZipFile.CreateFromDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging", Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\" + ModName_TB.Text + ".wlmm");
            }
            else
            {
                if (File.Exists(CurrentlyEditing_Path))
                {
                    File.Delete(CurrentlyEditing_Path);
                }
                ZipFile.CreateFromDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging", CurrentlyEditing_Path);

                // If this path is in Active Mods, reload that mod.
                ParentForm.ReloadAffectedMod(CurrentlyEditing_Path);
            }
            

            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                BuildMods_Button.Show();
                ProgressInfo_Label.Hide();
                BuildModProgress_PB.Hide();
                LoadMod_Button.Show();
                OpenModFolder_Button.Show();
            });
        }

        private void OpenModFolder_Button_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator");
            Process.Start("explorer.exe", Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator");
        }

        private void LoadMod_Button_Click(object sender, EventArgs e)
        {
            //.zip / .wlmm
            //Paks
            //    .pak files

            //AutoMod
            //    .txt files

            //metadata
            //icon
            //enabled.dat
            PakList.Items.Clear();
            AutoModList.Items.Clear();
            if (ParentForm.prevModPath == string.Empty)
            {
                openFileDialog3.InitialDirectory = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator";
            }
            else
            {
                openFileDialog3.InitialDirectory = ParentForm.prevModPath;
            }
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp"))
                {
                    Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp", true);
                }
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
                //Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging", true);
                //Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging");
                ZipFile.ExtractToDirectory(openFileDialog3.FileName, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
                CurrentlyEditing_Path = openFileDialog3.FileName;
                CurrentlyEditing_LL.Text = openFileDialog3.FileName;
                StopEditing_LL.Show();
                foreach (string pak in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Paks", "*.pak"))
                {
                    PakList.Items.Add(Path.GetFileName(pak), 0);
                    PakList.Items[PakList.Items.Count - 1].Tag = pak;
                }

                foreach (string AMs in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\AutoMod", "*.txt"))
                {
                    AutoModList.Items.Add(Path.GetFileName(AMs), 1);
                    AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                }
                foreach (string AMs in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\AutoMod", "*.collection"))
                {
                    AutoModList.Items.Add(Path.GetFileName(AMs), 2);
                    AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                }

                //Name Author Versions Version URL Icon
                //Read MetaData
                string SupVers = string.Empty;
                string[] MetaData = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
                foreach (string meta in MetaData)
                {
                    if (meta.StartsWith("ModAuthor"))
                    {
                        ModAuthor_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModName"))
                    {
                        ModName_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModVersion"))
                    {
                        ModVersion_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("SupportedWLVersions"))
                    {
                        SupVers = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModURL"))
                    {
                        ModURL_TB.Text = GetSlice(meta, "=", 1);
                    }
                }

                //Clear Supported Versions
                for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                {
                    SupportedWLVersions_CLB.SetItemChecked(i, false);
                }

                if (SupVers.Contains("All Versions"))
                {
                    SupportedWLVersions_CLB.SetItemChecked(SupportedWLVersions_CLB.Items.Count - 1, true);
                }
                else
                {
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
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Icon.png"))
                {
                    ModIconPath_TB.Text = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Icon.png";
                    ModIcon_Preview.ImageLocation = ModIconPath_TB.Text;
                }
                else
                {
                    ModIconPath_TB.Text = "Default";
                }
            }
        }

        private void AutoModList_DoubleClick(object sender, EventArgs e)
        {
            if (AutoModList.SelectedItems[0].Tag.ToString().EndsWith(".txt"))
            {
                AutoModCreator AutoModCreator_Form = new AutoModCreator();
                AutoModCreator_Form.Show();
                AutoModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, this);
                AutoModCreator_Form.LoadAutoMod(AutoModList.SelectedItems[0].Tag.ToString());
            }
        }

        private void ModIconPath_TB_TextChanged(object sender, EventArgs e)
        {
            if (ModIconPath_TB.Text == "Default")
            {
                ModIcon_Preview.ImageLocation = Application.StartupPath + @"System\Default_Icon.png";
            }
        }

        private void ModIconSetDefault_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModIconPath_TB.Text = "Default";
        }

        private void CopyMetaData_Button_Click(object sender, EventArgs e)
        {
            bool ModValid = true;
            string CharPool = @"=,\/:*?""<>|";
            // Validate Textfields
            if (ModName_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModName_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", ModName_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", ModName_TB, 3000);
            }

            if (ModAuthor_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModAuthor_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Author is empty or invalid character found =,\/:*?""<>|", ModAuthor_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Author is empty or invalid character found =,\/:*?""<>|", ModAuthor_TB, 3000);
            }

            if (ModVersion_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (ModVersion_TB.Text.Contains(c))
                    {
                        ModValid = false;
                        toolTip1.Show(@"Mod Version is empty or invalid character found =,\/:*?""<>|", ModVersion_TB, 3000);
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Version is empty or invalid character found =,\/:*?""<>|", ModVersion_TB, 3000);
            }

            if (ModURL_TB.Text == "")
            {
                ModURL_TB.Text = "None";
            }

            if (ModIconPath_TB.Text == "")
            {
                ModIconPath_TB.Text = "Default";
            }

            if (SupportedWLVersions_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No supported version selected.", SupportedWLVersions_CLB, 3000);
            }

            if (ModValid)
            {
                string SupportedVersions = "";
                int i;
                for (i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                {
                    if (SupportedWLVersions_CLB.GetItemChecked(i))
                    {
                        SupportedVersions += SupportedWLVersions_CLB.Items[i].ToString() + ",";
                    }
                }
                if (SupportedVersions.Contains("All Versions"))
                {
                    SupportedVersions = "All Versions";
                }
                else
                {
                    SupportedVersions = SupportedVersions.TrimEnd(',');
                }

                string Metadata = "ModName = " + ModName_TB.Text + "\r\nModAuthor = " + ModAuthor_TB.Text +
                    "\r\nModVersion = " + ModVersion_TB.Text + "\r\nSupportedWLVersions = " + SupportedVersions +
                    "\r\nModURL = " + ModURL_TB.Text;

                Clipboard.SetText(Metadata);
                MessageBox.Show("MetaData copied to clipboard.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CurrentlyEditing_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentlyEditing_Path == string.Empty)
            {
                Process.Start("explorer.exe", Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator");
            }
            else
            {
                string Dir = Path.GetDirectoryName(CurrentlyEditing_Path);
                if (Directory.Exists(Dir))
                {
                    Process.Start("explorer.exe", Dir);
                }
                else
                {
                    MessageBox.Show("Directory for the file was not found.", "Wild Life Mod Manager");
                }
            }
        }

        private void StopEditing_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentlyEditing_Path = string.Empty;
            CurrentlyEditing_LL.Text = "New Mod";
            StopEditing_LL.Hide();
        }
    }
}
