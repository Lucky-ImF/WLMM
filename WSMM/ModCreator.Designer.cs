namespace WSMM
{
    partial class ModCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModCreator));
            Close_Button = new PictureBox();
            Separator_1 = new PictureBox();
            TitlePanel = new Panel();
            ByLuckyLabel = new Label();
            TitleLabel = new Label();
            BuildMods_Button = new Button();
            openFileDialog1 = new OpenFileDialog();
            PakList = new ListView();
            IconImageList = new ImageList(components);
            label1 = new Label();
            RemovePak_Button = new Button();
            AddPak_Button = new Button();
            RemoveAutoMod_Button = new Button();
            AddAutoMod_Button = new Button();
            label2 = new Label();
            AutoModList = new ListView();
            CreateAutoMod_Button = new Button();
            panel1 = new Panel();
            CopyMetaData_Button = new Button();
            ModIconSetDefault_LL = new LinkLabel();
            ModIconBrowse_Button = new Button();
            label9 = new Label();
            ModIconPath_TB = new TextBox();
            ModIcon_Preview = new PictureBox();
            label8 = new Label();
            ModURL_TB = new TextBox();
            label7 = new Label();
            ModVersion_TB = new TextBox();
            label6 = new Label();
            SupportedWLVersions_CLB = new CheckedListBox();
            label5 = new Label();
            ModAuthor_TB = new TextBox();
            label4 = new Label();
            ModName_TB = new TextBox();
            label3 = new Label();
            openFileDialog2 = new OpenFileDialog();
            ProgressInfo_Label = new Label();
            BuildModProgress_PB = new ProgressBar();
            OpenModFolder_Button = new Button();
            LoadMod_Button = new Button();
            openFileDialog3 = new OpenFileDialog();
            Icon_PB = new PictureBox();
            CopyMarketplaceData_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            TitlePanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ModIcon_Preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            SuspendLayout();
            // 
            // Close_Button
            // 
            Close_Button.Image = Properties.Resources.Close_Icon;
            Close_Button.Location = new Point(602, 5);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(52, 50);
            Close_Button.SizeMode = PictureBoxSizeMode.Zoom;
            Close_Button.TabIndex = 4;
            Close_Button.TabStop = false;
            Close_Button.Click += Close_Button_Click;
            Close_Button.MouseEnter += Close_Button_MouseEnter;
            Close_Button.MouseLeave += Close_Button_MouseLeave;
            // 
            // Separator_1
            // 
            Separator_1.BackColor = SystemColors.ActiveCaption;
            Separator_1.Location = new Point(84, 38);
            Separator_1.Name = "Separator_1";
            Separator_1.Size = new Size(490, 2);
            Separator_1.TabIndex = 3;
            Separator_1.TabStop = false;
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = Color.FromArgb(32, 34, 81);
            TitlePanel.Controls.Add(ByLuckyLabel);
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Location = new Point(1, 1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(656, 40);
            TitlePanel.TabIndex = 2;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
            TitlePanel.MouseMove += TitlePanel_MouseMove;
            TitlePanel.MouseUp += TitlePanel_MouseUp;
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
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = SystemColors.ActiveCaption;
            TitleLabel.Location = new Point(221, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(218, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "WLMM - Mod Creator";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // BuildMods_Button
            // 
            BuildMods_Button.BackColor = Color.FromArgb(75, 68, 138);
            BuildMods_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            BuildMods_Button.FlatStyle = FlatStyle.Flat;
            BuildMods_Button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BuildMods_Button.ForeColor = SystemColors.ActiveCaption;
            BuildMods_Button.Location = new Point(220, 685);
            BuildMods_Button.Name = "BuildMods_Button";
            BuildMods_Button.Size = new Size(213, 45);
            BuildMods_Button.TabIndex = 5;
            BuildMods_Button.Text = "Create Mod";
            BuildMods_Button.UseVisualStyleBackColor = false;
            BuildMods_Button.Click += BuildMods_Button_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Multiselect = true;
            // 
            // PakList
            // 
            PakList.AllowDrop = true;
            PakList.BackColor = Color.FromArgb(32, 34, 81);
            PakList.ForeColor = SystemColors.InactiveCaption;
            PakList.LargeImageList = IconImageList;
            PakList.Location = new Point(44, 89);
            PakList.Name = "PakList";
            PakList.ShowItemToolTips = true;
            PakList.Size = new Size(570, 107);
            PakList.TabIndex = 6;
            PakList.UseCompatibleStateImageBehavior = false;
            PakList.DragDrop += PakList_DragDrop;
            PakList.DragEnter += PakList_DragEnter;
            // 
            // IconImageList
            // 
            IconImageList.ColorDepth = ColorDepth.Depth32Bit;
            IconImageList.ImageStream = (ImageListStreamer)resources.GetObject("IconImageList.ImageStream");
            IconImageList.TransparentColor = Color.Transparent;
            IconImageList.Images.SetKeyName(0, "Pak_Icon.png");
            IconImageList.Images.SetKeyName(1, "AutoMod_Icon.png");
            IconImageList.Images.SetKeyName(2, "AutoMod_Collection_Icon.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(300, 56);
            label1.Name = "label1";
            label1.Size = new Size(59, 30);
            label1.TabIndex = 2;
            label1.Text = ".Paks";
            // 
            // RemovePak_Button
            // 
            RemovePak_Button.BackColor = Color.FromArgb(75, 68, 138);
            RemovePak_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RemovePak_Button.FlatStyle = FlatStyle.Flat;
            RemovePak_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemovePak_Button.ForeColor = Color.LightCoral;
            RemovePak_Button.Location = new Point(446, 61);
            RemovePak_Button.Name = "RemovePak_Button";
            RemovePak_Button.Size = new Size(83, 26);
            RemovePak_Button.TabIndex = 8;
            RemovePak_Button.Text = "Remove -";
            RemovePak_Button.UseVisualStyleBackColor = false;
            RemovePak_Button.Click += RemovePak_Button_Click;
            // 
            // AddPak_Button
            // 
            AddPak_Button.BackColor = Color.FromArgb(75, 68, 138);
            AddPak_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            AddPak_Button.FlatStyle = FlatStyle.Flat;
            AddPak_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddPak_Button.ForeColor = Color.SeaGreen;
            AddPak_Button.Location = new Point(535, 61);
            AddPak_Button.Name = "AddPak_Button";
            AddPak_Button.Size = new Size(79, 26);
            AddPak_Button.TabIndex = 7;
            AddPak_Button.Text = "Add +";
            AddPak_Button.UseVisualStyleBackColor = false;
            AddPak_Button.Click += AddPak_Button_Click;
            // 
            // RemoveAutoMod_Button
            // 
            RemoveAutoMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            RemoveAutoMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RemoveAutoMod_Button.FlatStyle = FlatStyle.Flat;
            RemoveAutoMod_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemoveAutoMod_Button.ForeColor = Color.LightCoral;
            RemoveAutoMod_Button.Location = new Point(446, 203);
            RemoveAutoMod_Button.Name = "RemoveAutoMod_Button";
            RemoveAutoMod_Button.Size = new Size(83, 26);
            RemoveAutoMod_Button.TabIndex = 12;
            RemoveAutoMod_Button.Text = "Remove -";
            RemoveAutoMod_Button.UseVisualStyleBackColor = false;
            RemoveAutoMod_Button.Click += RemoveAutoMod_Button_Click;
            // 
            // AddAutoMod_Button
            // 
            AddAutoMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            AddAutoMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            AddAutoMod_Button.FlatStyle = FlatStyle.Flat;
            AddAutoMod_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddAutoMod_Button.ForeColor = Color.SeaGreen;
            AddAutoMod_Button.Location = new Point(535, 203);
            AddAutoMod_Button.Name = "AddAutoMod_Button";
            AddAutoMod_Button.Size = new Size(79, 26);
            AddAutoMod_Button.TabIndex = 11;
            AddAutoMod_Button.Text = "Add +";
            AddAutoMod_Button.UseVisualStyleBackColor = false;
            AddAutoMod_Button.Click += AddAutoMod_Button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(279, 198);
            label2.Name = "label2";
            label2.Size = new Size(101, 30);
            label2.TabIndex = 9;
            label2.Text = "AutoMod";
            // 
            // AutoModList
            // 
            AutoModList.AllowDrop = true;
            AutoModList.BackColor = Color.FromArgb(32, 34, 81);
            AutoModList.ForeColor = SystemColors.InactiveCaption;
            AutoModList.LargeImageList = IconImageList;
            AutoModList.Location = new Point(44, 231);
            AutoModList.Name = "AutoModList";
            AutoModList.ShowItemToolTips = true;
            AutoModList.Size = new Size(570, 107);
            AutoModList.TabIndex = 10;
            AutoModList.UseCompatibleStateImageBehavior = false;
            AutoModList.DragDrop += AutoModList_DragDrop;
            AutoModList.DragEnter += AutoModList_DragEnter;
            AutoModList.DoubleClick += AutoModList_DoubleClick;
            // 
            // CreateAutoMod_Button
            // 
            CreateAutoMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            CreateAutoMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CreateAutoMod_Button.FlatStyle = FlatStyle.Flat;
            CreateAutoMod_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateAutoMod_Button.ForeColor = Color.Yellow;
            CreateAutoMod_Button.Location = new Point(44, 203);
            CreateAutoMod_Button.Name = "CreateAutoMod_Button";
            CreateAutoMod_Button.Size = new Size(79, 26);
            CreateAutoMod_Button.TabIndex = 13;
            CreateAutoMod_Button.Text = "Create";
            CreateAutoMod_Button.UseVisualStyleBackColor = false;
            CreateAutoMod_Button.Click += CreateAutoMod_Button_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(CopyMarketplaceData_Button);
            panel1.Controls.Add(CopyMetaData_Button);
            panel1.Controls.Add(ModIconSetDefault_LL);
            panel1.Controls.Add(ModIconBrowse_Button);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(ModIconPath_TB);
            panel1.Controls.Add(ModIcon_Preview);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(ModURL_TB);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(ModVersion_TB);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(SupportedWLVersions_CLB);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ModAuthor_TB);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(ModName_TB);
            panel1.Location = new Point(44, 373);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 303);
            panel1.TabIndex = 14;
            // 
            // CopyMetaData_Button
            // 
            CopyMetaData_Button.BackColor = Color.FromArgb(75, 68, 138);
            CopyMetaData_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CopyMetaData_Button.FlatStyle = FlatStyle.Flat;
            CopyMetaData_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyMetaData_Button.ForeColor = SystemColors.ActiveCaption;
            CopyMetaData_Button.Location = new Point(327, 266);
            CopyMetaData_Button.Name = "CopyMetaData_Button";
            CopyMetaData_Button.Size = new Size(228, 27);
            CopyMetaData_Button.TabIndex = 20;
            CopyMetaData_Button.Text = "Copy MetaData Patch to Clipboard";
            CopyMetaData_Button.UseVisualStyleBackColor = false;
            CopyMetaData_Button.Click += CopyMetaData_Button_Click;
            // 
            // ModIconSetDefault_LL
            // 
            ModIconSetDefault_LL.ActiveLinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ModIconSetDefault_LL.AutoSize = true;
            ModIconSetDefault_LL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconSetDefault_LL.LinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.Location = new Point(365, 199);
            ModIconSetDefault_LL.Margin = new Padding(4, 0, 4, 0);
            ModIconSetDefault_LL.Name = "ModIconSetDefault_LL";
            ModIconSetDefault_LL.Size = new Size(86, 16);
            ModIconSetDefault_LL.TabIndex = 37;
            ModIconSetDefault_LL.TabStop = true;
            ModIconSetDefault_LL.Tag = "null";
            ModIconSetDefault_LL.Text = "Set to Default";
            ModIconSetDefault_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.LinkClicked += ModIconSetDefault_LL_LinkClicked;
            // 
            // ModIconBrowse_Button
            // 
            ModIconBrowse_Button.BackColor = Color.FromArgb(75, 68, 138);
            ModIconBrowse_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ModIconBrowse_Button.FlatStyle = FlatStyle.Flat;
            ModIconBrowse_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconBrowse_Button.ForeColor = SystemColors.ActiveCaption;
            ModIconBrowse_Button.Location = new Point(477, 193);
            ModIconBrowse_Button.Name = "ModIconBrowse_Button";
            ModIconBrowse_Button.Size = new Size(79, 22);
            ModIconBrowse_Button.TabIndex = 28;
            ModIconBrowse_Button.Text = "Browse...";
            ModIconBrowse_Button.UseVisualStyleBackColor = false;
            ModIconBrowse_Button.Click += ModIconBrowse_Button_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaption;
            label9.Location = new Point(283, 198);
            label9.Name = "label9";
            label9.Size = new Size(64, 17);
            label9.TabIndex = 27;
            label9.Text = "Mod Icon";
            // 
            // ModIconPath_TB
            // 
            ModIconPath_TB.AllowDrop = true;
            ModIconPath_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModIconPath_TB.BorderStyle = BorderStyle.FixedSingle;
            ModIconPath_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconPath_TB.ForeColor = SystemColors.ActiveCaption;
            ModIconPath_TB.Location = new Point(118, 218);
            ModIconPath_TB.Name = "ModIconPath_TB";
            ModIconPath_TB.Size = new Size(438, 27);
            ModIconPath_TB.TabIndex = 26;
            ModIconPath_TB.Text = "Default";
            ModIconPath_TB.TextAlign = HorizontalAlignment.Center;
            ModIconPath_TB.TextChanged += ModIconPath_TB_TextChanged;
            ModIconPath_TB.DragDrop += ModIconPath_TB_DragDrop;
            ModIconPath_TB.DragEnter += ModIconPath_TB_DragEnter;
            // 
            // ModIcon_Preview
            // 
            ModIcon_Preview.BorderStyle = BorderStyle.FixedSingle;
            ModIcon_Preview.Location = new Point(12, 195);
            ModIcon_Preview.Name = "ModIcon_Preview";
            ModIcon_Preview.Size = new Size(100, 100);
            ModIcon_Preview.SizeMode = PictureBoxSizeMode.Zoom;
            ModIcon_Preview.TabIndex = 25;
            ModIcon_Preview.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaption;
            label8.Location = new Point(253, 142);
            label8.Name = "label8";
            label8.Size = new Size(63, 17);
            label8.TabIndex = 24;
            label8.Text = "Mod URL";
            // 
            // ModURL_TB
            // 
            ModURL_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModURL_TB.BorderStyle = BorderStyle.FixedSingle;
            ModURL_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModURL_TB.ForeColor = SystemColors.ActiveCaption;
            ModURL_TB.Location = new Point(12, 162);
            ModURL_TB.Name = "ModURL_TB";
            ModURL_TB.Size = new Size(544, 27);
            ModURL_TB.TabIndex = 23;
            ModURL_TB.Text = "None";
            ModURL_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(380, 61);
            label7.Name = "label7";
            label7.Size = new Size(83, 17);
            label7.TabIndex = 22;
            label7.Text = "Mod Version";
            // 
            // ModVersion_TB
            // 
            ModVersion_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModVersion_TB.BorderStyle = BorderStyle.FixedSingle;
            ModVersion_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModVersion_TB.ForeColor = SystemColors.ActiveCaption;
            ModVersion_TB.Location = new Point(287, 81);
            ModVersion_TB.Name = "ModVersion_TB";
            ModVersion_TB.Size = new Size(269, 27);
            ModVersion_TB.TabIndex = 21;
            ModVersion_TB.Text = "v.1.0";
            ModVersion_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(84, 61);
            label6.Name = "label6";
            label6.Size = new Size(123, 17);
            label6.TabIndex = 20;
            label6.Text = "Supported Versions";
            // 
            // SupportedWLVersions_CLB
            // 
            SupportedWLVersions_CLB.BackColor = Color.FromArgb(75, 68, 138);
            SupportedWLVersions_CLB.BorderStyle = BorderStyle.FixedSingle;
            SupportedWLVersions_CLB.ForeColor = SystemColors.ActiveCaption;
            SupportedWLVersions_CLB.FormattingEnabled = true;
            SupportedWLVersions_CLB.Location = new Point(12, 81);
            SupportedWLVersions_CLB.Name = "SupportedWLVersions_CLB";
            SupportedWLVersions_CLB.ScrollAlwaysVisible = true;
            SupportedWLVersions_CLB.Size = new Size(269, 56);
            SupportedWLVersions_CLB.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(383, 7);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 18;
            label5.Text = "Mod Author";
            // 
            // ModAuthor_TB
            // 
            ModAuthor_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModAuthor_TB.BorderStyle = BorderStyle.FixedSingle;
            ModAuthor_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModAuthor_TB.ForeColor = SystemColors.ActiveCaption;
            ModAuthor_TB.Location = new Point(287, 27);
            ModAuthor_TB.Name = "ModAuthor_TB";
            ModAuthor_TB.Size = new Size(269, 27);
            ModAuthor_TB.TabIndex = 17;
            ModAuthor_TB.Text = "Me";
            ModAuthor_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(112, 7);
            label4.Name = "label4";
            label4.Size = new Size(75, 17);
            label4.TabIndex = 16;
            label4.Text = "Mod Name";
            // 
            // ModName_TB
            // 
            ModName_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModName_TB.BorderStyle = BorderStyle.FixedSingle;
            ModName_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_TB.ForeColor = SystemColors.ActiveCaption;
            ModName_TB.Location = new Point(12, 27);
            ModName_TB.Name = "ModName_TB";
            ModName_TB.Size = new Size(269, 27);
            ModName_TB.TabIndex = 0;
            ModName_TB.Text = "My Mod";
            ModName_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(268, 340);
            label3.Name = "label3";
            label3.Size = new Size(122, 30);
            label3.TabIndex = 15;
            label3.Text = "Information";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            openFileDialog2.Filter = "PNG files (*.PNG)|*.PNG";
            // 
            // ProgressInfo_Label
            // 
            ProgressInfo_Label.AutoSize = true;
            ProgressInfo_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressInfo_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressInfo_Label.Location = new Point(279, 687);
            ProgressInfo_Label.Name = "ProgressInfo_Label";
            ProgressInfo_Label.Size = new Size(90, 21);
            ProgressInfo_Label.TabIndex = 17;
            ProgressInfo_Label.Text = "Initializing...";
            ProgressInfo_Label.Visible = false;
            // 
            // BuildModProgress_PB
            // 
            BuildModProgress_PB.Location = new Point(60, 714);
            BuildModProgress_PB.Maximum = 5;
            BuildModProgress_PB.Name = "BuildModProgress_PB";
            BuildModProgress_PB.Size = new Size(541, 13);
            BuildModProgress_PB.TabIndex = 16;
            BuildModProgress_PB.Visible = false;
            // 
            // OpenModFolder_Button
            // 
            OpenModFolder_Button.BackColor = Color.FromArgb(75, 68, 138);
            OpenModFolder_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            OpenModFolder_Button.FlatStyle = FlatStyle.Flat;
            OpenModFolder_Button.Font = new Font("Segoe UI", 12F);
            OpenModFolder_Button.ForeColor = SystemColors.ActiveCaption;
            OpenModFolder_Button.Location = new Point(31, 692);
            OpenModFolder_Button.Name = "OpenModFolder_Button";
            OpenModFolder_Button.Size = new Size(170, 31);
            OpenModFolder_Button.TabIndex = 18;
            OpenModFolder_Button.Text = "Open Mod Folder";
            OpenModFolder_Button.UseVisualStyleBackColor = false;
            OpenModFolder_Button.Click += OpenModFolder_Button_Click;
            // 
            // LoadMod_Button
            // 
            LoadMod_Button.BackColor = Color.FromArgb(75, 68, 138);
            LoadMod_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            LoadMod_Button.FlatStyle = FlatStyle.Flat;
            LoadMod_Button.Font = new Font("Segoe UI", 12F);
            LoadMod_Button.ForeColor = SystemColors.ActiveCaption;
            LoadMod_Button.Location = new Point(452, 692);
            LoadMod_Button.Name = "LoadMod_Button";
            LoadMod_Button.Size = new Size(175, 31);
            LoadMod_Button.TabIndex = 19;
            LoadMod_Button.Text = "Load Mod";
            LoadMod_Button.UseVisualStyleBackColor = false;
            LoadMod_Button.Click += LoadMod_Button_Click;
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            openFileDialog3.Filter = ".wlmm files (*.wlmm)|*.wlmm";
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(5, 5);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(70, 70);
            Icon_PB.SizeMode = PictureBoxSizeMode.Zoom;
            Icon_PB.TabIndex = 2;
            Icon_PB.TabStop = false;
            Icon_PB.MouseDown += TitlePanel_MouseDown;
            Icon_PB.MouseMove += TitlePanel_MouseMove;
            Icon_PB.MouseUp += TitlePanel_MouseUp;
            // 
            // CopyMarketplaceData_Button
            // 
            CopyMarketplaceData_Button.BackColor = Color.FromArgb(75, 68, 138);
            CopyMarketplaceData_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CopyMarketplaceData_Button.FlatStyle = FlatStyle.Flat;
            CopyMarketplaceData_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyMarketplaceData_Button.ForeColor = SystemColors.ActiveCaption;
            CopyMarketplaceData_Button.Location = new Point(119, 266);
            CopyMarketplaceData_Button.Name = "CopyMarketplaceData_Button";
            CopyMarketplaceData_Button.Size = new Size(202, 27);
            CopyMarketplaceData_Button.TabIndex = 38;
            CopyMarketplaceData_Button.Text = "Copy Marketplace Data";
            CopyMarketplaceData_Button.UseVisualStyleBackColor = false;
            CopyMarketplaceData_Button.Click += CopyMarketplaceData_Button_Click;
            // 
            // ModCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(658, 739);
            ControlBox = false;
            Controls.Add(Icon_PB);
            Controls.Add(ProgressInfo_Label);
            Controls.Add(BuildModProgress_PB);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(CreateAutoMod_Button);
            Controls.Add(RemoveAutoMod_Button);
            Controls.Add(AddAutoMod_Button);
            Controls.Add(label2);
            Controls.Add(AutoModList);
            Controls.Add(RemovePak_Button);
            Controls.Add(AddPak_Button);
            Controls.Add(label1);
            Controls.Add(PakList);
            Controls.Add(BuildMods_Button);
            Controls.Add(Close_Button);
            Controls.Add(Separator_1);
            Controls.Add(TitlePanel);
            Controls.Add(OpenModFolder_Button);
            Controls.Add(LoadMod_Button);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModCreator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WLMM - Mod Creator";
            Load += ModCreator_Load;
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ModIcon_Preview).EndInit();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Close_Button;
        private PictureBox Separator_1;
        private Panel TitlePanel;
        private Label ByLuckyLabel;
        private Label TitleLabel;
        private Button BuildMods_Button;
        private OpenFileDialog openFileDialog1;
        private ListView PakList;
        private ImageList IconImageList;
        private Label label1;
        private Button RemovePak_Button;
        private Button AddPak_Button;
        private Button RemoveAutoMod_Button;
        private Button AddAutoMod_Button;
        private Label label2;
        private ListView AutoModList;
        private Button CreateAutoMod_Button;
        private Panel panel1;
        private Label label3;
        private CheckedListBox SupportedWLVersions_CLB;
        private Label label5;
        private TextBox ModAuthor_TB;
        private Label label4;
        private TextBox ModName_TB;
        private Label label6;
        private Button ModIconBrowse_Button;
        private Label label9;
        private TextBox ModIconPath_TB;
        private PictureBox ModIcon_Preview;
        private Label label8;
        private TextBox ModURL_TB;
        private Label label7;
        private TextBox ModVersion_TB;
        private OpenFileDialog openFileDialog2;
        private Label ProgressInfo_Label;
        private ProgressBar BuildModProgress_PB;
        private Button OpenModFolder_Button;
        private Button LoadMod_Button;
        private OpenFileDialog openFileDialog3;
        private PictureBox Icon_PB;
        private LinkLabel ModIconSetDefault_LL;
        private Button CopyMetaData_Button;
        private Button CopyMarketplaceData_Button;
    }
}