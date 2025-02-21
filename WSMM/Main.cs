using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml;
using UAssetAPI;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UAssetAPI.UnrealTypes;
using UAssetAPI.Unversioned;
using System.Net;
using System.Security.Cryptography;
using CG.Web.MegaApiClient;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;

namespace WSMM
{
    public partial class Main : Form
    {
        private bool mouseDown = false;
        private Point lastLocation;

        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        private int ChangesMade = 0;
        private bool StartingUp = true;
        private bool HasOldChanges = false;

        private string WLMM_Version = "1.1.5";
        private string Datatable_Version = string.Empty;
        string BuildLog = string.Empty;

        public string prevIconPath = string.Empty;
        public string prevPakPath = string.Empty;
        public string prevAutoModPath = string.Empty;
        public string prevModPath = string.Empty;

        int SelectedModID = 0;

        string DTVersion = "";
        string DTLink = "";

        bool MMMode = false;

        string ModPackPath = string.Empty;

        //Panel, Picturebox, Label(Name), Label(Error), Label(Version), Label(SupportedVersions), Label(Author), LinkLabel(Remove), LinkLabel(Link), Checkbox
        Panel[] Mod_Panel = new Panel[100];
        PictureBox[] Mod_Icon = new PictureBox[100];
        Label[] Mod_NameLabel = new Label[100];
        Label[] Mod_ErrorLabel = new Label[100];
        Label[] Mod_VersionLabel = new Label[100];
        Label[] Mod_SupportedVersionsLabel = new Label[100];
        Label[] Mod_CharactersLabel = new Label[100];
        LinkLabel[] Mod_ContainsLabel = new LinkLabel[100];
        Label[] Mod_AuthorLabel = new Label[100];
        LinkLabel[] Mod_RemoveButton = new LinkLabel[100];
        LinkLabel[] Mod_ReloadButton = new LinkLabel[100];
        LinkLabel[] Mod_EditButton = new LinkLabel[100];
        LinkLabel[] Mod_LinkButton = new LinkLabel[100];
        CheckBox[] Mod_EnabledCB = new CheckBox[100];
        string[] Mod_WLMMPath = new string[100];
        string[] Mod_Categories = new string[100];
        List<string>[] Mod_Dependencies = new List<string>[100];

        List<int> Mod_Entries = new List<int>();
        int Mod_CurrentEntryID = 0;

        System.Windows.Forms.Button[] Cat_Button = new System.Windows.Forms.Button[20];
        FlowLayoutPanel[] Cat_Flow = new FlowLayoutPanel[20];
        int Cat_CurrentEntryID = 0;
        List<int> Cat_Entries = new List<int>();

