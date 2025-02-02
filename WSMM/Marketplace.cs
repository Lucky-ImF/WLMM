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
using CG.Web.MegaApiClient;
using System.IO.Compression;

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

        Panel[] Mod_Panel = new Panel[100];
        PictureBox[] Mod_Icon = new PictureBox[100];
        LinkLabel[] Mod_NameLabel = new LinkLabel[100];
        Label[] Mod_VersionLabel = new Label[100];
        Label[] Mod_SupportedVersionsLabel = new Label[100];
        Label[] Mod_AuthorLabel = new Label[100];
        Label[] Mod_InfoLabel = new Label[100];
        string[] Mod_Category = new string[100];

        List<int> Mod_Entries = new List<int>();
        int Mod_CurrentEntryID = 0;

        private List<string> LoadedModScreenshots = new List<string>();
        private int CurrentScreenshot = 0;

        public Main Main_Form = null;

        public Marketplace()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, string UEV, Main MainForm)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
            Main_Form = MainForm;

            GetMarketplaceMods();
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

        private void Marketplace_Load(object sender, EventArgs e)
        {
            //GetMarketplaceMods();
        }

        private void RefreshMods_Button_Click(object sender, EventArgs e)
        {
            GetMarketplaceMods();
        }

        private void GetMarketplaceMods()
        {
            RefreshDelay.Start();
            RefreshMods_Button.Enabled = false;
            MarketplaceMods.Clear();
            try
            {
                string VersionInfo = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pastebin.com/raw/iZSuG0WY");
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                request.ContentType = "application/json; charset=utf-8";
                request.UserAgent = "WildLifeModManager";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    readStream = new StreamReader(receiveStream);

                    VersionInfo = readStream.ReadToEnd();

                    response.Dispose();
                    readStream.Dispose();
                }

                string[] TempArray = VersionInfo.Split('\r');
                foreach (string temp in TempArray)
                {
                    MarketplaceMods.Add(temp.Trim('\n'));
                }
                LastUpdate_Label.Text = DateAndTime.Now.ToString();
                LastUpdate_Label.ForeColor = SystemColors.ActiveCaption;
            }
            catch (Exception)
            {
                LastUpdate_Label.Text = "Unable to connect to Marketplace...";
                LastUpdate_Label.ForeColor = Color.LightCoral;
                NoModsFound_Label.Show();
            }
            LoadMarketplaceMods();
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
            Mod_VersionLabel[EntryID] = new Label();
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
            Mod_AuthorLabel[EntryID] = new Label();
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
            Mod_InfoLabel[EntryID] = new Label();
            Mod_InfoLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_InfoLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_InfoLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
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
            ModFileSize_Label.Text = ModSize;
            DownloadMod_Button.Tag = ModDownloadLink;
            DownloadMod_Button.Text = "Download";

            ModLastUpdate_Label.Left = ModPanel_Panel.Width / 2 - LastUpdate_Label.Width / 2;
            ModFileSize_Label.Left = ModPanel_Panel.Width / 2 - ModFileSize_Label.Width / 2;

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
            DownloadMod_Button.Hide();
            ProgressInfo_Label.Show();
            DownloadProgress_PB.Show();
            DownloadProgress_PB.Value = 0;
            CloseModPanel_Button.Enabled = false;
            Close_Button.Enabled = false;
            DownloadFile(DownloadMod_Button.Tag.ToString());
        }

        async void DownloadFile(string link)
        {
            var client = new MegaApiClient();
            client.LoginAnonymous();

            try
            {
                if (Directory.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads") == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads");
                }

                Uri fileLink = new Uri(link);
                INode node = client.GetNodeFromLink(fileLink);

                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + node.Name))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + node.Name);
                }

                IProgress<double> progressHandler = new Progress<double>(x =>
                {
                    ProgressInfo_Label.Text = "Downloading... " + ((int)x).ToString() + "%";
                    DownloadProgress_PB.Value = ((int)x);
                }
                );

                await client.DownloadFileAsync(fileLink, Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + node.Name, progressHandler);

                client.Logout();

                //Add Mod to active mods
                List<string> mods = new List<string>();
                mods.Add(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Downloads\" + node.Name);
                Main_Form.AddMods(mods);

                DownloadMod_Button.Show();
                DownloadMod_Button.Text = "Mod Downloaded!";
                ProgressInfo_Label.Hide();
                ProgressInfo_Label.Text = "Initializing...";
                DownloadProgress_PB.Hide();
                DownloadProgress_PB.Value = 0;
                CloseModPanel_Button.Enabled = true;
                Close_Button.Enabled = true;

                LoadMarketplaceMods();
            }
            catch (Exception ex)
            {
                DownloadMod_Button.Show();
                DownloadMod_Button.Text = "Download";
                ProgressInfo_Label.Hide();
                ProgressInfo_Label.Text = "Initializing...";
                DownloadProgress_PB.Hide();
                DownloadProgress_PB.Value = 0;
                CloseModPanel_Button.Enabled = true;
                Close_Button.Enabled = true;

                if (client.IsLoggedIn)
                {
                    client.Logout();
                }

                MessageBox.Show(ex.Message, "WLMM Download Error");
                LoadMarketplaceMods();
            }
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
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            foreach (int ModID in Mod_Entries)
            {
                if (Mod_Category[ModID].Contains(Filter_CB.Text) && Mod_NameLabel[ModID].Text.ToLower().Contains(Search_TB.Text.ToLower()))
                {
                    Mod_Panel[ModID].Show();
                }
                else if (Filter_CB.Text == "All" && Mod_NameLabel[ModID].Text.ToLower().Contains(Search_TB.Text.ToLower()))
                {
                    Mod_Panel[ModID].Show();
                }
                else
                {
                    Mod_Panel[ModID].Hide();
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
    }
}
