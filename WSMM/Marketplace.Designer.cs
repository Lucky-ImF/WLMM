namespace WSMM
{
    partial class Marketplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Marketplace));
            Icon_PB = new PictureBox();
            Close_Button = new PictureBox();
            TitlePanel = new Panel();
            TitleLabel = new Label();
            Separator_1 = new PictureBox();
            ModMain_Panel = new Panel();
            ModPanel_Panel = new Panel();
            HideModButton = new PictureBox();
            DeleteAfterDownload_CB = new CheckBox();
            ModAuthor_Label = new Label();
            DownloadMod_Button = new Button();
            ModFileSize_Label = new Label();
            ProgressDetails_Label = new Label();
            Screenshot_HoverLabel = new Label();
            CloseModPanel_Button = new PictureBox();
            Characters_Label = new Label();
            Categories_Label = new Label();
            ModVersion_Label = new Label();
            ModDescription_TB = new TextBox();
            ModLastUpdate_Label = new Label();
            SupportedVersions_Label = new Label();
            ProgressInfo_Label = new Label();
            DownloadProgress_PB = new ProgressBar();
            PreviousScreenshot_Button = new Button();
            NextScreenshot_Button = new Button();
            Screenshot = new PictureBox();
            ModName_Label = new Label();
            ModLink_LL = new LinkLabel();
            LastUpdate_Label = new Label();
            NoModsFound_Label = new Label();
            RefreshMods_Button = new Button();
            ModFlow_Panel = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            label6 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            linkLabel1 = new LinkLabel();
            Filter_CB = new ComboBox();
            Search_TB = new TextBox();
            RefreshDelay = new System.Windows.Forms.Timer(components);
            ResetHiddenMods_LL = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            ModMain_Panel.SuspendLayout();
            ModPanel_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HideModButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CloseModPanel_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Screenshot).BeginInit();
            ModFlow_Panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(4, 4);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(40, 40);
            Icon_PB.SizeMode = PictureBoxSizeMode.Zoom;
            Icon_PB.TabIndex = 9;
            Icon_PB.TabStop = false;
            // 
            // Close_Button
            // 
            Close_Button.Image = Properties.Resources.Close_Icon;
            Close_Button.Location = new Point(804, 4);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(40, 40);
            Close_Button.SizeMode = PictureBoxSizeMode.Zoom;
            Close_Button.TabIndex = 11;
            Close_Button.TabStop = false;
            Close_Button.Click += Close_Button_Click;
            Close_Button.MouseEnter += Close_Button_MouseEnter;
            Close_Button.MouseLeave += Close_Button_MouseLeave;
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = Color.FromArgb(32, 34, 81);
            TitlePanel.Controls.Add(ResetHiddenMods_LL);
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Location = new Point(1, 1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(846, 40);
            TitlePanel.TabIndex = 10;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
            TitlePanel.MouseMove += TitlePanel_MouseMove;
            TitlePanel.MouseUp += TitlePanel_MouseUp;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = SystemColors.ActiveCaption;
            TitleLabel.Location = new Point(316, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(215, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "WLMM - Marketplace";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // Separator_1
            // 
            Separator_1.BackColor = SystemColors.ActiveCaption;
            Separator_1.Location = new Point(128, 36);
            Separator_1.Name = "Separator_1";
            Separator_1.Size = new Size(590, 2);
            Separator_1.TabIndex = 12;
            Separator_1.TabStop = false;
            // 
            // ModMain_Panel
            // 
            ModMain_Panel.BorderStyle = BorderStyle.Fixed3D;
            ModMain_Panel.Controls.Add(ModPanel_Panel);
            ModMain_Panel.Controls.Add(LastUpdate_Label);
            ModMain_Panel.Controls.Add(NoModsFound_Label);
            ModMain_Panel.Controls.Add(RefreshMods_Button);
            ModMain_Panel.Controls.Add(ModFlow_Panel);
            ModMain_Panel.Controls.Add(Filter_CB);
            ModMain_Panel.Controls.Add(Search_TB);
            ModMain_Panel.Location = new Point(4, 47);
            ModMain_Panel.Name = "ModMain_Panel";
            ModMain_Panel.Size = new Size(840, 667);
            ModMain_Panel.TabIndex = 13;
            // 
            // ModPanel_Panel
            // 
            ModPanel_Panel.BorderStyle = BorderStyle.Fixed3D;
            ModPanel_Panel.Controls.Add(HideModButton);
            ModPanel_Panel.Controls.Add(DeleteAfterDownload_CB);
            ModPanel_Panel.Controls.Add(ModAuthor_Label);
            ModPanel_Panel.Controls.Add(DownloadMod_Button);
            ModPanel_Panel.Controls.Add(ModFileSize_Label);
            ModPanel_Panel.Controls.Add(ProgressDetails_Label);
            ModPanel_Panel.Controls.Add(Screenshot_HoverLabel);
            ModPanel_Panel.Controls.Add(CloseModPanel_Button);
            ModPanel_Panel.Controls.Add(Characters_Label);
            ModPanel_Panel.Controls.Add(Categories_Label);
            ModPanel_Panel.Controls.Add(ModVersion_Label);
            ModPanel_Panel.Controls.Add(ModDescription_TB);
            ModPanel_Panel.Controls.Add(ModLastUpdate_Label);
            ModPanel_Panel.Controls.Add(SupportedVersions_Label);
            ModPanel_Panel.Controls.Add(ProgressInfo_Label);
            ModPanel_Panel.Controls.Add(DownloadProgress_PB);
            ModPanel_Panel.Controls.Add(PreviousScreenshot_Button);
            ModPanel_Panel.Controls.Add(NextScreenshot_Button);
            ModPanel_Panel.Controls.Add(Screenshot);
            ModPanel_Panel.Controls.Add(ModName_Label);
            ModPanel_Panel.Controls.Add(ModLink_LL);
            ModPanel_Panel.Location = new Point(125, 18);
            ModPanel_Panel.Name = "ModPanel_Panel";
            ModPanel_Panel.Size = new Size(586, 627);
            ModPanel_Panel.TabIndex = 14;
            ModPanel_Panel.Visible = false;
            // 
            // HideModButton
            // 
            HideModButton.Image = Properties.Resources.Eye_Icon;
            HideModButton.Location = new Point(6, 8);
            HideModButton.Name = "HideModButton";
            HideModButton.Size = new Size(30, 30);
            HideModButton.SizeMode = PictureBoxSizeMode.Zoom;
            HideModButton.TabIndex = 32;
            HideModButton.TabStop = false;
            HideModButton.Click += HideModButton_Click;
            HideModButton.MouseEnter += HideModButton_MouseEnter;
            HideModButton.MouseLeave += HideModButton_MouseLeave;
            // 
            // DeleteAfterDownload_CB
            // 
            DeleteAfterDownload_CB.AutoSize = true;
            DeleteAfterDownload_CB.ForeColor = Color.White;
            DeleteAfterDownload_CB.Location = new Point(196, 596);
            DeleteAfterDownload_CB.Name = "DeleteAfterDownload_CB";
            DeleteAfterDownload_CB.Size = new Size(201, 19);
            DeleteAfterDownload_CB.TabIndex = 31;
            DeleteAfterDownload_CB.Text = "Delete .wlmm file after download";
            DeleteAfterDownload_CB.UseVisualStyleBackColor = true;
            DeleteAfterDownload_CB.CheckedChanged += DeleteAfterDownload_CB_CheckedChanged;
            // 
            // ModAuthor_Label
            // 
            ModAuthor_Label.AutoEllipsis = true;
            ModAuthor_Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModAuthor_Label.ForeColor = SystemColors.ActiveCaption;
            ModAuthor_Label.Location = new Point(24, 37);
            ModAuthor_Label.Name = "ModAuthor_Label";
            ModAuthor_Label.Size = new Size(534, 25);
            ModAuthor_Label.TabIndex = 20;
            ModAuthor_Label.Text = "Author";
            ModAuthor_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DownloadMod_Button
            // 
            DownloadMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            DownloadMod_Button.BackgroundImageLayout = ImageLayout.Zoom;
            DownloadMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            DownloadMod_Button.FlatStyle = FlatStyle.Flat;
            DownloadMod_Button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DownloadMod_Button.ForeColor = SystemColors.ActiveCaption;
            DownloadMod_Button.Location = new Point(156, 552);
            DownloadMod_Button.Name = "DownloadMod_Button";
            DownloadMod_Button.Size = new Size(275, 38);
            DownloadMod_Button.TabIndex = 3;
            DownloadMod_Button.Text = "Download";
            DownloadMod_Button.UseVisualStyleBackColor = false;
            DownloadMod_Button.Click += DownloadMod_Button_Click;
            // 
            // ModFileSize_Label
            // 
            ModFileSize_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModFileSize_Label.ForeColor = Color.FromArgb(192, 255, 255);
            ModFileSize_Label.Location = new Point(78, 528);
            ModFileSize_Label.Name = "ModFileSize_Label";
            ModFileSize_Label.Size = new Size(426, 21);
            ModFileSize_Label.TabIndex = 14;
            ModFileSize_Label.Text = "Size: 512 MB | Downloads: 0";
            ModFileSize_Label.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProgressDetails_Label
            // 
            ProgressDetails_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressDetails_Label.ForeColor = Color.Orange;
            ProgressDetails_Label.Location = new Point(24, 555);
            ProgressDetails_Label.Name = "ProgressDetails_Label";
            ProgressDetails_Label.Size = new Size(534, 21);
            ProgressDetails_Label.TabIndex = 30;
            ProgressDetails_Label.Text = "Speed: 0 B/s | 0 B / 0 B | Time Left: 00:00:00";
            ProgressDetails_Label.TextAlign = ContentAlignment.TopCenter;
            ProgressDetails_Label.Visible = false;
            // 
            // Screenshot_HoverLabel
            // 
            Screenshot_HoverLabel.AutoSize = true;
            Screenshot_HoverLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Screenshot_HoverLabel.ForeColor = SystemColors.ActiveCaption;
            Screenshot_HoverLabel.Location = new Point(162, 475);
            Screenshot_HoverLabel.Name = "Screenshot_HoverLabel";
            Screenshot_HoverLabel.Size = new Size(258, 21);
            Screenshot_HoverLabel.TabIndex = 29;
            Screenshot_HoverLabel.Text = "Click to open image in web browser";
            Screenshot_HoverLabel.Visible = false;
            // 
            // CloseModPanel_Button
            // 
            CloseModPanel_Button.Image = Properties.Resources.Close_Icon;
            CloseModPanel_Button.Location = new Point(544, 8);
            CloseModPanel_Button.Name = "CloseModPanel_Button";
            CloseModPanel_Button.Size = new Size(30, 30);
            CloseModPanel_Button.SizeMode = PictureBoxSizeMode.Zoom;
            CloseModPanel_Button.TabIndex = 24;
            CloseModPanel_Button.TabStop = false;
            CloseModPanel_Button.Click += CloseModPanel_Button_Click;
            CloseModPanel_Button.MouseEnter += CloseModPanel_Button_MouseEnter;
            CloseModPanel_Button.MouseLeave += CloseModPanel_Button_MouseLeave;
            // 
            // Characters_Label
            // 
            Characters_Label.AutoEllipsis = true;
            Characters_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Characters_Label.ForeColor = SystemColors.GradientInactiveCaption;
            Characters_Label.Location = new Point(24, 110);
            Characters_Label.Name = "Characters_Label";
            Characters_Label.Size = new Size(534, 20);
            Characters_Label.TabIndex = 28;
            Characters_Label.Text = "Maya";
            Characters_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Categories_Label
            // 
            Categories_Label.AutoEllipsis = true;
            Categories_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Categories_Label.ForeColor = SystemColors.GradientInactiveCaption;
            Categories_Label.Location = new Point(24, 88);
            Categories_Label.Name = "Categories_Label";
            Categories_Label.Size = new Size(534, 20);
            Categories_Label.TabIndex = 27;
            Categories_Label.Text = "Outfit";
            Categories_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ModVersion_Label
            // 
            ModVersion_Label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ModVersion_Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModVersion_Label.ForeColor = SystemColors.ActiveCaption;
            ModVersion_Label.Location = new Point(475, 11);
            ModVersion_Label.Name = "ModVersion_Label";
            ModVersion_Label.Size = new Size(68, 25);
            ModVersion_Label.TabIndex = 26;
            ModVersion_Label.Text = "v.1.0";
            ModVersion_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ModDescription_TB
            // 
            ModDescription_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModDescription_TB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModDescription_TB.ForeColor = SystemColors.ActiveCaption;
            ModDescription_TB.Location = new Point(43, 156);
            ModDescription_TB.Multiline = true;
            ModDescription_TB.Name = "ModDescription_TB";
            ModDescription_TB.ScrollBars = ScrollBars.Vertical;
            ModDescription_TB.Size = new Size(496, 66);
            ModDescription_TB.TabIndex = 25;
            ModDescription_TB.Text = "Mod description";
            ModDescription_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // ModLastUpdate_Label
            // 
            ModLastUpdate_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModLastUpdate_Label.ForeColor = SystemColors.ActiveCaption;
            ModLastUpdate_Label.Location = new Point(78, 507);
            ModLastUpdate_Label.Name = "ModLastUpdate_Label";
            ModLastUpdate_Label.Size = new Size(426, 21);
            ModLastUpdate_Label.TabIndex = 23;
            ModLastUpdate_Label.Text = "Last Update: 2024-09-29 ";
            ModLastUpdate_Label.TextAlign = ContentAlignment.TopCenter;
            // 
            // SupportedVersions_Label
            // 
            SupportedVersions_Label.AutoEllipsis = true;
            SupportedVersions_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SupportedVersions_Label.ForeColor = SystemColors.GradientInactiveCaption;
            SupportedVersions_Label.Location = new Point(24, 131);
            SupportedVersions_Label.Name = "SupportedVersions_Label";
            SupportedVersions_Label.Size = new Size(534, 20);
            SupportedVersions_Label.TabIndex = 22;
            SupportedVersions_Label.Text = "2024.08.22_Shipping_Full_Build";
            SupportedVersions_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProgressInfo_Label
            // 
            ProgressInfo_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressInfo_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressInfo_Label.Location = new Point(24, 534);
            ProgressInfo_Label.Name = "ProgressInfo_Label";
            ProgressInfo_Label.Size = new Size(534, 21);
            ProgressInfo_Label.TabIndex = 19;
            ProgressInfo_Label.Text = "Initializing...";
            ProgressInfo_Label.TextAlign = ContentAlignment.TopCenter;
            ProgressInfo_Label.Visible = false;
            // 
            // DownloadProgress_PB
            // 
            DownloadProgress_PB.Location = new Point(24, 577);
            DownloadProgress_PB.Name = "DownloadProgress_PB";
            DownloadProgress_PB.Size = new Size(534, 13);
            DownloadProgress_PB.TabIndex = 18;
            DownloadProgress_PB.Visible = false;
            // 
            // PreviousScreenshot_Button
            // 
            PreviousScreenshot_Button.BackColor = Color.FromArgb(75, 68, 138);
            PreviousScreenshot_Button.Enabled = false;
            PreviousScreenshot_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            PreviousScreenshot_Button.FlatStyle = FlatStyle.Flat;
            PreviousScreenshot_Button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PreviousScreenshot_Button.ForeColor = SystemColors.ActiveCaption;
            PreviousScreenshot_Button.Location = new Point(43, 228);
            PreviousScreenshot_Button.Name = "PreviousScreenshot_Button";
            PreviousScreenshot_Button.Size = new Size(26, 272);
            PreviousScreenshot_Button.TabIndex = 16;
            PreviousScreenshot_Button.Text = "<";
            PreviousScreenshot_Button.UseVisualStyleBackColor = false;
            PreviousScreenshot_Button.Click += PreviousScreenshot_Button_Click;
            // 
            // NextScreenshot_Button
            // 
            NextScreenshot_Button.BackColor = Color.FromArgb(75, 68, 138);
            NextScreenshot_Button.Enabled = false;
            NextScreenshot_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            NextScreenshot_Button.FlatStyle = FlatStyle.Flat;
            NextScreenshot_Button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NextScreenshot_Button.ForeColor = SystemColors.ActiveCaption;
            NextScreenshot_Button.Location = new Point(513, 228);
            NextScreenshot_Button.Name = "NextScreenshot_Button";
            NextScreenshot_Button.Size = new Size(26, 272);
            NextScreenshot_Button.TabIndex = 15;
            NextScreenshot_Button.Text = ">";
            NextScreenshot_Button.UseVisualStyleBackColor = false;
            NextScreenshot_Button.Click += NextScreenshot_Button_Click;
            // 
            // Screenshot
            // 
            Screenshot.BorderStyle = BorderStyle.FixedSingle;
            Screenshot.Cursor = Cursors.SizeAll;
            Screenshot.ImageLocation = "";
            Screenshot.Location = new Point(78, 228);
            Screenshot.Name = "Screenshot";
            Screenshot.Size = new Size(426, 272);
            Screenshot.SizeMode = PictureBoxSizeMode.Zoom;
            Screenshot.TabIndex = 13;
            Screenshot.TabStop = false;
            Screenshot.Click += Screenshot_Click;
            Screenshot.MouseEnter += Screenshot_MouseEnter;
            Screenshot.MouseLeave += Screenshot_MouseLeave;
            // 
            // ModName_Label
            // 
            ModName_Label.AutoEllipsis = true;
            ModName_Label.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_Label.ForeColor = SystemColors.ActiveCaption;
            ModName_Label.Location = new Point(42, 6);
            ModName_Label.Name = "ModName_Label";
            ModName_Label.Size = new Size(501, 32);
            ModName_Label.TabIndex = 12;
            ModName_Label.Text = "Mod Name";
            ModName_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ModLink_LL
            // 
            ModLink_LL.ActiveLinkColor = SystemColors.ActiveCaption;
            ModLink_LL.AutoEllipsis = true;
            ModLink_LL.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModLink_LL.LinkColor = SystemColors.Highlight;
            ModLink_LL.Location = new Point(24, 63);
            ModLink_LL.Name = "ModLink_LL";
            ModLink_LL.Size = new Size(534, 25);
            ModLink_LL.TabIndex = 21;
            ModLink_LL.TabStop = true;
            ModLink_LL.Tag = "https://discord.com/channels/1105479421932097566/1220011707469004893";
            ModLink_LL.Text = "Link";
            ModLink_LL.TextAlign = ContentAlignment.MiddleCenter;
            ModLink_LL.VisitedLinkColor = SystemColors.Highlight;
            ModLink_LL.LinkClicked += ModLink_LL_LinkClicked;
            // 
            // LastUpdate_Label
            // 
            LastUpdate_Label.AutoSize = true;
            LastUpdate_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastUpdate_Label.ForeColor = SystemColors.ActiveCaption;
            LastUpdate_Label.Location = new Point(125, 7);
            LastUpdate_Label.Name = "LastUpdate_Label";
            LastUpdate_Label.Size = new Size(141, 21);
            LastUpdate_Label.TabIndex = 12;
            LastUpdate_Label.Text = "Last Update: Never";
            // 
            // NoModsFound_Label
            // 
            NoModsFound_Label.AutoSize = true;
            NoModsFound_Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoModsFound_Label.ForeColor = SystemColors.ActiveCaption;
            NoModsFound_Label.Location = new Point(323, 316);
            NoModsFound_Label.Name = "NoModsFound_Label";
            NoModsFound_Label.Size = new Size(191, 30);
            NoModsFound_Label.TabIndex = 11;
            NoModsFound_Label.Text = "- No Mods Found -";
            NoModsFound_Label.Visible = false;
            // 
            // RefreshMods_Button
            // 
            RefreshMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            RefreshMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RefreshMods_Button.FlatStyle = FlatStyle.Flat;
            RefreshMods_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshMods_Button.ForeColor = SystemColors.ActiveCaption;
            RefreshMods_Button.Location = new Point(4, 5);
            RefreshMods_Button.Name = "RefreshMods_Button";
            RefreshMods_Button.Size = new Size(115, 26);
            RefreshMods_Button.TabIndex = 3;
            RefreshMods_Button.Text = "Refresh";
            RefreshMods_Button.UseVisualStyleBackColor = false;
            RefreshMods_Button.Click += RefreshMods_Button_Click;
            // 
            // ModFlow_Panel
            // 
            ModFlow_Panel.AutoScroll = true;
            ModFlow_Panel.Controls.Add(panel1);
            ModFlow_Panel.Location = new Point(3, 35);
            ModFlow_Panel.Name = "ModFlow_Panel";
            ModFlow_Panel.Size = new Size(830, 625);
            ModFlow_Panel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(linkLabel1);
            panel1.ForeColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 315);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.OliveDrab;
            label1.Location = new Point(77, 3);
            label1.Name = "label1";
            label1.Size = new Size(107, 17);
            label1.TabIndex = 10;
            label1.Text = "Update Available";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(2, 262);
            label6.Name = "label6";
            label6.Size = new Size(256, 21);
            label6.TabIndex = 8;
            label6.Text = "by: Mr.Sergoo";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(177, 283);
            label3.Name = "label3";
            label3.Size = new Size(81, 28);
            label3.TabIndex = 3;
            label3.Text = "v.2";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox2
            // 
            pictureBox2.ImageLocation = "https://i.imgur.com/dVO9puX.png";
            pictureBox2.Location = new Point(2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(256, 230);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoEllipsis = true;
            linkLabel1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = SystemColors.ActiveCaption;
            linkLabel1.Location = new Point(2, 232);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(256, 30);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Dirty Body - Skin Mod UE 5.4";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.VisitedLinkColor = SystemColors.ActiveCaption;
            // 
            // Filter_CB
            // 
            Filter_CB.BackColor = Color.FromArgb(75, 68, 138);
            Filter_CB.FlatStyle = FlatStyle.Flat;
            Filter_CB.ForeColor = SystemColors.ActiveCaption;
            Filter_CB.FormattingEnabled = true;
            Filter_CB.Items.AddRange(new object[] { "Latest", "Most Popular", "Outfit", "Hair", "Beard", "Skin", "Pubic Hair", "Eyes", "Eyeliner", "Eyeshadow", "Lipstick", "Tanlines", "Fur", "Audio", "Other" });
            Filter_CB.Location = new Point(688, 6);
            Filter_CB.Name = "Filter_CB";
            Filter_CB.Size = new Size(145, 23);
            Filter_CB.TabIndex = 15;
            Filter_CB.Text = "Latest";
            Filter_CB.TextChanged += Filter_CB_TextChanged;
            // 
            // Search_TB
            // 
            Search_TB.BackColor = Color.FromArgb(75, 68, 138);
            Search_TB.BorderStyle = BorderStyle.FixedSingle;
            Search_TB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Search_TB.ForeColor = SystemColors.ActiveCaption;
            Search_TB.Location = new Point(516, 6);
            Search_TB.Name = "Search_TB";
            Search_TB.PlaceholderText = "Search";
            Search_TB.Size = new Size(166, 23);
            Search_TB.TabIndex = 18;
            Search_TB.TextAlign = HorizontalAlignment.Center;
            Search_TB.TextChanged += Search_TB_TextChanged;
            // 
            // RefreshDelay
            // 
            RefreshDelay.Interval = 5000;
            RefreshDelay.Tick += RefreshDelay_Tick;
            // 
            // ResetHiddenMods_LL
            // 
            ResetHiddenMods_LL.ActiveLinkColor = SystemColors.ActiveCaption;
            ResetHiddenMods_LL.AutoEllipsis = true;
            ResetHiddenMods_LL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResetHiddenMods_LL.LinkColor = SystemColors.Highlight;
            ResetHiddenMods_LL.Location = new Point(607, 8);
            ResetHiddenMods_LL.Name = "ResetHiddenMods_LL";
            ResetHiddenMods_LL.Size = new Size(190, 25);
            ResetHiddenMods_LL.TabIndex = 22;
            ResetHiddenMods_LL.TabStop = true;
            ResetHiddenMods_LL.Tag = "";
            ResetHiddenMods_LL.Text = "Reset Hidden Mods: 0";
            ResetHiddenMods_LL.TextAlign = ContentAlignment.MiddleCenter;
            ResetHiddenMods_LL.Visible = false;
            ResetHiddenMods_LL.VisitedLinkColor = SystemColors.Highlight;
            ResetHiddenMods_LL.LinkClicked += ResetHiddenMods_LL_LinkClicked;
            // 
            // Marketplace
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(847, 719);
            ControlBox = false;
            Controls.Add(ModMain_Panel);
            Controls.Add(Separator_1);
            Controls.Add(Icon_PB);
            Controls.Add(Close_Button);
            Controls.Add(TitlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Marketplace";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marketplace";
            Load += Marketplace_Load;
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            ModMain_Panel.ResumeLayout(false);
            ModMain_Panel.PerformLayout();
            ModPanel_Panel.ResumeLayout(false);
            ModPanel_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HideModButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)CloseModPanel_Button).EndInit();
            ((System.ComponentModel.ISupportInitialize)Screenshot).EndInit();
            ModFlow_Panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Icon_PB;
        private PictureBox Close_Button;
        private Panel TitlePanel;
        private Label TitleLabel;
        private PictureBox Separator_1;
        private Panel ModMain_Panel;
        private Label NoModsFound_Label;
        private Button RefreshMods_Button;
        private FlowLayoutPanel ModFlow_Panel;
        private Panel panel1;
        private Label label6;
        private Label label3;
        private PictureBox pictureBox2;
        private Label LastUpdate_Label;
        private LinkLabel linkLabel1;
        private Panel ModPanel_Panel;
        private Label ModFileSize_Label;
        private PictureBox Screenshot;
        private Label ModName_Label;
        private Button DownloadMod_Button;
        private Button PreviousScreenshot_Button;
        private Button NextScreenshot_Button;
        private Label ModAuthor_Label;
        private Label ProgressInfo_Label;
        private ProgressBar DownloadProgress_PB;
        private Label SupportedVersions_Label;
        private LinkLabel ModLink_LL;
        private Label ModLastUpdate_Label;
        private TextBox ModDescription_TB;
        private PictureBox CloseModPanel_Button;
        private Label ModVersion_Label;
        private System.Windows.Forms.Timer RefreshDelay;
        private ComboBox Filter_CB;
        private TextBox Search_TB;
        private Label label1;
        private Label Characters_Label;
        private Label Categories_Label;
        private Label Screenshot_HoverLabel;
        private Label ProgressDetails_Label;
        private CheckBox DeleteAfterDownload_CB;
        private PictureBox HideModButton;
        private LinkLabel ResetHiddenMods_LL;
    }
}