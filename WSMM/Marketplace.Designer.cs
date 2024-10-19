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
            Search_TB = new TextBox();
            ModPanel_Panel = new Panel();
            ModVersion_Label = new Label();
            ModDescription_TB = new TextBox();
            CloseModPanel_Button = new PictureBox();
            ModLastUpdate_Label = new Label();
            SupportedVersions_Label = new Label();
            ModAuthor_Label = new Label();
            ProgressInfo_Label = new Label();
            DownloadProgress_PB = new ProgressBar();
            PreviousScreenshot_Button = new Button();
            NextScreenshot_Button = new Button();
            ModFileSize_Label = new Label();
            Screenshot = new PictureBox();
            ModName_Label = new Label();
            DownloadMod_Button = new Button();
            ModLink_LL = new LinkLabel();
            LastUpdate_Label = new Label();
            NoModsFound_Label = new Label();
            RefreshMods_Button = new Button();
            ModFlow_Panel = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            Filter_CB = new ComboBox();
            RefreshDelay = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            ModMain_Panel.SuspendLayout();
            ModPanel_Panel.SuspendLayout();
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
            Close_Button.Location = new Point(705, 4);
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
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Location = new Point(1, 1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(748, 40);
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
            TitleLabel.Location = new Point(268, 4);
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
            Separator_1.Location = new Point(98, 36);
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
            ModMain_Panel.Size = new Size(742, 667);
            ModMain_Panel.TabIndex = 13;
            // 
            // Search_TB
            // 
            Search_TB.BackColor = Color.FromArgb(75, 68, 138);
            Search_TB.BorderStyle = BorderStyle.FixedSingle;
            Search_TB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Search_TB.ForeColor = SystemColors.ActiveCaption;
            Search_TB.Location = new Point(415, 6);
            Search_TB.Name = "Search_TB";
            Search_TB.PlaceholderText = "Search";
            Search_TB.Size = new Size(166, 23);
            Search_TB.TabIndex = 18;
            Search_TB.TextAlign = HorizontalAlignment.Center;
            Search_TB.TextChanged += Search_TB_TextChanged;
            // 
            // ModPanel_Panel
            // 
            ModPanel_Panel.BorderStyle = BorderStyle.Fixed3D;
            ModPanel_Panel.Controls.Add(ModVersion_Label);
            ModPanel_Panel.Controls.Add(ModDescription_TB);
            ModPanel_Panel.Controls.Add(CloseModPanel_Button);
            ModPanel_Panel.Controls.Add(ModLastUpdate_Label);
            ModPanel_Panel.Controls.Add(SupportedVersions_Label);
            ModPanel_Panel.Controls.Add(ModAuthor_Label);
            ModPanel_Panel.Controls.Add(ProgressInfo_Label);
            ModPanel_Panel.Controls.Add(DownloadProgress_PB);
            ModPanel_Panel.Controls.Add(PreviousScreenshot_Button);
            ModPanel_Panel.Controls.Add(NextScreenshot_Button);
            ModPanel_Panel.Controls.Add(ModFileSize_Label);
            ModPanel_Panel.Controls.Add(Screenshot);
            ModPanel_Panel.Controls.Add(ModName_Label);
            ModPanel_Panel.Controls.Add(DownloadMod_Button);
            ModPanel_Panel.Controls.Add(ModLink_LL);
            ModPanel_Panel.Location = new Point(23, 10);
            ModPanel_Panel.Name = "ModPanel_Panel";
            ModPanel_Panel.Size = new Size(691, 619);
            ModPanel_Panel.TabIndex = 14;
            ModPanel_Panel.Visible = false;
            // 
            // ModVersion_Label
            // 
            ModVersion_Label.AutoSize = true;
            ModVersion_Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModVersion_Label.ForeColor = SystemColors.ActiveCaption;
            ModVersion_Label.Location = new Point(319, 69);
            ModVersion_Label.Name = "ModVersion_Label";
            ModVersion_Label.Size = new Size(49, 25);
            ModVersion_Label.TabIndex = 26;
            ModVersion_Label.Text = "v.1.0";
            // 
            // ModDescription_TB
            // 
            ModDescription_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModDescription_TB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModDescription_TB.ForeColor = SystemColors.ActiveCaption;
            ModDescription_TB.Location = new Point(130, 155);
            ModDescription_TB.Multiline = true;
            ModDescription_TB.Name = "ModDescription_TB";
            ModDescription_TB.ScrollBars = ScrollBars.Vertical;
            ModDescription_TB.Size = new Size(426, 80);
            ModDescription_TB.TabIndex = 25;
            ModDescription_TB.Text = "Mod description";
            ModDescription_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // CloseModPanel_Button
            // 
            CloseModPanel_Button.Image = Properties.Resources.Close_Icon;
            CloseModPanel_Button.Location = new Point(642, 5);
            CloseModPanel_Button.Name = "CloseModPanel_Button";
            CloseModPanel_Button.Size = new Size(40, 40);
            CloseModPanel_Button.SizeMode = PictureBoxSizeMode.Zoom;
            CloseModPanel_Button.TabIndex = 24;
            CloseModPanel_Button.TabStop = false;
            CloseModPanel_Button.Click += CloseModPanel_Button_Click;
            CloseModPanel_Button.MouseEnter += CloseModPanel_Button_MouseEnter;
            CloseModPanel_Button.MouseLeave += CloseModPanel_Button_MouseLeave;
            // 
            // ModLastUpdate_Label
            // 
            ModLastUpdate_Label.AutoSize = true;
            ModLastUpdate_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModLastUpdate_Label.ForeColor = SystemColors.ActiveCaption;
            ModLastUpdate_Label.Location = new Point(252, 518);
            ModLastUpdate_Label.Name = "ModLastUpdate_Label";
            ModLastUpdate_Label.Size = new Size(183, 21);
            ModLastUpdate_Label.TabIndex = 23;
            ModLastUpdate_Label.Text = "Last Update: 2024-09-29";
            // 
            // SupportedVersions_Label
            // 
            SupportedVersions_Label.AutoSize = true;
            SupportedVersions_Label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SupportedVersions_Label.ForeColor = SystemColors.ActiveCaption;
            SupportedVersions_Label.Location = new Point(237, 127);
            SupportedVersions_Label.Name = "SupportedVersions_Label";
            SupportedVersions_Label.Size = new Size(213, 20);
            SupportedVersions_Label.TabIndex = 22;
            SupportedVersions_Label.Text = "2024.08.22_Shipping_Full_Build";
            // 
            // ModAuthor_Label
            // 
            ModAuthor_Label.AutoSize = true;
            ModAuthor_Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModAuthor_Label.ForeColor = SystemColors.ActiveCaption;
            ModAuthor_Label.Location = new Point(308, 44);
            ModAuthor_Label.Name = "ModAuthor_Label";
            ModAuthor_Label.Size = new Size(70, 25);
            ModAuthor_Label.TabIndex = 20;
            ModAuthor_Label.Text = "Author";
            // 
            // ProgressInfo_Label
            // 
            ProgressInfo_Label.AutoSize = true;
            ProgressInfo_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressInfo_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressInfo_Label.Location = new Point(298, 561);
            ProgressInfo_Label.Name = "ProgressInfo_Label";
            ProgressInfo_Label.Size = new Size(90, 21);
            ProgressInfo_Label.TabIndex = 19;
            ProgressInfo_Label.Text = "Initializing...";
            ProgressInfo_Label.Visible = false;
            // 
            // DownloadProgress_PB
            // 
            DownloadProgress_PB.Location = new Point(73, 588);
            DownloadProgress_PB.Name = "DownloadProgress_PB";
            DownloadProgress_PB.Size = new Size(541, 13);
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
            PreviousScreenshot_Button.Location = new Point(98, 241);
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
            NextScreenshot_Button.Location = new Point(562, 241);
            NextScreenshot_Button.Name = "NextScreenshot_Button";
            NextScreenshot_Button.Size = new Size(26, 272);
            NextScreenshot_Button.TabIndex = 15;
            NextScreenshot_Button.Text = ">";
            NextScreenshot_Button.UseVisualStyleBackColor = false;
            NextScreenshot_Button.Click += NextScreenshot_Button_Click;
            // 
            // ModFileSize_Label
            // 
            ModFileSize_Label.AutoSize = true;
            ModFileSize_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModFileSize_Label.ForeColor = SystemColors.ActiveCaption;
            ModFileSize_Label.Location = new Point(308, 539);
            ModFileSize_Label.Name = "ModFileSize_Label";
            ModFileSize_Label.Size = new Size(64, 21);
            ModFileSize_Label.TabIndex = 14;
            ModFileSize_Label.Text = "512 MB";
            // 
            // Screenshot
            // 
            Screenshot.BorderStyle = BorderStyle.FixedSingle;
            Screenshot.ImageLocation = "";
            Screenshot.Location = new Point(130, 241);
            Screenshot.Name = "Screenshot";
            Screenshot.Size = new Size(426, 272);
            Screenshot.SizeMode = PictureBoxSizeMode.Zoom;
            Screenshot.TabIndex = 13;
            Screenshot.TabStop = false;
            // 
            // ModName_Label
            // 
            ModName_Label.AutoSize = true;
            ModName_Label.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_Label.ForeColor = SystemColors.ActiveCaption;
            ModName_Label.Location = new Point(276, 13);
            ModName_Label.Name = "ModName_Label";
            ModName_Label.Size = new Size(135, 32);
            ModName_Label.TabIndex = 12;
            ModName_Label.Text = "Mod Name";
            // 
            // DownloadMod_Button
            // 
            DownloadMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            DownloadMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            DownloadMod_Button.FlatStyle = FlatStyle.Flat;
            DownloadMod_Button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DownloadMod_Button.ForeColor = SystemColors.ActiveCaption;
            DownloadMod_Button.Location = new Point(206, 563);
            DownloadMod_Button.Name = "DownloadMod_Button";
            DownloadMod_Button.Size = new Size(275, 38);
            DownloadMod_Button.TabIndex = 3;
            DownloadMod_Button.Text = "Download";
            DownloadMod_Button.UseVisualStyleBackColor = false;
            DownloadMod_Button.Click += DownloadMod_Button_Click;
            // 
            // ModLink_LL
            // 
            ModLink_LL.ActiveLinkColor = SystemColors.ActiveCaption;
            ModLink_LL.AutoSize = true;
            ModLink_LL.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModLink_LL.LinkColor = SystemColors.Highlight;
            ModLink_LL.Location = new Point(319, 93);
            ModLink_LL.Name = "ModLink_LL";
            ModLink_LL.Size = new Size(46, 25);
            ModLink_LL.TabIndex = 21;
            ModLink_LL.TabStop = true;
            ModLink_LL.Tag = "https://discord.com/channels/1105479421932097566/1220011707469004893";
            ModLink_LL.Text = "Link";
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
            NoModsFound_Label.Location = new Point(274, 316);
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
            ModFlow_Panel.Size = new Size(733, 625);
            ModFlow_Panel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.ForeColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(708, 95);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.OliveDrab;
            label1.Location = new Point(579, 63);
            label1.Name = "label1";
            label1.Size = new Size(107, 17);
            label1.TabIndex = 10;
            label1.Text = "Update Available";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = SystemColors.ActiveCaption;
            linkLabel1.Location = new Point(90, 2);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(280, 30);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Dirty Body - Skin Mod UE 5.4";
            linkLabel1.VisitedLinkColor = SystemColors.ActiveCaption;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(90, 63);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 8;
            label6.Text = "by: Mr.Sergoo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LightCoral;
            label5.Location = new Point(90, 35);
            label5.Name = "label5";
            label5.Size = new Size(195, 17);
            label5.TabIndex = 5;
            label5.Text = "2024.06.14_Shipping_Full_Build_1";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(660, 4);
            label3.Name = "label3";
            label3.Size = new Size(39, 30);
            label3.TabIndex = 3;
            label3.Text = "v.2";
            // 
            // pictureBox2
            // 
            pictureBox2.ImageLocation = "";
            pictureBox2.Location = new Point(3, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // Filter_CB
            // 
            Filter_CB.BackColor = Color.FromArgb(75, 68, 138);
            Filter_CB.FlatStyle = FlatStyle.Flat;
            Filter_CB.ForeColor = SystemColors.ActiveCaption;
            Filter_CB.FormattingEnabled = true;
            Filter_CB.Items.AddRange(new object[] { "All", "Outfit", "Hair", "Skin", "Pubic Hair", "Eyes", "Eyeliner", "Eyeshadow", "Lipstick", "Tanlines", "Fur", "Audio", "Other" });
            Filter_CB.Location = new Point(587, 6);
            Filter_CB.Name = "Filter_CB";
            Filter_CB.Size = new Size(145, 23);
            Filter_CB.TabIndex = 15;
            Filter_CB.Text = "All";
            Filter_CB.TextChanged += Filter_CB_TextChanged;
            // 
            // RefreshDelay
            // 
            RefreshDelay.Interval = 5000;
            RefreshDelay.Tick += RefreshDelay_Tick;
            // 
            // Marketplace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(750, 719);
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
        private Label label5;
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
    }
}