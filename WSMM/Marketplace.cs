using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using System.Text.Json;
using System.Reflection.Emit;
using System.Diagnostics.Eventing.Reader;

namespace WSMM
{
    public partial class Marketplace : Form
    {
        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        private bool mouseDown = false;
        private Point lastLocation;

        private List<string> MarketplaceMods = new List<string>();
        private Dictionary<string, int> ModDownloadsDict = new Dictionary<string, int>();

        Panel[] Mod_Panel = new Panel[100];
        PictureBox[] Mod_Icon = new PictureBox[100];
        PictureBox[] Mod_DLIcon = new PictureBox[100];
        LinkLabel[] Mod_NameLabel = new LinkLabel[100];
        System.Windows.Forms.Label[] Mod_VersionLabel = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] Mod_SupportedVersionsLabel = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] Mod_AuthorLabel = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] Mod_InfoLabel = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] Mod_DownloadsLabel = new System.Windows.Forms.Label[100];
        string[] Mod_Category = new string[100];

        List<int> Mod_Entries = new List<int>();
        int Mod_CurrentEntryID = 0;

        private List<string> LoadedModScreenshots = new List<string>();
        private int CurrentScreenshot = 0;

        public Main Main_Form = null;

        string CurrentlyDownloadingModName = string.Empty;

        private DateTime startTime;
        private DateTime lastProgressUpdateTime;
        private long lastProgressUpdateBytes;

        private int DownloadsRemaining = 50;

        public Marketplace()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, string UEV, bool DelAfterDl, Main MainForm)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
            DeleteAfterDownload_CB.Checked = DelAfterDl;
            Main_Form = MainForm;

            Filter_CB.Items.Clear();
            Filter_CB.Items.Add("Latest");
            Filter_CB.Items.Add("Most Popular");
            Filter_CB.Items.AddRange(Main_Form.Categories_List.ToArray());

            GetMarketplaceMods();
        }

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            string[] TempArray = Txt.Split(Delimiter);
            if (slice == 999)
            {
                return TempArray[TempArray.Length - 1].Trim();
            }
            else
            {
                return TempArray[slice].Trim();
            }
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

        private void Marketplace_Load(object sender, EventArgs e)
        {

        }

        private void RefreshMods_Button_Click(object sender, EventArgs e)
        {
            ModDownloadsDict.Clear();
            GetMarketplaceMods();
        }

        private async void GetMarketplaceMods()
        {
            RefreshDelay.Start();
            RefreshMods_Button.Enabled = false;
            MarketplaceMods.Clear();
            try
            {
                string VersionInfo = "";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("WildLifeModManager");
                    HttpResponseMessage response = await client.GetAsync("https://gist.githubusercontent.com/Lucky-ImF/cb6aa813b89cb5f73708a487968efeac/raw/WLMM_Marketplace_Data.txt");
                    response.EnsureSuccessStatusCode();
                    VersionInfo = await response.Content.ReadAsStringAsync();
                }
                string Decompressed_MP_Data = DecompressString(VersionInfo);

                string[] TempArray = Decompressed_MP_Data.Split('\r');
                foreach (string temp in TempArray)
                {
                    MarketplaceMods.Add(temp.Trim('\n'));
                }
                LastUpdate_Label.Text = DateAndTime.Now.ToString();
                LastUpdate_Label.ForeColor = SystemColors.ActiveCaption;
            }
            catch (Exception ex)
            {
                LastUpdate_Label.Text = "Unable to connect to Marketplace...";
                LastUpdate_Label.ForeColor = Color.LightCoral;
                NoModsFound_Label.Show();
                MessageBox.Show(ex.Message, "WLMM Marketplace Error");
            }
            LoadMarketplaceMods();
        }
        public class ModJson
        {
            public string ModName { get; set; }
            public int ModDownloads { get; set; }
        }
        private async void GetAllDownloadAmounts()
        {
            if (ModDownloadsDict.Count == 0)
            {
                try
                {
                    string ModInfo = "";

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("WLMM");
                        HttpResponseMessage response = await client.GetAsync("https://wlmm-worker.luckybot.one/?action=ALL&modName=ALL");
                        response.EnsureSuccessStatusCode();
                        ModInfo = await response.Content.ReadAsStringAsync();
                    }
                    List<ModJson> mods = JsonSerializer.Deserialize<List<ModJson>>(ModInfo);

                    foreach (ModJson mod in mods)
                    {
                        ModDownloadsDict.Add(mod.ModName, mod.ModDownloads);
                    }

                    foreach (int ModID in Mod_Entries)
                    {
                        if (ModDownloadsDict.ContainsKey(Mod_NameLabel[ModID].Text.Replace(" ", "_")))
                        {
                            Mod_DownloadsLabel[ModID].Text = Mod_DownloadsLabel[ModID].Text.Replace("?", ModDownloadsDict.GetValueOrDefault(Mod_NameLabel[ModID].Text.Replace(" ", "_")).ToString());
                        }
                        else
                        {
                            Mod_DownloadsLabel[ModID].Text = Mod_DownloadsLabel[ModID].Text.Replace("?", "0");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                foreach (int ModID in Mod_Entries)
                {
                    if (ModDownloadsDict.ContainsKey(Mod_NameLabel[ModID].Text.Replace(" ", "_")))
                    {
                        Mod_DownloadsLabel[ModID].Text = Mod_DownloadsLabel[ModID].Text.Replace("?", ModDownloadsDict.GetValueOrDefault(Mod_NameLabel[ModID].Text.Replace(" ", "_")).ToString());
                    }
                    else
                    {
                        Mod_DownloadsLabel[ModID].Text = Mod_DownloadsLabel[ModID].Text.Replace("?", "0");
                    }
                }
            }
        }
        public static string DecompressString(string compressedString)
        {
            byte[] decompressedBytes;

            var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString));

            using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    decompressorStream.CopyTo(decompressedStream);

                    decompressedBytes = decompressedStream.ToArray();
                }
            }

            return Encoding.UTF8.GetString(decompressedBytes);
        }

        private void CloseModPanel_Button_Click(object sender, EventArgs e)
        {
            ModPanel_Panel.Hide();
        }

        private void CloseModPanel_Button_MouseEnter(object sender, EventArgs e)
        {
            CloseModPanel_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void CloseModPanel_Button_MouseLeave(object sender, EventArgs e)
        {
            CloseModPanel_Button.Image = Properties.Resources.Close_Icon;
        }

        private void LoadMarketplaceMods()
        {
            ModFlow_Panel.Controls.Clear();
            Mod_Entries.Clear();
            Mod_CurrentEntryID = 0;

            if (MarketplaceMods.Count > 0)
            {
                NoModsFound_Label.Hide();
                foreach (string entry in MarketplaceMods)
                {
                    CreateModEntry(entry);
                }
            }

            if (Mod_CurrentEntryID == 0)
            {
                NoModsFound_Label.Show();
            }
            else
            {
                NoModsFound_Label.Hide();
            }
            GetAllDownloadAmounts();
            ApplyFilter();
        }

        private void CreateModEntry(string ModString)
        {
            if (Mod_CurrentEntryID >= 101)
            {
                return;
            }
            string ModName = string.Empty;
            string ModAuthor = string.Empty;
            string ModVersion = string.Empty;
            string SupportedVersions = string.Empty;
            string ModURL = string.Empty;
            string ModIcon = string.Empty;
            string ModSize = string.Empty;
            string Category = string.Empty;
            string LastUpdate = string.Empty;
            string ModDescription = string.Empty;
            string ModDownloadLink = string.Empty;
            string ModScreenshots = string.Empty;

            //Read MetaData
            string[] MetaData = ModString.Split(",");
            foreach (string meta in MetaData)
            {
                if (meta.StartsWith("ModAuthor"))
                {
                    ModAuthor = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModVersion"))
                {
                    ModVersion = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("SupportedVersions"))
                {
                    SupportedVersions = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                    SupportedVersions = SupportedVersions.Replace("*", ", ");
                }
                else if (meta.StartsWith("ModLink"))
                {
                    ModURL = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModName"))
                {
                    ModName = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModSize"))
                {
                    ModSize = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModIcon"))
                {
                    ModIcon = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("Category"))
                {
                    Category = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("LastUpdate"))
                {
                    LastUpdate = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModDescription"))
                {
                    ModDescription = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("DownloadLink"))
                {
                    ModDownloadLink = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("Screenshots"))
                {
                    ModScreenshots = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
            }

            if (isVersionValid(SupportedVersions) == false)
            {
                return;
            }

            int EntryID = Mod_CurrentEntryID;
            //Panel[] Mod_Panel = new Panel[50];
            Mod_Panel[EntryID] = new Panel();
            Mod_Panel[EntryID].Size = new System.Drawing.Size(265, 315);
            Mod_Panel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Panel[EntryID].BorderStyle = BorderStyle.FixedSingle;
            //PictureBox[] Mod_Icon = new PictureBox[50];
            Mod_Icon[EntryID] = new PictureBox();
            Mod_Icon[EntryID].Size = new System.Drawing.Size(256, 230);
            Mod_Icon[EntryID].Location = new Point(2, 2);
            Mod_Icon[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Icon[EntryID].BorderStyle = BorderStyle.None;
            Mod_Icon[EntryID].SizeMode = PictureBoxSizeMode.Zoom;
            Mod_Icon[EntryID].ImageLocation = ModIcon;
            Mod_Icon[EntryID].Tag = ModString;
            Mod_Icon[EntryID].Click += Mod_Icon_Click;
            Mod_Icon[EntryID].Cursor = Cursors.Hand;

            //Label[] Mod_NameLabel = new Label[50];
            Mod_NameLabel[EntryID] = new LinkLabel();
            Mod_NameLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_NameLabel[EntryID].LinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_NameLabel[EntryID].VisitedLinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_NameLabel[EntryID].ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            Mod_NameLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 16);
            Mod_NameLabel[EntryID].Text = ModName;
            Mod_NameLabel[EntryID].AutoSize = false;
            Mod_NameLabel[EntryID].AutoEllipsis = true;
            Mod_NameLabel[EntryID].TextAlign = ContentAlignment.MiddleCenter;
            Mod_NameLabel[EntryID].Location = new Point(2, 232);
            Mod_NameLabel[EntryID].Size = new Size(256, 30);
            Mod_NameLabel[EntryID].Tag = ModString;
            Mod_NameLabel[EntryID].Click += Mod_NameLabel_Click;
            //Label[] Mod_VersionLabel = new Label[50];
            Mod_VersionLabel[EntryID] = new System.Windows.Forms.Label();
            Mod_VersionLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_VersionLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_VersionLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 16);
            Mod_VersionLabel[EntryID].Text = ModVersion;
            Mod_VersionLabel[EntryID].AutoSize = false;
            Mod_VersionLabel[EntryID].Size = new Size(81, 28);
            Mod_VersionLabel[EntryID].TextAlign = ContentAlignment.MiddleRight;
            Graphics g = CreateGraphics();
            SizeF LabelSize = g.MeasureString(Mod_VersionLabel[EntryID].Text, Mod_VersionLabel[EntryID].Font);
            Mod_VersionLabel[EntryID].Location = new Point(177, 283);
            //Label[] Mod_AuthorLabel = new Label[50];
            Mod_AuthorLabel[EntryID] = new System.Windows.Forms.Label();
            Mod_AuthorLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_AuthorLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_AuthorLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
            Mod_AuthorLabel[EntryID].Text = "By: " + ModAuthor;
            Mod_AuthorLabel[EntryID].AutoSize = false;
            Mod_AuthorLabel[EntryID].AutoEllipsis = true;
            Mod_AuthorLabel[EntryID].TextAlign = ContentAlignment.MiddleCenter;
            Mod_AuthorLabel[EntryID].Size = new Size(256, 21);
            Mod_AuthorLabel[EntryID].Location = new Point(2, 262);
            //Label[] Mod_InfoLabel = new Label[50];
            Mod_InfoLabel[EntryID] = new System.Windows.Forms.Label();
            Mod_InfoLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_InfoLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_InfoLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
            //PictureBox[] Mod_DLIcon = new PictureBox[50];
            Mod_DLIcon[EntryID] = new PictureBox();
            Mod_DLIcon[EntryID].Size = new System.Drawing.Size(24, 24);
            Mod_DLIcon[EntryID].Location = new Point(4, Mod_Panel[EntryID].Size.Height - 28);
            Mod_DLIcon[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_DLIcon[EntryID].BorderStyle = BorderStyle.None;
            Mod_DLIcon[EntryID].SizeMode = PictureBoxSizeMode.Zoom;
            Mod_DLIcon[EntryID].Image = Properties.Resources.Download_Icon;
            //Label[] Mod_DownloadsLabel = new Label[50];
            Mod_DownloadsLabel[EntryID] = new System.Windows.Forms.Label();
            Mod_DownloadsLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_DownloadsLabel[EntryID].ForeColor = System.Drawing.Color.FromArgb(192, 255, 255);
            Mod_DownloadsLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 14);
            Mod_DownloadsLabel[EntryID].Text = "?";
            Mod_DownloadsLabel[EntryID].AutoSize = true;
            Mod_DownloadsLabel[EntryID].Location = new Point(30, Mod_Panel[EntryID].Size.Height - 30);
            // Check if this mod is in active mods
            string ActiveModVersion = Main_Form.GetActiveModByName(ModName);
            if (ActiveModVersion == ModVersion)
            {
                Mod_InfoLabel[EntryID].Text = "[Downloaded]";
            }
            else if (ActiveModVersion != ModVersion && ActiveModVersion != string.Empty)
            {
                Mod_InfoLabel[EntryID].Text = "[Update Available]";
                Mod_InfoLabel[EntryID].ForeColor = Color.OliveDrab;
            }
            else
            {
                Mod_InfoLabel[EntryID].Text = "";
                Mod_InfoLabel[EntryID].Visible = false;
            }
            Mod_InfoLabel[EntryID].AutoSize = true;
            LabelSize = g.MeasureString(Mod_InfoLabel[EntryID].Text, Mod_InfoLabel[EntryID].Font);
            Mod_InfoLabel[EntryID].Location = new Point(Mod_Panel[EntryID].Size.Width / 2 - ((int)LabelSize.Width / 2), 3);

            Mod_Panel[EntryID].Controls.Add(Mod_Icon[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_NameLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_VersionLabel[EntryID]);
            //Mod_Panel[EntryID].Controls.Add(Mod_SupportedVersionsLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_AuthorLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_InfoLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_DLIcon[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_DownloadsLabel[EntryID]);
            Mod_InfoLabel[EntryID].BringToFront();

            Mod_Category[EntryID] = Category;

            ModFlow_Panel.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                ModFlow_Panel.Controls.Add(Mod_Panel[EntryID]);
                Mod_Entries.Add(EntryID);
                Mod_CurrentEntryID += 1;
            });
        }

        private void Mod_NameLabel_Click(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            OpenMod(Casted.Tag.ToString());
        }

        private void Mod_Icon_Click(object sender, EventArgs e)
        {
            PictureBox Casted = sender as PictureBox;
            OpenMod(Casted.Tag.ToString());
        }

        private bool isVersionValid(string Supported)
        {
            if (Supported.Contains(LoadedWLVersion) || Supported.Contains("All Versions") || Supported.Contains(LoadedUEVersion))
            {
                return true;
            }
            else { return false; }
        }

        private async void GetDownloadAmount(string ModName)
        {
            ModName = ModName.Replace(" ", "_");
            try
            {
                string ModInfo = "";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("WLMM");
                    HttpResponseMessage response = await client.GetAsync("https://wlmm-worker.luckybot.one/?action=GET&" + "modName=" + ModName);
                    response.EnsureSuccessStatusCode();
                    ModInfo = await response.Content.ReadAsStringAsync();
                }
                Debug.WriteLine(ModInfo);
                ModFileSize_Label.Text += GetSlice(ModInfo, ":", 999).TrimEnd('}');
            }
            catch (Exception ex)
            {
                ModFileSize_Label.Text += "0";
            }
        }

        private async void IncrementDownloadAmount(string ModName)
        {
            ModName = ModName.Replace(" ", "_");
            if (ModDownloadsDict.ContainsKey(ModName))
            {
                ModDownloadsDict[ModName] += 1;
            }
            else
            {
                ModDownloadsDict.Add(ModName, 1);
            }
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("WLMM");
                    HttpResponseMessage response = await client.GetAsync("https://wlmm-worker.luckybot.one/?action=DL&" + "modName=" + ModName);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "WLMM DATABASE Error");
            }
        }

        private void OpenMod(string ModString)
        {
            ModPanel_Panel.Show();
            NextScreenshot_Button.Enabled = false;
            PreviousScreenshot_Button.Enabled = false;

            string ModName = string.Empty;
            string ModAuthor = string.Empty;
            string ModVersion = string.Empty;
            string SupportedVersions = string.Empty;
            string ModURL = string.Empty;
            string ModIcon = string.Empty;
            string ModSize = string.Empty;
            string Category = string.Empty;
            string Characters = string.Empty;
            string LastUpdate = string.Empty;
            string ModDescription = string.Empty;
            string ModDownloadLink = string.Empty;
            string ModScreenshots = string.Empty;

            //Read MetaData
            string[] MetaData = ModString.Split(",");
            foreach (string meta in MetaData)
            {
                if (meta.StartsWith("ModAuthor"))
                {
                    ModAuthor = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModVersion"))
                {
                    ModVersion = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("SupportedVersions"))
                {
                    SupportedVersions = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModLink"))
                {
                    ModURL = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModName"))
                {
                    ModName = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModSize"))
                {
                    ModSize = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModIcon"))
                {
                    ModIcon = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("Category"))
                {
                    Category = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("LastUpdate"))
                {
                    LastUpdate = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("ModDescription"))
                {
                    ModDescription = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                    ModDescription = ModDescription.Replace("(nl)", "\r\n");
                }
                else if (meta.StartsWith("DownloadLink"))
                {
                    ModDownloadLink = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("Screenshots"))
                {
                    ModScreenshots = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
                else if (meta.StartsWith("Characters"))
                {
                    Characters = meta.Replace(GetSlice(meta, ":", 0) + ":", "");
                }
            }

            ModName_Label.Text = ModName;
            ModAuthor_Label.Text = ModAuthor;
            ModVersion_Label.Text = ModVersion;
            SupportedVersions_Label.Text = SupportedVersions.Replace("*", ", ");
            Characters_Label.Text = Characters.Replace("*", ", ");
            Categories_Label.Text = Category.Replace("*", ", ");
            ModLink_LL.Text = ModURL;
            ModDescription_TB.Text = ModDescription;
            Screenshot.ImageLocation = ModIcon;
            ModLastUpdate_Label.Text = "Last Update: " + LastUpdate;
            ModFileSize_Label.Text = "Size: " + ModSize + " | Downloads: " + ModDownloadsDict.GetValueOrDefault(ModName.Replace(" ", "_")).ToString();
            DownloadMod_Button.Tag = ModDownloadLink;
            DownloadMod_Button.Text = "Download";

            LoadedModScreenshots.Clear();
            LoadedModScreenshots.Add(ModIcon);
            string[] Screens = ModScreenshots.Split("*");
            foreach (string s in Screens)
            {
                if (s != string.Empty)
                {
                    LoadedModScreenshots.Add(s);
                    NextScreenshot_Button.Enabled = true;
                }
            }

            // Check if this mod is in active mods
            string ActiveModVersion = Main_Form.GetActiveModByName(ModName);
            if (ActiveModVersion == ModVersion)
            {
                DownloadMod_Button.Text = "Repair";
            }
            else if (ActiveModVersion != ModVersion && ActiveModVersion != string.Empty)
            {
                DownloadMod_Button.Text = "Update";
            }
        }

        private void DownloadMod_Button_Click(object sender, EventArgs e)
        {
            if (DownloadMod_Button.Text != "Mod Downloaded!")
            {
                if (DownloadsRemaining <= 0)
                {
                    MessageBox.Show("You have reached the download limit for this session. Please try again later.", "Download Limit Reached");
                    return;
                }
                DownloadMod_Button.Hide();
                ModFileSize_Label.Hide();
                ProgressInfo_Label.Show();
                ProgressDetails_Label.Show();
                DownloadProgress_PB.Show();
                DownloadProgress_PB.Value = 0;
                CloseModPanel_Button.Enabled = false;
                Close_Button.Enabled = false;
                DownloadFile(DownloadMod_Button.Tag.ToString(), ModName_Label.Text);
            }
        }

        async void DownloadFile(string link, string ModName)
        {
            try
            {
                if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads") == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads");
                }

                Uri fileLink = new Uri(link);

                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + ModName + ".wlmm"))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + ModName + ".wlmm");
                }

                ProgressInfo_Label.Text = "Downloading... 0%";
                DownloadProgress_PB.Value = 0;
                CurrentlyDownloadingModName = ModName;

                startTime = DateTime.Now;
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    wc.Headers.Add("User-Agent: WLMM");
                    wc.DownloadProgressChanged += MP_DownloadProgressChanged;
                    wc.DownloadFileAsync(fileLink, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + ModName + ".wlmm");
                }
            }
            catch (Exception ex)
            {
                DownloadMod_Button.Show();
                DownloadMod_Button.Text = "Download";
                ModFileSize_Label.Show();
                ProgressInfo_Label.Hide();
                ProgressInfo_Label.Text = "Initializing...";
                ProgressDetails_Label.Hide();
                ProgressDetails_Label.Text = "Speed: 0 B/s | 0 B / 0 B | Time Left: 00:00:00";
                DownloadProgress_PB.Hide();
                DownloadProgress_PB.Value = 0;
                CloseModPanel_Button.Enabled = true;
                Close_Button.Enabled = true;

                MessageBox.Show(ex.Message, "WLMM Download Error");
                LoadMarketplaceMods();
            }
        }

        void MP_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = e.BytesReceived;
            double totalBytes = e.TotalBytesToReceive;
            double percentage = bytesIn / totalBytes * 100;

            string DLSpeed = string.Empty;
            string DLCurrent = string.Empty;
            string DLTimeLeft = string.Empty;

            DownloadProgress_PB.Value = (int)Math.Truncate(percentage);

            // Calculate download speed
            DateTime now = DateTime.Now;
            TimeSpan timeElapsed = now - lastProgressUpdateTime;

            if (timeElapsed.TotalMilliseconds > 250)
            {
                long bytesSinceLastUpdate = e.BytesReceived - lastProgressUpdateBytes;
                double speedInBytesPerSecond = bytesSinceLastUpdate / timeElapsed.TotalSeconds;

                if (speedInBytesPerSecond < 0)
                {
                    speedInBytesPerSecond = 0;
                }

                DLSpeed = FormatBytes(speedInBytesPerSecond) + "/s";

                DLCurrent = string.Format("{0} / {1}", FormatBytes(bytesIn), FormatBytes(totalBytes));

                // Calculate time left
                if (e.BytesReceived > 0 && e.BytesReceived < e.TotalBytesToReceive)
                {
                    double downloadRate = bytesIn / (DateTime.Now - startTime).TotalSeconds;
                    double remainingBytes = totalBytes - bytesIn;
                    double timeLeftInSeconds = remainingBytes / downloadRate;

                    if (timeLeftInSeconds > 0)
                    {
                        TimeSpan timeLeft = TimeSpan.FromSeconds(timeLeftInSeconds);

                        // Display time left
                        DLTimeLeft = string.Format("{0:D2}:{1:D2}:{2:D2}", timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);
                    }
                }

                ProgressDetails_Label.Text = "Speed: " + DLSpeed + " | " + DLCurrent + " | Time Left: " + DLTimeLeft;

                lastProgressUpdateTime = now;
                lastProgressUpdateBytes = e.BytesReceived;
            }

            ProgressInfo_Label.Text = "Downloading... " + (string)Math.Truncate(percentage).ToString() + "%";


            if (DownloadProgress_PB.Value == 100)
            {
                ProgressInfo_Label.Text = "Extracting Mod...";
                ProgressDetails_Label.Text = "Almost there.";
                DownloadProgress_PB.Value = 100;
                Application.DoEvents();
                try
                {
                    Thread.Sleep(500); //Potential crash fix
                    //Add Mod to active mods
                    List<string> mods = new List<string>();
                    mods.Add(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + CurrentlyDownloadingModName + ".wlmm");
                    Main_Form.AddMods(mods);

                    if (DeleteAfterDownload_CB.Checked == true)
                    {
                        File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + CurrentlyDownloadingModName + ".wlmm");
                        Main_Form.LoadMods();
                    }

                    DownloadMod_Button.Show();
                    DownloadMod_Button.Text = "Mod Downloaded!";
                    ModFileSize_Label.Show();
                    ProgressInfo_Label.Hide();
                    ProgressInfo_Label.Text = "Initializing...";
                    ProgressDetails_Label.Hide();
                    ProgressDetails_Label.Text = "Speed: 0 B/s | 0 B / 0 B | Time Left: 00:00:00";
                    DownloadProgress_PB.Hide();
                    DownloadProgress_PB.Value = 0;
                    CloseModPanel_Button.Enabled = true;
                    Close_Button.Enabled = true;

                    DownloadsRemaining -= 1;

                    IncrementDownloadAmount(CurrentlyDownloadingModName);
                    ModFileSize_Label.Text = GetSlice(ModFileSize_Label.Text, "|", 0) + " | Downloads: " + ModDownloadsDict.GetValueOrDefault(CurrentlyDownloadingModName.Replace(" ", "_")).ToString();

                    LoadMarketplaceMods();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "WLMM Download Error");
                }
            }
        }

        string FormatBytes(double bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            while (bytes >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                bytes /= 1024;
                suffixIndex++;
            }

            return string.Format("{0:0.##} {1}", bytes, suffixes[suffixIndex]);
        }

        private void RefreshDelay_Tick(object sender, EventArgs e)
        {
            RefreshMods_Button.Enabled = true;
            RefreshDelay.Stop();
        }

        private void ModLink_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", ModLink_LL.Text);
        }

        private void NextScreenshot_Button_Click(object sender, EventArgs e)
        {
            CurrentScreenshot++;
            Screenshot.ImageLocation = LoadedModScreenshots[CurrentScreenshot];

            if (CurrentScreenshot >= LoadedModScreenshots.Count - 1)
            {
                NextScreenshot_Button.Enabled = false;
            }
            PreviousScreenshot_Button.Enabled = true;
        }

        private void PreviousScreenshot_Button_Click(object sender, EventArgs e)
        {
            CurrentScreenshot--;
            Screenshot.ImageLocation = LoadedModScreenshots[CurrentScreenshot];

            if (CurrentScreenshot == 0)
            {
                PreviousScreenshot_Button.Enabled = false;
            }
            NextScreenshot_Button.Enabled = true;
        }

        private void Filter_CB_TextChanged(object sender, EventArgs e)
        {
            //LoadMarketplaceMods();
            if (Filter_CB.Text == "Latest")
            {
                LoadMarketplaceMods();
            }
            else
            {
                ApplyFilter();
            } 
        }

        private void ApplyFilter()
        {
            Dictionary<int, int> UnsortedDict = new Dictionary<int, int>();
            foreach (int ModID in Mod_Entries)
            {
                if (Filter_CB.Text == "Most Popular")
                {
                    UnsortedDict.Add(ModID, ModDownloadsDict.GetValueOrDefault(Mod_NameLabel[ModID].Text.Replace(" ", "_")));
                }
                else
                {
                    if (Mod_Category[ModID].Contains(Filter_CB.Text) && Mod_NameLabel[ModID].Text.ToLower().Contains(Search_TB.Text.ToLower()))
                    {
                        Mod_Panel[ModID].Show();
                    }
                    else if (Filter_CB.Text == "Latest" && Mod_NameLabel[ModID].Text.ToLower().Contains(Search_TB.Text.ToLower()))
                    {
                        Mod_Panel[ModID].Show();
                    }
                    else
                    {
                        Mod_Panel[ModID].Hide();
                    }
                }
            }
            if (Filter_CB.Text == "Most Popular")
            {
                ModFlow_Panel.Controls.Clear();
                foreach (KeyValuePair<int, int> entry in UnsortedDict.OrderByDescending(key => key.Value))
                {
                    ModFlow_Panel.Controls.Add(Mod_Panel[entry.Key]);
                    Mod_Panel[entry.Key].Show();
                }
            }
        }

        private void Search_TB_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void Screenshot_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Screenshot.ImageLocation);
        }

        private void Screenshot_MouseEnter(object sender, EventArgs e)
        {
            Screenshot_HoverLabel.Show();
        }

        private void Screenshot_MouseLeave(object sender, EventArgs e)
        {
            Screenshot_HoverLabel.Hide();
        }

        private void DeleteAfterDownload_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form is not null)
            {
                Main_Form.DeleteWLMMAfterDownload = DeleteAfterDownload_CB.Checked;
            }
        }
    }
}