        List<string> Categories_List = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Close_Button_MouseEnter(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void Close_Button_MouseLeave(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon;
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

        public static void CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void ModCreator_Button_Click(object sender, EventArgs e)
        {
            ModCreator ModCreator_Form = new ModCreator();
            ModCreator_Form.Show();
            ModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, this);
        }

        private void Mod_RemoveButtonClick(object sender, EventArgs e)
        {
            LinkLabel? Casted = sender as LinkLabel;
        }
        private void Mod_LinkButtonClick(object sender, EventArgs e)
        {
            LinkLabel? Casted = sender as LinkLabel;
        }

        private void LoadGame_Button_Click(object sender, EventArgs e)
        {
            SelectWLVersion_Panel.Show();
            SelectWLVersionPath_TB.Text = "None";
            SelectWLVersion_CB.Text = "Please specify version...";
            SelectWLVersionUEV_TB.Text = "None";
        }

        private void SelectWLVersion_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            SelectWLVersion_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void SelectWLVersion_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            SelectWLVersion_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void SelectWLVersionBrowse_Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog2.FileName.EndsWith(".exe"))
                {
                    string CleanFileName = Path.GetFileName(openFileDialog2.FileName);
                    string CleanPath = Path.GetDirectoryName(openFileDialog2.FileName);

                    if (File.Exists(CleanPath + @"\WildLifeC\Content\Paks\WildLifeC-Windows.pak"))
                    {
                        bool FoundVersion = false;
                        bool NotSupported = true;
                        string Version = string.Empty;
                        string Version_Creation = string.Empty;
                        string Version_Edit = string.Empty;
                        foreach (string S in SelectWLVersion_CB.Items)
                        {
                            if (openFileDialog2.FileName.Contains(S))
                            {
                                MessageBox.Show("Found Wild Life version.", "Wild Life Mod Manager", MessageBoxButtons.OK);
                                SelectWLVersion_CB.Text = S.ToString();
                                Version = S.ToString();
                                FoundVersion = true;
                                NotSupported = false;
                                break;
                            }
                        }

                        if (FoundVersion == false)
                        {
                            DateTime CreationDate = File.GetCreationTime(CleanPath + @"\WildLifeC\Content\Paks\WildLifeC-Windows.pak");
                            string zeroPadded_Month = CreationDate.Month.ToString();
                            if (zeroPadded_Month.Length == 1) { zeroPadded_Month = zeroPadded_Month.Insert(0, "0"); }
                            string zeroPadded_Day = CreationDate.Day.ToString();
                            if (zeroPadded_Day.Length == 1) { zeroPadded_Day = zeroPadded_Day.Insert(0, "0"); }
                            Version_Creation = CreationDate.Year.ToString() + "." + zeroPadded_Month + "." + zeroPadded_Day + "_Shipping_Full_Build_1";

                            DateTime EditDate = File.GetLastWriteTime(CleanPath + @"\WildLifeC\Content\Paks\WildLifeC-Windows.pak");
                            zeroPadded_Month = EditDate.Month.ToString();
                            if (zeroPadded_Month.Length == 1) { zeroPadded_Month = zeroPadded_Month.Insert(0, "0"); }
                            zeroPadded_Day = EditDate.Day.ToString();
                            if (zeroPadded_Day.Length == 1) { zeroPadded_Day = zeroPadded_Day.Insert(0, "0"); }
                            Version_Edit = EditDate.Year.ToString() + "." + zeroPadded_Month + "." + zeroPadded_Day + "_Shipping_Full_Build_1";

                            FoundVersion = true;
                        }

                        foreach (string S in SelectWLVersion_CB.Items)
                        {
                            if (S == Version_Creation)
                            {
                                Version = Version_Creation;
                                FoundVersion = true;
                                NotSupported = false;
                            }
                            else if (S == Version_Edit)
                            {
                                Version = Version_Edit;
                                FoundVersion = true;
                                NotSupported = false;
                            }
                        }

                        SelectWLVersionPath_TB.Text = openFileDialog2.FileName.ToString();
                        if (FoundVersion == false)
                        {
                            MessageBox.Show("Couldn't find Wild Life version.\nPlease manually specify version.", "Wild Life Mod Manager", MessageBoxButtons.OK);
                            SelectWLVersion_CB.Text = "Please specify version...";
                        }
                        else if (NotSupported == true)
                        {
                            MessageBox.Show("This version of Wild Life is not supported.\nPlease manually specify version." + Version, "Wild Life Mod Manager", MessageBoxButtons.OK);
                            SelectWLVersion_CB.Text = "Please specify version...";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find a Wild Life instance.\nMake sure you select the WildLifeC.exe in the root folder.", "Wild Life Mod Manager", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void SelectWLVersion_CloseButton_Click(object sender, EventArgs e)
        {
            SelectWLVersion_Panel.Hide();
        }

        private void SelectWLVersionConfirm_Button_Click(object sender, EventArgs e)
        {
            if (SelectWLVersionPath_TB.Text.EndsWith(".exe") && SelectWLVersion_CB.Text != "Please specify version...")
            {
                SelectWLVersion_Panel.Hide();

                //Clear Mods
                foreach (int EntryID in Mod_Entries)
                {
                    Mod_Icon[EntryID].Dispose();
                    Mod_NameLabel[EntryID].Dispose();
                    Mod_ErrorLabel[EntryID].Dispose();
                    Mod_VersionLabel[EntryID].Dispose();
                    Mod_SupportedVersionsLabel[EntryID].Dispose();
                    Mod_CharactersLabel[EntryID].Dispose();
                    Mod_ContainsLabel[EntryID].Dispose();
                    Mod_AuthorLabel[EntryID].Dispose();
                    Mod_RemoveButton[EntryID].Dispose();
                    Mod_ReloadButton[EntryID].Dispose();
                    Mod_EditButton[EntryID].Dispose();
                    Mod_LinkButton[EntryID].Dispose();
                    Mod_EnabledCB[EntryID].Dispose();
                    Mod_Panel[EntryID].Dispose();
                    Mod_WLMMPath[EntryID] = string.Empty;
                    Mod_Categories[EntryID] = string.Empty;

                    AddChange();
                }
                Mod_Entries.Clear();
                Mod_CurrentEntryID = 0;

                //Clear Cats
                foreach (int EntryID in Cat_Entries)
                {
                    Cat_Button[EntryID].Dispose();
                    Cat_Flow[EntryID].Dispose();
                }
                Cat_Entries.Clear();
                Cat_CurrentEntryID = 0;

                NoModsFound_Label.Show();

                LoadGameVersion(Path.GetDirectoryName(SelectWLVersionPath_TB.Text), SelectWLVersion_CB.Text, SelectWLVersionUEV_TB.Text);
            }
        }

        private void LoadGameVersion(string Path, string Version, string UEV)
        {
            LoadedWLPath = Path;
            LoadedWLVersion = Version;
            LoadedUEVersion = UEV;

            // Check UE version if empty
            if (LoadedUEVersion == string.Empty)
            {
                LoadedUEVersion = GetUEVersion(LoadedWLVersion);
            }

            WLVersionLoaded_Label.Text = LoadedWLVersion + " - " + LoadedUEVersion;
            LoadDataTables();
            LoadMappings();
            LoadCategories();

            LoadBuildSettings();

            CreateCoreFiles();

            //Enable Buttons
            ToggleButtons(true);

            NoGameLoaded_Panel.Visible = false;
            ModFlow_Panel.AllowDrop = true;

            SaveSession();
            SaveBuildSettings();

            //Load Mods
            NoModsFound_Label.Visible = true;
            LoadMods();

            if (DT_Updater_Panel.Visible == true)
            {
                ToggleButtons(false);
            }
        }

        private void CreateCoreFiles()
        {
            if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion) == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Staging");
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator");
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod");
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded");
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod");
            }
        }

        private void LoadCategories()
        {
            Categories_List.Clear();
            if (File.Exists(Application.StartupPath + @"System\Categories.ini"))
            {
                Categories_List.AddRange(File.ReadAllLines(Application.StartupPath + @"System\Categories.ini"));
            }
            else
            {
                Categories_List.Add("Other");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Set title
            this.Text = "Wild Life Mod Manager - v." + WLMM_Version;
            TitleLabel.Text = "Wild Life Mod Manager - v." + WLMM_Version;

            if (HasMissingDLLS() == true)
            {
                MessageBox.Show("Missing core DLLs.\nPlease re-extract the .zip file.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            CreateMissingFolders();

            LoadDatatableVersion();

            //Version Check
            CheckForUpdate();

            LoadSupportedVersions();

            //Load previous game version if it exists
            LoadSession();

            if (HasOldChanges == false)
            {
                ChangesMade_Label.Text = "No changes made.";
                ChangesMade = 0;
            }

            if (LoadedWLVersion != "" && LoadedWLVersion != string.Empty && DT_Updater_Panel.Visible == false)
            {
                BuildMods_Button.Enabled = true;
                ModCreator_Button.Enabled = true;
            }
            else
            {
                BuildMods_Button.Enabled = false;
                ModCreator_Button.Enabled = false;
            }

            StartingUp = false;
            HasOldChanges = false;
        }

        private void LoadSupportedVersions()
        {
            if (File.Exists(Application.StartupPath + @"System\SupportedVersions.ini"))
            {
                SelectWLVersion_CB.Items.Clear();
                SelectWLVersion_CB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"System\SupportedVersions.ini"));
            }
        }

        private void LoadDatatableVersion()
        {
            if (File.Exists(Application.StartupPath + @"System\DatatableVersion.ini"))
            {
                Datatable_Version = File.ReadAllText(Application.StartupPath + @"System\DatatableVersion.ini");
            }
        }

        private void CheckForUpdate()
        {
            try
            {
                string ThisVersion = WLMM_Version;
                string VersionInfo = "";
                string DTChanges = "";
                string DTSupVers = "";
                string MM = "";
                string MMInfo = "";
                string MMMessage = "";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync("https://pastebin.com/raw/qskfNxrz").Result;
                    response.EnsureSuccessStatusCode();
                    VersionInfo = response.Content.ReadAsStringAsync().Result;
                }

                string[] TempArray = VersionInfo.Split("\r");
                if (ThisVersion != TempArray[0])
                {
                    UpdateLink.Text = "New version " + TempArray[0] + " available! Click here to download!";
                    UpdateLink.Tag = TempArray[1].Trim('\n');
                    UpdateLink.Show();
                    WildSanctum_Link.Tag = TempArray[2].Trim('\n');
                    WLMMPost_Link.Tag = TempArray[3].Trim('\n');
                    DTVersion = TempArray[4].Trim('\n');
                    DTLink = TempArray[5].Trim('\n');
                    DTChanges = TempArray[6].Trim('\n');
                    DTSupVers = TempArray[7].Trim('\n');
                    MM = TempArray[8].Trim('\n');
                    MMInfo = TempArray[9].Trim('\n');
                    MMMessage = TempArray[10].Trim('\n');
                }
                else
                {
                    WildSanctum_Link.Tag = TempArray[2].Trim('\n');
                    WLMMPost_Link.Tag = TempArray[3].Trim('\n');
                    DTVersion = TempArray[4].Trim('\n');
                    DTLink = TempArray[5].Trim('\n');
                    DTChanges = TempArray[6].Trim('\n');
                    DTSupVers = TempArray[7].Trim('\n');
                    MM = TempArray[8].Trim('\n');
                    MMInfo = TempArray[9].Trim('\n');
                    MMMessage = TempArray[10].Trim('\n');
                }

                if (Datatable_Version == string.Empty)
                {
                    // No Datatables
                    ToggleButtons(false);
                    DT_Updater_Panel.Show();
                    DT_Updater_VersionLabel.Text = "None > " + DTVersion;
                    DT_Updater_ChangesTB.Text = DTChanges.Replace("*", "\n");
                    DT_Updater_SupVerLB.Items.Clear();
                    DT_Updater_SupVerLB.Items.AddRange(DTSupVers.Split('*'));
                }
                else if (DTVersion != Datatable_Version)
                {
                    // Datatables outdated
                    ToggleButtons(false);
                    DT_Updater_Panel.Show();
                    DT_Updater_VersionLabel.Text = Datatable_Version + " > " + DTVersion;
                    DT_Updater_ChangesTB.Text = DTChanges.Replace("*", "\n");
                    DT_Updater_SupVerLB.Items.Clear();
                    DT_Updater_SupVerLB.Items.AddRange(DTSupVers.Split('*'));
                }

                if (MM == "MM=True")
                {
                    MM_Panel.Show();
                    MM_Info.Text = MMInfo;
                    MM_Message.Text = MMMessage.Replace("(nl)", "\r\n");
                    Marketplace_Button.Enabled = false;
                    DT_Updater_DownloadButton.Enabled = false;
                    MMMode = true;
                    MM_Panel.BringToFront();
                }
            }
            catch (Exception)
            {
                UpdateLink.Text = "Unable to check for new version.";
                UpdateLink.LinkColor = Color.LightCoral;
                UpdateLink.VisitedLinkColor = Color.LightCoral;

                MM_Panel.Show();
                MM_Info.Text = "Unable to check for new version.";
                MM_Message.Text = "Is your network down or firewall blocking WLMM?\nIf not, check the WLMM post on Discord for info/help.";
            }
        }

        private void ToggleButtons(bool State)
        {
            ReloadMods_Button.Visible = State;
            EnableMods_Button.Visible = State;
            DisableMods_Button.Visible = State;
            RemoveMods_Button.Visible = State;
            AddMod_Button.Visible = State;

            BuildSettings_Button.Enabled = State;
            ModCreator_Button.Enabled = State;
            MetaDataPatcher_Button.Enabled = State;
            OpenWLFolder_Button.Enabled = State;
            LaunchWL_Button.Enabled = State;
            RefreshBuildSettings_Button.Enabled = State;
            ReloadMods_Button.Enabled = State;
            EnableMods_Button.Enabled = State;
            DisableMods_Button.Enabled = State;
            RemoveMods_Button.Enabled = State;
            AddMod_Button.Enabled = State;
            if (MMMode == false)
            {
                Marketplace_Button.Enabled = State;
            }
            MarketplaceEditor_Button.Enabled = State;
            TransferModsOpen_Button.Enabled = State;
            ModCreator_Button.Enabled = State;
            BuildMods_Button.Enabled = State;
            CreateBuildLog_Button.Enabled = State;
            OpenBuildLog_Button.Enabled = State;
            LoadGame_Button.Enabled = State;
            CreateModPack_Button.Enabled = State;
            ModPack_Add_Button.Enabled = State;
            ModPack_Close_Button.Enabled = State;
        }

        async void DownloadDatatables(string url, string version)
        {
            DTDownload_Progress.Value = 0;
            var client = new MegaApiClient();
            client.LoginAnonymous();

            try
            {
                if (Directory.Exists(Application.StartupPath + @"Temp") == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"Temp");
                }

                Uri fileLink = new Uri(url);
                INode node = client.GetNodeFromLink(fileLink);

                if (File.Exists(Application.StartupPath + @"Temp\" + node.Name))
                {
                    File.Delete(Application.StartupPath + @"Temp\" + node.Name);
                }

                IProgress<double> progressHandler = new Progress<double>(x =>
                {
                    DTDownload_Progress.Value = ((int)x);
                }
                );

                await client.DownloadFileAsync(fileLink, Application.StartupPath + @"Temp\" + node.Name, progressHandler);

                if (client.IsLoggedIn)
                {
                    client.Logout();
                }

                if (Directory.Exists(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name)))
                {
                    Directory.Delete(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name), true);
                }
                ZipFile.ExtractToDirectory(Application.StartupPath + @"Temp\" + node.Name, Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name), true);

                // Replace System\SupportedVersions.ini
                if (File.Exists(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\SupportedVersions.ini"))
                {
                    File.Copy(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\SupportedVersions.ini", Application.StartupPath + @"System\SupportedVersions.ini", true);
                }

                // Replace System\EngineVersions.ini
                if (File.Exists(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\EngineVersions.ini"))
                {
                    File.Copy(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\EngineVersions.ini", Application.StartupPath + @"System\EngineVersions.ini", true);
                }

                // Replace System\Categories.ini
                if (File.Exists(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\Categories.ini"))
                {
                    File.Copy(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\System\Categories.ini", Application.StartupPath + @"System\Categories.ini", true);
                }

                // Copy/Replace Mappings
                foreach (string mapping in Directory.EnumerateFiles(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\Mappings", "*.usmap"))
                {
                    File.Copy(mapping, Application.StartupPath + @"Mappings\" + Path.GetFileName(mapping), true);
                }
                // Copy/Replace DataTables
                foreach (string DTS in Directory.EnumerateDirectories(Application.StartupPath + @"Temp\" + Path.GetFileNameWithoutExtension(node.Name) + @"\DataTables", "*"))
                {
                    CopyDirectory(DTS, Application.StartupPath + @"DataTables\" + Path.GetFileName(DTS));
                }
                // Remove Temp Files
                Directory.Delete(Application.StartupPath + @"Temp", true);
                // Update DatatableVersion.ini
                File.WriteAllText(Application.StartupPath + @"System\DatatableVersion.ini", version);

                LoadSupportedVersions();
                LoadCategories();

                DT_Updater_Panel.Hide();
                MessageBox.Show("DataTables updated!", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToggleButtons(true);
            }
            catch (Exception ex)
            {
                if (client.IsLoggedIn)
                {
                    client.Logout();
                }

                if (Directory.Exists(Application.StartupPath + @"Temp"))
                {
                    Directory.Delete(Application.StartupPath + @"Temp", true);
                }

                DT_Updater_Panel.Hide();
                MessageBox.Show(ex.Message, "WLMM Download Error\n" + ex.Message);
                ToggleButtons(true);
            }
        }

        private void BuildSettings_Button_Click(object sender, EventArgs e)
        {
            BuildSettings_Panel.Show();
            if (BuildSettings_Button.Text == "Close")
            {
                BuildSettings_Button.Text = "Build Settings";
                BuildSettings_Panel.Hide();
            }
            else
            {
                BuildSettings_Button.Text = "Close";
                BuildSettings_Panel.Show();
            }
        }

        private void BuildSettingsDTFolder_Button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath + @"DataTables\" + LoadedWLVersion);
        }

        private void LoadMappings()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mappings", "*.usmap"))
                {
                    BS_Mappings.Items.Add(Path.GetFileName(file));
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadDataTables()
        {
            BS_BaseClothesOutfitFile.Items.Clear();
            BS_BaseGameCharacterOutfitFile.Items.Clear();
            BS_BaseGameCharacterCustomizationFile.Items.Clear();
            BS_Mappings.Items.Clear();

            try
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"DataTables\" + LoadedWLVersion, "DT_ClothesOutfit_*.json"))
                {
                    if (file.Contains("DT_ClothesOutfit_Generated") == false && file.Contains("DT_ClothesOutfit_Entry_Default") == false && file.Contains("DT_ClothesOutfit_Entry_FurMask") == false && file.Contains("DT_ClothesOutfit_Debug") == false)
                    {
                        BS_BaseClothesOutfitFile.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"DataTables\" + LoadedWLVersion, "DT_GameCharacterOutfits_*.json"))
                {
                    if (file.Contains("DT_GameCharacterOutfits_Generated") == false && file.Contains("DT_GameCharacterOutfits_Entry_Default") == false && file.Contains("DT_GameCharacterOutfits_Debug") == false)
                    {
                        BS_BaseGameCharacterOutfitFile.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"DataTables\" + LoadedWLVersion, "DT_GameCharacterCustomization_*.json"))
                {
                    if (file.Contains("DT_GameCharacterCustomization_Generated") == false && file.Contains("DT_GameCharacterCustomization_Entry_Default") == false && file.Contains("DT_GameCharacterCustomization_Debug") == false)
                    {
                        BS_BaseGameCharacterCustomizationFile.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadSession()
        {
            if (File.Exists(Application.StartupPath + @"System\Session.dat"))
            {
                //WL_Path = C:\Games\Wild Life\2024.08.15_Shipping_Test_Build_1\Windows
                //WL_Version = 2024.08.15_Shipping_Test_Build_1
                var FileContents = File.ReadAllLines(Application.StartupPath + @"System\Session.dat");
                foreach (string file in FileContents)
                {
                    if (file.StartsWith("WL_Path"))
                    {
                        LoadedWLPath = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("WL_Version"))
                    {
                        LoadedWLVersion = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("UE_Version"))
                    {
                        LoadedUEVersion = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("ChangesMade"))
                    {
                        ChangesMade = int.Parse(GetSlice(file, "=", 1));
                        if (ChangesMade > 0)
                        {
                            HasOldChanges = true;
                            ChangesMade_Label.Text = "Changes Made: " + ChangesMade.ToString();
                        }
                    }
                    else if (file.StartsWith("prevIconPath"))
                    {
                        prevIconPath = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("prevPakPath"))
                    {
                        prevPakPath = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("prevAutoModPath"))
                    {
                        prevAutoModPath = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("prevModPath"))
                    {
                        prevModPath = GetSlice(file, "=", 1);
                    }
                }

                if (LoadedWLPath != "" && LoadedWLPath != string.Empty)
                {
                    if (LoadedWLVersion != "" && LoadedWLVersion != string.Empty)
                    {
                        LoadGameVersion(LoadedWLPath, LoadedWLVersion, LoadedUEVersion);
                    }
                }
            }
        }

        private void SaveSession()
        {
            string SaveFile = "WL_Path = " + LoadedWLPath + "\nWL_Version = " + LoadedWLVersion + "\nUE_Version = " + LoadedUEVersion + "\nChangesMade = " + ChangesMade.ToString() + "\nprevIconPath = " + prevIconPath + "\nprevPakPath = " + prevPakPath + "\nprevAutoModPath = " + prevAutoModPath + "\nprevModPath = " + prevModPath;
            File.WriteAllText(Application.StartupPath + @"System\Session.dat", SaveFile);
        }

        private void LoadBuildSettings()
        {
            if (File.Exists(Application.StartupPath + @"System\" + LoadedWLVersion + @"_BuildSettings.ini"))
            {
                var FileContents = File.ReadAllLines(Application.StartupPath + @"System\" + LoadedWLVersion + @"_BuildSettings.ini");
                foreach (string file in FileContents)
                {
                    if (file.StartsWith("DT_ClothesOutfit"))
                    {
                        BS_BaseClothesOutfitFile.Text = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("DT_GameCharacterOutfits"))
                    {
                        BS_BaseGameCharacterOutfitFile.Text = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("DT_GameCharacterCustomization"))
                    {
                        BS_BaseGameCharacterCustomizationFile.Text = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("Mappings"))
                    {
                        BS_Mappings.Text = GetSlice(file, "=", 1);
                    }
                    else if (file.StartsWith("VerifyIntegrity"))
                    {
                        if (GetSlice(file, "=", 1) == "Checked")
                        {
                            BS_VerifyFI_CB.Checked = true;
                        }
                        else
                        {
                            BS_VerifyFI_CB.Checked = false;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    BS_BaseClothesOutfitFile.Text = BS_BaseClothesOutfitFile.Items[0].ToString();
                    BS_BaseGameCharacterOutfitFile.Text = BS_BaseGameCharacterOutfitFile.Items[0].ToString();
                    BS_BaseGameCharacterCustomizationFile.Text = BS_BaseGameCharacterCustomizationFile.Items[0].ToString();
                    foreach (string M in BS_Mappings.Items)
                    {
                        if (M.Contains(LoadedWLVersion))
                        {
                            BS_Mappings.Text = M;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("DataTable error.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveBuildSettings()
        {
            string SaveFile = "DT_ClothesOutfit = " + BS_BaseClothesOutfitFile.Text + "\nDT_GameCharacterOutfits = " + BS_BaseGameCharacterOutfitFile.Text +
                "\nDT_GameCharacterCustomization = " + BS_BaseGameCharacterCustomizationFile.Text + "\nMappings = " + BS_Mappings.Text + "\nVerifyIntegrity = " + BS_VerifyFI_CB.CheckState.ToString();
            File.WriteAllText(Application.StartupPath + @"System\" + LoadedWLVersion + @"_BuildSettings.ini", SaveFile);
        }

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            string[] TempArray = Txt.Split(Delimiter);
            return TempArray[slice].Trim();
        }

        private void BS_Mappings_SelectedValueChanged(object sender, EventArgs e)
        {
            if (StartingUp == false)
            {
                SaveBuildSettings();
            }
        }

        private void RefreshBuildSettings_Button_Click(object sender, EventArgs e)
        {
            LoadDataTables();
            LoadMappings();
        }

        private void AddMod_Button_Click(object sender, EventArgs e)
        {
            if (prevModPath != string.Empty)
            {
                openFileDialog1.InitialDirectory = prevModPath;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] Mods = openFileDialog1.FileNames;
                List<string> ValidMods = new List<string>();
                List<string> ValidModPacks = new List<string>();
                foreach (string Mod in Mods)
                {
                    if (Mod.EndsWith(".wlmm"))
                    {
                        ValidMods.Add(Mod);
                    }
                    else if (Mod.EndsWith(".wlmp"))
                    {
                        ValidModPacks.Add(Mod);
                    }
                }
                if (ValidMods.Count > 0)
                {
                    ProgressPanel.Show();
                    ProgressTitle_Label.Text = "Loading Mods...";
                    ProgressInfo_Label.Text = "Initializing...";
                    BuildModProgress_PB.Value = 0;
                    BuildModProgress_PB.Maximum = ValidMods.Count;

                    // Create a thread and call a background method
                    Thread backgroundThread = new Thread(() => AddMods(ValidMods));
                    // Start thread
                    backgroundThread.Start();
                }
                else if (ValidModPacks.Count > 0)
                {
                    ModPackPath = ValidModPacks[0];
                    LoadModPack();
                }
                prevModPath = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        public void AddMods(List<string> Mods)
        {
            foreach (string Mod in Mods)
            {
                //Unzip to Loaded\Mod Name
                ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ProgressInfo_Label.Text = "Unpacking " + Path.GetFileName(Mod) + "...";
                });
                if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod)))
                {
                    Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod), true);
                }
                //ZipFile.ExtractToDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileName(Mod), Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod), true);
                ZipFile.ExtractToDirectory(Mod, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod), true);

                //Calculate hash for each .pak
                string Hashes = string.Empty;
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod) + @"\Paks", "*.pak"))
                {
                    ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        ProgressInfo_Label.Text = "Calculating MD5 hash for " + Path.GetFileName(file) + "...";
                    });
                    string Md5Hash = CalculateMD5(file);
                    Hashes += Path.GetFileName(file) + " = " + Md5Hash + "\n";
                }
                Hashes = Hashes.Trim();
                File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod) + @"\Integrity.dat", Hashes);
                File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod) + @"\WLMM.dat", Mod);
                ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    BuildModProgress_PB.Value++;
                });
            }
            //Load Mods
            ProgressPanel.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressPanel.Hide();
                BuildModProgress_PB.Value = 0;
            });
            LoadMods();
        }

        private FlowLayoutPanel GetCategoryFlow(string category)
        {
            int FoundID = 0;
            foreach (int i in Cat_Entries)
            {
                if (Cat_Flow[i].Tag.ToString() == category)
                {
                    FoundID = i;
                    break;
                }
            }
            return Cat_Flow[FoundID];
        }

        private void CheckCategories()
        {
            foreach (int i in Cat_Entries)
            {
                if (Cat_Flow[i].Controls.Count == 0)
                {
                    this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        Cat_Flow[i].Hide();
                        Cat_Button[i].Hide();
                        Cat_Button[i].Image = Properties.Resources.ArrowSmall_R;
                    });
                }
                else
                {
                    this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        Cat_Flow[i].Show();
                        Cat_Button[i].Show();
                        Cat_Button[i].Image = Properties.Resources.ArrowSmall_D;
                    });
                }
            }
        }

        private void LoadMods()
        {
            //Clear ModFlow
            ModFlow_Panel.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ModFlow_Panel.Controls.Clear();
                Mod_Entries.Clear();
                Mod_CurrentEntryID = 0;
                Cat_CurrentEntryID = 0;
                Cat_Entries.Clear();
            });

            // Create Categories
            foreach (string cat in Categories_List)
            {
                Cat_Button[Cat_CurrentEntryID] = new System.Windows.Forms.Button();
                Cat_Button[Cat_CurrentEntryID].Text = cat;
                Cat_Button[Cat_CurrentEntryID].Size = new System.Drawing.Size(840, 37);
                Cat_Button[Cat_CurrentEntryID].BackColor = Color.FromArgb(75, 68, 138);
                Cat_Button[Cat_CurrentEntryID].FlatStyle = FlatStyle.Flat;
                Cat_Button[Cat_CurrentEntryID].ForeColor = SystemColors.ActiveCaption;
                Cat_Button[Cat_CurrentEntryID].Font = new Font(Cat_Button[Cat_CurrentEntryID].Font.FontFamily, 14, FontStyle.Bold);
                Cat_Button[Cat_CurrentEntryID].ImageAlign = ContentAlignment.MiddleLeft;
                Cat_Button[Cat_CurrentEntryID].Image = Properties.Resources.ArrowSmall_R;
                Cat_Button[Cat_CurrentEntryID].TextImageRelation = TextImageRelation.ImageBeforeText;
                Cat_Button[Cat_CurrentEntryID].Tag = Cat_CurrentEntryID;
                Cat_Button[Cat_CurrentEntryID].Click += Cat_Button_Click;

                Cat_Flow[Cat_CurrentEntryID] = new FlowLayoutPanel();
                Cat_Flow[Cat_CurrentEntryID].AutoSize = true;
                Cat_Flow[Cat_CurrentEntryID].Tag = cat;
                Cat_Flow[Cat_CurrentEntryID].Visible = false;

                ModFlow_Panel.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ModFlow_Panel.Controls.Add(Cat_Button[Cat_CurrentEntryID]);
                    ModFlow_Panel.Controls.Add(Cat_Flow[Cat_CurrentEntryID]);
                });

                Cat_Entries.Add(Cat_CurrentEntryID);
                Cat_CurrentEntryID++;
            }


            // Get all folders in Loaded
            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod") { continue; }
                //Create Integrity.dat if missing
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Integrity.dat") == false)
                {
                    //Calculate hash for each .pak
                    string Hashes = string.Empty;
                    foreach (string pak in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Paks", "*.pak"))
                    {
                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            ProgressPanel.Show();
                            ProgressTitle_Label.Text = "Patching...";
                            ProgressInfo_Label.Text = "Calculating MD5 hash for " + Path.GetFileName(pak) + "...";
                        });
                        string Md5Hash = CalculateMD5(pak);
                        Hashes += Path.GetFileName(pak) + " = " + Md5Hash + "\n";
                    }
                    Hashes = Hashes.Trim();
                    File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Integrity.dat", Hashes);
                    ProgressPanel.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        ProgressPanel.Hide();
                    });
                }

                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit.dat") == false)
                {
                    string LoadEdit_String = string.Empty;
                    foreach (string pak in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Paks", "*.pak"))
                    {
                        LoadEdit_String += Path.GetFileName(pak) + "\n";
                    }
                    foreach (string AM in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\AutoMod", "*.txt"))
                    {
                        LoadEdit_String += Path.GetFileName(AM) + "\n";
                    }
                    LoadEdit_String = LoadEdit_String.Trim();

                    File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit.dat", LoadEdit_String);
                }

                CreateModEntry(ModName);
                NoModsFound_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    NoModsFound_Label.Hide();
                });
            }

            // Conflict Check
            ConflictCheck();
            DependenciesCheck();

            CheckCategories();

            if (Mod_CurrentEntryID >= 101)
            {
                MessageBox.Show("Mod limit reached.");
            }
        }

        private void Main_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateModEntry(string ModName)
        {
            if (Mod_CurrentEntryID >= 101)
            {
                return;
            }
            string ModAuthor = string.Empty;
            string ModVersion = string.Empty;
            string SupportedVersions = string.Empty;
            string ModURL = string.Empty;
            string Categories = string.Empty;
            string FirstCategory = string.Empty;
            string Characters = string.Empty;
            string Dependencies = string.Empty;
            int PakCount = 0;
            int AutoModCount = 0;

            //Read MetaData
            string[] MetaData = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Metadata.dat");
            foreach (string meta in MetaData)
            {
                if (meta.StartsWith("ModAuthor"))
                {
                    ModAuthor = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("ModVersion"))
                {
                    ModVersion = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("SupportedWLVersions"))
                {
                    SupportedVersions = GetSlice(meta, "=", 1);
                    SupportedVersions = SupportedVersions.Replace(",", ", ");
                }
                else if (meta.StartsWith("ModURL"))
                {
                    ModURL = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("Categories"))
                {
                    Categories = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("Characters"))
                {
                    Characters = GetSlice(meta, "=", 1);
                    Characters = Characters.Replace(",", ", ");
                }
                else if (meta.StartsWith("Dependencies"))
                {
                    Dependencies = GetSlice(meta, "=", 1);
                }
            }

            //Read Enabled.dat
            string isEnabled = File.ReadAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Enabled.dat");

            PakCount = Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Paks", "*.pak").Count();
            AutoModCount = Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\AutoMod", "*.txt").Count();
            AutoModCount += Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\AutoMod", "*.collection").Count();

            int EntryID = Mod_CurrentEntryID;

            Mod_Categories[EntryID] = Categories;
            if (Categories.Contains(","))
            {
                FirstCategory = GetSlice(Categories, ",", 0);
            }
            else
            {
                FirstCategory = Categories;
            }
            //Read WLMM.dat
            if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\WLMM.dat"))
            {
                Mod_WLMMPath[EntryID] = File.ReadAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\WLMM.dat");
            }
            //Panel[] Mod_Panel = new Panel[50];
            Mod_Panel[EntryID] = new Panel();
            Mod_Panel[EntryID].Size = new System.Drawing.Size(840, 115);
            Mod_Panel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Panel[EntryID].BorderStyle = BorderStyle.Fixed3D;
            //PictureBox[] Mod_Icon = new PictureBox[50];
            Mod_Icon[EntryID] = new PictureBox();
            Mod_Icon[EntryID].Size = new System.Drawing.Size(100, 100);
            Mod_Icon[EntryID].Location = new Point(3, 5);
            Mod_Icon[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Icon[EntryID].BorderStyle = BorderStyle.FixedSingle;
            Mod_Icon[EntryID].SizeMode = PictureBoxSizeMode.Zoom;
            if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Icon.png"))
            {
                Mod_Icon[EntryID].ImageLocation = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Icon.png";
            }
            else
            {
                Mod_Icon[EntryID].ImageLocation = Application.StartupPath + @"System\Default_Icon.png";
            }
            //Label[] Mod_NameLabel = new Label[50];
            Mod_NameLabel[EntryID] = new Label();
            Mod_NameLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_NameLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_NameLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 16);
            Mod_NameLabel[EntryID].Text = ModName;
            Mod_NameLabel[EntryID].AutoSize = true;
            Mod_NameLabel[EntryID].Location = new Point(117, 4);
            //Label[] Mod_VersionLabel = new Label[50];
            Mod_VersionLabel[EntryID] = new Label();
            Mod_VersionLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_VersionLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_VersionLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 16);
            Mod_VersionLabel[EntryID].Text = ModVersion;
            Mod_VersionLabel[EntryID].AutoSize = true;
            Graphics g = CreateGraphics();
            SizeF LabelSize = g.MeasureString(Mod_VersionLabel[EntryID].Text, Mod_VersionLabel[EntryID].Font);
            Mod_VersionLabel[EntryID].Location = new Point(Mod_Panel[EntryID].Size.Width - ((int)LabelSize.Width) - 20, 4);
            //Label[] Mod_ErrorLabel = new Label[50];
            Mod_ErrorLabel[EntryID] = new Label();
            Mod_ErrorLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_ErrorLabel[EntryID].ForeColor = System.Drawing.Color.LightCoral;
            Mod_ErrorLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
            Mod_ErrorLabel[EntryID].Text = string.Empty;
            Mod_ErrorLabel[EntryID].Visible = false;
            Mod_ErrorLabel[EntryID].AutoSize = true;
            //Mod_ErrorLabel[EntryID].Location = new Point(533, 11);
            LabelSize = g.MeasureString(Mod_ErrorLabel[EntryID].Text, Mod_ErrorLabel[EntryID].Font);
            Mod_ErrorLabel[EntryID].Location = new Point(Mod_VersionLabel[EntryID].Left - ((int)LabelSize.Width) - 10, 11);
            //Label[] Mod_ContainsLabel = new Label[50];
            Mod_ContainsLabel[EntryID] = new LinkLabel();
            Mod_ContainsLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 10);
            Mod_ContainsLabel[EntryID].AutoSize = true;
            Mod_ContainsLabel[EntryID].Location = new Point(290, 82);
            Mod_ContainsLabel[EntryID].Tag = EntryID;
            Mod_ContainsLabel[EntryID].Click += Mod_ContainsLabel_Click;
            if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit_Mod.dat"))
            {
                int Mod_PakCount = 0;
                int Mod_AutoModCount = 0;
                var LE_Mod_Content = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit_Mod.dat");
                foreach (string line in LE_Mod_Content)
                {
                    if (line.EndsWith(".pak"))
                    {
                        Mod_PakCount++;
                    }
                    else if (line.EndsWith(".txt"))
                    {
                        Mod_AutoModCount++;
                    }
                }

                Mod_ContainsLabel[EntryID].LinkColor = Color.PaleGreen;
                Mod_ContainsLabel[EntryID].VisitedLinkColor = Color.PaleGreen;
                Mod_ContainsLabel[EntryID].ActiveLinkColor = Color.Green;
                Mod_ContainsLabel[EntryID].Text = "| Paks: " + Mod_PakCount.ToString() + "(" + PakCount.ToString() + ") | AutoMod: " + Mod_AutoModCount.ToString() + "(" + AutoModCount.ToString() + ") |";
            }
            else
            {
                Mod_ContainsLabel[EntryID].LinkColor = System.Drawing.SystemColors.GradientActiveCaption;
                Mod_ContainsLabel[EntryID].VisitedLinkColor = System.Drawing.SystemColors.GradientActiveCaption;
                Mod_ContainsLabel[EntryID].ActiveLinkColor = System.Drawing.SystemColors.Highlight;
                Mod_ContainsLabel[EntryID].Text = "| Paks: " + PakCount.ToString() + " | AutoMod: " + AutoModCount.ToString() + " |";
            }


            //LinkLabel[] Mod_RemoveButton = new LinkLabel[50];
            Mod_RemoveButton[EntryID] = new LinkLabel();
            Mod_RemoveButton[EntryID].Text = "Remove";
            Mod_RemoveButton[EntryID].LinkColor = System.Drawing.Color.LightCoral;
            Mod_RemoveButton[EntryID].VisitedLinkColor = System.Drawing.Color.LightCoral;
            Mod_RemoveButton[EntryID].ActiveLinkColor = System.Drawing.Color.Red;
            Mod_RemoveButton[EntryID].Location = new System.Drawing.Point(117, 80);
            Mod_RemoveButton[EntryID].Tag = EntryID;
            Mod_RemoveButton[EntryID].Click += Mod_RemoveButton_Click;
            Mod_RemoveButton[EntryID].AutoSize = true;
            Mod_RemoveButton[EntryID].Font = new Font(Mod_RemoveButton[EntryID].Font.FontFamily, 12);
            //LinkLabel[] Mod_ReloadButton = new LinkLabel[50];
            Mod_ReloadButton[EntryID] = new LinkLabel();
            Mod_ReloadButton[EntryID].Text = "Reload";
            Mod_ReloadButton[EntryID].LinkColor = System.Drawing.SystemColors.Highlight;
            Mod_ReloadButton[EntryID].VisitedLinkColor = System.Drawing.SystemColors.Highlight;
            Mod_ReloadButton[EntryID].ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_ReloadButton[EntryID].Location = new System.Drawing.Point(191, 80);
            Mod_ReloadButton[EntryID].Tag = EntryID;
            Mod_ReloadButton[EntryID].Click += Mod_ReloadButton_Click;
            Mod_ReloadButton[EntryID].AutoSize = true;
            Mod_ReloadButton[EntryID].Font = new Font(Mod_ReloadButton[EntryID].Font.FontFamily, 12);
            if (Mod_WLMMPath[EntryID] != string.Empty && File.Exists(Mod_WLMMPath[EntryID]))
            {
                Mod_ReloadButton[EntryID].Enabled = true;
            }
            else
            {
                Mod_ReloadButton[EntryID].Enabled = false;
            }
            //LinkLabel[] Mod_EditButton = new LinkLabel[50];
            Mod_EditButton[EntryID] = new LinkLabel();
            Mod_EditButton[EntryID].Text = "Edit";
            Mod_EditButton[EntryID].LinkColor = System.Drawing.SystemColors.Highlight;
            Mod_EditButton[EntryID].VisitedLinkColor = System.Drawing.SystemColors.Highlight;
            Mod_EditButton[EntryID].ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_EditButton[EntryID].Location = new System.Drawing.Point(255, 80);
            Mod_EditButton[EntryID].Tag = EntryID;
            Mod_EditButton[EntryID].Click += Mod_EditButton_Click;
            Mod_EditButton[EntryID].AutoSize = true;
            Mod_EditButton[EntryID].Font = new Font(Mod_EditButton[EntryID].Font.FontFamily, 12);
            if (Mod_WLMMPath[EntryID] != string.Empty && File.Exists(Mod_WLMMPath[EntryID]))
            {
                Mod_EditButton[EntryID].Enabled = true;
            }
            else
            {
                Mod_EditButton[EntryID].Enabled = false;
            }
            //LinkLabel[] Mod_LinkButton = new LinkLabel[50];
            Mod_LinkButton[EntryID] = new LinkLabel();
            Mod_LinkButton[EntryID].Text = "Link";
            Mod_LinkButton[EntryID].LinkColor = System.Drawing.SystemColors.Highlight;
            Mod_LinkButton[EntryID].VisitedLinkColor = System.Drawing.SystemColors.Highlight;
            Mod_LinkButton[EntryID].ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_LinkButton[EntryID].Location = new System.Drawing.Point(480, 80);
            Mod_LinkButton[EntryID].Tag = ModURL;
            Mod_LinkButton[EntryID].Click += Mod_LinkButton_Click;
            Mod_LinkButton[EntryID].AutoSize = true;
            Mod_LinkButton[EntryID].Font = new Font(Mod_LinkButton[EntryID].Font.FontFamily, 12);
            if (ModURL == string.Empty || ModURL == "None")
            {
                Mod_LinkButton[EntryID].Visible = false;
            }
            //CheckBox[] Mod_EnabledCB = new CheckBox[50];
            Mod_EnabledCB[EntryID] = new CheckBox();
            if (isEnabled == "Checked")
            {
                Mod_EnabledCB[EntryID].Checked = true;
            }
            else
            {
                Mod_EnabledCB[EntryID].Checked = false;
            }
            Mod_EnabledCB[EntryID].ForeColor = SystemColors.ActiveCaption;
            Mod_EnabledCB[EntryID].Font = new Font(Mod_EnabledCB[EntryID].Font.FontFamily, 12);
            Mod_EnabledCB[EntryID].Location = new System.Drawing.Point(741, 80);
            Mod_EnabledCB[EntryID].AutoSize = true;
            Mod_EnabledCB[EntryID].Text = "Enabled";
            Mod_EnabledCB[EntryID].Tag = EntryID;
            Mod_EnabledCB[EntryID].CheckStateChanged += ModEnabledCB_CheckStateChanged;
            //Label[] Mod_AuthorLabel = new Label[50];
            Mod_AuthorLabel[EntryID] = new Label();
            Mod_AuthorLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_AuthorLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_AuthorLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
            Mod_AuthorLabel[EntryID].Text = "By: " + ModAuthor;
            Mod_AuthorLabel[EntryID].AutoSize = true;
            LabelSize = g.MeasureString(Mod_AuthorLabel[EntryID].Text, Mod_AuthorLabel[EntryID].Font);
            Mod_AuthorLabel[EntryID].Location = new Point(Mod_EnabledCB[EntryID].Left - (int)LabelSize.Width - 5, 80);
            //Label[] Mod_SupportedVersionsLabel = new Label[50];
            Mod_SupportedVersionsLabel[EntryID] = new Label();
            Mod_SupportedVersionsLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_SupportedVersionsLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_SupportedVersionsLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 10);
            Mod_SupportedVersionsLabel[EntryID].Text = SupportedVersions;
            Mod_SupportedVersionsLabel[EntryID].AutoSize = true;
            Mod_SupportedVersionsLabel[EntryID].Location = new Point(117, 34);
            if (isVersionValid(SupportedVersions) == false)
            {
                Mod_ErrorLabel[EntryID].Text = "Version Mismatch";
                Mod_ErrorLabel[EntryID].Visible = true;
                Mod_SupportedVersionsLabel[EntryID].ForeColor = System.Drawing.Color.LightCoral;
                Mod_EnabledCB[EntryID].Enabled = false;
                Mod_EnabledCB[EntryID].Checked = false;
            }
            //Label[] Mod_CharactersLabel = new Label[50];
            Mod_CharactersLabel[EntryID] = new Label();
            Mod_CharactersLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_CharactersLabel[EntryID].ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            Mod_CharactersLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 10);
            Mod_CharactersLabel[EntryID].Text = Characters;
            Mod_CharactersLabel[EntryID].AutoSize = true;
            Mod_CharactersLabel[EntryID].Location = new Point(117, 54);

            Mod_Panel[EntryID].Controls.Add(Mod_Icon[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_NameLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_ErrorLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_VersionLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_SupportedVersionsLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_CharactersLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_ContainsLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_AuthorLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_RemoveButton[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_ReloadButton[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_EditButton[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_LinkButton[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_EnabledCB[EntryID]);

            if (Dependencies.Contains(","))
            {
                Mod_Dependencies[EntryID] = new List<string>();
                string[] SplitChars = Dependencies.Split(",");
                foreach (string s in SplitChars)
                {
                    string TrimmedS = s.Trim();
                    Mod_Dependencies[EntryID].Add(TrimmedS);
                    Debug.WriteLine(Mod_Dependencies[EntryID].Count);
                }
            }
            else
            {
                Mod_Dependencies[EntryID] = new List<string>();
                string TrimmedS = Dependencies.Trim();
                if (TrimmedS != string.Empty)
                {
                    Mod_Dependencies[EntryID].Add(TrimmedS);
                    Debug.WriteLine(Mod_Dependencies[EntryID].Count);
                }
            }

            if (FirstCategory == string.Empty)
            {
                FirstCategory = "Other";
            }

            ModFlow_Panel.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                //ModFlow_Panel.Controls.Add(Mod_Panel[EntryID]);
                GetCategoryFlow(FirstCategory).Controls.Add(Mod_Panel[EntryID]);
                Mod_Entries.Add(EntryID);
                Mod_CurrentEntryID += 1;
                AddChange();
            });
        }

        private bool isVersionValid(string Supported)
        {
            if (Supported.Contains(LoadedWLVersion) || Supported.Contains("All Versions") || Supported.Contains(LoadedUEVersion))
            {
                return true;
            }
            else { return false; }
        }

        private void ModFlow_Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void ModFlow_Panel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            List<string> Mods = new List<string>();
            List<string> Modpacks = new List<string>();
            foreach (string file in files)
            {
                if (file.EndsWith(".wlmm"))
                {
                    Mods.Add(file);
                }
                else if (file.EndsWith(".wlmp"))
                {
                    Modpacks.Add(file);
                }
            }
            if (Mods.Count > 0)
            {
                ProgressPanel.Show();
                ProgressTitle_Label.Text = "Loading Mods...";
                ProgressInfo_Label.Text = "Initializing...";
                BuildModProgress_PB.Value = 0;
                BuildModProgress_PB.Maximum = Mods.Count;

                // Create a thread and call a background method
                Thread backgroundThread = new Thread(() => AddMods(Mods));
                // Start thread
                backgroundThread.Start();
            }
            else if (Modpacks.Count > 0)
            {
                ModPackPath = Modpacks[0];
                LoadModPack();
            }
        }

        private void Mod_RemoveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this mod?", "Wild Life Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LinkLabel Casted = sender as LinkLabel;
                int EntryID = int.Parse(Casted.Tag.ToString());

                //Remove the mod files
                Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text, true);
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm"))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm");
                }

