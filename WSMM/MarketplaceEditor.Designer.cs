namespace WSMM
{
    partial class MarketplaceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketplaceEditor));
            Icon_PB = new PictureBox();
            Close_Button = new PictureBox();
            Separator_1 = new PictureBox();
            TitlePanel = new Panel();
            ByLuckyLabel = new Label();
            TitleLabel = new Label();
            panel1 = new Panel();
            label14 = new Label();
            AffectedCharacters_CLB = new CheckedListBox();
            label13 = new Label();
            LastUpdate_TB = new TextBox();
            label12 = new Label();
            ModSize_TB = new TextBox();
            ModIconSetDefault_LL = new LinkLabel();
            label8 = new Label();
            ModURL_TB = new TextBox();
            label7 = new Label();
            ModVersion_TB = new TextBox();
            label6 = new Label();
            label1 = new Label();
            Categories_CLB = new CheckedListBox();
            SupportedWLVersions_CLB = new CheckedListBox();
            label5 = new Label();
            ModAuthor_TB = new TextBox();
            label4 = new Label();
            ModName_TB = new TextBox();
            panel2 = new Panel();
            LoadFromMarketplace_Button = new Button();
            ModWLMMBrowse_Button = new Button();
            label9 = new Label();
            ModWLMMPath_TB = new TextBox();
            linkLabel1 = new LinkLabel();
            panel3 = new Panel();
            label11 = new Label();
            ModDescription_TB = new TextBox();
            label10 = new Label();
            ModDLURL_TB = new TextBox();
            label3 = new Label();
            ModIconURL_TB = new TextBox();
            ScreenshotAdd_Button = new Button();
            ScreenshotAdd_TB = new TextBox();
            label2 = new Label();
            Screenshots_LB = new ListBox();
            linkLabel2 = new LinkLabel();
            CopyData_Button = new Button();
            openFileDialog1 = new OpenFileDialog();
            toolTip1 = new ToolTip(components);
            IncludeCodeTags = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            TitlePanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(5, 6);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(69, 50);
            Icon_PB.SizeMode = PictureBoxSizeMode.Zoom;
            Icon_PB.TabIndex = 5;
            Icon_PB.TabStop = false;
            Icon_PB.MouseDown += TitlePanel_MouseDown;
            Icon_PB.MouseMove += TitlePanel_MouseMove;
            Icon_PB.MouseUp += TitlePanel_MouseUp;
            // 
            // Close_Button
            // 
            Close_Button.Image = Properties.Resources.Close_Icon;
            Close_Button.Location = new Point(604, 6);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(52, 50);
            Close_Button.SizeMode = PictureBoxSizeMode.Zoom;
            Close_Button.TabIndex = 8;
            Close_Button.TabStop = false;
            Close_Button.Click += Close_Button_Click;
            Close_Button.MouseEnter += Close_Button_MouseEnter;
            Close_Button.MouseLeave += Close_Button_MouseLeave;
            // 
            // Separator_1
            // 
            Separator_1.BackColor = SystemColors.ActiveCaption;
            Separator_1.Location = new Point(93, 39);
            Separator_1.Name = "Separator_1";
            Separator_1.Size = new Size(490, 2);
            Separator_1.TabIndex = 7;
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
            TitlePanel.TabIndex = 6;
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
            TitleLabel.Location = new Point(191, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(275, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "WLMM - Marketplace Editor";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label14);
            panel1.Controls.Add(AffectedCharacters_CLB);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(LastUpdate_TB);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(ModSize_TB);
            panel1.Controls.Add(ModIconSetDefault_LL);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(ModURL_TB);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(ModVersion_TB);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Categories_CLB);
            panel1.Controls.Add(SupportedWLVersions_CLB);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ModAuthor_TB);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(ModName_TB);
            panel1.Location = new Point(48, 129);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 332);
            panel1.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ActiveCaption;
            label14.Location = new Point(386, 229);
            label14.Name = "label14";
            label14.Size = new Size(70, 17);
            label14.TabIndex = 43;
            label14.Text = "Characters";
            // 
            // AffectedCharacters_CLB
            // 
            AffectedCharacters_CLB.BackColor = Color.FromArgb(75, 68, 138);
            AffectedCharacters_CLB.BorderStyle = BorderStyle.FixedSingle;
            AffectedCharacters_CLB.ForeColor = SystemColors.ActiveCaption;
            AffectedCharacters_CLB.FormattingEnabled = true;
            AffectedCharacters_CLB.Location = new Point(287, 249);
            AffectedCharacters_CLB.Name = "AffectedCharacters_CLB";
            AffectedCharacters_CLB.ScrollAlwaysVisible = true;
            AffectedCharacters_CLB.SelectionMode = SelectionMode.None;
            AffectedCharacters_CLB.Size = new Size(269, 74);
            AffectedCharacters_CLB.TabIndex = 42;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaption;
            label13.Location = new Point(390, 181);
            label13.Name = "label13";
            label13.Size = new Size(78, 17);
            label13.TabIndex = 41;
            label13.Text = "Last Update";
            // 
            // LastUpdate_TB
            // 
            LastUpdate_TB.BackColor = Color.FromArgb(75, 68, 138);
            LastUpdate_TB.BorderStyle = BorderStyle.FixedSingle;
            LastUpdate_TB.Enabled = false;
            LastUpdate_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastUpdate_TB.ForeColor = SystemColors.ActiveCaption;
            LastUpdate_TB.Location = new Point(287, 201);
            LastUpdate_TB.Name = "LastUpdate_TB";
            LastUpdate_TB.Size = new Size(269, 27);
            LastUpdate_TB.TabIndex = 40;
            LastUpdate_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaption;
            label12.Location = new Point(115, 181);
            label12.Name = "label12";
            label12.Size = new Size(63, 17);
            label12.TabIndex = 39;
            label12.Text = "Mod Size";
            // 
            // ModSize_TB
            // 
            ModSize_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModSize_TB.BorderStyle = BorderStyle.FixedSingle;
            ModSize_TB.Enabled = false;
            ModSize_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModSize_TB.ForeColor = SystemColors.ActiveCaption;
            ModSize_TB.Location = new Point(12, 201);
            ModSize_TB.Name = "ModSize_TB";
            ModSize_TB.Size = new Size(269, 27);
            ModSize_TB.TabIndex = 38;
            ModSize_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // ModIconSetDefault_LL
            // 
            ModIconSetDefault_LL.ActiveLinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ModIconSetDefault_LL.AutoSize = true;
            ModIconSetDefault_LL.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconSetDefault_LL.LinkColor = SystemColors.MenuHighlight;
            ModIconSetDefault_LL.Location = new Point(365, 429);
            ModIconSetDefault_LL.Margin = new Padding(4, 0, 4, 0);
            ModIconSetDefault_LL.Name = "ModIconSetDefault_LL";
            ModIconSetDefault_LL.Size = new Size(86, 16);
            ModIconSetDefault_LL.TabIndex = 37;
            ModIconSetDefault_LL.TabStop = true;
            ModIconSetDefault_LL.Tag = "null";
            ModIconSetDefault_LL.Text = "Set to Default";
            ModIconSetDefault_LL.VisitedLinkColor = SystemColors.MenuHighlight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaption;
            label8.Location = new Point(253, 132);
            label8.Name = "label8";
            label8.Size = new Size(63, 17);
            label8.TabIndex = 24;
            label8.Text = "Mod URL";
            // 
            // ModURL_TB
            // 
            ModURL_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModURL_TB.BorderStyle = BorderStyle.FixedSingle;
            ModURL_TB.Enabled = false;
            ModURL_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModURL_TB.ForeColor = SystemColors.ActiveCaption;
            ModURL_TB.Location = new Point(12, 152);
            ModURL_TB.Name = "ModURL_TB";
            ModURL_TB.Size = new Size(544, 27);
            ModURL_TB.TabIndex = 23;
            ModURL_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(380, 55);
            label7.Name = "label7";
            label7.Size = new Size(83, 17);
            label7.TabIndex = 22;
            label7.Text = "Mod Version";
            // 
            // ModVersion_TB
            // 
            ModVersion_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModVersion_TB.BorderStyle = BorderStyle.FixedSingle;
            ModVersion_TB.Enabled = false;
            ModVersion_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModVersion_TB.ForeColor = SystemColors.ActiveCaption;
            ModVersion_TB.Location = new Point(287, 75);
            ModVersion_TB.Name = "ModVersion_TB";
            ModVersion_TB.Size = new Size(269, 27);
            ModVersion_TB.TabIndex = 21;
            ModVersion_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(84, 55);
            label6.Name = "label6";
            label6.Size = new Size(123, 17);
            label6.TabIndex = 20;
            label6.Text = "Supported Versions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(112, 229);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 39;
            label1.Text = "Categories";
            // 
            // Categories_CLB
            // 
            Categories_CLB.BackColor = Color.FromArgb(75, 68, 138);
            Categories_CLB.BorderStyle = BorderStyle.FixedSingle;
            Categories_CLB.ForeColor = SystemColors.ActiveCaption;
            Categories_CLB.FormattingEnabled = true;
            Categories_CLB.Items.AddRange(new object[] { "Outfit", "Hair", "Beard", "Skin", "Pubic Hair", "Eyes", "Eyeliner", "Eyeshadow", "Lipstick", "Tanlines", "Fur", "Audio", "Other" });
            Categories_CLB.Location = new Point(13, 249);
            Categories_CLB.Name = "Categories_CLB";
            Categories_CLB.ScrollAlwaysVisible = true;
            Categories_CLB.SelectionMode = SelectionMode.None;
            Categories_CLB.Size = new Size(269, 74);
            Categories_CLB.TabIndex = 38;
            // 
            // SupportedWLVersions_CLB
            // 
            SupportedWLVersions_CLB.BackColor = Color.FromArgb(75, 68, 138);
            SupportedWLVersions_CLB.BorderStyle = BorderStyle.FixedSingle;
            SupportedWLVersions_CLB.ForeColor = SystemColors.ActiveCaption;
            SupportedWLVersions_CLB.FormattingEnabled = true;
            SupportedWLVersions_CLB.Location = new Point(12, 75);
            SupportedWLVersions_CLB.Name = "SupportedWLVersions_CLB";
            SupportedWLVersions_CLB.ScrollAlwaysVisible = true;
            SupportedWLVersions_CLB.SelectionMode = SelectionMode.None;
            SupportedWLVersions_CLB.Size = new Size(269, 56);
            SupportedWLVersions_CLB.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(383, 5);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 18;
            label5.Text = "Mod Author";
            // 
            // ModAuthor_TB
            // 
            ModAuthor_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModAuthor_TB.BorderStyle = BorderStyle.FixedSingle;
            ModAuthor_TB.Enabled = false;
            ModAuthor_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModAuthor_TB.ForeColor = SystemColors.ActiveCaption;
            ModAuthor_TB.Location = new Point(287, 25);
            ModAuthor_TB.Name = "ModAuthor_TB";
            ModAuthor_TB.Size = new Size(269, 27);
            ModAuthor_TB.TabIndex = 17;
            ModAuthor_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(112, 5);
            label4.Name = "label4";
            label4.Size = new Size(75, 17);
            label4.TabIndex = 16;
            label4.Text = "Mod Name";
            // 
            // ModName_TB
            // 
            ModName_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModName_TB.BorderStyle = BorderStyle.FixedSingle;
            ModName_TB.Enabled = false;
            ModName_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_TB.ForeColor = SystemColors.ActiveCaption;
            ModName_TB.Location = new Point(12, 25);
            ModName_TB.Name = "ModName_TB";
            ModName_TB.Size = new Size(269, 27);
            ModName_TB.TabIndex = 0;
            ModName_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(LoadFromMarketplace_Button);
            panel2.Controls.Add(ModWLMMBrowse_Button);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(ModWLMMPath_TB);
            panel2.Controls.Add(linkLabel1);
            panel2.Location = new Point(48, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 63);
            panel2.TabIndex = 16;
            // 
            // LoadFromMarketplace_Button
            // 
            LoadFromMarketplace_Button.BackColor = Color.FromArgb(75, 68, 138);
            LoadFromMarketplace_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            LoadFromMarketplace_Button.FlatStyle = FlatStyle.Flat;
            LoadFromMarketplace_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoadFromMarketplace_Button.ForeColor = SystemColors.ActiveCaption;
            LoadFromMarketplace_Button.Location = new Point(12, 4);
            LoadFromMarketplace_Button.Name = "LoadFromMarketplace_Button";
            LoadFromMarketplace_Button.Size = new Size(166, 22);
            LoadFromMarketplace_Button.TabIndex = 41;
            LoadFromMarketplace_Button.Text = "Load Data from Marketplace";
            LoadFromMarketplace_Button.UseVisualStyleBackColor = false;
            LoadFromMarketplace_Button.Visible = false;
            LoadFromMarketplace_Button.Click += LoadFromMarketplace_Button_Click;
            // 
            // ModWLMMBrowse_Button
            // 
            ModWLMMBrowse_Button.BackColor = Color.FromArgb(75, 68, 138);
            ModWLMMBrowse_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ModWLMMBrowse_Button.FlatStyle = FlatStyle.Flat;
            ModWLMMBrowse_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModWLMMBrowse_Button.ForeColor = SystemColors.ActiveCaption;
            ModWLMMBrowse_Button.Location = new Point(477, 4);
            ModWLMMBrowse_Button.Name = "ModWLMMBrowse_Button";
            ModWLMMBrowse_Button.Size = new Size(79, 22);
            ModWLMMBrowse_Button.TabIndex = 40;
            ModWLMMBrowse_Button.Text = "Browse...";
            ModWLMMBrowse_Button.UseVisualStyleBackColor = false;
            ModWLMMBrowse_Button.Click += ModWLMMBrowse_Button_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaption;
            label9.Location = new Point(235, 9);
            label9.Name = "label9";
            label9.Size = new Size(98, 17);
            label9.TabIndex = 39;
            label9.Text = "Core .wlmm file";
            // 
            // ModWLMMPath_TB
            // 
            ModWLMMPath_TB.AllowDrop = true;
            ModWLMMPath_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModWLMMPath_TB.BorderStyle = BorderStyle.FixedSingle;
            ModWLMMPath_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModWLMMPath_TB.ForeColor = SystemColors.ActiveCaption;
            ModWLMMPath_TB.Location = new Point(12, 29);
            ModWLMMPath_TB.Name = "ModWLMMPath_TB";
            ModWLMMPath_TB.Size = new Size(544, 27);
            ModWLMMPath_TB.TabIndex = 38;
            ModWLMMPath_TB.Text = "None";
            ModWLMMPath_TB.TextAlign = HorizontalAlignment.Center;
            ModWLMMPath_TB.DragDrop += ModWLMMPath_TB_DragDrop;
            ModWLMMPath_TB.DragEnter += ModWLMMPath_TB_DragEnter;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = SystemColors.MenuHighlight;
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = SystemColors.MenuHighlight;
            linkLabel1.Location = new Point(365, 260);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(86, 16);
            linkLabel1.TabIndex = 37;
            linkLabel1.TabStop = true;
            linkLabel1.Tag = "null";
            linkLabel1.Text = "Set to Default";
            linkLabel1.VisitedLinkColor = SystemColors.MenuHighlight;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(ModDescription_TB);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(ModDLURL_TB);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(ModIconURL_TB);
            panel3.Controls.Add(ScreenshotAdd_Button);
            panel3.Controls.Add(ScreenshotAdd_TB);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(Screenshots_LB);
            panel3.Controls.Add(linkLabel2);
            panel3.Location = new Point(48, 468);
            panel3.Name = "panel3";
            panel3.Size = new Size(570, 288);
            panel3.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaption;
            label11.Location = new Point(231, 210);
            label11.Name = "label11";
            label11.Size = new Size(106, 17);
            label11.TabIndex = 49;
            label11.Text = "Mod Description";
            // 
            // ModDescription_TB
            // 
            ModDescription_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModDescription_TB.BorderStyle = BorderStyle.FixedSingle;
            ModDescription_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModDescription_TB.ForeColor = SystemColors.ActiveCaption;
            ModDescription_TB.Location = new Point(12, 230);
            ModDescription_TB.Multiline = true;
            ModDescription_TB.Name = "ModDescription_TB";
            ModDescription_TB.ScrollBars = ScrollBars.Vertical;
            ModDescription_TB.Size = new Size(544, 49);
            ModDescription_TB.TabIndex = 48;
            ModDescription_TB.Text = "No Description Provided.";
            ModDescription_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaption;
            label10.Location = new Point(221, 160);
            label10.Name = "label10";
            label10.Size = new Size(126, 17);
            label10.TabIndex = 47;
            label10.Text = "Mod Download URL";
            // 
            // ModDLURL_TB
            // 
            ModDLURL_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModDLURL_TB.BorderStyle = BorderStyle.FixedSingle;
            ModDLURL_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModDLURL_TB.ForeColor = SystemColors.ActiveCaption;
            ModDLURL_TB.Location = new Point(12, 180);
            ModDLURL_TB.Name = "ModDLURL_TB";
            ModDLURL_TB.Size = new Size(544, 27);
            ModDLURL_TB.TabIndex = 46;
            ModDLURL_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(138, 110);
            label3.Name = "label3";
            label3.Size = new Size(292, 17);
            label3.TabIndex = 45;
            label3.Text = "Mod Icon URL (Must end with PNG, JPG or JPEG)";
            // 
            // ModIconURL_TB
            // 
            ModIconURL_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModIconURL_TB.BorderStyle = BorderStyle.FixedSingle;
            ModIconURL_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModIconURL_TB.ForeColor = SystemColors.ActiveCaption;
            ModIconURL_TB.Location = new Point(12, 130);
            ModIconURL_TB.Name = "ModIconURL_TB";
            ModIconURL_TB.Size = new Size(544, 27);
            ModIconURL_TB.TabIndex = 44;
            ModIconURL_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // ScreenshotAdd_Button
            // 
            ScreenshotAdd_Button.BackColor = Color.FromArgb(75, 68, 138);
            ScreenshotAdd_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ScreenshotAdd_Button.FlatStyle = FlatStyle.Flat;
            ScreenshotAdd_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScreenshotAdd_Button.ForeColor = SystemColors.ActiveCaption;
            ScreenshotAdd_Button.Location = new Point(517, 22);
            ScreenshotAdd_Button.Name = "ScreenshotAdd_Button";
            ScreenshotAdd_Button.Size = new Size(39, 27);
            ScreenshotAdd_Button.TabIndex = 43;
            ScreenshotAdd_Button.Text = "Add";
            ScreenshotAdd_Button.UseVisualStyleBackColor = false;
            ScreenshotAdd_Button.Click += ScreenshotAdd_Button_Click;
            // 
            // ScreenshotAdd_TB
            // 
            ScreenshotAdd_TB.BackColor = Color.FromArgb(75, 68, 138);
            ScreenshotAdd_TB.BorderStyle = BorderStyle.FixedSingle;
            ScreenshotAdd_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScreenshotAdd_TB.ForeColor = SystemColors.ActiveCaption;
            ScreenshotAdd_TB.Location = new Point(13, 22);
            ScreenshotAdd_TB.Name = "ScreenshotAdd_TB";
            ScreenshotAdd_TB.Size = new Size(498, 27);
            ScreenshotAdd_TB.TabIndex = 42;
            ScreenshotAdd_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(145, 2);
            label2.Name = "label2";
            label2.Size = new Size(304, 17);
            label2.TabIndex = 41;
            label2.Text = "Screenshots (Must end with PNG, JPG, JPEG or GIF)";
            // 
            // Screenshots_LB
            // 
            Screenshots_LB.BackColor = Color.FromArgb(75, 68, 138);
            Screenshots_LB.ForeColor = SystemColors.ActiveCaption;
            Screenshots_LB.FormattingEnabled = true;
            Screenshots_LB.ItemHeight = 15;
            Screenshots_LB.Location = new Point(13, 55);
            Screenshots_LB.Name = "Screenshots_LB";
            Screenshots_LB.ScrollAlwaysVisible = true;
            Screenshots_LB.Size = new Size(543, 49);
            Screenshots_LB.TabIndex = 40;
            Screenshots_LB.SelectedIndexChanged += Screenshots_LB_SelectedIndexChanged;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = SystemColors.MenuHighlight;
            linkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkColor = SystemColors.MenuHighlight;
            linkLabel2.Location = new Point(365, 485);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(86, 16);
            linkLabel2.TabIndex = 37;
            linkLabel2.TabStop = true;
            linkLabel2.Tag = "null";
            linkLabel2.Text = "Set to Default";
            linkLabel2.VisitedLinkColor = SystemColors.MenuHighlight;
            // 
            // CopyData_Button
            // 
            CopyData_Button.BackColor = Color.FromArgb(75, 68, 138);
            CopyData_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CopyData_Button.FlatStyle = FlatStyle.Flat;
            CopyData_Button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyData_Button.ForeColor = SystemColors.ActiveCaption;
            CopyData_Button.Location = new Point(48, 785);
            CopyData_Button.Name = "CopyData_Button";
            CopyData_Button.Size = new Size(570, 45);
            CopyData_Button.TabIndex = 18;
            CopyData_Button.Text = "Copy Marketplace Data to Clipboard";
            CopyData_Button.UseVisualStyleBackColor = false;
            CopyData_Button.Click += CopyData_Button_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = ".wlmm files (*.wlmm)|*.wlmm";
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 500;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 100;
            // 
            // IncludeCodeTags
            // 
            IncludeCodeTags.AutoSize = true;
            IncludeCodeTags.Checked = true;
            IncludeCodeTags.CheckState = CheckState.Checked;
            IncludeCodeTags.ForeColor = SystemColors.ActiveCaption;
            IncludeCodeTags.Location = new Point(231, 762);
            IncludeCodeTags.Name = "IncludeCodeTags";
            IncludeCodeTags.Size = new Size(198, 19);
            IncludeCodeTags.TabIndex = 19;
            IncludeCodeTags.Text = "Include Discord Code Block Tags";
            IncludeCodeTags.UseVisualStyleBackColor = true;
            // 
            // MarketplaceEditor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(658, 839);
            Controls.Add(IncludeCodeTags);
            Controls.Add(CopyData_Button);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Icon_PB);
            Controls.Add(Close_Button);
            Controls.Add(Separator_1);
            Controls.Add(TitlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MarketplaceEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marketplace Editor";
            Load += MarketplaceEditor_Load;
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Icon_PB;
        private PictureBox Close_Button;
        private PictureBox Separator_1;
        private Panel TitlePanel;
        private Label ByLuckyLabel;
        private Label TitleLabel;
        private Panel panel1;
        private LinkLabel ModIconSetDefault_LL;
        private Label label8;
        private TextBox ModURL_TB;
        private Label label7;
        private TextBox ModVersion_TB;
        private Label label6;
        private CheckedListBox SupportedWLVersions_CLB;
        private Label label5;
        private TextBox ModAuthor_TB;
        private Label label4;
        private TextBox ModName_TB;
        private Panel panel2;
        private LinkLabel linkLabel1;
        private Button ModWLMMBrowse_Button;
        private Label label9;
        private TextBox ModWLMMPath_TB;
        private Panel panel3;
        private LinkLabel linkLabel2;
        private Label label13;
        private TextBox LastUpdate_TB;
        private Label label12;
        private TextBox ModSize_TB;
        private Label label1;
        private CheckedListBox Categories_CLB;
        private TextBox ScreenshotAdd_TB;
        private Label label2;
        private ListBox Screenshots_LB;
        private Button ScreenshotAdd_Button;
        private Label label3;
        private TextBox ModIconURL_TB;
        private Label label10;
        private TextBox ModDLURL_TB;
        private Label label11;
        private TextBox ModDescription_TB;
        private Button CopyData_Button;
        private OpenFileDialog openFileDialog1;
        private ToolTip toolTip1;
        private Label label14;
        private CheckedListBox AffectedCharacters_CLB;
        private Button LoadFromMarketplace_Button;
        private CheckBox IncludeCodeTags;
    }
}