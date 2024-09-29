﻿using Microsoft.VisualBasic;
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

namespace WSMM
{
    public partial class Marketplace : Form
    {
        private string LoadedWLVersion = string.Empty;
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

        List<int> Mod_Entries = new List<int>();
        int Mod_CurrentEntryID = 0;

        private List<string> LoadedModScreenshots = new List<string>();
        private int CurrentScreenshot = 0;

        public Main Main_Form = null;

        public Marketplace()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, Main MainForm)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            Main_Form = MainForm;
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
            GetMarketplaceMods();
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

            if (Filter_CB.Text != "All")
            {
                if (Category.Contains(Filter_CB.Text) == false)
                {
                    return;
                }
            }

            int EntryID = Mod_CurrentEntryID;
            //Panel[] Mod_Panel = new Panel[50];
            Mod_Panel[EntryID] = new Panel();
            Mod_Panel[EntryID].Size = new System.Drawing.Size(708, 95);
            Mod_Panel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Panel[EntryID].BorderStyle = BorderStyle.Fixed3D;
            //PictureBox[] Mod_Icon = new PictureBox[50];
            Mod_Icon[EntryID] = new PictureBox();
            Mod_Icon[EntryID].Size = new System.Drawing.Size(80, 80);
            Mod_Icon[EntryID].Location = new Point(3, 5);
            Mod_Icon[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_Icon[EntryID].BorderStyle = BorderStyle.FixedSingle;
            Mod_Icon[EntryID].SizeMode = PictureBoxSizeMode.Zoom;
            Mod_Icon[EntryID].ImageLocation = ModIcon;

            //Label[] Mod_NameLabel = new Label[50];
            Mod_NameLabel[EntryID] = new LinkLabel();
            Mod_NameLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_NameLabel[EntryID].LinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_NameLabel[EntryID].VisitedLinkColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_NameLabel[EntryID].ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            Mod_NameLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 16);
            Mod_NameLabel[EntryID].Text = ModName;
            Mod_NameLabel[EntryID].AutoSize = true;
            Mod_NameLabel[EntryID].Location = new Point(90, 2);
            Mod_NameLabel[EntryID].Tag = ModString;
            Mod_NameLabel[EntryID].Click += Mod_NameLabel_Click;
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
            //Label[] Mod_AuthorLabel = new Label[50];
            Mod_AuthorLabel[EntryID] = new Label();
            Mod_AuthorLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_AuthorLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_AuthorLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 12);
            Mod_AuthorLabel[EntryID].Text = "By: " + ModAuthor;
            Mod_AuthorLabel[EntryID].AutoSize = true;
            Mod_AuthorLabel[EntryID].Location = new Point(90, 63);
            //Label[] Mod_SupportedVersionsLabel = new Label[50];
            Mod_SupportedVersionsLabel[EntryID] = new Label();
            Mod_SupportedVersionsLabel[EntryID].BackColor = System.Drawing.Color.FromArgb(32, 34, 81);
            Mod_SupportedVersionsLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            Mod_SupportedVersionsLabel[EntryID].Font = new Font(Mod_NameLabel[EntryID].Font.FontFamily, 10);
            Mod_SupportedVersionsLabel[EntryID].Text = SupportedVersions;
            Mod_SupportedVersionsLabel[EntryID].AutoSize = true;
            Mod_SupportedVersionsLabel[EntryID].Location = new Point(90, 35);

            Mod_Panel[EntryID].Controls.Add(Mod_Icon[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_NameLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_VersionLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_SupportedVersionsLabel[EntryID]);
            Mod_Panel[EntryID].Controls.Add(Mod_AuthorLabel[EntryID]);

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

        private bool isVersionValid(string Supported)
        {
            if (Supported.Contains(LoadedWLVersion) || Supported.Contains("All Versions"))
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

            ModName_Label.Text = ModName;
            ModAuthor_Label.Text = ModAuthor;
            ModVersion_Label.Text = ModVersion;
            SupportedVersions_Label.Text = SupportedVersions;
            ModLink_LL.Text = ModURL;
            ModDescription_TB.Text = ModDescription;
            Screenshot.ImageLocation = ModIcon;
            ModLastUpdate_Label.Text = "Last Update: " + LastUpdate;
            ModFileSize_Label.Text = ModSize;
            DownloadMod_Button.Tag = ModDownloadLink;
            DownloadMod_Button.Text = "Download";

            ModName_Label.Left = ModPanel_Panel.Width / 2 - ModName_Label.Width / 2;
            ModAuthor_Label.Left = ModPanel_Panel.Width / 2 - ModAuthor_Label.Width / 2;
            ModVersion_Label.Left = ModPanel_Panel.Width / 2 - ModVersion_Label.Width / 2;
            SupportedVersions_Label.Left = ModPanel_Panel.Width / 2 - SupportedVersions_Label.Width / 2;
            ModLink_LL.Left = ModPanel_Panel.Width / 2 - ModLink_LL.Width / 2;
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

                //IProgress<double> progressHandler = new Progress<double>(x => ProgressInfo_Label.Text = "Downloading... " + ((int)x).ToString() + "%");

                IProgress<double> progressHandler = new Progress<double>(x =>
                {
                    ProgressInfo_Label.Text = "Downloading... " + ((int)x).ToString() + "%";
                    ProgressInfo_Label.Left = ModPanel_Panel.Width / 2 - ProgressInfo_Label.Width / 2;
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

                client.Logout();

                MessageBox.Show(ex.Message, "WLMM Download Error");
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

        private void ApplyFilter_Button_Click(object sender, EventArgs e)
        {
            LoadMarketplaceMods();
        }
    }
}