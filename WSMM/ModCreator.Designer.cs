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
            ManagePrereqs_Button = new Button();
            AffectedCharacters_Sort_LL = new LinkLabel();
            AffectedCharacterSetWithAutoMod_LL = new LinkLabel();
            label11 = new Label();
            AffectedCharacters_CLB = new CheckedListBox();
            label10 = new Label();
            Categories_CLB = new CheckedListBox();
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
            toolTip1 = new ToolTip(components);
            StopEditing_LL = new LinkLabel();
            CurrentlyEditing_LL = new LinkLabel();
            label106 = new Label();
            AutoModList_Expand_Button = new Button();
            PaksList_Expand_Button = new Button();
            PrereqManager_Panel = new Panel();
            PrereqRemove_Button = new Button();
            label12 = new Label();
            PrereqAdd_Button = new Button();
            PrereqAdd_TB = new TextBox();
            label15 = new Label();
            Prereqs_LB = new ListBox();
            linkLabel2 = new LinkLabel();
            SearchPanel_AM = new Panel();
            SearchClear_AM = new Button();
            label21 = new Label();
            SearchTB_AM = new TextBox();
            SearchPanel_Pak = new Panel();
            SearchClear_Pak = new Button();
            label13 = new Label();
            SearchTB_Pak = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            TitlePanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ModIcon_Preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            PrereqManager_Panel.SuspendLayout();
            SearchPanel_AM.SuspendLayout();
            SearchPanel_Pak.SuspendLayout();
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
            BuildMods_Button.Location = new Point(220, 800);
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
            AutoModList.TileSize = new Size(64, 64);
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
            panel1.Controls.Add(ManagePrereqs_Button);
            panel1.Controls.Add(AffectedCharacters_Sort_LL);
            panel1.Controls.Add(AffectedCharacterSetWithAutoMod_LL);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(AffectedCharacters_CLB);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(Categories_CLB);
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
            panel1.Size = new Size(570, 403);
            panel1.TabIndex = 14;
            // 
            // ManagePrereqs_Button
            // 
            ManagePrereqs_Button.BackColor = Color.FromArgb(75, 68, 138);
            ManagePrereqs_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ManagePrereqs_Button.FlatStyle = FlatStyle.Flat;
            ManagePrereqs_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ManagePrereqs_Button.ForeColor = Color.White;
            ManagePrereqs_Button.Location = new Point(287, 104);
            ManagePrereqs_Button.Name = "ManagePrereqs_Button";
            ManagePrereqs_Button.Size = new Size(269, 26);
            ManagePrereqs_Button.TabIndex = 46;
            ManagePrereqs_Button.Text = "Manage Dependencies: 0";
            ManagePrereqs_Button.UseVisualStyleBackColor = false;
            ManagePrereqs_Button.Click += ManagePrereqs_Button_Click;
            // 
            // AffectedCharacters_Sort_LL
            // 
            AffectedCharacters_Sort_LL.ActiveLinkColor = SystemColors.MenuHighlight;
            AffectedCharacters_Sort_LL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AffectedCharacters_Sort_LL.LinkColor = SystemColors.MenuHighlight;
            AffectedCharacters_Sort_LL.Location = new Point(287, 185);
            AffectedCharacters_Sort_LL.Margin = new Padding(4, 0, 4, 0);
            AffectedCharacters_Sort_LL.Name = "AffectedCharacters_Sort_LL";
            AffectedCharacters_Sort_LL.Size = new Size(71, 16);
            AffectedCharacters_Sort_LL.TabIndex = 45;
            AffectedCharacters_Sort_LL.TabStop = true;
            AffectedCharacters_Sort_LL.Tag = "null";
            AffectedCharacters_Sort_LL.Text = "ABC";
            AffectedCharacters_Sort_LL.TextAlign = ContentAlignment.TopCenter;
            toolTip1.SetToolTip(AffectedCharacters_Sort_LL, "Sort alphabetically.");
            AffectedCharacters_Sort_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            AffectedCharacters_Sort_LL.LinkClicked += AffectedCharacters_Sort_LL_LinkClicked;
            // 
            // AffectedCharacterSetWithAutoMod_LL
            // 
            AffectedCharacterSetWithAutoMod_LL.ActiveLinkColor = SystemColors.MenuHighlight;
            AffectedCharacterSetWithAutoMod_LL.AutoSize = true;
            AffectedCharacterSetWithAutoMod_LL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AffectedCharacterSetWithAutoMod_LL.LinkColor = SystemColors.MenuHighlight;
            AffectedCharacterSetWithAutoMod_LL.Location = new Point(451, 185);
            AffectedCharacterSetWithAutoMod_LL.Margin = new Padding(4, 0, 4, 0);
            AffectedCharacterSetWithAutoMod_LL.Name = "AffectedCharacterSetWithAutoMod_LL";
            AffectedCharacterSetWithAutoMod_LL.Size = new Size(109, 16);
            AffectedCharacterSetWithAutoMod_LL.TabIndex = 44;
            AffectedCharacterSetWithAutoMod_LL.TabStop = true;
            AffectedCharacterSetWithAutoMod_LL.Tag = "null";
            AffectedCharacterSetWithAutoMod_LL.Text = "Set with AutoMod";
            AffectedCharacterSetWithAutoMod_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            AffectedCharacterSetWithAutoMod_LL.LinkClicked += AffectedCharacterSetWithAutoMod_LL_LinkClicked;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaption;
            label11.Location = new Point(365, 184);
            label11.Name = "label11";
            label11.Size = new Size(70, 17);
            label11.TabIndex = 43;
            label11.Text = "Characters";
            // 
            // AffectedCharacters_CLB
            // 
            AffectedCharacters_CLB.BackColor = Color.FromArgb(75, 68, 138);
            AffectedCharacters_CLB.BorderStyle = BorderStyle.FixedSingle;
            AffectedCharacters_CLB.ForeColor = SystemColors.ActiveCaption;
            AffectedCharacters_CLB.FormattingEnabled = true;
            AffectedCharacters_CLB.Location = new Point(287, 204);
            AffectedCharacters_CLB.Name = "AffectedCharacters_CLB";
            AffectedCharacters_CLB.ScrollAlwaysVisible = true;
            AffectedCharacters_CLB.Size = new Size(269, 74);
            AffectedCharacters_CLB.TabIndex = 42;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaption;
            label10.Location = new Point(108, 184);
            label10.Name = "label10";
            label10.Size = new Size(71, 17);
            label10.TabIndex = 41;
            label10.Text = "Categories";
            // 
            // Categories_CLB
            // 
            Categories_CLB.BackColor = Color.FromArgb(75, 68, 138);
            Categories_CLB.BorderStyle = BorderStyle.FixedSingle;
            Categories_CLB.ForeColor = SystemColors.ActiveCaption;
            Categories_CLB.FormattingEnabled = true;
            Categories_CLB.Items.AddRange(new object[] { "Outfit", "Hair", "Skin", "Pubic Hair", "Eyes", "Eyeliner", "Eyeshadow", "Lipstick", "Tanlines", "Fur", "Audio", "Other" });
            Categories_CLB.Location = new Point(12, 204);
            Categories_CLB.Name = "Categories_CLB";
            Categories_CLB.ScrollAlwaysVisible = true;
            Categories_CLB.Size = new Size(269, 74);
            Categories_CLB.TabIndex = 40;
            // 
            // CopyMetaData_Button
            // 
            CopyMetaData_Button.BackColor = Color.FromArgb(75, 68, 138);
            CopyMetaData_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CopyMetaData_Button.FlatStyle = FlatStyle.Flat;
            CopyMetaData_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyMetaData_Button.ForeColor = SystemColors.ActiveCaption;
            CopyMetaData_Button.Location = new Point(328, 364);
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
            ModIconSetDefault_LL.AutoSize = true;
            ModIconSetDefault_LL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconSetDefault_LL.LinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.Location = new Point(384, 294);
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
            ModIconBrowse_Button.Location = new Point(477, 291);
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
            label9.Location = new Point(283, 296);
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
            ModIconPath_TB.Location = new Point(118, 316);
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
            ModIcon_Preview.Location = new Point(12, 293);
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
            label8.Location = new Point(253, 133);
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
            ModURL_TB.Location = new Point(12, 153);
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
            label7.Location = new Point(380, 54);
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
            ModVersion_TB.Location = new Point(287, 74);
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
            label6.Location = new Point(84, 54);
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
            SupportedWLVersions_CLB.Location = new Point(12, 74);
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
            label5.Location = new Point(383, 4);
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
            ModAuthor_TB.Location = new Point(287, 24);
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
            label4.Location = new Point(112, 4);
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
            ModName_TB.Location = new Point(12, 24);
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
            ProgressInfo_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressInfo_Label.ForeColor = SystemColors.ActiveCaption;
            ProgressInfo_Label.Location = new Point(60, 802);
            ProgressInfo_Label.Name = "ProgressInfo_Label";
            ProgressInfo_Label.Size = new Size(541, 21);
            ProgressInfo_Label.TabIndex = 17;
            ProgressInfo_Label.Text = "Initializing...";
            ProgressInfo_Label.TextAlign = ContentAlignment.TopCenter;
            ProgressInfo_Label.Visible = false;
            // 
            // BuildModProgress_PB
            // 
            BuildModProgress_PB.Location = new Point(60, 829);
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
            OpenModFolder_Button.Location = new Point(31, 807);
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
            LoadMod_Button.Location = new Point(452, 807);
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
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 500;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 100;
            // 
            // StopEditing_LL
            // 
            StopEditing_LL.ActiveLinkColor = Color.Red;
            StopEditing_LL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StopEditing_LL.AutoEllipsis = true;
            StopEditing_LL.AutoSize = true;
            StopEditing_LL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StopEditing_LL.LinkColor = Color.LightCoral;
            StopEditing_LL.Location = new Point(599, 776);
            StopEditing_LL.Margin = new Padding(4, 0, 4, 0);
            StopEditing_LL.Name = "StopEditing_LL";
            StopEditing_LL.Size = new Size(19, 21);
            StopEditing_LL.TabIndex = 44;
            StopEditing_LL.TabStop = true;
            StopEditing_LL.Text = "X";
            toolTip1.SetToolTip(StopEditing_LL, "Stop Editing");
            StopEditing_LL.Visible = false;
            StopEditing_LL.VisitedLinkColor = Color.LightCoral;
            StopEditing_LL.LinkClicked += StopEditing_LL_LinkClicked;
            // 
            // CurrentlyEditing_LL
            // 
            CurrentlyEditing_LL.ActiveLinkColor = Color.DeepSkyBlue;
            CurrentlyEditing_LL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CurrentlyEditing_LL.AutoEllipsis = true;
            CurrentlyEditing_LL.LinkColor = SystemColors.MenuHighlight;
            CurrentlyEditing_LL.Location = new Point(147, 780);
            CurrentlyEditing_LL.Margin = new Padding(4, 0, 4, 0);
            CurrentlyEditing_LL.Name = "CurrentlyEditing_LL";
            CurrentlyEditing_LL.Size = new Size(453, 15);
            CurrentlyEditing_LL.TabIndex = 43;
            CurrentlyEditing_LL.TabStop = true;
            CurrentlyEditing_LL.Text = "New Mod";
            toolTip1.SetToolTip(CurrentlyEditing_LL, "Click to navigate to this file.");
            CurrentlyEditing_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            CurrentlyEditing_LL.LinkClicked += CurrentlyEditing_LL_LinkClicked;
            // 
            // label106
            // 
            label106.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label106.AutoSize = true;
            label106.ForeColor = SystemColors.ActiveCaption;
            label106.Location = new Point(44, 780);
            label106.Name = "label106";
            label106.Size = new Size(102, 15);
            label106.TabIndex = 42;
            label106.Text = "Currently Editing: ";
            // 
            // AutoModList_Expand_Button
            // 
            AutoModList_Expand_Button.BackColor = Color.FromArgb(75, 68, 138);
            AutoModList_Expand_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            AutoModList_Expand_Button.FlatStyle = FlatStyle.Flat;
            AutoModList_Expand_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutoModList_Expand_Button.ForeColor = Color.White;
            AutoModList_Expand_Button.Location = new Point(156, 203);
            AutoModList_Expand_Button.Name = "AutoModList_Expand_Button";
            AutoModList_Expand_Button.Size = new Size(95, 26);
            AutoModList_Expand_Button.TabIndex = 45;
            AutoModList_Expand_Button.Text = "Expand +";
            AutoModList_Expand_Button.UseVisualStyleBackColor = false;
            AutoModList_Expand_Button.Click += AutoModList_Expand_Button_Click;
            // 
            // PaksList_Expand_Button
            // 
            PaksList_Expand_Button.BackColor = Color.FromArgb(75, 68, 138);
            PaksList_Expand_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            PaksList_Expand_Button.FlatStyle = FlatStyle.Flat;
            PaksList_Expand_Button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PaksList_Expand_Button.ForeColor = Color.White;
            PaksList_Expand_Button.Location = new Point(156, 60);
            PaksList_Expand_Button.Name = "PaksList_Expand_Button";
            PaksList_Expand_Button.Size = new Size(95, 26);
            PaksList_Expand_Button.TabIndex = 46;
            PaksList_Expand_Button.Text = "Expand +";
            PaksList_Expand_Button.UseVisualStyleBackColor = false;
            PaksList_Expand_Button.Click += PaksList_Expand_Button_Click;
            // 
            // PrereqManager_Panel
            // 
            PrereqManager_Panel.BackColor = Color.FromArgb(75, 68, 138);
            PrereqManager_Panel.BorderStyle = BorderStyle.Fixed3D;
            PrereqManager_Panel.Controls.Add(PrereqRemove_Button);
            PrereqManager_Panel.Controls.Add(label12);
            PrereqManager_Panel.Controls.Add(PrereqAdd_Button);
            PrereqManager_Panel.Controls.Add(PrereqAdd_TB);
            PrereqManager_Panel.Controls.Add(label15);
            PrereqManager_Panel.Controls.Add(Prereqs_LB);
            PrereqManager_Panel.Controls.Add(linkLabel2);
            PrereqManager_Panel.Location = new Point(265, 507);
            PrereqManager_Panel.Name = "PrereqManager_Panel";
            PrereqManager_Panel.Size = new Size(336, 158);
            PrereqManager_Panel.TabIndex = 47;
            PrereqManager_Panel.Visible = false;
            // 
            // PrereqRemove_Button
            // 
            PrereqRemove_Button.BackColor = Color.FromArgb(32, 34, 81);
            PrereqRemove_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            PrereqRemove_Button.FlatStyle = FlatStyle.Flat;
            PrereqRemove_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrereqRemove_Button.ForeColor = Color.Red;
            PrereqRemove_Button.Location = new Point(285, 80);
            PrereqRemove_Button.Name = "PrereqRemove_Button";
            PrereqRemove_Button.Size = new Size(39, 27);
            PrereqRemove_Button.TabIndex = 45;
            PrereqRemove_Button.Text = "X";
            PrereqRemove_Button.UseVisualStyleBackColor = false;
            PrereqRemove_Button.Click += PrereqRemove_Button_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaption;
            label12.Location = new Point(11, 28);
            label12.Name = "label12";
            label12.Size = new Size(75, 17);
            label12.TabIndex = 44;
            label12.Text = "Mod Name";
            // 
            // PrereqAdd_Button
            // 
            PrereqAdd_Button.BackColor = Color.FromArgb(32, 34, 81);
            PrereqAdd_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            PrereqAdd_Button.FlatStyle = FlatStyle.Flat;
            PrereqAdd_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrereqAdd_Button.ForeColor = SystemColors.ActiveCaption;
            PrereqAdd_Button.Location = new Point(285, 47);
            PrereqAdd_Button.Name = "PrereqAdd_Button";
            PrereqAdd_Button.Size = new Size(39, 27);
            PrereqAdd_Button.TabIndex = 43;
            PrereqAdd_Button.Text = "Add";
            PrereqAdd_Button.UseVisualStyleBackColor = false;
            PrereqAdd_Button.Click += PrereqAdd_Button_Click;
            // 
            // PrereqAdd_TB
            // 
            PrereqAdd_TB.BackColor = Color.FromArgb(32, 34, 81);
            PrereqAdd_TB.BorderStyle = BorderStyle.FixedSingle;
            PrereqAdd_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrereqAdd_TB.ForeColor = SystemColors.ActiveCaption;
            PrereqAdd_TB.Location = new Point(11, 47);
            PrereqAdd_TB.Name = "PrereqAdd_TB";
            PrereqAdd_TB.Size = new Size(268, 27);
            PrereqAdd_TB.TabIndex = 42;
            PrereqAdd_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ActiveCaption;
            label15.Location = new Point(113, 7);
            label15.Name = "label15";
            label15.Size = new Size(107, 21);
            label15.TabIndex = 41;
            label15.Text = "Dependencies";
            // 
            // Prereqs_LB
            // 
            Prereqs_LB.BackColor = Color.FromArgb(32, 34, 81);
            Prereqs_LB.ForeColor = SystemColors.ActiveCaption;
            Prereqs_LB.FormattingEnabled = true;
            Prereqs_LB.ItemHeight = 15;
            Prereqs_LB.Location = new Point(11, 80);
            Prereqs_LB.Name = "Prereqs_LB";
            Prereqs_LB.ScrollAlwaysVisible = true;
            Prereqs_LB.Size = new Size(268, 49);
            Prereqs_LB.TabIndex = 40;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = SystemColors.MenuHighlight;
            linkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkColor = SystemColors.MenuHighlight;
            linkLabel2.Location = new Point(365, 539);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(86, 16);
            linkLabel2.TabIndex = 37;
            linkLabel2.TabStop = true;
            linkLabel2.Tag = "null";
            linkLabel2.Text = "Set to Default";
            linkLabel2.VisitedLinkColor = SystemColors.MenuHighlight;
            // 
            // SearchPanel_AM
            // 
            SearchPanel_AM.BorderStyle = BorderStyle.FixedSingle;
            SearchPanel_AM.Controls.Add(SearchClear_AM);
            SearchPanel_AM.Controls.Add(label21);
            SearchPanel_AM.Controls.Add(SearchTB_AM);
            SearchPanel_AM.Location = new Point(44, 231);
            SearchPanel_AM.Name = "SearchPanel_AM";
            SearchPanel_AM.Size = new Size(570, 35);
            SearchPanel_AM.TabIndex = 48;
            SearchPanel_AM.Visible = false;
            // 
            // SearchClear_AM
            // 
            SearchClear_AM.BackColor = Color.FromArgb(32, 34, 81);
            SearchClear_AM.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            SearchClear_AM.FlatStyle = FlatStyle.Flat;
            SearchClear_AM.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchClear_AM.ForeColor = Color.Red;
            SearchClear_AM.Location = new Point(432, 3);
            SearchClear_AM.Name = "SearchClear_AM";
            SearchClear_AM.Size = new Size(28, 27);
            SearchClear_AM.TabIndex = 46;
            SearchClear_AM.Text = "X";
            SearchClear_AM.UseVisualStyleBackColor = false;
            SearchClear_AM.Click += SearchClear_AM_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = SystemColors.ActiveCaption;
            label21.Location = new Point(108, 7);
            label21.Name = "label21";
            label21.Size = new Size(50, 17);
            label21.TabIndex = 16;
            label21.Text = "Search:";
            // 
            // SearchTB_AM
            // 
            SearchTB_AM.BackColor = Color.FromArgb(75, 68, 138);
            SearchTB_AM.BorderStyle = BorderStyle.FixedSingle;
            SearchTB_AM.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTB_AM.ForeColor = SystemColors.ActiveCaption;
            SearchTB_AM.Location = new Point(158, 3);
            SearchTB_AM.Name = "SearchTB_AM";
            SearchTB_AM.Size = new Size(269, 27);
            SearchTB_AM.TabIndex = 0;
            SearchTB_AM.TextAlign = HorizontalAlignment.Center;
            SearchTB_AM.TextChanged += SearchTB_AM_TextChanged;
            // 
            // SearchPanel_Pak
            // 
            SearchPanel_Pak.BorderStyle = BorderStyle.FixedSingle;
            SearchPanel_Pak.Controls.Add(SearchClear_Pak);
            SearchPanel_Pak.Controls.Add(label13);
            SearchPanel_Pak.Controls.Add(SearchTB_Pak);
            SearchPanel_Pak.Location = new Point(44, 89);
            SearchPanel_Pak.Name = "SearchPanel_Pak";
            SearchPanel_Pak.Size = new Size(570, 35);
            SearchPanel_Pak.TabIndex = 49;
            SearchPanel_Pak.Visible = false;
            // 
            // SearchClear_Pak
            // 
            SearchClear_Pak.BackColor = Color.FromArgb(32, 34, 81);
            SearchClear_Pak.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            SearchClear_Pak.FlatStyle = FlatStyle.Flat;
            SearchClear_Pak.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchClear_Pak.ForeColor = Color.Red;
            SearchClear_Pak.Location = new Point(432, 3);
            SearchClear_Pak.Name = "SearchClear_Pak";
            SearchClear_Pak.Size = new Size(28, 27);
            SearchClear_Pak.TabIndex = 46;
            SearchClear_Pak.Text = "X";
            SearchClear_Pak.UseVisualStyleBackColor = false;
            SearchClear_Pak.Click += SearchClear_Pak_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaption;
            label13.Location = new Point(108, 7);
            label13.Name = "label13";
            label13.Size = new Size(50, 17);
            label13.TabIndex = 16;
            label13.Text = "Search:";
            // 
            // SearchTB_Pak
            // 
            SearchTB_Pak.BackColor = Color.FromArgb(75, 68, 138);
            SearchTB_Pak.BorderStyle = BorderStyle.FixedSingle;
            SearchTB_Pak.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTB_Pak.ForeColor = SystemColors.ActiveCaption;
            SearchTB_Pak.Location = new Point(158, 3);
            SearchTB_Pak.Name = "SearchTB_Pak";
            SearchTB_Pak.Size = new Size(269, 27);
            SearchTB_Pak.TabIndex = 0;
            SearchTB_Pak.TextAlign = HorizontalAlignment.Center;
            SearchTB_Pak.TextChanged += SearchTB_Pak_TextChanged;
            // 
            // ModCreator
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(658, 850);
            ControlBox = false;
            Controls.Add(SearchPanel_Pak);
            Controls.Add(SearchPanel_AM);
            Controls.Add(PrereqManager_Panel);
            Controls.Add(PakList);
            Controls.Add(PaksList_Expand_Button);
            Controls.Add(AutoModList);
            Controls.Add(AutoModList_Expand_Button);
            Controls.Add(StopEditing_LL);
            Controls.Add(CurrentlyEditing_LL);
            Controls.Add(label106);
            Controls.Add(Icon_PB);
            Controls.Add(ProgressInfo_Label);
            Controls.Add(BuildModProgress_PB);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(CreateAutoMod_Button);
            Controls.Add(RemoveAutoMod_Button);
            Controls.Add(AddAutoMod_Button);
            Controls.Add(label2);
            Controls.Add(RemovePak_Button);
            Controls.Add(AddPak_Button);
            Controls.Add(label1);
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
            PrereqManager_Panel.ResumeLayout(false);
            PrereqManager_Panel.PerformLayout();
            SearchPanel_AM.ResumeLayout(false);
            SearchPanel_AM.PerformLayout();
            SearchPanel_Pak.ResumeLayout(false);
            SearchPanel_Pak.PerformLayout();
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
        private ToolTip toolTip1;
        private LinkLabel StopEditing_LL;
        private LinkLabel CurrentlyEditing_LL;
        private Label label106;
        private LinkLabel AffectedCharacterSetWithAutoMod_LL;
        private Label label11;
        private CheckedListBox AffectedCharacters_CLB;
        private Label label10;
        private CheckedListBox Categories_CLB;
        private LinkLabel AffectedCharacters_Sort_LL;
        private Button AutoModList_Expand_Button;
        private Button PaksList_Expand_Button;
        private Button ManagePrereqs_Button;
        private Panel PrereqManager_Panel;
        private Button PrereqRemove_Button;
        private Label label12;
        private Button PrereqAdd_Button;
        private TextBox PrereqAdd_TB;
        private Label label15;
        private ListBox Prereqs_LB;
        private LinkLabel linkLabel2;
        private Panel SearchPanel_AM;
        private Label label21;
        private TextBox SearchTB_AM;
        private Button SearchClear_AM;
        private Panel SearchPanel_Pak;
        private Button SearchClear_Pak;
        private Label label13;
        private TextBox SearchTB_Pak;
    }
}