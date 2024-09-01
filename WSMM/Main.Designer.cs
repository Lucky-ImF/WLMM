namespace WSMM
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            TitlePanel = new Panel();
            BugReportLink = new LinkLabel();
            UpdateLink = new LinkLabel();
            ByLuckyLabel = new Label();
            TitleLabel = new Label();
            Separator_1 = new PictureBox();
            Close_Button = new PictureBox();
            LoadGame_Button = new Button();
            WLVersionLoaded_Label = new Label();
            ModMain_Panel = new Panel();
            DragNDrop_Panel = new Panel();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            NoModsFound_Label = new Label();
            NoGameLoaded_Panel = new Panel();
            pictureBox4 = new PictureBox();
            label11 = new Label();
            RemoveMods_Button = new Button();
            AddMod_Button = new Button();
            DisableMods_Button = new Button();
            EnableMods_Button = new Button();
            ModFlow_Panel = new FlowLayoutPanel();
            panel1 = new Panel();
            label17 = new Label();
            linkLabel2 = new LinkLabel();
            label6 = new Label();
            checkBox1 = new CheckBox();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            BuildMods_Button = new Button();
            pictureBox1 = new PictureBox();
            ChangesMade_Label = new Label();
            ModCreator_Button = new Button();
            ProgressPanel = new Panel();
            ProgressInfo_Label = new Label();
            BuildModProgress_PB = new ProgressBar();
            ProgressTitle_Label = new Label();
            SelectWLVersion_Panel = new Panel();
            SelectWLVersionConfirm_Button = new Button();
            SelectWLVersion_CloseButton = new PictureBox();
            label13 = new Label();
            SelectWLVersion_CB = new ComboBox();
            SelectWLVersionBrowse_Button = new Button();
            label12 = new Label();
            SelectWLVersionPath_TB = new TextBox();
            label10 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            BuildSettings_Button = new Button();
            BuildSettings_Panel = new Panel();
            label1 = new Label();
            BS_Mappings = new ComboBox();
            BuildSettingsDTFolder_Button = new Button();
            label16 = new Label();
            BS_BaseGameCharacterCustomizationFile = new ComboBox();
            label15 = new Label();
            BS_BaseGameCharacterOutfitFile = new ComboBox();
            label14 = new Label();
            BS_BaseClothesOutfitFile = new ComboBox();
            RefreshBuildSettings_Button = new Button();
            openFileDialog1 = new OpenFileDialog();
            Icon_PB = new PictureBox();
            BugReport_Panel = new Panel();
            WLMMPost_Link = new LinkLabel();
            WildSanctum_Link = new LinkLabel();
            BugReport_CloseButton = new PictureBox();
            label7 = new Label();
            label18 = new Label();
            label19 = new Label();
            OpenWLFolder_Button = new Button();
            CreateBuildLog_Button = new Button();
            openFileDialog2 = new OpenFileDialog();
            MetaDataPatcher_Button = new Button();
            ExpandedLink_Panel = new Panel();
            ExpandedLinkCopy_LL = new LinkLabel();
            ExpandedLink_LL = new LinkLabel();
            ExpandedLink_CloseButton = new PictureBox();
            label22 = new Label();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            ModMain_Panel.SuspendLayout();
            DragNDrop_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            NoGameLoaded_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ModFlow_Panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ProgressPanel.SuspendLayout();
            SelectWLVersion_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectWLVersion_CloseButton).BeginInit();
            BuildSettings_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            BugReport_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BugReport_CloseButton).BeginInit();
            ExpandedLink_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExpandedLink_CloseButton).BeginInit();
            SuspendLayout();
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = Color.FromArgb(32, 34, 81);
            TitlePanel.Controls.Add(BugReportLink);
            TitlePanel.Controls.Add(UpdateLink);
            TitlePanel.Controls.Add(ByLuckyLabel);
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Location = new Point(1, 1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(1132, 40);
            TitlePanel.TabIndex = 0;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
            TitlePanel.MouseMove += TitlePanel_MouseMove;
            TitlePanel.MouseUp += TitlePanel_MouseUp;
            // 
            // BugReportLink
            // 
            BugReportLink.ActiveLinkColor = Color.Red;
            BugReportLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BugReportLink.AutoSize = true;
            BugReportLink.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BugReportLink.LinkColor = Color.LightCoral;
            BugReportLink.Location = new Point(973, 13);
            BugReportLink.Margin = new Padding(4, 0, 4, 0);
            BugReportLink.Name = "BugReportLink";
            BugReportLink.Size = new Size(86, 16);
            BugReportLink.TabIndex = 23;
            BugReportLink.TabStop = true;
            BugReportLink.Tag = "null";
            BugReportLink.Text = "Report a Bug";
            BugReportLink.VisitedLinkColor = Color.LightCoral;
            BugReportLink.LinkClicked += BugReportLink_LinkClicked;
            // 
            // UpdateLink
            // 
            UpdateLink.ActiveLinkColor = Color.LimeGreen;
            UpdateLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpdateLink.AutoSize = true;
            UpdateLink.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateLink.LinkColor = Color.ForestGreen;
            UpdateLink.Location = new Point(93, 13);
            UpdateLink.Margin = new Padding(4, 0, 4, 0);
            UpdateLink.Name = "UpdateLink";
            UpdateLink.Size = new Size(76, 16);
            UpdateLink.TabIndex = 22;
            UpdateLink.TabStop = true;
            UpdateLink.Tag = "null";
            UpdateLink.Text = "UpdateLink";
            UpdateLink.Visible = false;
            UpdateLink.VisitedLinkColor = Color.ForestGreen;
            UpdateLink.LinkClicked += UpdateLink_LinkClicked;
            // 
            // ByLuckyLabel
            // 
            ByLuckyLabel.AutoSize = true;
            ByLuckyLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ByLuckyLabel.ForeColor = SystemColors.GradientActiveCaption;
            ByLuckyLabel.Location = new Point(783, 12);
            ByLuckyLabel.Name = "ByLuckyLabel";
            ByLuckyLabel.Size = new Size(65, 20);
            ByLuckyLabel.TabIndex = 1;
            ByLuckyLabel.Text = "by Lucky";
            ByLuckyLabel.MouseDown += TitlePanel_MouseDown;
            ByLuckyLabel.MouseMove += TitlePanel_MouseMove;
            ByLuckyLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = SystemColors.ActiveCaption;
            TitleLabel.Location = new Point(413, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(310, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Wild Life Mod Manager - v.1.0.0";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // Separator_1
            // 
            Separator_1.BackColor = SystemColors.ActiveCaption;
            Separator_1.Location = new Point(92, 38);
            Separator_1.Name = "Separator_1";
            Separator_1.Size = new Size(950, 2);
            Separator_1.TabIndex = 1;
            Separator_1.TabStop = false;
            // 
            // Close_Button
            // 
            Close_Button.Image = Properties.Resources.Close_Icon;
            Close_Button.Location = new Point(1079, 5);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(50, 50);
            Close_Button.SizeMode = PictureBoxSizeMode.Zoom;
            Close_Button.TabIndex = 1;
            Close_Button.TabStop = false;
            Close_Button.Click += Close_Button_Click;
            Close_Button.MouseEnter += Close_Button_MouseEnter;
            Close_Button.MouseLeave += Close_Button_MouseLeave;
            // 
            // LoadGame_Button
            // 
            LoadGame_Button.BackColor = Color.FromArgb(75, 68, 138);
            LoadGame_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            LoadGame_Button.FlatStyle = FlatStyle.Flat;
            LoadGame_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoadGame_Button.ForeColor = SystemColors.ActiveCaption;
            LoadGame_Button.Location = new Point(764, 48);
            LoadGame_Button.Name = "LoadGame_Button";
            LoadGame_Button.Size = new Size(128, 30);
            LoadGame_Button.TabIndex = 2;
            LoadGame_Button.Text = "Load Game";
            LoadGame_Button.UseVisualStyleBackColor = false;
            LoadGame_Button.Click += LoadGame_Button_Click;
            // 
            // WLVersionLoaded_Label
            // 
            WLVersionLoaded_Label.AutoSize = true;
            WLVersionLoaded_Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WLVersionLoaded_Label.ForeColor = SystemColors.ActiveCaption;
            WLVersionLoaded_Label.Location = new Point(259, 46);
            WLVersionLoaded_Label.Name = "WLVersionLoaded_Label";
            WLVersionLoaded_Label.Size = new Size(297, 30);
            WLVersionLoaded_Label.TabIndex = 2;
            WLVersionLoaded_Label.Text = "- No Wild Life version loaded -";
            // 
            // ModMain_Panel
            // 
            ModMain_Panel.BorderStyle = BorderStyle.Fixed3D;
            ModMain_Panel.Controls.Add(DragNDrop_Panel);
            ModMain_Panel.Controls.Add(NoModsFound_Label);
            ModMain_Panel.Controls.Add(NoGameLoaded_Panel);
            ModMain_Panel.Controls.Add(RemoveMods_Button);
            ModMain_Panel.Controls.Add(AddMod_Button);
            ModMain_Panel.Controls.Add(DisableMods_Button);
            ModMain_Panel.Controls.Add(EnableMods_Button);
            ModMain_Panel.Controls.Add(ModFlow_Panel);
            ModMain_Panel.Location = new Point(12, 82);
            ModMain_Panel.Name = "ModMain_Panel";
            ModMain_Panel.Size = new Size(880, 667);
            ModMain_Panel.TabIndex = 3;
            // 
            // DragNDrop_Panel
            // 
            DragNDrop_Panel.AllowDrop = true;
            DragNDrop_Panel.BackColor = Color.FromArgb(75, 68, 138);
            DragNDrop_Panel.BorderStyle = BorderStyle.FixedSingle;
            DragNDrop_Panel.Controls.Add(pictureBox3);
            DragNDrop_Panel.Controls.Add(label8);
            DragNDrop_Panel.Controls.Add(label9);
            DragNDrop_Panel.Location = new Point(347, 245);
            DragNDrop_Panel.Name = "DragNDrop_Panel";
            DragNDrop_Panel.Size = new Size(183, 172);
            DragNDrop_Panel.TabIndex = 9;
            DragNDrop_Panel.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.DragDrop_Icon;
            pictureBox3.Location = new Point(42, 36);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 100);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaption;
            label8.Location = new Point(48, 141);
            label8.Name = "label8";
            label8.Size = new Size(92, 21);
            label8.TabIndex = 4;
            label8.Text = ".wlmm files.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaption;
            label9.Location = new Point(19, 1);
            label9.Name = "label9";
            label9.Size = new Size(151, 30);
            label9.TabIndex = 2;
            label9.Text = "Drag and Drop";
            // 
            // NoModsFound_Label
            // 
            NoModsFound_Label.AutoSize = true;
            NoModsFound_Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoModsFound_Label.ForeColor = SystemColors.ActiveCaption;
            NoModsFound_Label.Location = new Point(343, 316);
            NoModsFound_Label.Name = "NoModsFound_Label";
            NoModsFound_Label.Size = new Size(191, 30);
            NoModsFound_Label.TabIndex = 11;
            NoModsFound_Label.Text = "- No Mods Found -";
            NoModsFound_Label.Visible = false;
            // 
            // NoGameLoaded_Panel
            // 
            NoGameLoaded_Panel.BackColor = Color.FromArgb(75, 68, 138);
            NoGameLoaded_Panel.BorderStyle = BorderStyle.FixedSingle;
            NoGameLoaded_Panel.Controls.Add(pictureBox4);
            NoGameLoaded_Panel.Controls.Add(label11);
            NoGameLoaded_Panel.Location = new Point(297, 245);
            NoGameLoaded_Panel.Name = "NoGameLoaded_Panel";
            NoGameLoaded_Panel.Size = new Size(283, 172);
            NoGameLoaded_Panel.TabIndex = 10;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.AutoMod_Icon;
            pictureBox4.Location = new Point(90, 17);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 100);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaption;
            label11.Location = new Point(18, 126);
            label11.Name = "label11";
            label11.Size = new Size(249, 30);
            label11.TabIndex = 2;
            label11.Text = "No Game Version Loaded";
            // 
            // RemoveMods_Button
            // 
            RemoveMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            RemoveMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RemoveMods_Button.FlatStyle = FlatStyle.Flat;
            RemoveMods_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemoveMods_Button.ForeColor = Color.LightCoral;
            RemoveMods_Button.Location = new Point(637, 5);
            RemoveMods_Button.Name = "RemoveMods_Button";
            RemoveMods_Button.Size = new Size(115, 26);
            RemoveMods_Button.TabIndex = 6;
            RemoveMods_Button.Text = "Remove All";
            RemoveMods_Button.UseVisualStyleBackColor = false;
            RemoveMods_Button.Visible = false;
            RemoveMods_Button.Click += RemoveMods_Button_Click;
            // 
            // AddMod_Button
            // 
            AddMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            AddMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            AddMod_Button.FlatStyle = FlatStyle.Flat;
            AddMod_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddMod_Button.ForeColor = Color.SeaGreen;
            AddMod_Button.Location = new Point(758, 5);
            AddMod_Button.Name = "AddMod_Button";
            AddMod_Button.Size = new Size(115, 26);
            AddMod_Button.TabIndex = 5;
            AddMod_Button.Text = "Add +";
            AddMod_Button.UseVisualStyleBackColor = false;
            AddMod_Button.Visible = false;
            AddMod_Button.Click += AddMod_Button_Click;
            // 
            // DisableMods_Button
            // 
            DisableMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            DisableMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            DisableMods_Button.FlatStyle = FlatStyle.Flat;
            DisableMods_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DisableMods_Button.ForeColor = Color.LightCoral;
            DisableMods_Button.Location = new Point(125, 5);
            DisableMods_Button.Name = "DisableMods_Button";
            DisableMods_Button.Size = new Size(115, 26);
            DisableMods_Button.TabIndex = 4;
            DisableMods_Button.Text = "Disable All";
            DisableMods_Button.UseVisualStyleBackColor = false;
            DisableMods_Button.Visible = false;
            DisableMods_Button.Click += DisableMods_Button_Click;
            // 
            // EnableMods_Button
            // 
            EnableMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            EnableMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            EnableMods_Button.FlatStyle = FlatStyle.Flat;
            EnableMods_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnableMods_Button.ForeColor = SystemColors.ActiveCaption;
            EnableMods_Button.Location = new Point(4, 5);
            EnableMods_Button.Name = "EnableMods_Button";
            EnableMods_Button.Size = new Size(115, 26);
            EnableMods_Button.TabIndex = 3;
            EnableMods_Button.Text = "Enable All";
            EnableMods_Button.UseVisualStyleBackColor = false;
            EnableMods_Button.Visible = false;
            EnableMods_Button.Click += EnableMods_Button_Click;
            // 
            // ModFlow_Panel
            // 
            ModFlow_Panel.AutoScroll = true;
            ModFlow_Panel.Controls.Add(panel1);
            ModFlow_Panel.Location = new Point(3, 35);
            ModFlow_Panel.Name = "ModFlow_Panel";
            ModFlow_Panel.Size = new Size(870, 625);
            ModFlow_Panel.TabIndex = 0;
            ModFlow_Panel.DragDrop += ModFlow_Panel_DragDrop;
            ModFlow_Panel.DragEnter += ModFlow_Panel_DragEnter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label17);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.ForeColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 115);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.GradientActiveCaption;
            label17.Location = new Point(294, 83);
            label17.Name = "label17";
            label17.Size = new Size(142, 17);
            label17.TabIndex = 10;
            label17.Text = "| Paks: 1 | AutoMod: 1 |";
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = SystemColors.ActiveCaption;
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkColor = SystemColors.Highlight;
            linkLabel2.Location = new Point(503, 80);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(39, 21);
            linkLabel2.TabIndex = 9;
            linkLabel2.TabStop = true;
            linkLabel2.Tag = "https://discord.com/channels/1105479421932097566/1220011707469004893";
            linkLabel2.Text = "Link";
            linkLabel2.VisitedLinkColor = SystemColors.Highlight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(587, 80);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 8;
            label6.Text = "by: Mr.Sergoo";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = SystemColors.ActiveCaption;
            checkBox1.Location = new Point(741, 80);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(84, 25);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.MistyRose;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.LightCoral;
            linkLabel1.Location = new Point(117, 80);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(67, 21);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Remove";
            linkLabel1.VisitedLinkColor = Color.LightCoral;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LightCoral;
            label5.Location = new Point(117, 34);
            label5.Name = "label5";
            label5.Size = new Size(195, 17);
            label5.TabIndex = 5;
            label5.Text = "2024.06.14_Shipping_Full_Build_1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightCoral;
            label4.Location = new Point(533, 11);
            label4.Name = "label4";
            label4.Size = new Size(134, 21);
            label4.TabIndex = 4;
            label4.Text = "Version Mismatch";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(792, 4);
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
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(117, 4);
            label2.Name = "label2";
            label2.Size = new Size(280, 30);
            label2.TabIndex = 1;
            label2.Text = "Dirty Body - Skin Mod UE 5.4";
            // 
            // BuildMods_Button
            // 
            BuildMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            BuildMods_Button.Enabled = false;
            BuildMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            BuildMods_Button.FlatStyle = FlatStyle.Flat;
            BuildMods_Button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BuildMods_Button.ForeColor = SystemColors.ActiveCaption;
            BuildMods_Button.Location = new Point(907, 704);
            BuildMods_Button.Name = "BuildMods_Button";
            BuildMods_Button.Size = new Size(213, 45);
            BuildMods_Button.TabIndex = 4;
            BuildMods_Button.Text = "Build Mods";
            BuildMods_Button.UseVisualStyleBackColor = false;
            BuildMods_Button.Click += BuildMods_Button_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(916, 675);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 2);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ChangesMade_Label
            // 
            ChangesMade_Label.AutoSize = true;
            ChangesMade_Label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChangesMade_Label.ForeColor = SystemColors.ActiveCaption;
            ChangesMade_Label.Location = new Point(956, 681);
            ChangesMade_Label.Name = "ChangesMade_Label";
            ChangesMade_Label.Size = new Size(118, 17);
            ChangesMade_Label.TabIndex = 6;
            ChangesMade_Label.Text = "No changes made.";
            // 
            // ModCreator_Button
            // 
            ModCreator_Button.BackColor = Color.FromArgb(75, 68, 138);
            ModCreator_Button.Enabled = false;
            ModCreator_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ModCreator_Button.FlatStyle = FlatStyle.Flat;
            ModCreator_Button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModCreator_Button.ForeColor = SystemColors.ActiveCaption;
            ModCreator_Button.Location = new Point(907, 70);
            ModCreator_Button.Name = "ModCreator_Button";
            ModCreator_Button.Size = new Size(213, 45);
            ModCreator_Button.TabIndex = 7;
            ModCreator_Button.Text = "Mod Creator";
            ModCreator_Button.UseVisualStyleBackColor = false;
            ModCreator_Button.Click += ModCreator_Button_Click;
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.FromArgb(75, 68, 138);
            ProgressPanel.BorderStyle = BorderStyle.FixedSingle;
            ProgressPanel.Controls.Add(ProgressInfo_Label);
            ProgressPanel.Controls.Add(BuildModProgress_PB);
            ProgressPanel.Controls.Add(ProgressTitle_Label);
            ProgressPanel.Location = new Point(235, 636);
            ProgressPanel.Name = "ProgressPanel";
            ProgressPanel.Size = new Size(589, 100);
            ProgressPanel.TabIndex = 8;
            ProgressPanel.Visible = false;
            // 
            // ProgressInfo_Label
            // 
            ProgressInfo_Label.AutoSize = true;
            ProgressInfo_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressInfo_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressInfo_Label.Location = new Point(242, 36);
            ProgressInfo_Label.Name = "ProgressInfo_Label";
            ProgressInfo_Label.Size = new Size(90, 21);
            ProgressInfo_Label.TabIndex = 4;
            ProgressInfo_Label.Text = "Initializing...";
            // 
            // BuildModProgress_PB
            // 
            BuildModProgress_PB.Location = new Point(23, 67);
            BuildModProgress_PB.Name = "BuildModProgress_PB";
            BuildModProgress_PB.Size = new Size(541, 13);
            BuildModProgress_PB.TabIndex = 3;
            // 
            // ProgressTitle_Label
            // 
            ProgressTitle_Label.AutoSize = true;
            ProgressTitle_Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressTitle_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressTitle_Label.Location = new Point(213, 1);
            ProgressTitle_Label.Name = "ProgressTitle_Label";
            ProgressTitle_Label.Size = new Size(161, 30);
            ProgressTitle_Label.TabIndex = 2;
            ProgressTitle_Label.Text = "Building Mods...";
            // 
            // SelectWLVersion_Panel
            // 
            SelectWLVersion_Panel.BackColor = Color.FromArgb(75, 68, 138);
            SelectWLVersion_Panel.BorderStyle = BorderStyle.FixedSingle;
            SelectWLVersion_Panel.Controls.Add(SelectWLVersionConfirm_Button);
            SelectWLVersion_Panel.Controls.Add(SelectWLVersion_CloseButton);
            SelectWLVersion_Panel.Controls.Add(label13);
            SelectWLVersion_Panel.Controls.Add(SelectWLVersion_CB);
            SelectWLVersion_Panel.Controls.Add(SelectWLVersionBrowse_Button);
            SelectWLVersion_Panel.Controls.Add(label12);
            SelectWLVersion_Panel.Controls.Add(SelectWLVersionPath_TB);
            SelectWLVersion_Panel.Controls.Add(label10);
            SelectWLVersion_Panel.Location = new Point(316, 294);
            SelectWLVersion_Panel.Name = "SelectWLVersion_Panel";
            SelectWLVersion_Panel.Size = new Size(503, 198);
            SelectWLVersion_Panel.TabIndex = 11;
            SelectWLVersion_Panel.Visible = false;
            // 
            // SelectWLVersionConfirm_Button
            // 
            SelectWLVersionConfirm_Button.BackColor = Color.FromArgb(75, 68, 138);
            SelectWLVersionConfirm_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            SelectWLVersionConfirm_Button.FlatStyle = FlatStyle.Flat;
            SelectWLVersionConfirm_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectWLVersionConfirm_Button.ForeColor = SystemColors.ActiveCaption;
            SelectWLVersionConfirm_Button.Location = new Point(184, 157);
            SelectWLVersionConfirm_Button.Name = "SelectWLVersionConfirm_Button";
            SelectWLVersionConfirm_Button.Size = new Size(128, 30);
            SelectWLVersionConfirm_Button.TabIndex = 35;
            SelectWLVersionConfirm_Button.Text = "Confirm";
            SelectWLVersionConfirm_Button.UseVisualStyleBackColor = false;
            SelectWLVersionConfirm_Button.Click += SelectWLVersionConfirm_Button_Click;
            // 
            // SelectWLVersion_CloseButton
            // 
            SelectWLVersion_CloseButton.Image = Properties.Resources.Close_Icon;
            SelectWLVersion_CloseButton.Location = new Point(460, 4);
            SelectWLVersion_CloseButton.Name = "SelectWLVersion_CloseButton";
            SelectWLVersion_CloseButton.Size = new Size(37, 39);
            SelectWLVersion_CloseButton.SizeMode = PictureBoxSizeMode.Zoom;
            SelectWLVersion_CloseButton.TabIndex = 34;
            SelectWLVersion_CloseButton.TabStop = false;
            SelectWLVersion_CloseButton.Click += SelectWLVersion_CloseButton_Click;
            SelectWLVersion_CloseButton.MouseEnter += SelectWLVersion_CloseButton_MouseEnter;
            SelectWLVersion_CloseButton.MouseLeave += SelectWLVersion_CloseButton_MouseLeave;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaption;
            label13.Location = new Point(13, 104);
            label13.Name = "label13";
            label13.Size = new Size(108, 17);
            label13.TabIndex = 33;
            label13.Text = "Wild Life Version:";
            // 
            // SelectWLVersion_CB
            // 
            SelectWLVersion_CB.BackColor = Color.FromArgb(32, 34, 81);
            SelectWLVersion_CB.FlatStyle = FlatStyle.Flat;
            SelectWLVersion_CB.ForeColor = SystemColors.ActiveCaption;
            SelectWLVersion_CB.FormattingEnabled = true;
            SelectWLVersion_CB.Items.AddRange(new object[] { "2024.08.22_Shipping_Full_Build_1" });
            SelectWLVersion_CB.Location = new Point(13, 124);
            SelectWLVersion_CB.Name = "SelectWLVersion_CB";
            SelectWLVersion_CB.Size = new Size(477, 23);
            SelectWLVersion_CB.TabIndex = 32;
            SelectWLVersion_CB.Text = "Please specify version...";
            // 
            // SelectWLVersionBrowse_Button
            // 
            SelectWLVersionBrowse_Button.BackColor = Color.FromArgb(75, 68, 138);
            SelectWLVersionBrowse_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            SelectWLVersionBrowse_Button.FlatStyle = FlatStyle.Flat;
            SelectWLVersionBrowse_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectWLVersionBrowse_Button.ForeColor = SystemColors.ActiveCaption;
            SelectWLVersionBrowse_Button.Location = new Point(411, 76);
            SelectWLVersionBrowse_Button.Name = "SelectWLVersionBrowse_Button";
            SelectWLVersionBrowse_Button.Size = new Size(79, 22);
            SelectWLVersionBrowse_Button.TabIndex = 31;
            SelectWLVersionBrowse_Button.Text = "Browse...";
            SelectWLVersionBrowse_Button.UseVisualStyleBackColor = false;
            SelectWLVersionBrowse_Button.Click += SelectWLVersionBrowse_Button_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaption;
            label12.Location = new Point(13, 37);
            label12.Name = "label12";
            label12.Size = new Size(483, 34);
            label12.TabIndex = 30;
            label12.Text = "WildLifeC Executable:\r\n(ex. C:\\Games\\Wild Life\\2024.08.22_Shipping_Test_Build_1\\Windows\\WildLifeC.exe)";
            // 
            // SelectWLVersionPath_TB
            // 
            SelectWLVersionPath_TB.BackColor = Color.FromArgb(32, 34, 81);
            SelectWLVersionPath_TB.BorderStyle = BorderStyle.FixedSingle;
            SelectWLVersionPath_TB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectWLVersionPath_TB.ForeColor = SystemColors.ActiveCaption;
            SelectWLVersionPath_TB.Location = new Point(13, 76);
            SelectWLVersionPath_TB.Name = "SelectWLVersionPath_TB";
            SelectWLVersionPath_TB.Size = new Size(392, 23);
            SelectWLVersionPath_TB.TabIndex = 29;
            SelectWLVersionPath_TB.Text = "None";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaption;
            label10.Location = new Point(133, 4);
            label10.Name = "label10";
            label10.Size = new Size(213, 30);
            label10.TabIndex = 2;
            label10.Text = "Specify Wild Life Path";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // BuildSettings_Button
            // 
            BuildSettings_Button.BackColor = Color.FromArgb(75, 68, 138);
            BuildSettings_Button.Enabled = false;
            BuildSettings_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            BuildSettings_Button.FlatStyle = FlatStyle.Flat;
            BuildSettings_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BuildSettings_Button.ForeColor = SystemColors.ActiveCaption;
            BuildSettings_Button.Location = new Point(943, 643);
            BuildSettings_Button.Name = "BuildSettings_Button";
            BuildSettings_Button.Size = new Size(115, 26);
            BuildSettings_Button.TabIndex = 12;
            BuildSettings_Button.Text = "Build Settings";
            BuildSettings_Button.UseVisualStyleBackColor = false;
            BuildSettings_Button.Click += BuildSettings_Button_Click;
            // 
            // BuildSettings_Panel
            // 
            BuildSettings_Panel.BorderStyle = BorderStyle.FixedSingle;
            BuildSettings_Panel.Controls.Add(label1);
            BuildSettings_Panel.Controls.Add(BS_Mappings);
            BuildSettings_Panel.Controls.Add(BuildSettingsDTFolder_Button);
            BuildSettings_Panel.Controls.Add(label16);
            BuildSettings_Panel.Controls.Add(BS_BaseGameCharacterCustomizationFile);
            BuildSettings_Panel.Controls.Add(label15);
            BuildSettings_Panel.Controls.Add(BS_BaseGameCharacterOutfitFile);
            BuildSettings_Panel.Controls.Add(label14);
            BuildSettings_Panel.Controls.Add(BS_BaseClothesOutfitFile);
            BuildSettings_Panel.Location = new Point(898, 398);
            BuildSettings_Panel.Name = "BuildSettings_Panel";
            BuildSettings_Panel.Size = new Size(231, 237);
            BuildSettings_Panel.TabIndex = 13;
            BuildSettings_Panel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(79, 184);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 42;
            label1.Text = "Mappings:";
            // 
            // BS_Mappings
            // 
            BS_Mappings.BackColor = Color.FromArgb(32, 34, 81);
            BS_Mappings.FlatStyle = FlatStyle.Flat;
            BS_Mappings.ForeColor = SystemColors.ActiveCaption;
            BS_Mappings.FormattingEnabled = true;
            BS_Mappings.Location = new Point(6, 204);
            BS_Mappings.Name = "BS_Mappings";
            BS_Mappings.Size = new Size(218, 23);
            BS_Mappings.TabIndex = 41;
            BS_Mappings.SelectedValueChanged += BS_Mappings_SelectedValueChanged;
            // 
            // BuildSettingsDTFolder_Button
            // 
            BuildSettingsDTFolder_Button.BackColor = Color.FromArgb(75, 68, 138);
            BuildSettingsDTFolder_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            BuildSettingsDTFolder_Button.FlatStyle = FlatStyle.Flat;
            BuildSettingsDTFolder_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BuildSettingsDTFolder_Button.ForeColor = SystemColors.ActiveCaption;
            BuildSettingsDTFolder_Button.Location = new Point(35, 151);
            BuildSettingsDTFolder_Button.Name = "BuildSettingsDTFolder_Button";
            BuildSettingsDTFolder_Button.Size = new Size(159, 26);
            BuildSettingsDTFolder_Button.TabIndex = 40;
            BuildSettingsDTFolder_Button.Text = "Open DataTable Folder";
            BuildSettingsDTFolder_Button.UseVisualStyleBackColor = false;
            BuildSettingsDTFolder_Button.Click += BuildSettingsDTFolder_Button_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.ActiveCaption;
            label16.Location = new Point(13, 100);
            label16.Name = "label16";
            label16.Size = new Size(203, 17);
            label16.TabIndex = 39;
            label16.Text = "DT_GameCharacterCustomization:";
            // 
            // BS_BaseGameCharacterCustomizationFile
            // 
            BS_BaseGameCharacterCustomizationFile.BackColor = Color.FromArgb(32, 34, 81);
            BS_BaseGameCharacterCustomizationFile.FlatStyle = FlatStyle.Flat;
            BS_BaseGameCharacterCustomizationFile.ForeColor = SystemColors.ActiveCaption;
            BS_BaseGameCharacterCustomizationFile.FormattingEnabled = true;
            BS_BaseGameCharacterCustomizationFile.Location = new Point(5, 120);
            BS_BaseGameCharacterCustomizationFile.Name = "BS_BaseGameCharacterCustomizationFile";
            BS_BaseGameCharacterCustomizationFile.Size = new Size(218, 23);
            BS_BaseGameCharacterCustomizationFile.TabIndex = 38;
            BS_BaseGameCharacterCustomizationFile.SelectedValueChanged += BS_Mappings_SelectedValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ActiveCaption;
            label15.Location = new Point(35, 52);
            label15.Name = "label15";
            label15.Size = new Size(159, 17);
            label15.TabIndex = 37;
            label15.Text = "DT_GameCharacterOutfits:";
            // 
            // BS_BaseGameCharacterOutfitFile
            // 
            BS_BaseGameCharacterOutfitFile.BackColor = Color.FromArgb(32, 34, 81);
            BS_BaseGameCharacterOutfitFile.FlatStyle = FlatStyle.Flat;
            BS_BaseGameCharacterOutfitFile.ForeColor = SystemColors.ActiveCaption;
            BS_BaseGameCharacterOutfitFile.FormattingEnabled = true;
            BS_BaseGameCharacterOutfitFile.Location = new Point(6, 72);
            BS_BaseGameCharacterOutfitFile.Name = "BS_BaseGameCharacterOutfitFile";
            BS_BaseGameCharacterOutfitFile.Size = new Size(217, 23);
            BS_BaseGameCharacterOutfitFile.TabIndex = 36;
            BS_BaseGameCharacterOutfitFile.SelectedValueChanged += BS_Mappings_SelectedValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ActiveCaption;
            label14.Location = new Point(61, 5);
            label14.Name = "label14";
            label14.Size = new Size(106, 17);
            label14.TabIndex = 35;
            label14.Text = "DT_ClothesOutfit:";
            // 
            // BS_BaseClothesOutfitFile
            // 
            BS_BaseClothesOutfitFile.BackColor = Color.FromArgb(32, 34, 81);
            BS_BaseClothesOutfitFile.FlatStyle = FlatStyle.Flat;
            BS_BaseClothesOutfitFile.ForeColor = SystemColors.ActiveCaption;
            BS_BaseClothesOutfitFile.FormattingEnabled = true;
            BS_BaseClothesOutfitFile.Location = new Point(5, 25);
            BS_BaseClothesOutfitFile.Name = "BS_BaseClothesOutfitFile";
            BS_BaseClothesOutfitFile.Size = new Size(218, 23);
            BS_BaseClothesOutfitFile.TabIndex = 34;
            BS_BaseClothesOutfitFile.SelectedValueChanged += BS_Mappings_SelectedValueChanged;
            // 
            // RefreshBuildSettings_Button
            // 
            RefreshBuildSettings_Button.BackColor = Color.FromArgb(75, 68, 138);
            RefreshBuildSettings_Button.BackgroundImage = Properties.Resources.Refresh_Icon;
            RefreshBuildSettings_Button.BackgroundImageLayout = ImageLayout.Zoom;
            RefreshBuildSettings_Button.Enabled = false;
            RefreshBuildSettings_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RefreshBuildSettings_Button.FlatStyle = FlatStyle.Flat;
            RefreshBuildSettings_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RefreshBuildSettings_Button.ForeColor = SystemColors.ActiveCaption;
            RefreshBuildSettings_Button.Location = new Point(1066, 643);
            RefreshBuildSettings_Button.Name = "RefreshBuildSettings_Button";
            RefreshBuildSettings_Button.Size = new Size(25, 26);
            RefreshBuildSettings_Button.TabIndex = 43;
            RefreshBuildSettings_Button.UseVisualStyleBackColor = false;
            RefreshBuildSettings_Button.Click += RefreshBuildSettings_Button_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "wlmm files (*.wlmm)|*.wlmm|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(5, 5);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(70, 70);
            Icon_PB.SizeMode = PictureBoxSizeMode.Zoom;
            Icon_PB.TabIndex = 44;
            Icon_PB.TabStop = false;
            Icon_PB.MouseDown += TitlePanel_MouseDown;
            Icon_PB.MouseMove += TitlePanel_MouseMove;
            Icon_PB.MouseUp += TitlePanel_MouseUp;
            // 
            // BugReport_Panel
            // 
            BugReport_Panel.BackColor = Color.FromArgb(75, 68, 138);
            BugReport_Panel.BorderStyle = BorderStyle.FixedSingle;
            BugReport_Panel.Controls.Add(WLMMPost_Link);
            BugReport_Panel.Controls.Add(WildSanctum_Link);
            BugReport_Panel.Controls.Add(BugReport_CloseButton);
            BugReport_Panel.Controls.Add(label7);
            BugReport_Panel.Controls.Add(label18);
            BugReport_Panel.Controls.Add(label19);
            BugReport_Panel.Location = new Point(400, 322);
            BugReport_Panel.Name = "BugReport_Panel";
            BugReport_Panel.Size = new Size(334, 116);
            BugReport_Panel.TabIndex = 45;
            BugReport_Panel.Visible = false;
            // 
            // WLMMPost_Link
            // 
            WLMMPost_Link.ActiveLinkColor = SystemColors.MenuHighlight;
            WLMMPost_Link.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            WLMMPost_Link.AutoSize = true;
            WLMMPost_Link.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WLMMPost_Link.LinkColor = SystemColors.MenuHighlight;
            WLMMPost_Link.Location = new Point(208, 80);
            WLMMPost_Link.Margin = new Padding(4, 0, 4, 0);
            WLMMPost_Link.Name = "WLMMPost_Link";
            WLMMPost_Link.Size = new Size(95, 20);
            WLMMPost_Link.TabIndex = 37;
            WLMMPost_Link.TabStop = true;
            WLMMPost_Link.Tag = "null";
            WLMMPost_Link.Text = "WLMM Post";
            WLMMPost_Link.VisitedLinkColor = SystemColors.MenuHighlight;
            WLMMPost_Link.LinkClicked += WLMMPost_Link_LinkClicked;
            // 
            // WildSanctum_Link
            // 
            WildSanctum_Link.ActiveLinkColor = SystemColors.MenuHighlight;
            WildSanctum_Link.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            WildSanctum_Link.AutoSize = true;
            WildSanctum_Link.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WildSanctum_Link.LinkColor = SystemColors.MenuHighlight;
            WildSanctum_Link.Location = new Point(205, 46);
            WildSanctum_Link.Margin = new Padding(4, 0, 4, 0);
            WildSanctum_Link.Name = "WildSanctum_Link";
            WildSanctum_Link.Size = new Size(107, 20);
            WildSanctum_Link.TabIndex = 36;
            WildSanctum_Link.TabStop = true;
            WildSanctum_Link.Tag = "null";
            WildSanctum_Link.Text = "Wild Sanctum";
            WildSanctum_Link.VisitedLinkColor = SystemColors.MenuHighlight;
            WildSanctum_Link.LinkClicked += WildSanctum_Link_LinkClicked;
            // 
            // BugReport_CloseButton
            // 
            BugReport_CloseButton.Image = Properties.Resources.Close_Icon;
            BugReport_CloseButton.Location = new Point(298, 3);
            BugReport_CloseButton.Name = "BugReport_CloseButton";
            BugReport_CloseButton.Size = new Size(30, 30);
            BugReport_CloseButton.SizeMode = PictureBoxSizeMode.Zoom;
            BugReport_CloseButton.TabIndex = 34;
            BugReport_CloseButton.TabStop = false;
            BugReport_CloseButton.Click += BugReport_CloseButton_Click;
            BugReport_CloseButton.MouseEnter += BugReport_CloseButton_MouseEnter;
            BugReport_CloseButton.MouseLeave += BugReport_CloseButton_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(20, 81);
            label7.Name = "label7";
            label7.Size = new Size(180, 17);
            label7.TabIndex = 33;
            label7.Text = "Report your bug in this post: ";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.ActiveCaption;
            label18.Location = new Point(13, 48);
            label18.Name = "label18";
            label18.Size = new Size(188, 17);
            label18.TabIndex = 30;
            label18.Text = "Join the Wild Sanctum Discord:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.ActiveCaption;
            label19.Location = new Point(108, 4);
            label19.Name = "label19";
            label19.Size = new Size(116, 30);
            label19.TabIndex = 2;
            label19.Text = "Bug Report";
            // 
            // OpenWLFolder_Button
            // 
            OpenWLFolder_Button.BackColor = Color.FromArgb(75, 68, 138);
            OpenWLFolder_Button.Enabled = false;
            OpenWLFolder_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            OpenWLFolder_Button.FlatStyle = FlatStyle.Flat;
            OpenWLFolder_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OpenWLFolder_Button.ForeColor = SystemColors.ActiveCaption;
            OpenWLFolder_Button.Location = new Point(939, 226);
            OpenWLFolder_Button.Name = "OpenWLFolder_Button";
            OpenWLFolder_Button.Size = new Size(148, 26);
            OpenWLFolder_Button.TabIndex = 46;
            OpenWLFolder_Button.Text = "Open Wild Life Folder";
            OpenWLFolder_Button.UseVisualStyleBackColor = false;
            OpenWLFolder_Button.Click += OpenWLFolder_Button_Click;
            // 
            // CreateBuildLog_Button
            // 
            CreateBuildLog_Button.BackColor = Color.FromArgb(75, 68, 138);
            CreateBuildLog_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CreateBuildLog_Button.FlatStyle = FlatStyle.Flat;
            CreateBuildLog_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateBuildLog_Button.ForeColor = SystemColors.ActiveCaption;
            CreateBuildLog_Button.Location = new Point(939, 182);
            CreateBuildLog_Button.Name = "CreateBuildLog_Button";
            CreateBuildLog_Button.Size = new Size(148, 26);
            CreateBuildLog_Button.TabIndex = 48;
            CreateBuildLog_Button.Text = "Create Build Log";
            CreateBuildLog_Button.UseVisualStyleBackColor = false;
            CreateBuildLog_Button.Click += CreateBuildLog_Button_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog1";
            openFileDialog2.Filter = "Wild Life Executable (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog2.Multiselect = true;
            // 
            // MetaDataPatcher_Button
            // 
            MetaDataPatcher_Button.BackColor = Color.FromArgb(75, 68, 138);
            MetaDataPatcher_Button.Enabled = false;
            MetaDataPatcher_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            MetaDataPatcher_Button.FlatStyle = FlatStyle.Flat;
            MetaDataPatcher_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MetaDataPatcher_Button.ForeColor = SystemColors.ActiveCaption;
            MetaDataPatcher_Button.Location = new Point(939, 138);
            MetaDataPatcher_Button.Name = "MetaDataPatcher_Button";
            MetaDataPatcher_Button.Size = new Size(148, 26);
            MetaDataPatcher_Button.TabIndex = 49;
            MetaDataPatcher_Button.Text = "Patch MetaData";
            MetaDataPatcher_Button.UseVisualStyleBackColor = false;
            MetaDataPatcher_Button.Click += MetaDataPatcher_Button_Click;
            // 
            // ExpandedLink_Panel
            // 
            ExpandedLink_Panel.BackColor = Color.FromArgb(75, 68, 138);
            ExpandedLink_Panel.BorderStyle = BorderStyle.FixedSingle;
            ExpandedLink_Panel.Controls.Add(ExpandedLinkCopy_LL);
            ExpandedLink_Panel.Controls.Add(ExpandedLink_LL);
            ExpandedLink_Panel.Controls.Add(ExpandedLink_CloseButton);
            ExpandedLink_Panel.Controls.Add(label22);
            ExpandedLink_Panel.Location = new Point(213, 330);
            ExpandedLink_Panel.Name = "ExpandedLink_Panel";
            ExpandedLink_Panel.Size = new Size(765, 100);
            ExpandedLink_Panel.TabIndex = 50;
            ExpandedLink_Panel.Visible = false;
            // 
            // ExpandedLinkCopy_LL
            // 
            ExpandedLinkCopy_LL.ActiveLinkColor = SystemColors.ActiveCaption;
            ExpandedLinkCopy_LL.AutoSize = true;
            ExpandedLinkCopy_LL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpandedLinkCopy_LL.LinkColor = SystemColors.Highlight;
            ExpandedLinkCopy_LL.Location = new Point(481, 11);
            ExpandedLinkCopy_LL.Name = "ExpandedLinkCopy_LL";
            ExpandedLinkCopy_LL.Size = new Size(165, 21);
            ExpandedLinkCopy_LL.TabIndex = 37;
            ExpandedLinkCopy_LL.TabStop = true;
            ExpandedLinkCopy_LL.Tag = "https://discord.com/channels/1105479421932097566/1220011707469004893";
            ExpandedLinkCopy_LL.Text = "Copy link to Clipboard";
            ExpandedLinkCopy_LL.VisitedLinkColor = SystemColors.Highlight;
            ExpandedLinkCopy_LL.LinkClicked += ExpandedLinkCopy_LL_LinkClicked;
            // 
            // ExpandedLink_LL
            // 
            ExpandedLink_LL.ActiveLinkColor = SystemColors.MenuHighlight;
            ExpandedLink_LL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExpandedLink_LL.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpandedLink_LL.LinkColor = SystemColors.MenuHighlight;
            ExpandedLink_LL.Location = new Point(21, 40);
            ExpandedLink_LL.Margin = new Padding(4, 0, 4, 0);
            ExpandedLink_LL.Name = "ExpandedLink_LL";
            ExpandedLink_LL.Size = new Size(726, 48);
            ExpandedLink_LL.TabIndex = 36;
            ExpandedLink_LL.TabStop = true;
            ExpandedLink_LL.Tag = "null";
            ExpandedLink_LL.Text = "https://discord.com/channels/1080948953161400320/1276994043196211301";
            ExpandedLink_LL.TextAlign = ContentAlignment.MiddleCenter;
            ExpandedLink_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            ExpandedLink_LL.LinkClicked += ExpandedLink_LL_LinkClicked;
            // 
            // ExpandedLink_CloseButton
            // 
            ExpandedLink_CloseButton.Image = Properties.Resources.Close_Icon;
            ExpandedLink_CloseButton.Location = new Point(729, 5);
            ExpandedLink_CloseButton.Name = "ExpandedLink_CloseButton";
            ExpandedLink_CloseButton.Size = new Size(30, 30);
            ExpandedLink_CloseButton.SizeMode = PictureBoxSizeMode.Zoom;
            ExpandedLink_CloseButton.TabIndex = 34;
            ExpandedLink_CloseButton.TabStop = false;
            ExpandedLink_CloseButton.Click += ExpandedLink_CloseButton_Click;
            ExpandedLink_CloseButton.MouseEnter += ExpandedLink_CloseButton_MouseEnter;
            ExpandedLink_CloseButton.MouseLeave += ExpandedLink_CloseButton_MouseLeave;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ActiveCaption;
            label22.Location = new Point(356, 4);
            label22.Name = "label22";
            label22.Size = new Size(50, 30);
            label22.TabIndex = 2;
            label22.Text = "Link";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(1134, 761);
            ControlBox = false;
            Controls.Add(ExpandedLink_Panel);
            Controls.Add(MetaDataPatcher_Button);
            Controls.Add(CreateBuildLog_Button);
            Controls.Add(OpenWLFolder_Button);
            Controls.Add(BugReport_Panel);
            Controls.Add(Icon_PB);
            Controls.Add(RefreshBuildSettings_Button);
            Controls.Add(BuildSettings_Panel);
            Controls.Add(BuildSettings_Button);
            Controls.Add(SelectWLVersion_Panel);
            Controls.Add(ProgressPanel);
            Controls.Add(ModCreator_Button);
            Controls.Add(ChangesMade_Label);
            Controls.Add(pictureBox1);
            Controls.Add(BuildMods_Button);
            Controls.Add(ModMain_Panel);
            Controls.Add(WLVersionLoaded_Label);
            Controls.Add(LoadGame_Button);
            Controls.Add(Close_Button);
            Controls.Add(Separator_1);
            Controls.Add(TitlePanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wild Life Mod Manager - ";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            ModMain_Panel.ResumeLayout(false);
            ModMain_Panel.PerformLayout();
            DragNDrop_Panel.ResumeLayout(false);
            DragNDrop_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            NoGameLoaded_Panel.ResumeLayout(false);
            NoGameLoaded_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ModFlow_Panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            SelectWLVersion_Panel.ResumeLayout(false);
            SelectWLVersion_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SelectWLVersion_CloseButton).EndInit();
            BuildSettings_Panel.ResumeLayout(false);
            BuildSettings_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            BugReport_Panel.ResumeLayout(false);
            BugReport_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BugReport_CloseButton).EndInit();
            ExpandedLink_Panel.ResumeLayout(false);
            ExpandedLink_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ExpandedLink_CloseButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel TitlePanel;
        private Label TitleLabel;
        private PictureBox Separator_1;
        private PictureBox Close_Button;
        private Label ByLuckyLabel;
        private Button LoadGame_Button;
        private Label WLVersionLoaded_Label;
        private Panel ModMain_Panel;
        private Button AddMod_Button;
        private Button DisableMods_Button;
        private Button EnableMods_Button;
        private FlowLayoutPanel ModFlow_Panel;
        private Button BuildMods_Button;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label label4;
        private CheckBox checkBox1;
        private Label ChangesMade_Label;
        private Label label6;
        private Button RemoveMods_Button;
        private Button ModCreator_Button;
        private LinkLabel linkLabel2;
        private Panel ProgressPanel;
        private Label ProgressInfo_Label;
        private ProgressBar BuildModProgress_PB;
        private Label ProgressTitle_Label;
        private Panel DragNDrop_Panel;
        private PictureBox pictureBox3;
        private Label label8;
        private Label label9;
        private Panel NoGameLoaded_Panel;
        private PictureBox pictureBox4;
        private Label label11;
        private Panel SelectWLVersion_Panel;
        private Label label10;
        private Button SelectWLVersionBrowse_Button;
        private Label label12;
        private TextBox SelectWLVersionPath_TB;
        private Label label13;
        private ComboBox SelectWLVersion_CB;
        private FolderBrowserDialog folderBrowserDialog1;
        private PictureBox SelectWLVersion_CloseButton;
        private Button SelectWLVersionConfirm_Button;
        private Button BuildSettings_Button;
        private Panel BuildSettings_Panel;
        private Label label14;
        private ComboBox BS_BaseClothesOutfitFile;
        private Label label16;
        private ComboBox BS_BaseGameCharacterCustomizationFile;
        private Label label15;
        private ComboBox BS_BaseGameCharacterOutfitFile;
        private Button BuildSettingsDTFolder_Button;
        private Label NoModsFound_Label;
        private Label label1;
        private ComboBox BS_Mappings;
        private Label label17;
        private Button RefreshBuildSettings_Button;
        private OpenFileDialog openFileDialog1;
        private PictureBox Icon_PB;
        private LinkLabel UpdateLink;
        private LinkLabel BugReportLink;
        private Panel BugReport_Panel;
        private LinkLabel WLMMPost_Link;
        private LinkLabel WildSanctum_Link;
        private PictureBox BugReport_CloseButton;
        private Label label7;
        private Label label18;
        private Label label19;
        private Button OpenWLFolder_Button;
        private Button CreateBuildLog_Button;
        private OpenFileDialog openFileDialog2;
        private Button MetaDataPatcher_Button;
        private Panel ExpandedLink_Panel;
        private LinkLabel ExpandedLink_LL;
        private PictureBox ExpandedLink_CloseButton;
        private Label label22;
        private LinkLabel ExpandedLinkCopy_LL;
    }
}