                Mod_Icon[EntryID].Dispose();
                Mod_NameLabel[EntryID].Dispose();
                Mod_ErrorLabel[EntryID].Dispose();
                Mod_VersionLabel[EntryID].Dispose();
                Mod_SupportedVersionsLabel[EntryID].Dispose();
                Mod_CharactersLabel[EntryID].Dispose();
                Mod_ContainsLabel[EntryID].Dispose();
                Mod_AuthorLabel[EntryID].Dispose();
                Mod_RemoveButton[EntryID].Dispose();
                Mod_ReloadButton[EntryID].Dispose();
                Mod_EditButton[EntryID].Dispose();
                Mod_LinkButton[EntryID].Dispose();
                Mod_EnabledCB[EntryID].Dispose();
                Mod_Panel[EntryID].Dispose();
                Mod_WLMMPath[EntryID] = string.Empty;
                Mod_Categories[EntryID] = string.Empty;

                Mod_Entries.Remove(EntryID);

                if (Mod_Entries.Count == 0)
                {
                    Mod_CurrentEntryID = 0;
                    NoModsFound_Label.Show();
                }
                AddChange();
                ConflictCheck();
                DependenciesCheck();
            }
        }

        private void Mod_LinkButton_Click(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            //Process.Start("explorer", Casted.Tag.ToString());
            ExpandedLink_Panel.Show();
            ExpandedLink_LL.Text = Casted.Tag.ToString();
        }

        private void Mod_ContainsLabel_Click(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            int EntryID = int.Parse(Casted.Tag.ToString());
            SelectedModID = EntryID;
            LoadEdit_Panel.Show();
            Load_LoadEdit(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text);
        }

        private void Mod_ReloadButton_Click(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            int EntryID = int.Parse(Casted.Tag.ToString());
            List<string> ValidMods = new List<string>();
            ValidMods.Add(Mod_WLMMPath[EntryID]);
            Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(Mod_WLMMPath[EntryID]), true);
            AddMods(ValidMods);
        }

        private void Mod_EditButton_Click(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            int EntryID = int.Parse(Casted.Tag.ToString());

            ModCreator ModCreator_Form = new ModCreator();
            ModCreator_Form.Show();
            ModCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, this);
            ModCreator_Form.LoadMod(Mod_WLMMPath[EntryID]);
        }

        private void ModEnabledCB_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox Casted = sender as CheckBox;
            int EntryID = int.Parse(Casted.Tag.ToString());
            File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + @"\Enabled.dat", Casted.CheckState.ToString());
            AddChange();
        }

        private void Cat_Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button Casted = sender as System.Windows.Forms.Button;
            int EntryID = int.Parse(Casted.Tag.ToString());

            if (Cat_Flow[EntryID].Visible == false)
            {
                Cat_Flow[EntryID].Show();
                Cat_Button[EntryID].Image = Properties.Resources.ArrowSmall_D;
            }
            else
            {
                Cat_Flow[EntryID].Hide();
                Cat_Button[EntryID].Image = Properties.Resources.ArrowSmall_R;
            }
        }

        private void RemoveMods_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove ALL mods?", "Wild Life Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (int EntryID in Mod_Entries)
                {
                    //Remove the mod files
                    Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text, true);
                    if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm"))
                    {
                        File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm");
                    }

                    Mod_Icon[EntryID].Dispose();
                    Mod_NameLabel[EntryID].Dispose();
                    Mod_ErrorLabel[EntryID].Dispose();
                    Mod_VersionLabel[EntryID].Dispose();
                    Mod_SupportedVersionsLabel[EntryID].Dispose();
                    Mod_CharactersLabel[EntryID].Dispose();
                    Mod_ContainsLabel[EntryID].Dispose();
                    Mod_AuthorLabel[EntryID].Dispose();
                    Mod_RemoveButton[EntryID].Dispose();
                    Mod_ReloadButton[EntryID].Dispose();
                    Mod_EditButton[EntryID].Dispose();
                    Mod_LinkButton[EntryID].Dispose();
                    Mod_EnabledCB[EntryID].Dispose();
                    Mod_Panel[EntryID].Dispose();
                    Mod_WLMMPath[EntryID] = string.Empty;
                    Mod_Categories[EntryID] = string.Empty;

                    AddChange();
                }
                Mod_Entries.Clear();
                Mod_CurrentEntryID = 0;

                //Clear Cats
                foreach (int EntryID in Cat_Entries)
                {
                    Cat_Button[EntryID].Dispose();
                    Cat_Flow[EntryID].Dispose();
                }
                Cat_Entries.Clear();
                Cat_CurrentEntryID = 0;

                NoModsFound_Label.Show();
            }
        }

        private void AddChange()
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                if (HasOldChanges == false && DT_Updater_Panel.Visible == false)
                {
                    ChangesMade++;
                    BuildMods_Button.Enabled = true;
                    ChangesMade_Label.Text = "Changes Made: " + ChangesMade.ToString();
                }
            });
        }

        private void BuildMods_Button_Click(object sender, EventArgs e)
        {
            ProgressPanel.Show();
            ProgressTitle_Label.Text = "Building Mods...";
            ProgressInfo_Label.Text = "Initializing...";
            BuildModProgress_PB.Value = 0;
            BuildModProgress_PB.Maximum = Mod_Entries.Count + 2;
            BuildMods_Button.Enabled = false;

            // Create a thread and call a background method
            Thread backgroundThread = new Thread(() => BuildMods());
            // Start thread
            backgroundThread.Start();
        }

        private void BuildMods()
        {
            BuildLog = "WLMM - " + WLMM_Version + " - Build Log\n";
            BuildLog += "DataTable Version: " + Datatable_Version + "\n";
            BuildLog += "Initializing...\n";
            bool HasAutoMod = false;
            List<string> ActiveMods = new List<string>();
            Dictionary<string, string> HashDict = new Dictionary<string, string>();
            //ActiveMods.Add("AutoMod_P.pak");
            ActiveMods.Add("WildLifeC-Windows.pak");
            //Clear files in AutoMod
            BuildLog += "Clearing AutoMod...\n";
            if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod"))
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod"))
                {
                    BuildLog += "- " + Path.GetFileName(file) + ".\n";
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod");
            }

            BuildLog += "Copying .paks and AutoMod files...\n";
            ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Copying .pak files to Wild Life..."; //1
            });

            // Get all folders in Loaded
            string FileCopyMessage = string.Empty;
            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod") { continue; }
                BuildLog += "+ " + ModName + "\n";
                string isEnabled = File.ReadAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Enabled.dat");
                List<string> EnabledPaks = new List<string>();
                List<string> EnabledAutoMod = new List<string>();
                if (isEnabled == "Checked")
                {
                    if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit_Mod.dat"))
                    {
                        BuildLog += "+ " + "Load Edit Modified" + "\n";
                        var LE_Mod_Content = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\LoadEdit_Mod.dat");
                        foreach (string line in LE_Mod_Content)
                        {
                            if (line.EndsWith(".pak"))
                            {
                                EnabledPaks.Add(line.Trim());
                            }
                            else if (line.EndsWith(".txt"))
                            {
                                EnabledAutoMod.Add(line.Trim());
                            }
                        }
                    }

                    try
                    {
                        //Copy .paks to Game
                        foreach (string pak in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Paks", "*.pak"))
                        {
                            if (EnabledPaks.Count == 0)
                            {
                                BuildLog += "+ + " + Path.GetFileName(pak) + "\n";
                                File.Copy(pak, LoadedWLPath + @"\WildLifeC\Content\Paks\" + Path.GetFileName(pak), true);
                                ActiveMods.Add(Path.GetFileName(pak));
                            }
                            else
                            {
                                if (EnabledPaks.Contains(Path.GetFileName(pak)))
                                {
                                    BuildLog += "+ + " + Path.GetFileName(pak) + "\n";
                                    File.Copy(pak, LoadedWLPath + @"\WildLifeC\Content\Paks\" + Path.GetFileName(pak), true);
                                    ActiveMods.Add(Path.GetFileName(pak));
                                }
                                else
                                {
                                    BuildLog += "+ - [Disabled] " + Path.GetFileName(pak) + "\n";
                                }
                            }
                        }

                        //Copy .txt and .collection to AutoMod
                        foreach (string AMFile in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\AutoMod", "*.txt"))
                        {
                            if (EnabledAutoMod.Count == 0)
                            {
                                BuildLog += "+ + " + Path.GetFileName(AMFile) + "\n";
                                File.Copy(AMFile, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\" + Path.GetFileName(AMFile), true);
                                HasAutoMod = true;
                            }
                            else
                            {
                                if (EnabledAutoMod.Contains(Path.GetFileName(AMFile)))
                                {
                                    BuildLog += "+ + " + Path.GetFileName(AMFile) + "\n";
                                    File.Copy(AMFile, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\" + Path.GetFileName(AMFile), true);
                                    HasAutoMod = true;
                                }
                                else
                                {
                                    BuildLog += "+ - [Disabled] " + Path.GetFileName(AMFile) + "\n";
                                }
                            }
                        }
                        foreach (string AMFile in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\AutoMod", "*.collection"))
                        {
                            BuildLog += "+ + " + Path.GetFileName(AMFile) + "\n";
                            File.Copy(AMFile, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\" + Path.GetFileName(AMFile), true);
                            HasAutoMod = true;
                        }

                        //Read Integrity.dat
                        if (BS_VerifyFI_CB.Checked)
                        {
                            if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Integrity.dat"))
                            {
                                string[] Integrity = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\Integrity.dat");
                                foreach (string hash in Integrity)
                                {
                                    if (HashDict.ContainsKey(GetSlice(hash, "=", 0)) == false)
                                    {
                                        HashDict.Add(GetSlice(hash, "=", 0), GetSlice(hash, "=", 1));
                                    }
                                    else
                                    {
                                        BuildLog += "+ - " + GetSlice(hash, "=", 0) + " already exists in HashDict.\n";
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        FileCopyMessage = ex.Message;
                        BuildLog += "+ - Failed deploying mod: " + ModName + "\n";
                        BuildLog += "+ - ex: " + FileCopyMessage + "\n";
                        MessageBox.Show("Failed deploying mod: " + ModName + "\nCheck build log for detailed info.", "Wild Life Mod Manager");
                        ResetFromBuilding();
                        return;
                    }
                }
                else
                {
                    BuildLog += "+ - Disabled\n";
                }
                BuildModProgress_PB.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    BuildModProgress_PB.Value++;
                });
            }

            //Check for files in AutoMod folder
            if (HasAutoMod || BS_AlwaysRunAM_CB.Checked == true)
            {
                ActiveMods.Add("AutoMod_P.pak");
            }

            //Check what .paks are not in the active mods
            FileCopyMessage = string.Empty;
            bool KeepAll = false;
            bool RemoveAll = false;
            foreach (string pak in Directory.EnumerateFiles(LoadedWLPath + @"\WildLifeC\Content\Paks", "*.pak"))
            {
                bool Found = false;
                foreach (string am in ActiveMods)
                {
                    if (Path.GetFileName(pak) == am)
                    {
                        Found = true;
                    }
                }
                if (Found == false)
                {
                    BuildLog += "Found mod outside of active mods: " + Path.GetFileName(pak) + "\n";

                    string Result = "Keep";
                    if (RemoveAll == true)
                    {
                        Result = "RemoveAll";
                    }
                    else if (KeepAll == true)
                    {
                        continue;
                    }
                    else
                    {
                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            this.Enabled = false;
                        });
                        CustomMsgBox CustomMsgBox_Form = new CustomMsgBox();
                        CustomMsgBox_Form.InactiveMod(Path.GetFileNameWithoutExtension(pak), this);
                        DialogResult dialogResult = CustomMsgBox_Form.ShowDialog();
                        if (dialogResult == DialogResult.Yes)
                        {
                            //Keep
                            Result = "Keep";
                        }
                        else if (dialogResult == DialogResult.Continue)
                        {
                            //Keep All
                            Result = "KeepAll";
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //Remove
                            Result = "Remove";
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            //Remove All
                            Result = "RemoveAll";
                        }
                    }

                    try
                    {
                        if (Result == "Keep")
                        {
                            //Keep
                            BuildLog += "+ Keeping\n";
                        }
                        else if (Result == "KeepAll")
                        {
                            //Keep All
                            KeepAll = true;
                            BuildLog += "+ Keeping\n";
                        }
                        else if (Result == "Remove")
                        {
                            //Remove
                            BuildLog += "- Deleting.\n";
                            File.Delete(pak);
                        }
                        else if (Result == "RemoveAll")
                        {
                            //Remove All
                            BuildLog += "- Deleting.\n";
                            File.Delete(pak);
                            RemoveAll = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        FileCopyMessage = ex.Message;
                        BuildLog += "- Failed removing inactive .pak: " + Path.GetFileName(pak) + "\n";
                        BuildLog += "- ex: " + FileCopyMessage + "\n";
                        MessageBox.Show("Failed removing inactive .pak: " + Path.GetFileName(pak) + "\nIs the file in use?", "Wild Life Mod Manager");
                        ResetFromBuilding();
                        return;
                    }
                }
            }

            if (HasAutoMod || BS_AlwaysRunAM_CB.Checked == true)
            {
                BuildLog += "AutoMod Process...\n";
                if (BS_AlwaysRunAM_CB.Checked == true)
                {
                    BuildLog += "(AutoMod Process Forced)\n";
                }
                BuildLog += "+ Generating .JSON files...\n";
                //AutoMod Process
                //Generate .json files //2
                string JSON_Message = GenerateJSON();
                if (JSON_Message != "Success")
                {
                    BuildLog += "+ - Failed .JSON generation.\n";
                    BuildLog += "+ - ex: " + JSON_Message + "\n";
                    MessageBox.Show(JSON_Message, "Wild Life Mod Manager");
                    ResetFromBuilding();
                    return;
                }
                BuildLog += "+ + " + JSON_Message + ".\n";
                BuildModProgress_PB.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    BuildModProgress_PB.Value++;
                });
                BuildLog += "+ Serializing files...\n";
                //Serialize to .uasset //3
                string UAsset_Message = SerializeToUAsset();
                if (UAsset_Message != "Success")
                {
                    BuildLog += "+ - Failed serialization.\n";
                    BuildLog += "+ - ex: " + UAsset_Message + "\n";
                    MessageBox.Show(UAsset_Message, "Wild Life Mod Manager");
                    ResetFromBuilding();
                    return;
                }
                BuildLog += "+ + " + UAsset_Message + ".\n";
                BuildModProgress_PB.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    BuildModProgress_PB.Value++;
                });
                BuildLog += "+ Packaging AutoMod_P.pak...\n";
                //Pack to AutoMod_P.pak //4
                string Repak_Message = PackageAutoMod();
                if (Repak_Message != "Success")
                {
                    BuildLog += "+ - Failed packaging.\n";
                    BuildLog += "+ - ex: " + Repak_Message + "\n";
                    MessageBox.Show(Repak_Message, "Wild Life Mod Manager");
                    ResetFromBuilding();
                    return;
                }
                BuildLog += "+ + " + Repak_Message + ".\n";
                //Copy AutoMod_P.pak to Game //5
                BuildLog += "+ Moving AutoMod_P.pak to Game...\n";
                File.Move(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P.pak", LoadedWLPath + @"\WildLifeC\Content\Paks\AutoMod_P.pak", true);
                BuildLog += "+ AutoMod Process Success.\n";
            }
            else
            {
                BuildLog += "Skipping AutoMod Process.\n";
            }

            //Verify integrity of .paks
            if (BS_VerifyFI_CB.Checked)
            {
                ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ProgressInfo_Label.Text = "Verifying file integrity...";
                });
                BuildLog += "Verifying file integrity...\n";
                foreach (string pak in Directory.EnumerateFiles(LoadedWLPath + @"\WildLifeC\Content\Paks", "*.pak"))
                {
                    if (HashDict.ContainsKey(Path.GetFileName(pak)))
                    {
                        string CalculatedHash = CalculateMD5(pak);
                        string OriginalHash = HashDict[Path.GetFileName(pak)];
                        if (CalculatedHash == OriginalHash)
                        {
                            BuildLog += "+ " + Path.GetFileName(pak) + " valid.\n";
                            BuildLog += "+ + " + CalculatedHash + " = " + OriginalHash + "\n";
                        }
                        else
                        {
                            BuildLog += "- " + Path.GetFileName(pak) + " invalid.\n";
                            BuildLog += "- - " + CalculatedHash + " != " + OriginalHash + "\n";
                            MessageBox.Show(Path.GetFileName(pak) + " failed file verification.\nTry re-building mods or updating the affected mod.", "Wild Life Mod Manager");
                        }
                    }
                    else
                    {
                        BuildLog += "- " + Path.GetFileName(pak) + " skipped verification.\n";
                    }
                }
                BuildLog += "Verification completed.\n";
            }

            BuildLog += "Mods successfully deployed.\n";

            ResetFromBuilding();
        }

        private void ResetFromBuilding()
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressPanel.Hide();
                ProgressTitle_Label.Text = "Building Mods...";
                ProgressInfo_Label.Text = "Initializing...";
                BuildModProgress_PB.Value = 0;
                BuildModProgress_PB.Maximum = 100;
                ChangesMade_Label.Text = "Build Completed.";
                ChangesMade = 0;
                BuildMods_Button.Enabled = true;

                File.WriteAllText(Application.StartupPath + @"System\LatestBuildLog.txt", BuildLog);
                BuildLog = string.Empty;
            });
        }

        private string GenerateJSON()
        {
            //This needs a rewrite
            int OutfitNR = 0;
            int CustomNR = 0;
            string ClothesOutfit = string.Empty;
            string GameCharacterOutfits = string.Empty;
            string GameCharacterCustom = string.Empty;

            BS_BaseGameCharacterCustomizationFile.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                GameCharacterCustom = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\" + BS_BaseGameCharacterCustomizationFile.Text);
            });

            try
            {
                BS_BaseClothesOutfitFile.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ClothesOutfit = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\" + BS_BaseClothesOutfitFile.Text);
                });
            }
            catch (Exception)
            {
                return "Base DT_ClothesOutfit was not found.";
            }

            try
            {
                BS_BaseGameCharacterOutfitFile.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    GameCharacterOutfits = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\" + BS_BaseGameCharacterOutfitFile.Text);
                });
            }
            catch (Exception)
            {
                return "Base DT_GameCharacterOutfits was not found.";
            }

            List<string> Entries = new List<string>();
            List<string> NameMap = new List<string>();
            List<string> OutfitsNameMap = new List<string>();
            List<string> CustomNameMap = new List<string>();
            List<string> Outfits = new List<string>();
            List<string> Hair = new List<string>();
            List<string> Skin = new List<string>();
            List<string> PubicHair = new List<string>();
            List<string> Eyes = new List<string>();
            List<string> EyeLiner = new List<string>();
            List<string> EyeShadow = new List<string>();
            List<string> Lipstick = new List<string>();
            List<string> Tanlines = new List<string>();
            bool CustomEdited = false;
            bool FurEdited = false;

            var CharacterFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt");
            List<string> Characters = new List<string>(CharacterFile);
            CharacterFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\CustomizerCharacters.txt");
            List<string> CustomizerCharacters = new List<string>(CharacterFile);

            StringBuilder stringBuilder = new StringBuilder();
            var FurFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Default.json");
            var FurList = new List<string>(FurFile);


            string OutfitFileNameMap_Path = string.Empty;
            BS_BaseGameCharacterOutfitFile.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                OutfitFileNameMap_Path = Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\" + BS_BaseGameCharacterOutfitFile.Text.Replace(".json", "") + "_NameMap.txt";
            });

            if (File.Exists(OutfitFileNameMap_Path) == false)
            {
                OutfitFileNameMap_Path = Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Default_NameMap.txt";
            }
            string[] NameMap_Defaults = File.ReadAllLines(OutfitFileNameMap_Path);
            string[] CustomNameMap_Defaults = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Default_NameMap.txt");

            string Original_Entry = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Entry_Default.json");
            string Original_FurmaskEntry = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Entry_FurMask.json");
            string Original_OutfitEntry = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Entry_Default.json");
            string Original_CustomEntry = File.ReadAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Entry_Default.json");

            Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\Unzipped");
            foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod", "*.collection"))
            {
                ZipFile.ExtractToDirectory(file, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\Unzipped");
            }
            int UnzippedIndex = 0;
            foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\Unzipped", "*.txt"))
            {
                string NewFileName = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod\Temp_" + UnzippedIndex.ToString() + ".txt";
                File.Move(file, NewFileName);
                UnzippedIndex++;
            }

            foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod", "*.txt"))
            {
                //Debug.WriteLine(file.ToString());
                string Entry = Original_Entry;
                string OutfitEntry = Original_OutfitEntry;
                string CustomEntry = Original_CustomEntry;
                string[] contents;
                bool UsingFurMask = false;
                contents = File.ReadAllLines(file);
                ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ProgressInfo_Label.Text = "Generating .JSON...";
                });

                //Check for furmask entries
                foreach (string x in contents)
                {
                    if (x.Contains("_FURMASK_PATH]"))
                    {
                        Entry = Original_FurmaskEntry;
                        UsingFurMask = true;
                        break;
                    }
                }

                if (GetCleanString(contents, "Variant") == "Add")
                {
                    OutfitEntry = OutfitEntry.Replace("[OUTFIT_NR]", "Mod_" + OutfitNR.ToString());
                    OutfitsNameMap.Add("Mod_" + OutfitNR.ToString());
                    OutfitEntry = OutfitEntry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    OutfitEntry += "," + "\n";
                    OutfitEntry = OutfitEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                    OutfitsNameMap.Add(GetCleanString(contents, "[CLOTHING_ID]"));
                    Outfits.Add(OutfitEntry);

                    Entry = Entry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    Entry = Entry.Replace("[CLOTHING_NAME]", GetCleanString(contents, "[CLOTHING_NAME]"));
                    Entry = Entry.Replace("[HEAD_MESH_PATH]", GetCleanString(contents, "[HEAD_MESH_PATH]"));
                    Entry = Entry.Replace("[HEAD_MESH_NAME]", GetCleanString(contents, "[HEAD_MESH_NAME]"));
                    Entry = Entry.Replace("[HEAD_SEX_MESH_PATH]", GetCleanString(contents, "[HEAD_SEX_MESH_PATH]"));
                    Entry = Entry.Replace("[HEAD_SEX_MESH_NAME]", GetCleanString(contents, "[HEAD_SEX_MESH_NAME]"));
                    Entry = Entry.Replace("[HEAD_ICON_PATH]", GetCleanString(contents, "[HEAD_ICON_PATH]"));
                    Entry = Entry.Replace("[HEAD_ICON_NAME]", GetCleanString(contents, "[HEAD_ICON_NAME]"));
                    if (UsingFurMask == true)
                    {
                        Entry = Entry.Replace("[HEAD_FURMASK_PATH]", GetCleanString(contents, "[HEAD_FURMASK_PATH]"));
                        Entry = Entry.Replace("[HEAD_FURMASK_NAME]", GetCleanString(contents, "[HEAD_FURMASK_NAME]"));
                        Entry = Entry.Replace("[HEAD_SEX_FURMASK_PATH]", GetCleanString(contents, "[HEAD_SEX_FURMASK_PATH]"));
                        Entry = Entry.Replace("[HEAD_SEX_FURMASK_NAME]", GetCleanString(contents, "[HEAD_SEX_FURMASK_NAME]"));
                    }

                    Entry = Entry.Replace("[HEAD_PHYSICSAREAS]", GetCleanString(contents, "[HEAD_PHYSICSAREAS]"));
                    Entry = Entry.Replace("[HEAD_MORPHTARGET]", GetCleanString(contents, "[HEAD_MORPHTARGET]"));
                    Entry = Entry.Replace("[HEAD_MORPHTARGETVALUE]", GetCleanString(contents, "[HEAD_MORPHTARGETVALUE]"));
                    Entry = Entry.Replace("[HEAD_CONSTRAINTPROFILE]", GetCleanString(contents, "[HEAD_CONSTRAINTPROFILE]"));
                    Entry = Entry.Replace("[HEAD_AROUSALBLEND]", GetCleanString(contents, "[HEAD_AROUSALBLEND]"));
                    Entry = Entry.Replace("[HEAD_FLEXREGIONS]", GetCleanString(contents, "[HEAD_FLEXREGIONS]"));

                    Entry = Entry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    Entry = Entry.Replace("[CLOTHING_NAME]", GetCleanString(contents, "[CLOTHING_NAME]"));
                    Entry = Entry.Replace("[CHEST_MESH_PATH]", GetCleanString(contents, "[CHEST_MESH_PATH]"));
                    Entry = Entry.Replace("[CHEST_MESH_NAME]", GetCleanString(contents, "[CHEST_MESH_NAME]"));
                    Entry = Entry.Replace("[CHEST_SEX_MESH_PATH]", GetCleanString(contents, "[CHEST_SEX_MESH_PATH]"));
                    Entry = Entry.Replace("[CHEST_SEX_MESH_NAME]", GetCleanString(contents, "[CHEST_SEX_MESH_NAME]"));
                    Entry = Entry.Replace("[CHEST_ICON_PATH]", GetCleanString(contents, "[CHEST_ICON_PATH]"));
                    Entry = Entry.Replace("[CHEST_ICON_NAME]", GetCleanString(contents, "[CHEST_ICON_NAME]"));
                    if (UsingFurMask == true)
                    {
                        Entry = Entry.Replace("[CHEST_FURMASK_PATH]", GetCleanString(contents, "[CHEST_FURMASK_PATH]"));
                        Entry = Entry.Replace("[CHEST_FURMASK_NAME]", GetCleanString(contents, "[CHEST_FURMASK_NAME]"));
                        Entry = Entry.Replace("[CHEST_SEX_FURMASK_PATH]", GetCleanString(contents, "[CHEST_SEX_FURMASK_PATH]"));
                        Entry = Entry.Replace("[CHEST_SEX_FURMASK_NAME]", GetCleanString(contents, "[CHEST_SEX_FURMASK_NAME]"));
                    }

                    Entry = Entry.Replace("[CHEST_PHYSICSAREAS]", GetCleanString(contents, "[CHEST_PHYSICSAREAS]"));
                    Entry = Entry.Replace("[CHEST_MORPHTARGET]", GetCleanString(contents, "[CHEST_MORPHTARGET]"));
                    Entry = Entry.Replace("[CHEST_MORPHTARGETVALUE]", GetCleanString(contents, "[CHEST_MORPHTARGETVALUE]"));
                    Entry = Entry.Replace("[CHEST_CONSTRAINTPROFILE]", GetCleanString(contents, "[CHEST_CONSTRAINTPROFILE]"));
                    Entry = Entry.Replace("[CHEST_AROUSALBLEND]", GetCleanString(contents, "[CHEST_AROUSALBLEND]"));
                    Entry = Entry.Replace("[CHEST_FLEXREGIONS]", GetCleanString(contents, "[CHEST_FLEXREGIONS]"));

                    Entry = Entry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    Entry = Entry.Replace("[CLOTHING_NAME]", GetCleanString(contents, "[CLOTHING_NAME]"));
                    Entry = Entry.Replace("[HANDS_MESH_PATH]", GetCleanString(contents, "[HANDS_MESH_PATH]"));
                    Entry = Entry.Replace("[HANDS_MESH_NAME]", GetCleanString(contents, "[HANDS_MESH_NAME]"));
                    Entry = Entry.Replace("[HANDS_SEX_MESH_PATH]", GetCleanString(contents, "[HANDS_SEX_MESH_PATH]"));
                    Entry = Entry.Replace("[HANDS_SEX_MESH_NAME]", GetCleanString(contents, "[HANDS_SEX_MESH_NAME]"));
                    Entry = Entry.Replace("[HANDS_ICON_PATH]", GetCleanString(contents, "[HANDS_ICON_PATH]"));
                    Entry = Entry.Replace("[HANDS_ICON_NAME]", GetCleanString(contents, "[HANDS_ICON_NAME]"));
                    if (UsingFurMask == true)
                    {
                        Entry = Entry.Replace("[HANDS_FURMASK_PATH]", GetCleanString(contents, "[HANDS_FURMASK_PATH]"));
                        Entry = Entry.Replace("[HANDS_FURMASK_NAME]", GetCleanString(contents, "[HANDS_FURMASK_NAME]"));
                        Entry = Entry.Replace("[HANDS_SEX_FURMASK_PATH]", GetCleanString(contents, "[HANDS_SEX_FURMASK_PATH]"));
                        Entry = Entry.Replace("[HANDS_SEX_FURMASK_NAME]", GetCleanString(contents, "[HANDS_SEX_FURMASK_NAME]"));
                    }

                    Entry = Entry.Replace("[HANDS_PHYSICSAREAS]", GetCleanString(contents, "[HANDS_PHYSICSAREAS]"));
                    Entry = Entry.Replace("[HANDS_MORPHTARGET]", GetCleanString(contents, "[HANDS_MORPHTARGET]"));
                    Entry = Entry.Replace("[HANDS_MORPHTARGETVALUE]", GetCleanString(contents, "[HANDS_MORPHTARGETVALUE]"));
                    Entry = Entry.Replace("[HANDS_CONSTRAINTPROFILE]", GetCleanString(contents, "[HANDS_CONSTRAINTPROFILE]"));
                    Entry = Entry.Replace("[HANDS_AROUSALBLEND]", GetCleanString(contents, "[HANDS_AROUSALBLEND]"));
                    Entry = Entry.Replace("[HANDS_FLEXREGIONS]", GetCleanString(contents, "[HANDS_FLEXREGIONS]"));

                    Entry = Entry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    Entry = Entry.Replace("[CLOTHING_NAME]", GetCleanString(contents, "[CLOTHING_NAME]"));
                    Entry = Entry.Replace("[LEGS_MESH_PATH]", GetCleanString(contents, "[LEGS_MESH_PATH]"));
                    Entry = Entry.Replace("[LEGS_MESH_NAME]", GetCleanString(contents, "[LEGS_MESH_NAME]"));
                    Entry = Entry.Replace("[LEGS_SEX_MESH_PATH]", GetCleanString(contents, "[LEGS_SEX_MESH_PATH]"));
                    Entry = Entry.Replace("[LEGS_SEX_MESH_NAME]", GetCleanString(contents, "[LEGS_SEX_MESH_NAME]"));
                    Entry = Entry.Replace("[LEGS_ICON_PATH]", GetCleanString(contents, "[LEGS_ICON_PATH]"));
                    Entry = Entry.Replace("[LEGS_ICON_NAME]", GetCleanString(contents, "[LEGS_ICON_NAME]"));
                    if (UsingFurMask == true)
                    {
                        Entry = Entry.Replace("[LEGS_FURMASK_PATH]", GetCleanString(contents, "[LEGS_FURMASK_PATH]"));
                        Entry = Entry.Replace("[LEGS_FURMASK_NAME]", GetCleanString(contents, "[LEGS_FURMASK_NAME]"));
                        Entry = Entry.Replace("[LEGS_SEX_FURMASK_PATH]", GetCleanString(contents, "[LEGS_SEX_FURMASK_PATH]"));
                        Entry = Entry.Replace("[LEGS_SEX_FURMASK_NAME]", GetCleanString(contents, "[LEGS_SEX_FURMASK_NAME]"));
                    }

                    Entry = Entry.Replace("[LEGS_PHYSICSAREAS]", GetCleanString(contents, "[LEGS_PHYSICSAREAS]"));
                    Entry = Entry.Replace("[LEGS_MORPHTARGET]", GetCleanString(contents, "[LEGS_MORPHTARGET]"));
                    Entry = Entry.Replace("[LEGS_MORPHTARGETVALUE]", GetCleanString(contents, "[LEGS_MORPHTARGETVALUE]"));
                    Entry = Entry.Replace("[LEGS_CONSTRAINTPROFILE]", GetCleanString(contents, "[LEGS_CONSTRAINTPROFILE]"));
                    Entry = Entry.Replace("[LEGS_AROUSALBLEND]", GetCleanString(contents, "[LEGS_AROUSALBLEND]"));
                    Entry = Entry.Replace("[LEGS_FLEXREGIONS]", GetCleanString(contents, "[LEGS_FLEXREGIONS]"));

                    Entry = Entry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    Entry = Entry.Replace("[CLOTHING_NAME]", GetCleanString(contents, "[CLOTHING_NAME]"));
                    Entry = Entry.Replace("[FEET_MESH_PATH]", GetCleanString(contents, "[FEET_MESH_PATH]"));
                    Entry = Entry.Replace("[FEET_MESH_NAME]", GetCleanString(contents, "[FEET_MESH_NAME]"));
                    Entry = Entry.Replace("[FEET_SEX_MESH_PATH]", GetCleanString(contents, "[FEET_SEX_MESH_PATH]"));
                    Entry = Entry.Replace("[FEET_SEX_MESH_NAME]", GetCleanString(contents, "[FEET_SEX_MESH_NAME]"));
                    Entry = Entry.Replace("[FEET_ICON_PATH]", GetCleanString(contents, "[FEET_ICON_PATH]"));
                    Entry = Entry.Replace("[FEET_ICON_NAME]", GetCleanString(contents, "[FEET_ICON_NAME]"));
                    if (UsingFurMask == true)
                    {
                        Entry = Entry.Replace("[FEET_FURMASK_PATH]", GetCleanString(contents, "[FEET_FURMASK_PATH]"));
                        Entry = Entry.Replace("[FEET_FURMASK_NAME]", GetCleanString(contents, "[FEET_FURMASK_NAME]"));
                        Entry = Entry.Replace("[FEET_SEX_FURMASK_PATH]", GetCleanString(contents, "[FEET_SEX_FURMASK_PATH]"));
                        Entry = Entry.Replace("[FEET_SEX_FURMASK_NAME]", GetCleanString(contents, "[FEET_SEX_FURMASK_NAME]"));
                    }

                    Entry = Entry.Replace("[FEET_PHYSICSAREAS]", GetCleanString(contents, "[FEET_PHYSICSAREAS]"));
                    Entry = Entry.Replace("[FEET_MORPHTARGET]", GetCleanString(contents, "[FEET_MORPHTARGET]"));
                    Entry = Entry.Replace("[FEET_MORPHTARGETVALUE]", GetCleanString(contents, "[FEET_MORPHTARGETVALUE]"));
                    Entry = Entry.Replace("[FEET_CONSTRAINTPROFILE]", GetCleanString(contents, "[FEET_CONSTRAINTPROFILE]"));
                    Entry = Entry.Replace("[FEET_AROUSALBLEND]", GetCleanString(contents, "[FEET_AROUSALBLEND]"));
                    Entry = Entry.Replace("[FEET_FLEXREGIONS]", GetCleanString(contents, "[FEET_FLEXREGIONS]"));
                    Entry += "," + "\n";

                    Entries.Add(Entry);

                    string NM = GetCleanString(contents, "NameMap");
                    string[] TempArray = NM.Split(',');
                    foreach (string temp in TempArray)
                    {
                        bool isDupe = false;
                        foreach (string itm in NameMap)
                        {
                            if (itm == temp)
                            {
                                isDupe = true;
                                break;
                            }
                        }
                        if (isDupe == false)
                        {
                            foreach (string itm in NameMap_Defaults)
                            {
                                if (itm == temp)
                                {
                                    isDupe = true;
                                    break;
                                }
                            }
                        }
                        if (isDupe == false)
                        {
                            NameMap.Add(temp);
                        }
                    }

                    OutfitNR += 1;
                }
                else if (GetCleanString(contents, "Variant") == "Port")
                {
                    OutfitEntry = OutfitEntry.Replace("[OUTFIT_NR]", "Mod_" + OutfitNR.ToString());
                    OutfitsNameMap.Add("Mod_" + OutfitNR.ToString());
                    OutfitEntry = OutfitEntry.Replace("[CLOTHING_ID]", GetCleanString(contents, "[CLOTHING_ID]"));
                    OutfitEntry += "," + "\n";
                    OutfitEntry = OutfitEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                    Outfits.Add(OutfitEntry);

                    OutfitNR += 1;
                    //Outfit Port processed
                }
                else if (GetCleanString(contents, "Variant") == "Character Customization")
                {
                    CustomEdited = true;
                    foreach (string S in contents)
                    {
                        CustomEntry = Original_CustomEntry;
                        CustomEntry = CustomEntry.Replace("[CUSTOM_NR]", "Mod_" + CustomNR.ToString());
                        string[] TempArray = S.Split(':');

                        if (TempArray[0] == "Hair")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            Hair.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "Skin")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            Skin.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "PubicHair")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            PubicHair.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "Eyes")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            Eyes.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "EyeLiner")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            EyeLiner.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "EyeShadow")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            EyeShadow.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "Lipstick")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            Lipstick.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }
                        else if (TempArray[0] == "Tanlines")
                        {
                            string[] PathNameArray = TempArray[1].Split(',');
                            CustomEntry = CustomEntry.Replace("[PACKAGE_PATH]", PathNameArray[0].Trim());
                            CustomEntry = CustomEntry.Replace("[PACKAGE_NAME]", PathNameArray[1].Trim());
                            CustomEntry = CustomEntry.Insert(0, GetCleanString(contents, "Character") + "¤");
                            Tanlines.Add(CustomEntry);
                            CustomNameMap.Add("Mod_" + CustomNR.ToString());
                            CustomNR += 1;
                        }

                        string NM = GetCleanString(contents, "NameMap");
                        string[] TempArray2 = NM.Split(',');
                        foreach (string temp in TempArray2)
                        {
                            bool isDupe = false;
                            foreach (string itm in CustomNameMap)
                            {
                                if (itm == temp)
                                {
                                    isDupe = true;
                                    break;
                                }
                            }
                            if (isDupe == false)
                            {
                                foreach (string itm in CustomNameMap_Defaults)
                                {
                                    if (itm == temp)
                                    {
                                        isDupe = true;
                                        break;
                                    }
                                }
                            }
                            if (isDupe == false)
                            {
                                CustomNameMap.Add(temp);
                            }
                        }
                    }
                    //Customizer processed
                }
                else if (GetCleanString(contents, "Variant") == "Fur Customization")
                {
                    string State = "FindCharacter";
                    for (var i = 0; i < FurList.Count; i++)
                    {
                        string line = FurList[i];

                        if (State == "FindCharacter")
                        {
                            if (line.Contains("\"Name\": \"" + GetCleanString(contents, "Character") + "\","))
                            {
                                State = "FindShowHairMesh";
                            }
                        }
                        else if (State == "FindShowHairMesh")
                        {
                            if (line.Contains("\"Name\": \"bShowHairMesh\","))
                            {
                                State = "FoundShowHairMesh";
                            }
                        }
                        else if (State == "FoundShowHairMesh")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "bShowHairMesh");
                                State = "FindShowBeardMesh";
                            }
                        }
                        else if (State == "FindShowBeardMesh")
                        {
                            if (line.Contains("\"Name\": \"bShowBeardMesh\","))
                            {
                                State = "FoundShowBeardMesh";
                            }
                        }
                        else if (State == "FoundShowBeardMesh")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "bShowBeardMesh");
                                State = "FindLayerCount";
                            }
                        }
                        else if (State == "FindLayerCount")
                        {
                            if (line.Contains("\"Name\": \"LayerCount\","))
                            {
                                State = "FoundLayerCount";
                            }
                        }
                        else if (State == "FoundLayerCount")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "LayerCount");
                                State = "FindLODS";
                            }
                        }
                        else if (State == "FindLODS")
                        {
                            if (line.Contains("\"Name\": \"Lods\","))
                            {
                                State = "FindLODLayerCount";
                            }
                        }
                        else if (State == "FindLODLayerCount")
                        {
                            if (line.Contains("\"Name\": \"LayerCount\","))
                            {
                                State = "FoundLODLayerCount";
                            }
                        }
                        else if (State == "FoundLODLayerCount")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "LOD_LayerCount");
                                State = "FindLODPhysics";
                            }
                        }
                        else if (State == "FindLODPhysics")
                        {
                            if (line.Contains("\"Name\": \"physicsEnabled\","))
                            {
                                State = "FoundLODPhysics";
                            }
                        }
                        else if (State == "FoundLODPhysics")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "LOD_physicsEnabled");
                                State = "FindFurLength";
                            }
                        }
                        else if (State == "FindFurLength")
                        {
                            if (line.Contains("\"Name\": \"FurLength\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "FurLength") + ",";
                                State = "FindMinFurLength";
                            }
                        }
                        else if (State == "FindMinFurLength")
                        {
                            if (line.Contains("\"Name\": \"MinFurLength\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "MinFurLength") + ",";
                                State = "FindPhysics";
                            }
                        }
                        else if (State == "FindPhysics")
                        {
                            if (line.Contains("\"Name\": \"bPhysicsEnabled\","))
                            {
                                State = "FoundPhysics";
                            }
                        }
                        else if (State == "FoundPhysics")
                        {
                            if (line.Contains("\"Value\":"))
                            {
                                FurList[i] = "\"Value\": " + GetCleanString(contents, "bPhysicsEnabled");
                                State = "FindForceDistribution";
                            }
                        }
                        else if (State == "FindForceDistribution")
                        {
                            if (line.Contains("\"Name\": \"ForceDistribution\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "ForceDistribution") + ",";
                                State = "FindStiffness";
                            }
                        }
                        else if (State == "FindStiffness")
                        {
                            if (line.Contains("\"Name\": \"Stiffness\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "Stiffness") + ",";
                                State = "FindDamping";
                            }
                        }
                        else if (State == "FindDamping")
                        {
                            if (line.Contains("\"Name\": \"Damping\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "Damping") + ",";
                                State = "FindConstantForce";
                            }
                        }
                        else if (State == "FindConstantForce")
                        {
                            if (line.Contains("\"Name\": \"ConstantForce\","))
                            {
                                State = "FoundConstantForce";
                            }
                        }
                        else if (State == "FoundConstantForce")
                        {
                            if (line.Contains("\"X\":"))
                            {
                                FurList[i] = "\"X\": " + GetCleanString(contents, "ConstForce_X") + ",";
                            }
                            else if (line.Contains("\"Y\":"))
                            {
                                FurList[i] = "\"Y\": " + GetCleanString(contents, "ConstForce_Y") + ",";
                            }
                            else if (line.Contains("\"Z\":"))
                            {
                                FurList[i] = "\"Z\": " + GetCleanString(contents, "ConstForce_Z");
                                State = "FindMaxForce";
                            }
                        }
                        else if (State == "FindMaxForce")
                        {
                            if (line.Contains("\"Name\": \"MaxForce\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "MaxForce") + ",";
                                State = "FindMaxForceTorqueFactor";
                            }
                        }
                        else if (State == "FindMaxForceTorqueFactor")
                        {
                            if (line.Contains("\"Name\": \"MaxForceTorqueFactor\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "MaxForceTorqueFactor") + ",";
                                State = "FindReferenceHairBias";
                            }
                        }
                        else if (State == "FindReferenceHairBias")
                        {
                            if (line.Contains("\"Name\": \"ReferenceHairBias\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "ReferenceHairBias") + ",";
                                State = "FindHairLengthForceUniformity";
                            }
                        }
                        else if (State == "FindHairLengthForceUniformity")
                        {
                            if (line.Contains("\"Name\": \"HairLengthForceUniformity\","))
                            {
                                FurList[i - 1] = "\"Value\": " + GetCleanString(contents, "HairLengthForceUniformity") + ",";
                                State = "Done";
                            }
                        }

                        if (State == "Done")
                        {
                            FurEdited = true;
                            //Fur processed
                            break;
                        }
                    }
                }
            }

            //Remove Temp files
            foreach (string filename in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\AutoMod", "*.txt"))
            {
                if (Path.GetFileName(filename).StartsWith("Temp_"))
                {
                    File.Delete(filename);
                }
            }

            string CompiledEntries = string.Empty;
            string CompiledNameMap = string.Empty;
            try
            {
                foreach (string Ent in Entries)
                {
                    CompiledEntries += Ent;
                }
                CompiledEntries = CompiledEntries.TrimEnd(',');

                foreach (string Ent in NameMap)
                {
                    CompiledNameMap += "\"" + Ent + "\"" + "," + "\n";
                }
                CompiledNameMap = CompiledNameMap.TrimEnd(',');

                ClothesOutfit = ClothesOutfit.Replace("[ENTRYSTART]", CompiledEntries);
                ClothesOutfit = ClothesOutfit.Replace("[NAMEMAPSTART]", CompiledNameMap);
                File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Debug.json", ClothesOutfit);
                dynamic ClothesArray = JsonConvert.DeserializeObject(ClothesOutfit);
                string ClothesjsonString = JsonConvert.SerializeObject(ClothesArray, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Generated.json", ClothesjsonString);
                //ClothesOutfit Done
            }
            catch (Exception ex)
            {
                return "DT_ClothesOutfit json error: " + ex.Message;
            }

            //Write DT_GameCharacterOutfits
            try
            {
                foreach (string GameChar in Characters)
                {
                    CompiledEntries = string.Empty;
                    foreach (string Ent in Outfits)
                    {
                        //Trim out the Character
                        string[] TempArray = Ent.Split('¤');
                        if (TempArray[0] == GameChar)
                        {
                            CompiledEntries += TempArray[1];
                        }
                    }
                    CompiledEntries = CompiledEntries.TrimEnd(',');

                    if (CompiledEntries == string.Empty) { GameCharacterOutfits = GameCharacterOutfits.Replace(",[" + GameChar.ToUpper() + "_OUTFITADD]", ""); }
                    else
                    {
                        CompiledEntries = CompiledEntries.Insert(0, "\n");
                        GameCharacterOutfits = GameCharacterOutfits.Replace("[" + GameChar.ToUpper() + "_OUTFITADD]", CompiledEntries);

                    }
                }

                CompiledNameMap = string.Empty;
                foreach (string Ent in OutfitsNameMap)
                {
                    CompiledNameMap += "\"" + Ent + "\"" + "," + "\n";
                }
                CompiledNameMap = CompiledNameMap.TrimEnd(',');

                GameCharacterOutfits = GameCharacterOutfits.Replace("[NAMEMAPSTART]", CompiledNameMap);
                File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Debug.json", GameCharacterOutfits);
                dynamic OutfitsArray = JsonConvert.DeserializeObject(GameCharacterOutfits);
                string OutfitsjsonString = JsonConvert.SerializeObject(OutfitsArray, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Generated.json", OutfitsjsonString);
                //Outfits Done
            }
            catch (Exception ex)
            {
                return "DT_GameCharacterOutfits json error: " + ex.Message;
            }

            try
            {
                if (CustomEdited == true)
                {
                    string CompiledHairEntries = string.Empty;
                    string CompiledSkinEntries = string.Empty;
                    string CompiledPubicHairEntries = string.Empty;
                    string CompiledEyesEntries = string.Empty;
                    string CompiledEyeLinerEntries = string.Empty;
                    string CompiledEyeShadowEntries = string.Empty;
                    string CompiledLipstickEntries = string.Empty;
                    string CompiledTanlinesEntries = string.Empty;
                    string CompiledCustomNameMap = string.Empty;
                    try
                    {
                        string GameChar = "HUMANFEMALESTANDARD";
                        foreach (string Ent in Hair)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledHairEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_HAIR]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_HAIR]", CompiledHairEntries);
                        }

                        foreach (string Ent in Skin)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledSkinEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_SKIN]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_SKIN]", CompiledSkinEntries);
                        }

                        foreach (string Ent in PubicHair)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledPubicHairEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_PUBICHAIR]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_PUBICHAIR]", CompiledPubicHairEntries);
                        }

                        foreach (string Ent in Eyes)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledEyesEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_EYES]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_EYES]", CompiledEyesEntries);
                        }

                        foreach (string Ent in EyeLiner)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledEyeLinerEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_EYELINER]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_EYELINER]", CompiledEyeLinerEntries);
                        }

                        foreach (string Ent in EyeShadow)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledEyeShadowEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_EYESHADOW]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_EYESHADOW]", CompiledEyeShadowEntries);
                        }

                        foreach (string Ent in Lipstick)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledLipstickEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_LIPSTICK]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_LIPSTICK]", CompiledLipstickEntries);
                        }

                        foreach (string Ent in Tanlines)
                        {
                            string[] TempArray = Ent.Split('¤');
                            GameChar = TempArray[0].ToUpper();
                            CompiledTanlinesEntries = "\n" + TempArray[1].TrimEnd('\n') + ",[" + GameChar + "_TANLINES]";
                            GameCharacterCustom = GameCharacterCustom.Replace("[" + GameChar + "_TANLINES]", CompiledTanlinesEntries);
                        }

                        // Remove Markers
                        foreach (string GmCh in CustomizerCharacters)
                        {
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_HAIR]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_SKIN]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_PUBICHAIR]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_EYES]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_EYELINER]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_EYESHADOW]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_LIPSTICK]", "");
                            GameCharacterCustom = GameCharacterCustom.Replace(",[" + GmCh.ToUpper() + "_TANLINES]", "");
                        }

                        foreach (string Ent in CustomNameMap)
                        {
                            CompiledCustomNameMap += "\"" + Ent + "\"" + "," + "\n";
                        }
                        CompiledCustomNameMap = CompiledCustomNameMap.TrimEnd('\n');
                        CompiledCustomNameMap = CompiledCustomNameMap.TrimEnd(',');

                        GameCharacterCustom = GameCharacterCustom.Replace("[NAMEMAPSTART]", CompiledCustomNameMap);
                        File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Debug.json", GameCharacterCustom);
                        dynamic CustomArray = JsonConvert.DeserializeObject(GameCharacterCustom);
                        string CustomjsonString = JsonConvert.SerializeObject(CustomArray, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json", CustomjsonString);
                        //Customization Done
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        return "DT_GameCharacterCustomization json error: " + ex.Message;
                    }
                }
                else
                {
                    //Skipping Customizer
                    if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json"))
                    {
                        File.Delete(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json");
                    }
                }
            }
            catch (Exception ex)
            {
                return "DT_GameCharacterCustomization json error: " + ex.Message;
            }

            try
            {
                if (FurEdited == true)
                {
                    foreach (string line in FurList)
                    {
                        stringBuilder.AppendLine(line);
                    }
                    File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Debug.json", stringBuilder.ToString());
                    dynamic CustomArray = JsonConvert.DeserializeObject(stringBuilder.ToString());
                    string CustomjsonString = JsonConvert.SerializeObject(CustomArray, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json", CustomjsonString);
                    //GFur Done
                }
                else
                {
                    //Skipping GFur
                    if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json"))
                    {
                        File.Delete(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json");
                    }
                }
            }
            catch (Exception ex)
            {
                return "DT_GFur json error: " + ex.Message;
            }
            return "Success";
        }

        private string GetCleanString(string[] contents, string txt)
        {
            foreach (string S in contents)
            {
                if (S.StartsWith(txt))
                {
                    string CleanString = S;
                    string[] TempArray = CleanString.Split(':');
                    CleanString = TempArray[1].Trim(' ');

                    return CleanString;
                }
            }
            Debug.WriteLine("ERROR: Can't find entry.");
            return "";
        }

        private string SerializeToUAsset()
        {
            ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Serializing .uassets...";
            });

            Usmap mappings = new Usmap(Application.StartupPath + @"Mappings\" + LoadedWLVersion + ".usmap");

            var DT_ClothesOutfit = new UAsset();
            try
            {
                using (var sr = new FileStream(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Generated.json", FileMode.Open))
                {
                    DT_ClothesOutfit = UAsset.DeserializeJson(sr);
                }
                DT_ClothesOutfit.Mappings = mappings;

                DT_ClothesOutfit.Write(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_ClothesOutfit.uasset");
            }
            catch (Exception ex)
            {
                return "DT_ClothesOutfit Serialization Error: " + ex.Message;
            }

            var DT_GameCharacterOutfits = new UAsset();
            try
            {
                using (var sr = new FileStream(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Generated.json", FileMode.Open))
                {
                    DT_GameCharacterOutfits = UAsset.DeserializeJson(sr);
                }
                DT_GameCharacterOutfits.Mappings = mappings;

                DT_GameCharacterOutfits.Write(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterOutfits.uasset");
            }
            catch (Exception ex)
            {
                return "DT_GameCharacterOutfits Serialization Error: " + ex.Message;
            }

            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json"))
            {
                var DT_GameCharacterCustomization = new UAsset();
                try
                {
                    using (var sr = new FileStream(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json", FileMode.Open))
                    {
                        DT_GameCharacterCustomization = UAsset.DeserializeJson(sr);
                    }
                    DT_GameCharacterCustomization.Mappings = mappings;

                    DT_GameCharacterCustomization.Write(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterCustomization.uasset");
                }
                catch (Exception ex)
                {
                    return "DT_GameCharacterCustomization Serialization Error: " + ex.Message;
                }
            }

            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json"))
            {
                var DT_GFur = new UAsset();
                try
                {
                    using (var sr = new FileStream(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json", FileMode.Open))
                    {
                        DT_GFur = UAsset.DeserializeJson(sr);
                    }
                    DT_GFur.Mappings = mappings;

                    DT_GFur.Write(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_GFur.uasset");
                }
                catch (Exception ex)
                {
                    return "DT_GFur Serialization Error: " + ex.Message;
                }
            }

            return "Success";
        }

        private string PackageAutoMod()
        {
            ProgressInfo_Label.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ProgressInfo_Label.Text = "Packaging AutoMod_P.pak...";
            });

            try
            {
                using (FileStream stream = new FileStream(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P.pak", FileMode.Create))
                {
                    var builder = new PakBuilder();
                    var pak_writer = builder.Writer(stream);
                    pak_writer.WriteFile("WildLifeC/Content/DataTables/DT_ClothesOutfit.uasset", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_ClothesOutfit.uasset"));
                    pak_writer.WriteFile("WildLifeC/Content/DataTables/DT_ClothesOutfit.uexp", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_ClothesOutfit.uexp"));
                    if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Generated.json"))
                    {
                        pak_writer.WriteFile("WildLifeC/Content/DataTables/DT_GFur.uasset", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_GFur.uasset"));
                        pak_writer.WriteFile("WildLifeC/Content/DataTables/DT_GFur.uexp", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\DT_GFur.uexp"));
                    }
                    pak_writer.WriteFile("WildLifeC/Content/DataTables/NPC/DT_GameCharacterOutfits.uasset", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterOutfits.uasset"));
                    pak_writer.WriteFile("WildLifeC/Content/DataTables/NPC/DT_GameCharacterOutfits.uexp", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterOutfits.uexp"));
                    if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Generated.json"))
                    {
                        pak_writer.WriteFile("WildLifeC/Content/DataTables/NPC/DT_GameCharacterCustomization.uasset", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterCustomization.uasset"));
                        pak_writer.WriteFile("WildLifeC/Content/DataTables/NPC/DT_GameCharacterCustomization.uexp", File.ReadAllBytes(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\AutoMod_P\WildLifeC\Content\DataTables\NPC\DT_GameCharacterCustomization.uexp"));
                    }
                    pak_writer.WriteIndex();
                }
            }
            catch (Exception ex)
            {
                return "Packaging Error: " + ex.Message;
            }

            return "Success";
        }

        private void EnableMods_Button_Click(object sender, EventArgs e)
        {
            foreach (int EntryID in Mod_Entries)
            {
                if (Mod_EnabledCB[EntryID].Enabled == true)
                {
                    Mod_EnabledCB[EntryID].Checked = true;
                }
            }
        }

        private void DisableMods_Button_Click(object sender, EventArgs e)
        {
            foreach (int EntryID in Mod_Entries)
            {
                Mod_EnabledCB[EntryID].Checked = false;
            }
        }

        private void UpdateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (UpdateLink.Tag.ToString() != "null")
                {
                    Process.Start("explorer", UpdateLink.Tag.ToString().Trim('\r'));
                }
            }
            catch
            {
                MessageBox.Show("Error: Could not open your default webbrowser.");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSession();
        }

        private void BugReportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BugReport_Panel.Show();
        }

        private void BugReport_CloseButton_Click(object sender, EventArgs e)
        {
            BugReport_Panel.Hide();
        }

        private void BugReport_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            BugReport_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void BugReport_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            BugReport_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void WildSanctum_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (WildSanctum_Link.Tag.ToString() != "null")
                {
                    Process.Start("explorer", WildSanctum_Link.Tag.ToString().Trim('\r'));
                }
            }
            catch
            {
                MessageBox.Show("Error: Could not open your default webbrowser.");
            }
        }

        private void WLMMPost_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (WLMMPost_Link.Tag.ToString() != "null")
                {
                    Process.Start("explorer", WLMMPost_Link.Tag.ToString().Trim('\r'));
                }
            }
            catch
            {
                MessageBox.Show("Error: Could not open your default webbrowser.");
            }
        }

        private void OpenWLFolder_Button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", LoadedWLPath);
        }

        private void CreateBuildLog_Button_Click(object sender, EventArgs e)
        {
            //Clear Folder
            if (Directory.Exists(Application.StartupPath + @"System\BuildLog"))
            {
                foreach (string file in Directory.EnumerateFiles(Application.StartupPath + @"System\BuildLog"))
                {
                    File.Delete(file);
                }
            }
            //Create Folder
            Directory.CreateDirectory(Application.StartupPath + @"System\BuildLog");
            //Get all Debug files
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Debug.json"))
            {
                File.Copy(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Debug.json", Application.StartupPath + @"System\BuildLog\DT_ClothesOutfit_Debug.json");
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Debug.json"))
            {
                File.Copy(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterOutfits_Debug.json", Application.StartupPath + @"System\BuildLog\DT_GameCharacterOutfits_Debug.json");
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Debug.json"))
            {
                File.Copy(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GameCharacterCustomization_Debug.json", Application.StartupPath + @"System\BuildLog\DT_GameCharacterCustomization_Debug.json");
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Debug.json"))
            {
                File.Copy(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Debug.json", Application.StartupPath + @"System\BuildLog\DT_GFur_Debug.json");
            }
            //Get Buildlog
            if (File.Exists(Application.StartupPath + @"System\LatestBuildLog.txt"))
            {
                File.Copy(Application.StartupPath + @"System\LatestBuildLog.txt", Application.StartupPath + @"System\BuildLog\LatestBuildLog.txt");
            }
            //Zip it up
            if (File.Exists(Application.StartupPath + @"System\BuildLog.zip"))
            {
                File.Delete(Application.StartupPath + @"System\BuildLog.zip");
            }
            ZipFile.CreateFromDirectory(Application.StartupPath + @"System\BuildLog", Application.StartupPath + @"System\BuildLog.zip");
            //Open folder
            Process.Start("explorer.exe", Application.StartupPath + @"System");
        }

        private void MetaDataPatcher_Button_Click(object sender, EventArgs e)
        {
            MetaDataPatcher MetaDataPatcher_Form = new MetaDataPatcher();
            MetaDataPatcher_Form.Show();
            MetaDataPatcher_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion);
        }

        private void ExpandedLink_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            ExpandedLink_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void ExpandedLink_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            ExpandedLink_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void ExpandedLink_CloseButton_Click(object sender, EventArgs e)
        {
            ExpandedLink_Panel.Hide();
        }

        private void ExpandedLink_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", ExpandedLink_LL.Text);
            ExpandedLink_Panel.Hide();
        }

        private void ExpandedLinkCopy_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(ExpandedLink_LL.Text);
            ExpandedLink_Panel.Hide();
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void BS_VerifyFI_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (StartingUp == false)
            {
                SaveBuildSettings();
            }
        }

        private void OpenBuildLog_Button_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"System\LatestBuildLog.txt"))
            {
                Process.Start("explorer.exe", Application.StartupPath + @"System\LatestBuildLog.txt");
            }
        }

        private void Marketplace_Button_Click(object sender, EventArgs e)
        {
            Marketplace Marketplace_Form = new Marketplace();
            Marketplace_Form.Show();
            Marketplace_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion, this);
        }

        private string GetUEVersion(string version)
        {
            if (File.Exists(Application.StartupPath + @"System\EngineVersions.ini"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"System\EngineVersions.ini"))
                {
                    string[] versions = GetSlice(line, "#", 1).Split("*");
                    if (versions.Length > 0)
                    {
                        foreach (string vers in versions)
                        {
                            if (version == vers)
                            {
                                return GetSlice(line, "#", 0);
                            }
                        }
                    }
                }
            }
            return "None";
        }

        private void SelectWLVersion_CB_TextChanged(object sender, EventArgs e)
        {
            // Check Engine version
            if (SelectWLVersion_CB.Text == "All Versions")
            {
                SelectWLVersionUEV_TB.Text = "All";
                return;
            }
            SelectWLVersionUEV_TB.Text = GetUEVersion(SelectWLVersion_CB.Text);
        }

        public string GetActiveModByName(string ModName)
        {
            foreach (int ModID in Mod_Entries)
            {
                if (ModName == Mod_NameLabel[ModID].Text)
                {
                    return Mod_VersionLabel[ModID].Text;
                }
            }
            return string.Empty;
        }

        private void BS_AllowOutdated_CB_CheckedChanged(object sender, EventArgs e)
        {
            foreach (int ModID in Mod_Entries)
            {
                if (BS_AllowOutdated_CB.Checked == true)
                {
                    if (Mod_EnabledCB[ModID].Enabled == false)
                    {
                        Mod_EnabledCB[ModID].Enabled = true;
                    }
                }
                else
                {
                    if (Mod_ErrorLabel[ModID].Text == "Version Mismatch")
                    {
                        Mod_EnabledCB[ModID].Enabled = false;
                    }
                }
            }
        }

        private void MarketplaceEditor_Button_Click(object sender, EventArgs e)
        {
            MarketplaceEditor MarketplaceEditor_Form = new MarketplaceEditor();
            MarketplaceEditor_Form.Show();
            MarketplaceEditor_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion);
        }

        private void TransferModsClose_Button_Click(object sender, EventArgs e)
        {
            TransferMods_Panel.Hide();
            TransferModsFromUEV_TB.Text = "None";
            TransferModsFrom_CB.Text = "Please specify version...";
            TransferModsList_LB.Items.Clear();
            TransferMods_Button.Enabled = false;
            TransferAllMods_RB.Enabled = false;
            TransferCompatMods_RB.Enabled = false;
        }

        private void TransferModsClose_Button_MouseEnter(object sender, EventArgs e)
        {
            TransferModsClose_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void TransferModsClose_Button_MouseLeave(object sender, EventArgs e)
        {
            TransferModsClose_Button.Image = Properties.Resources.Close_Icon;
        }

        private void TransferModsOpen_Button_Click(object sender, EventArgs e)
        {
            TransferMods_Panel.Show();

            // Load existing versions
            TransferModsFrom_CB.Items.Clear();
            foreach (string Vers in Directory.EnumerateDirectories(Application.StartupPath + @"Mods", "*"))
            {
                if (Path.GetFileName(Vers) != LoadedWLVersion)
                {
                    TransferModsFrom_CB.Items.Add(Path.GetFileName(Vers));
                }
            }
        }

        private void TransferModsFrom_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransferModsFromUEV_TB.Text = GetUEVersion(TransferModsFrom_CB.Text);
            TransferModsList_LB.Items.Clear();
            TransferMods_Button.Enabled = false;

            // Load all folders in Loaded
            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod") { continue; }
                TransferModsList_LB.Items.Add(ModName);
            }
            if (TransferModsList_LB.Items.Count > 0)
            {
                TransferMods_Button.Enabled = true;
                TransferAllMods_RB.Enabled = true;
                TransferCompatMods_RB.Enabled = true;
            }
        }

        private void TransferMods_Button_Click(object sender, EventArgs e)
        {
            List<string> ValidMods = new List<string>();

            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod" || TransferModsList_LB.Items.Contains(ModName) == false) { continue; }
                ValidMods.Add(ModPath);
            }

            TransferMods_Panel.Hide();
            TransferModsFromUEV_TB.Text = "None";
            TransferModsFrom_CB.Text = "Please specify version...";
            TransferModsList_LB.Items.Clear();
            TransferAllMods_RB.Checked = true;
            TransferMods_Button.Enabled = false;
            TransferAllMods_RB.Enabled = false;
            TransferCompatMods_RB.Enabled = false;

            if (ValidMods.Count > 0)
            {
                foreach (string ModPath in ValidMods)
                {
                    CopyDirectory(ModPath, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileName(ModPath));
                }
            }

            LoadMods();
        }

        private void ConflictCheck()
        {
            foreach (int ModID_X in Mod_Entries)
            {
                bool ConflictFound = false;
                foreach (int ModID_Y in Mod_Entries)
                {
                    if (ModID_X != ModID_Y)
                    {
                        foreach (string pak_X in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[ModID_X].Text + @"\Paks", "*.pak"))
                        {
                            foreach (string pak_Y in Directory.EnumerateFiles(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[ModID_Y].Text + @"\Paks", "*.pak"))
                            {
                                if (Path.GetFileName(pak_X) == Path.GetFileName(pak_Y))
                                {
                                    // Conflict Found
                                    ConflictFound = true;
                                    Mod_ErrorLabel[ModID_X].Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        Mod_ErrorLabel[ModID_X].Text = "Conflicting with: " + Mod_NameLabel[ModID_Y].Text;
                                        Mod_ErrorLabel[ModID_X].ForeColor = Color.Gold;
                                        Mod_ErrorLabel[ModID_X].Visible = true;
                                        Graphics g = CreateGraphics();
                                        SizeF LabelSize = g.MeasureString(Mod_ErrorLabel[ModID_X].Text, Mod_ErrorLabel[ModID_X].Font);
                                        Mod_ErrorLabel[ModID_X].Location = new Point(Mod_VersionLabel[ModID_X].Left - ((int)LabelSize.Width) - 5, 11);
                                    });
                                    break;
                                }
                            }
                            if (ConflictFound == true)
                            {
                                break;
                            }
                        }
                    }
                    if (ConflictFound == true)
                    {
                        break;
                    }
                }
                if (ConflictFound == false)
                {
                    Mod_ErrorLabel[ModID_X].Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        Mod_ErrorLabel[ModID_X].Visible = false;
                    });
                }
            }
        }

        private void DependenciesCheck()
        {
            foreach (int ModID_X in Mod_Entries)
            {
                bool AllDependenciesFound = true;
                string DependenciesMissing = string.Empty;

                if (Mod_Dependencies[ModID_X].Count != 0)
                {
                    foreach (string DependingOn in Mod_Dependencies[ModID_X])
                    {
                        bool CurrentDependencyFound = false;
                        foreach (int ModID_Y in Mod_Entries)
                        {
                            if (Mod_NameLabel[ModID_Y].Text == DependingOn)
                            {
                                CurrentDependencyFound = true;
                                break;
                            }
                        }
                        if (CurrentDependencyFound == false)
                        {
                            AllDependenciesFound = false;
                            DependenciesMissing += DependingOn + ", ";
                        }
                    }

                    if (AllDependenciesFound == false)
                    {
                        DependenciesMissing = DependenciesMissing.TrimEnd(' ', ',');
                        Mod_ErrorLabel[ModID_X].Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            Mod_ErrorLabel[ModID_X].Text = "Dependencies Missing: " + DependenciesMissing;
                            Mod_ErrorLabel[ModID_X].ForeColor = System.Drawing.Color.LightCoral;
                            Mod_ErrorLabel[ModID_X].Visible = true;
                            Mod_EnabledCB[ModID_X].Enabled = false;
                            Mod_EnabledCB[ModID_X].Checked = false;
                            Graphics g = CreateGraphics();
                            SizeF LabelSize = g.MeasureString(Mod_ErrorLabel[ModID_X].Text, Mod_ErrorLabel[ModID_X].Font);
                            Mod_ErrorLabel[ModID_X].Location = new Point(Mod_VersionLabel[ModID_X].Left - ((int)LabelSize.Width) - 5, 11);
                            Mod_ErrorLabel[ModID_X].BringToFront();
                        });
                    }
                    else
                    {
                        Mod_ErrorLabel[ModID_X].Visible = false;
                        Mod_EnabledCB[ModID_X].Enabled = true;
                    }
                }
            }
        }

        private void TransferAllMods_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (TransferAllMods_RB.Checked == true)
            {
                TransferModsList_LB.Items.Clear();
                TransferMods_Button.Enabled = false;

                // Load all folders in Loaded
                if (Directory.Exists(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded"))
                {
                    foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded", "*"))
                    {
                        string ModName = Path.GetFileName(ModPath);
                        if (ModName == "AutoMod") { continue; }
                        TransferModsList_LB.Items.Add(Path.GetFileNameWithoutExtension(ModName));
                    }
                    if (TransferModsList_LB.Items.Count > 0)
                    {
                        TransferMods_Button.Enabled = true;
                    }
                    else
                    {
                        TransferModsList_LB.Enabled = false;
                    }
                }
            }
        }

        private void TransferCompatMods_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (TransferCompatMods_RB.Checked == true)
            {
                TransferModsList_LB.Items.Clear();
                TransferMods_Button.Enabled = false;

                // Load all folders in Loaded
                if (Directory.Exists(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded"))
                {
                    foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded", "*"))
                    {
                        string ModName = Path.GetFileName(ModPath);
                        if (ModName == "AutoMod") { continue; }
                        //Read MetaData
                        string SupVers = string.Empty;
                        string[] MetaData = File.ReadAllLines(Application.StartupPath + @"Mods\" + TransferModsFrom_CB.Text + @"\Loaded\" + ModName + @"\Metadata.dat");
                        foreach (string meta in MetaData)
                        {
                            if (meta.StartsWith("SupportedWLVersions"))
                            {
                                SupVers = GetSlice(meta, "=", 1);
                                if (isVersionValid(SupVers))
                                {
                                    TransferModsList_LB.Items.Add(ModName);
                                    break;
                                }
                            }
                        }
                    }
                    if (TransferModsList_LB.Items.Count > 0)
                    {
                        TransferMods_Button.Enabled = true;
                    }
                    else
                    {
                        TransferModsList_LB.Enabled = false;
                    }
                }
            }
        }

        public void ReloadAffectedMod(string WLMMPath, string NewPath)
        {
            List<string> ValidMods = new List<string>();
            ValidMods.Add(WLMMPath);

            bool FoundMatch = false;
            // Load all folders in Loaded
            foreach (string ModPath in Directory.EnumerateDirectories(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded", "*"))
            {
                string ModName = Path.GetFileName(ModPath);
                if (ModName == "AutoMod") { continue; }
                //Read WLMM.dat
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\WLMM.dat"))
                {
                    if (File.ReadAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + ModName + @"\WLMM.dat") == WLMMPath)
                    {
                        // Match, reload
                        FoundMatch = true;
                        ValidMods.Clear();
                        ValidMods.Add(NewPath);
                        break;
                    }
                }
            }

            if (FoundMatch)
            {
                Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Path.GetFileNameWithoutExtension(WLMMPath), true);
                AddMods(ValidMods);
            }
        }

        private void ReloadMods_Button_Click(object sender, EventArgs e)
        {
            LoadMods();
        }

        private static bool HasMissingDLLS()
        {
            if (File.Exists(Application.StartupPath + @"Newtonsoft.Json.dll") == false)
            {
                return true;
            }
            if (File.Exists(Application.StartupPath + @"MegaApiClient.dll") == false)
            {
                return true;
            }
            if (File.Exists(Application.StartupPath + @"UAssetAPI.dll") == false)
            {
                return true;
            }
            if (File.Exists(Application.StartupPath + @"WSMM.dll") == false)
            {
                return true;
            }
            if (File.Exists(Application.StartupPath + @"ZstdSharp.dll") == false)
            {
                return true;
            }
            return false;
        }

        private void CreateMissingFolders()
        {
            if (Directory.Exists(Application.StartupPath + @"DataTables") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"DataTables");
            }
            if (Directory.Exists(Application.StartupPath + @"Mappings") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"Mappings");
            }
            if (Directory.Exists(Application.StartupPath + @"Mods") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"Mods");
            }
            if (Directory.Exists(Application.StartupPath + @"System") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"System");
            }
        }

        private void LoadEdit_CloseButton_Click(object sender, EventArgs e)
        {
            LoadEdit_Panel.Hide();
        }

        private void LoadEdit_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            LoadEdit_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void LoadEdit_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            LoadEdit_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void Load_LoadEdit(string ModPath)
        {
            LoadEdit_Paks_CLB.Items.Clear();
            LoadEdit_AutoMod_CLB.Items.Clear();

            LoadEdit_ModName_Label.Text = Path.GetFileName(ModPath);

            var LE_Content = File.ReadAllLines(ModPath + @"\LoadEdit.dat");
            foreach (string line in LE_Content)
            {
                if (line.EndsWith(".pak"))
                {
                    LoadEdit_Paks_CLB.Items.Add(line, false);
                }
                else if (line.EndsWith(".txt"))
                {
                    LoadEdit_AutoMod_CLB.Items.Add(line, false);
                }
            }

            // Check if modified LoadEdit exists
            if (File.Exists(ModPath + @"\LoadEdit_Mod.dat"))
            {
                var LE_Mod_Content = File.ReadAllLines(ModPath + @"\LoadEdit_Mod.dat");
                foreach (string line in LE_Mod_Content)
                {
                    if (line.EndsWith(".pak"))
                    {
                        for (int i = 0; i <= (LoadEdit_Paks_CLB.Items.Count - 1); i++)
                        {
                            if (line.Trim() == LoadEdit_Paks_CLB.Items[i].ToString().Trim())
                            {
                                LoadEdit_Paks_CLB.SetItemChecked(i, true);
                            }
                        }
                    }
                    else if (line.EndsWith(".txt"))
                    {
                        for (int i = 0; i <= (LoadEdit_AutoMod_CLB.Items.Count - 1); i++)
                        {
                            if (line.Trim() == LoadEdit_AutoMod_CLB.Items[i].ToString().Trim())
                            {
                                LoadEdit_AutoMod_CLB.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            else
            {
                //Enable All
                for (int i = 0; i <= (LoadEdit_Paks_CLB.Items.Count - 1); i++)
                {
                    LoadEdit_Paks_CLB.SetItemChecked(i, true);
                }
                for (int i = 0; i <= (LoadEdit_AutoMod_CLB.Items.Count - 1); i++)
                {
                    LoadEdit_AutoMod_CLB.SetItemChecked(i, true);
                }
            }
        }

        private void LoadEdit_SaveButton_Click(object sender, EventArgs e)
        {
            if (LoadEdit_Paks_CLB.CheckedItems.Count != LoadEdit_Paks_CLB.Items.Count || LoadEdit_AutoMod_CLB.CheckedItems.Count != LoadEdit_AutoMod_CLB.Items.Count)
            {
                //Is modified
                string LoadEdit_String = string.Empty;
                foreach (string pak in LoadEdit_Paks_CLB.CheckedItems)
                {
                    LoadEdit_String += pak + "\n";
                }
                foreach (string AM in LoadEdit_AutoMod_CLB.CheckedItems)
                {
                    LoadEdit_String += AM + "\n";
                }
                LoadEdit_String = LoadEdit_String.Trim();

                File.WriteAllText(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + LoadEdit_ModName_Label.Text + @"\LoadEdit_Mod.dat", LoadEdit_String);
                Mod_ContainsLabel[SelectedModID].LinkColor = Color.PaleGreen;
                Mod_ContainsLabel[SelectedModID].VisitedLinkColor = Color.PaleGreen;
                Mod_ContainsLabel[SelectedModID].ActiveLinkColor = Color.Green;
                Mod_ContainsLabel[SelectedModID].Text = "| Paks: " + LoadEdit_Paks_CLB.CheckedItems.Count.ToString() + "(" + LoadEdit_Paks_CLB.Items.Count.ToString() + ") | AutoMod: " + LoadEdit_AutoMod_CLB.CheckedItems.Count.ToString() + "(" + LoadEdit_AutoMod_CLB.Items.Count.ToString() + ") |";
                LoadEdit_Panel.Hide();

                AddChange();
            }
            else
            {
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + LoadEdit_ModName_Label.Text + @"\LoadEdit_Mod.dat"))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + LoadEdit_ModName_Label.Text + @"\LoadEdit_Mod.dat");
                }
                Mod_ContainsLabel[SelectedModID].LinkColor = System.Drawing.SystemColors.GradientActiveCaption;
                Mod_ContainsLabel[SelectedModID].VisitedLinkColor = System.Drawing.SystemColors.GradientActiveCaption;
                Mod_ContainsLabel[SelectedModID].ActiveLinkColor = System.Drawing.SystemColors.Highlight;
                Mod_ContainsLabel[SelectedModID].Text = "| Paks: " + LoadEdit_Paks_CLB.CheckedItems.Count.ToString() + " | AutoMod: " + LoadEdit_AutoMod_CLB.CheckedItems.Count.ToString() + " |";
                LoadEdit_Panel.Hide();
                AddChange();
            }
        }

        private void LaunchWL_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(LoadedWLPath + @"\WildLifeC.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("WildLifeC.exe not found in root...", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DT_Updater_DownloadButton_Click(object sender, EventArgs e)
        {
            DT_Updater_DownloadButton.Hide();
            DT_Updater_MDownloadButton.Hide();
            DT_Updater_MInstallButton.Hide();
            DT_Updater_CloseButton.Hide();
            DTDownload_Progress.Show();
            DT_Updater_ProgressLabel.Show();
            DownloadDatatables(DTLink, DTVersion);
        }

        private void DT_Updater_CloseButton_Click(object sender, EventArgs e)
        {
            DT_Updater_Panel.Hide();
            ToggleButtons(true);
        }

        private void DT_Updater_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            DT_Updater_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void DT_Updater_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            DT_Updater_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void CreateModPack_Button_Click(object sender, EventArgs e)
        {
            ModPackCreator ModPackCreator_Form = new ModPackCreator();
            ModPackCreator_Form.Show();
            ModPackCreator_Form.TransferInfo(LoadedWLPath, LoadedWLVersion, LoadedUEVersion);
        }

        private void ModPack_Close_Button_Click(object sender, EventArgs e)
        {
            ModPack_Panel.Hide();
        }

        private void ModPack_Close_Button_MouseEnter(object sender, EventArgs e)
        {
            ModPack_Close_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void ModPack_Close_Button_MouseLeave(object sender, EventArgs e)
        {
            ModPack_Close_Button.Image = Properties.Resources.Close_Icon;
        }

        private void LoadModPack()
        {
            ModPack_Panel.Show();
            ModPack_ModList_LB.Items.Clear();
            ModPack_SupVers_LB.Items.Clear();
            ModPack_KeepCurrent_RB.Checked = true;
            using (ZipArchive archive = ZipFile.OpenRead(ModPackPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries.Where(e => e.FullName == "Metadata.dat"))
                {
                    entry.ExtractToFile(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat", true);
                    break;
                }
            }
            string SupVers = string.Empty;
            string ModList = string.Empty;
            string[] MetaData = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
            foreach (string meta in MetaData)
            {
                if (meta.StartsWith("ModAuthor"))
                {
                    ModPack_Author_Label.Text = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("ModName"))
                {
                    ModPack_Name_Label.Text = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("ModDescription"))
                {
                    ModPack_Description_TB.Text = GetSlice(meta, "=", 1);
                    ModPack_Description_TB.Text = ModPack_Description_TB.Text.Replace("(nl)", "\r\n");
                }
                else if (meta.StartsWith("SupportedWLVersions"))
                {
                    SupVers = GetSlice(meta, "=", 1);
                }
                else if (meta.StartsWith("ModList"))
                {
                    ModList = GetSlice(meta, "=", 1);
                }
            }
            string[] SplitString = SupVers.Split(',');
            foreach (string vers in SplitString)
            {
                ModPack_SupVers_LB.Items.Add(vers);
            }
            SplitString = ModList.Split(',');
            foreach (string mod in SplitString)
            {
                ModPack_ModList_LB.Items.Add(mod);
            }
        }

        private void ModPack_Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleButtons(false);
                if (ModPack_DisableCurrent_RB.Checked == true)
                {
                    foreach (int EntryID in Mod_Entries)
                    {
                        Mod_EnabledCB[EntryID].Checked = false;
                    }
                }
                else if (ModPack_RemoveCurrent_RB.Checked == true)
                {
                    foreach (int EntryID in Mod_Entries)
                    {
                        //Remove the mod files
                        Directory.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text, true);
                        if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm"))
                        {
                            File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\" + Mod_NameLabel[EntryID].Text + ".wlmm");
                        }

                        Mod_Icon[EntryID].Dispose();
                        Mod_NameLabel[EntryID].Dispose();
                        Mod_ErrorLabel[EntryID].Dispose();
                        Mod_VersionLabel[EntryID].Dispose();
                        Mod_SupportedVersionsLabel[EntryID].Dispose();
                        Mod_CharactersLabel[EntryID].Dispose();
                        Mod_ContainsLabel[EntryID].Dispose();
                        Mod_AuthorLabel[EntryID].Dispose();
                        Mod_RemoveButton[EntryID].Dispose();
                        Mod_ReloadButton[EntryID].Dispose();
                        Mod_EditButton[EntryID].Dispose();
                        Mod_LinkButton[EntryID].Dispose();
                        Mod_EnabledCB[EntryID].Dispose();
                        Mod_Panel[EntryID].Dispose();
                        Mod_WLMMPath[EntryID] = string.Empty;
                        Mod_Categories[EntryID] = string.Empty;

                        AddChange();
                    }
                    Mod_Entries.Clear();
                    Mod_CurrentEntryID = 0;

                    //Clear Cats
                    foreach (int EntryID in Cat_Entries)
                    {
                        Cat_Button[EntryID].Dispose();
                        Cat_Flow[EntryID].Dispose();
                    }
                    Cat_Entries.Clear();
                    Cat_CurrentEntryID = 0;
                }

                ZipFile.ExtractToDirectory(ModPackPath, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded");
                File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Loaded\Metadata.dat");

                ToggleButtons(true);
                ModPack_Panel.Hide();
                LoadMods();
                MessageBox.Show("Mod Pack added successfully.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding modpack.\nEx: " + ex.Message.ToString(), "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MM_CloseButton_Click(object sender, EventArgs e)
        {
            MM_Panel.Hide();
        }

        private void MM_CloseButton_MouseEnter(object sender, EventArgs e)
        {
            MM_CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void MM_CloseButton_MouseLeave(object sender, EventArgs e)
        {
            MM_CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void DT_Updater_MInstallButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog3.FileName) && Path.GetFileName(openFileDialog3.FileName).StartsWith("WLMM_DT_"))
                {
                    InstallDatatables(openFileDialog3.FileName, DTVersion);
                }
            }
        }

        private void DT_Updater_MDownloadButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", DTLink.Trim('\r'));
        }

        private void InstallDatatables(string filename, string version)
        {
            bool Valid = true;
            string DTName = Path.GetFileNameWithoutExtension(filename);
            ZipFile.ExtractToDirectory(filename, Application.StartupPath + @"Temp\" + DTName, true);

            // Replace System\SupportedVersions.ini
            if (File.Exists(Application.StartupPath + @"Temp\" + DTName + @"\System\SupportedVersions.ini"))
            {
                File.Copy(Application.StartupPath + @"Temp\" + DTName + @"\System\SupportedVersions.ini", Application.StartupPath + @"System\SupportedVersions.ini", true);
            }
            else
            {
                Valid = false;
            }

            // Replace System\EngineVersions.ini
            if (File.Exists(Application.StartupPath + @"Temp\" + DTName + @"\System\EngineVersions.ini"))
            {
                File.Copy(Application.StartupPath + @"Temp\" + DTName + @"\System\EngineVersions.ini", Application.StartupPath + @"System\EngineVersions.ini", true);
            }
            else
            {
                Valid = false;
            }

            // Replace System\Categories.ini
            if (File.Exists(Application.StartupPath + @"Temp\" + DTName + @"\System\Categories.ini"))
            {
                File.Copy(Application.StartupPath + @"Temp\" + DTName + @"\System\Categories.ini", Application.StartupPath + @"System\Categories.ini", true);
            }
            else
            {
                Valid = false;
            }

            if (Valid)
            {
                // Copy/Replace Mappings
                foreach (string mapping in Directory.EnumerateFiles(Application.StartupPath + @"Temp\" + DTName + @"\Mappings", "*.usmap"))
                {
                    File.Copy(mapping, Application.StartupPath + @"Mappings\" + Path.GetFileName(mapping), true);
                }
                // Copy/Replace DataTables
                foreach (string DTS in Directory.EnumerateDirectories(Application.StartupPath + @"Temp\" + DTName + @"\DataTables", "*"))
                {
                    CopyDirectory(DTS, Application.StartupPath + @"DataTables\" + Path.GetFileName(DTS));
                }
            }
            
            // Remove Temp Files
            Directory.Delete(Application.StartupPath + @"Temp", true);
            if (Valid)
            {
                // Update DatatableVersion.ini
                File.WriteAllText(Application.StartupPath + @"System\DatatableVersion.ini", version);
                LoadSupportedVersions();
                LoadCategories();

                DT_Updater_Panel.Hide();
                MessageBox.Show("DataTables updated!", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToggleButtons(true);
            }
            else
            {
                MessageBox.Show("DataTable updated failed.", "Wild Life Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleButtons(false);
            }
        }
    }
}
