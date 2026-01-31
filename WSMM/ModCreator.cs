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

        string CurrentSearchTerm = string.Empty;
        int SearchTotal = 0;
        int SearchCurrent = 0;
        List<string> SearchResults = new List<string>();

        public void TransferInfo(string Path, string Version, string UEV, Main main)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
            ParentForm = main;

            LoadSupportedVersions();
            LoadCharacters();
            LoadCategories();
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
            ModIconPath_TB.Text = "Default";
            ModIcon_Preview.ImageLocation = Application.StartupPath + @"System\Default_Icon.png";
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

        private void LoadCategories()
        {
            Categories_CLB.Items.Clear();
            if (File.Exists(Application.StartupPath + @"System\Categories.ini"))
            {
                Categories_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"System\Categories.ini"));
            }
            else
            {
                Categories_CLB.Items.Add("Other");
            }
        }

        private void LoadCharacters()
        {
            AffectedCharacters_CLB.Items.Clear();
            AffectedCharacters_CLB.Items.Add("All");
            AffectedCharacters_CLB.Items.Add("None");
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"))
            {
                AffectedCharacters_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"));
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\CustomizerCharacters.txt"))
                {
                    if (AffectedCharacters_CLB.Items.Contains(line) == false)
                    {
                        AffectedCharacters_CLB.Items.Add(line);
                    }
                }
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
            AutoModList.Items[AutoModList.Items.Count - 1].ToolTipText = "Double Click to load file in AutoMod Creator.";
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
                        AutoModList.Items[AutoModList.Items.Count - 1].ToolTipText = "Double Click to load file in AutoMod Creator.";
                    }
                    else if (Path.GetExtension(AMs) == ".collection")
                    {
                        AutoModList.Items.Add(Path.GetFileName(AMs), 2);
                        AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                        AutoModList.Items[AutoModList.Items.Count - 1].ToolTipText = "You currently can't edit .collection files.";
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
            AutoModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, ModAuthor_TB.Text, this);
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

            if (Categories_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No Categories selected.", Categories_CLB, 3000);
            }

            if (AffectedCharacters_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No Characters selected.", AffectedCharacters_CLB, 3000);
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

            // Categories
            string Categories = "";
            i = 0;
            for (i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
            {
                if (Categories_CLB.GetItemChecked(i))
                {
                    Categories += Categories_CLB.Items[i].ToString() + ",";
                }
            }
            Categories = Categories.TrimEnd(',');

            // Characters
            string Characters = "";
            i = 0;
            for (i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
            {
                if (AffectedCharacters_CLB.GetItemChecked(i))
                {
                    Characters += AffectedCharacters_CLB.Items[i].ToString() + ",";
                }
            }
            Characters = Characters.TrimEnd(',');

            string Dependencies = "";
            foreach (string D in Prereqs_LB.Items)
            {
                Dependencies += D.ToString() + ",";
            }
            Dependencies = Dependencies.TrimEnd(',');

            string Incompatibilities = "";
            foreach (string D in Incompat_LB.Items)
            {
                Incompatibilities += D.ToString() + ",";
            }
            Incompatibilities = Incompatibilities.TrimEnd(',');

            string Metadata = "ModName = " + ModName_TB.Text + "\nModAuthor = " + ModAuthor_TB.Text +
                "\nModVersion = " + ModVersion_TB.Text + "\nSupportedWLVersions = " + SupportedVersions +
                "\nModURL = " + ModURL_TB.Text + "\nCategories = " + Categories +
                "\nCharacters = " + Characters + "\nDependencies = " + Dependencies + "\nIncompatibilities = " + Incompatibilities;
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
                EditNewFile(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\" + ModName_TB.Text + ".wlmm");
            }
            else
            {
                if (File.Exists(CurrentlyEditing_Path))
                {
                    File.Delete(CurrentlyEditing_Path);
                }
                ZipFile.CreateFromDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging", Path.GetDirectoryName(CurrentlyEditing_Path) + @"\" + ModName_TB.Text + ".wlmm");

                // If this path is in Active Mods, reload that mod.
                Thread.Sleep(500); // Let the compression fully finish.
                ParentForm.ReloadAffectedMod(CurrentlyEditing_Path, Path.GetDirectoryName(CurrentlyEditing_Path) + @"\" + ModName_TB.Text + ".wlmm");
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
                LoadMod(openFileDialog3.FileName);
            }
        }

        public void LoadMod(string ModPath)
        {
            if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp"))
            {
                Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp", true);
            }
            Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
            ZipFile.ExtractToDirectory(ModPath, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
            CurrentlyEditing_Path = ModPath;
            CurrentlyEditing_LL.Text = ModPath;
            BuildMods_Button.Text = "Edit Mod";
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
                AutoModList.Items[AutoModList.Items.Count - 1].ToolTipText = "Double Click to load file in AutoMod Creator.";
            }
            foreach (string AMs in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\AutoMod", "*.collection"))
            {
                AutoModList.Items.Add(Path.GetFileName(AMs), 2);
                AutoModList.Items[AutoModList.Items.Count - 1].Tag = AMs;
                AutoModList.Items[AutoModList.Items.Count - 1].ToolTipText = "You currently can't edit .collection files.";
            }

            //Name Author Versions Version URL Icon
            //Read MetaData
            string SupVers = string.Empty;
            string Categories = string.Empty;
            string Characters = string.Empty;
            string Dependencies = string.Empty;
            string Incompatibilities = string.Empty;
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
                else if (meta.StartsWith("Categories"))
                {
                    Categories = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("Characters"))
                {
                    Characters = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("Dependencies"))
                {
                    Dependencies = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("Incompatibilities"))
                {
                    Incompatibilities = GetSlice(meta, "=", 1);
                }
            }

            //Clear Supported Versions
            for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
            {
                SupportedWLVersions_CLB.SetItemChecked(i, false);
            }
            //Clear Characters
            for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
            {
                AffectedCharacters_CLB.SetItemChecked(i, false);
            }
            //Clear Categories
            for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
            {
                Categories_CLB.SetItemChecked(i, false);
            }
            Prereqs_LB.Items.Clear();
            PrereqManager_Panel.Hide();

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

            // Characters
            if (Characters.Contains(","))
            {
                string[] SplitChars = Characters.Split(",");
                foreach (string s in SplitChars)
                {
                    string TrimmedS = s.Trim();
                    for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                    {
                        if (AffectedCharacters_CLB.Items[i].ToString() == TrimmedS)
                        {
                            AffectedCharacters_CLB.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                {
                    if (AffectedCharacters_CLB.Items[i].ToString() == Characters)
                    {
                        AffectedCharacters_CLB.SetItemChecked(i, true);
                    }
                }
            }

            // Categories
            if (Categories.Contains(","))
            {
                string[] SplitCats = Categories.Split(",");
                foreach (string s in SplitCats)
                {
                    string TrimmedS = s.Trim();
                    for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                    {
                        if (Categories_CLB.Items[i].ToString() == TrimmedS)
                        {
                            Categories_CLB.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                {
                    if (Categories_CLB.Items[i].ToString() == Categories)
                    {
                        Categories_CLB.SetItemChecked(i, true);
                    }
                }
            }

            if (Dependencies.Contains(","))
            {
                string[] SplitChars = Dependencies.Split(",");
                foreach (string s in SplitChars)
                {
                    string TrimmedS = s.Trim();
                    Prereqs_LB.Items.Add(TrimmedS);
                }
            }
            else
            {
                string TrimmedS = Dependencies.Trim();
                if (TrimmedS != string.Empty)
                {
                    Prereqs_LB.Items.Add(TrimmedS);
                }
            }

            if (Incompatibilities.Contains(","))
            {
                string[] SplitChars = Incompatibilities.Split(",");
                foreach (string s in SplitChars)
                {
                    string TrimmedS = s.Trim();
                    Incompat_LB.Items.Add(TrimmedS);
                }
            }
            else
            {
                string TrimmedS = Incompatibilities.Trim();
                if (TrimmedS != string.Empty)
                {
                    Incompat_LB.Items.Add(TrimmedS);
                }
            }

            ManagePrereqs_Button.Text = "Manage Dependencies: " + (Prereqs_LB.Items.Count + Incompat_LB.Items.Count).ToString();


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

        private void AutoModList_DoubleClick(object sender, EventArgs e)
        {
            if (AutoModList.SelectedItems[0].Tag.ToString().EndsWith(".txt"))
            {
                AutoModCreator AutoModCreator_Form = new AutoModCreator();
                AutoModCreator_Form.Show();
                AutoModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, "", this);
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

            if (Categories_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No Categories selected.", Categories_CLB, 3000);
            }

            if (AffectedCharacters_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                toolTip1.Show("No Characters selected.", AffectedCharacters_CLB, 3000);
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

                // Categories
                string Categories = "";
                i = 0;
                for (i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                {
                    if (Categories_CLB.GetItemChecked(i))
                    {
                        Categories += Categories_CLB.Items[i].ToString() + ",";
                    }
                }
                Categories = Categories.TrimEnd(',');

                // Characters
                string Characters = "";
                i = 0;
                for (i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                {
                    if (AffectedCharacters_CLB.GetItemChecked(i))
                    {
                        Characters += AffectedCharacters_CLB.Items[i].ToString() + ",";
                    }
                }
                Characters = Characters.TrimEnd(',');

                string Metadata = "ModName = " + ModName_TB.Text + "\r\nModAuthor = " + ModAuthor_TB.Text +
                    "\r\nModVersion = " + ModVersion_TB.Text + "\r\nSupportedWLVersions = " + SupportedVersions +
                    "\r\nModURL = " + ModURL_TB.Text + "\r\nCategories = " + Categories +
                    "\r\nCharacters = " + Characters;

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
            BuildMods_Button.Text = "Create Mod";
        }

        private void AffectedCharacterSetWithAutoMod_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Clear Characters
            for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
            {
                AffectedCharacters_CLB.SetItemChecked(i, false);
            }

            int CharactersAdded = 0;
            List<string> CharactersAddedList = new List<string>();
            foreach (ListViewItem AMEntry in AutoModList.Items)
            {
                string[] contents;
                contents = File.ReadAllLines(AMEntry.Tag.ToString());

                foreach (string line in contents)
                {
                    if (GetSlice(line, ":", 0) == "Character")
                    {
                        string Character = GetSlice(line, ":", 1);
                        for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                        {
                            if (AffectedCharacters_CLB.Items[i].ToString() == Character)
                            {
                                AffectedCharacters_CLB.SetItemChecked(i, true);
                                bool AlreadyCounted = false;
                                foreach (string s in CharactersAddedList)
                                {
                                    if (s == Character)
                                    {
                                        AlreadyCounted = true;
                                        break;
                                    }
                                }
                                if (AlreadyCounted == false)
                                {
                                    CharactersAddedList.Add(Character);
                                    CharactersAdded++;
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Characters added: " + CharactersAdded.ToString(), "Wild Life Mod Manager");
        }

        private void AffectedCharacters_Sort_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AffectedCharacters_Sort_LL.Text == "ABC")
            {
                AffectedCharacters_CLB.Sorted = true;
                AffectedCharacters_Sort_LL.Text = "Default";
                toolTip1.SetToolTip(AffectedCharacters_Sort_LL, "Reset sorting to default.");
            }
            else
            {
                AffectedCharacters_CLB.Sorted = false;
                LoadCharacters();
                AffectedCharacters_Sort_LL.Text = "ABC";
                toolTip1.SetToolTip(AffectedCharacters_Sort_LL, "Sort alphabetically.");
            }
        }

        private void AutoModList_Expand_Button_Click(object sender, EventArgs e)
        {
            if (AutoModList.Height == 107)
            {
                AutoModList.Height = 545 - 36;
                PakList.Height = 107;
                AutoModList_Expand_Button.Text = "Collapse -";
                PaksList_Expand_Button.Text = "Expand +";

                SearchPanel_AM.Show();
                AutoModList.Top += 36;

                SearchPanel_Pak.Hide();
                PakList.Top = 89;
                SearchTB_Pak.Text = "";
                foreach (ListViewItem item in PakList.Items)
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
            else
            {
                AutoModList.Height = 107;
                AutoModList_Expand_Button.Text = "Expand +";
                SearchPanel_AM.Hide();
                AutoModList.Top = 231;
                SearchTB_AM.Text = "";
                foreach (ListViewItem item in AutoModList.Items)
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
        }

        private void PaksList_Expand_Button_Click(object sender, EventArgs e)
        {
            if (PakList.Height == 107)
            {
                PakList.Height = 688 - 36;
                AutoModList.Height = 107;
                PaksList_Expand_Button.Text = "Collapse -";
                AutoModList_Expand_Button.Text = "Expand +";

                SearchPanel_Pak.Show();
                PakList.Top += 36;

                SearchPanel_AM.Hide();
                AutoModList.Top = 231;
                SearchTB_AM.Text = "";
                foreach (ListViewItem item in AutoModList.Items)
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
            else
            {
                PakList.Height = 107;
                PaksList_Expand_Button.Text = "Expand +";
                SearchPanel_Pak.Hide();
                PakList.Top = 89;
                SearchTB_Pak.Text = "";
                foreach (ListViewItem item in PakList.Items)
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
        }

        private void ManagePrereqs_Button_Click(object sender, EventArgs e)
        {
            if (PrereqManager_Panel.Visible == true)
            {
                PrereqManager_Panel.Hide();
            }
            else
            {
                PrereqManager_Panel.Show();
            }
        }

        private void PrereqAdd_Button_Click(object sender, EventArgs e)
        {
            bool ModValid = true;
            string CharPool = @"=,\/:*?""<>|";
            // Validate Text
            if (PrereqAdd_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (PrereqAdd_TB.Text.Contains(c))
                    {
                        toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", PrereqAdd_TB, 3000);
                        ModValid = false;
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Name is empty or invalid character found =,\/:*?""<>|", PrereqAdd_TB, 3000);
            }
            if (ModValid == true)
            {
                Prereqs_LB.Items.Add(PrereqAdd_TB.Text);
                ManagePrereqs_Button.Text = "Manage Dependencies: " + (Prereqs_LB.Items.Count + Incompat_LB.Items.Count).ToString();
            }
        }

        private void PrereqRemove_Button_Click(object sender, EventArgs e)
        {
            if (Prereqs_LB.SelectedIndex != -1)
            {
                Prereqs_LB.Items.RemoveAt(Prereqs_LB.SelectedIndex);
            }
            ManagePrereqs_Button.Text = "Manage Dependencies: " + (Prereqs_LB.Items.Count + Incompat_LB.Items.Count).ToString();
        }

        private void SearchButton_AM_Click(object sender, EventArgs e)
        {

        }

        private void SearchAM()
        {
            bool found = false;
            foreach (ListViewItem item in AutoModList.Items)
            {
                if (item.Text.ToLower().Contains(SearchTB_AM.Text.ToLower()) && SearchTB_AM.Text != "")
                {
                    item.BackColor = Color.Red;
                    if (found == false)
                    {
                        item.EnsureVisible();
                        found = true;
                    }
                }
                else
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
        }

        private void SearchPak()
        {
            bool found = false;
            foreach (ListViewItem item in PakList.Items)
            {
                if (item.Text.ToLower().Contains(SearchTB_Pak.Text.ToLower()) && SearchTB_Pak.Text != "")
                {
                    item.BackColor = Color.Red;
                    if (found == false)
                    {
                        item.EnsureVisible();
                        found = true;
                    }
                }
                else
                {
                    item.BackColor = Color.FromArgb(32, 34, 81);
                }
            }
        }

        private void SearchTB_AM_TextChanged(object sender, EventArgs e)
        {
            SearchAM();
        }

        private void SearchClear_AM_Click(object sender, EventArgs e)
        {
            SearchTB_AM.Text = "";
        }

        private void SearchClear_Pak_Click(object sender, EventArgs e)
        {
            SearchTB_Pak.Text = "";
        }

        private void SearchTB_Pak_TextChanged(object sender, EventArgs e)
        {
            SearchPak();
        }

        private void IncompatAdd_Button_Click(object sender, EventArgs e)
        {
            bool ModValid = true;
            string CharPool = @"=,\/:*?""<>|";
            // Validate Text
            if (IncompatAdd_TB.Text != "")
            {
                foreach (char c in CharPool)
                {
                    if (IncompatAdd_TB.Text.Contains(c))
                    {
                        toolTip1.Show(@"Mod Name / Wild Life Build is empty or invalid character found =,\/:*?""<>|", IncompatAdd_TB, 3000);
                        ModValid = false;
                        break;
                    }
                }
            }
            else
            {
                ModValid = false;
                toolTip1.Show(@"Mod Name / Wild Life Build is empty or invalid character found =,\/:*?""<>|", IncompatAdd_TB, 3000);
            }
            if (ModValid == true)
            {
                Incompat_LB.Items.Add(IncompatAdd_TB.Text);
                ManagePrereqs_Button.Text = "Manage Dependencies: " + (Prereqs_LB.Items.Count + Incompat_LB.Items.Count).ToString();
            }
        }

        private void IncompatRemove_Button_Click(object sender, EventArgs e)
        {
            if (Incompat_LB.SelectedIndex != -1)
            {
                Incompat_LB.Items.RemoveAt(Incompat_LB.SelectedIndex);
            }
            ManagePrereqs_Button.Text = "Manage Dependencies: " + (Prereqs_LB.Items.Count + Incompat_LB.Items.Count).ToString();
        }

        private void EditNewFile(string Path)
        {
            BuildMods_Button.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                CurrentlyEditing_Path = Path;
                CurrentlyEditing_LL.Text = Path;
                BuildMods_Button.Text = "Edit Mod";
                StopEditing_LL.Show();
            });
        }
    }
}
