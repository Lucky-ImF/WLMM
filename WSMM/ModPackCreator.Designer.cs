namespace WSMM
{
    partial class ModPackCreator
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
            Icon_PB = new PictureBox();
            Separator_1 = new PictureBox();
            TitlePanel = new Panel();
            ByLuckyLabel = new Label();
            TitleLabel = new Label();
            Close_Button = new PictureBox();
            label7 = new Label();
            ModDescription_TB = new TextBox();
            label6 = new Label();
            SupportedWLVersions_CLB = new CheckedListBox();
            label5 = new Label();
            ModAuthor_TB = new TextBox();
            label4 = new Label();
            ModName_TB = new TextBox();
            label2 = new Label();
            ModList_LB = new ListBox();
            CreateModPack_Button = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            SuspendLayout();
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(5, 6);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(70, 70);
            Icon_PB.SizeMode = PictureBoxSizeMode.Zoom;
            Icon_PB.TabIndex = 9;
            Icon_PB.TabStop = false;
            Icon_PB.MouseDown += TitlePanel_MouseDown;
            Icon_PB.MouseMove += TitlePanel_MouseMove;
            Icon_PB.MouseUp += TitlePanel_MouseUp;
            // 
            // Separator_1
            // 
            Separator_1.BackColor = SystemColors.ActiveCaption;
            Separator_1.Location = new Point(93, 39);
            Separator_1.Name = "Separator_1";
            Separator_1.Size = new Size(490, 2);
            Separator_1.TabIndex = 11;
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
            TitlePanel.TabIndex = 10;
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
            TitleLabel.Location = new Point(198, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(261, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "WLMM - Modpack Creator";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // Close_Button
            // 
            Close_Button.Image = Properties.Resources.Close_Icon;
            Close_Button.Location = new Point(604, 6);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(52, 50);
            Close_Button.SizeMode = PictureBoxSizeMode.Zoom;
            Close_Button.TabIndex = 12;
            Close_Button.TabStop = false;
            Close_Button.Click += Close_Button_Click;
            Close_Button.MouseEnter += Close_Button_MouseEnter;
            Close_Button.MouseLeave += Close_Button_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(263, 201);
            label7.Name = "label7";
            label7.Size = new Size(133, 17);
            label7.TabIndex = 30;
            label7.Text = "Modpack Description";
            // 
            // ModDescription_TB
            // 
            ModDescription_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModDescription_TB.BorderStyle = BorderStyle.FixedSingle;
            ModDescription_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModDescription_TB.ForeColor = SystemColors.ActiveCaption;
            ModDescription_TB.Location = new Point(66, 221);
            ModDescription_TB.Multiline = true;
            ModDescription_TB.Name = "ModDescription_TB";
            ModDescription_TB.ScrollBars = ScrollBars.Vertical;
            ModDescription_TB.Size = new Size(543, 69);
            ModDescription_TB.TabIndex = 29;
            ModDescription_TB.Text = "No description...";
            ModDescription_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(139, 122);
            label6.Name = "label6";
            label6.Size = new Size(123, 17);
            label6.TabIndex = 28;
            label6.Text = "Supported Versions";
            // 
            // SupportedWLVersions_CLB
            // 
            SupportedWLVersions_CLB.BackColor = Color.FromArgb(75, 68, 138);
            SupportedWLVersions_CLB.BorderStyle = BorderStyle.FixedSingle;
            SupportedWLVersions_CLB.ForeColor = SystemColors.ActiveCaption;
            SupportedWLVersions_CLB.FormattingEnabled = true;
            SupportedWLVersions_CLB.Location = new Point(66, 142);
            SupportedWLVersions_CLB.Name = "SupportedWLVersions_CLB";
            SupportedWLVersions_CLB.ScrollAlwaysVisible = true;
            SupportedWLVersions_CLB.SelectionMode = SelectionMode.None;
            SupportedWLVersions_CLB.Size = new Size(269, 56);
            SupportedWLVersions_CLB.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(421, 122);
            label5.Name = "label5";
            label5.Size = new Size(106, 17);
            label5.TabIndex = 26;
            label5.Text = "Modpack Author";
            // 
            // ModAuthor_TB
            // 
            ModAuthor_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModAuthor_TB.BorderStyle = BorderStyle.FixedSingle;
            ModAuthor_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModAuthor_TB.ForeColor = SystemColors.ActiveCaption;
            ModAuthor_TB.Location = new Point(341, 142);
            ModAuthor_TB.Name = "ModAuthor_TB";
            ModAuthor_TB.Size = new Size(269, 27);
            ModAuthor_TB.TabIndex = 25;
            ModAuthor_TB.Text = "Me";
            ModAuthor_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(278, 62);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 24;
            label4.Text = "Modpack Name";
            // 
            // ModName_TB
            // 
            ModName_TB.BackColor = Color.FromArgb(75, 68, 138);
            ModName_TB.BorderStyle = BorderStyle.FixedSingle;
            ModName_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_TB.ForeColor = SystemColors.ActiveCaption;
            ModName_TB.Location = new Point(66, 82);
            ModName_TB.Name = "ModName_TB";
            ModName_TB.Size = new Size(544, 27);
            ModName_TB.TabIndex = 23;
            ModName_TB.Text = "My Mod Pack";
            ModName_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(290, 293);
            label2.Name = "label2";
            label2.Size = new Size(95, 17);
            label2.TabIndex = 43;
            label2.Text = "Included Mods";
            // 
            // ModList_LB
            // 
            ModList_LB.BackColor = Color.FromArgb(75, 68, 138);
            ModList_LB.ForeColor = SystemColors.ActiveCaption;
            ModList_LB.FormattingEnabled = true;
            ModList_LB.ItemHeight = 15;
            ModList_LB.Location = new Point(66, 313);
            ModList_LB.Name = "ModList_LB";
            ModList_LB.ScrollAlwaysVisible = true;
            ModList_LB.SelectionMode = SelectionMode.None;
            ModList_LB.Size = new Size(543, 109);
            ModList_LB.TabIndex = 42;
            // 
            // CreateModPack_Button
            // 
            CreateModPack_Button.BackColor = Color.FromArgb(75, 68, 138);
            CreateModPack_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            CreateModPack_Button.FlatStyle = FlatStyle.Flat;
            CreateModPack_Button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateModPack_Button.ForeColor = SystemColors.ActiveCaption;
            CreateModPack_Button.Location = new Point(215, 440);
            CreateModPack_Button.Name = "CreateModPack_Button";
            CreateModPack_Button.Size = new Size(213, 45);
            CreateModPack_Button.TabIndex = 44;
            CreateModPack_Button.Text = "Create Modpack";
            CreateModPack_Button.UseVisualStyleBackColor = false;
            CreateModPack_Button.Click += CreateModPack_Button_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Select folder where your mod pack should be saved";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.CommonDocuments;
            // 
            // ModPackCreator
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(658, 502);
            Controls.Add(CreateModPack_Button);
            Controls.Add(label2);
            Controls.Add(ModList_LB);
            Controls.Add(label7);
            Controls.Add(ModDescription_TB);
            Controls.Add(label6);
            Controls.Add(SupportedWLVersions_CLB);
            Controls.Add(label5);
            Controls.Add(ModAuthor_TB);
            Controls.Add(label4);
            Controls.Add(ModName_TB);
            Controls.Add(Close_Button);
            Controls.Add(Icon_PB);
            Controls.Add(Separator_1);
            Controls.Add(TitlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ModPackCreator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mod Pack Creator";
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Icon_PB;
        private PictureBox Separator_1;
        private Panel TitlePanel;
        private Label ByLuckyLabel;
        private Label TitleLabel;
        private PictureBox Close_Button;
        private Label label7;
        private TextBox ModDescription_TB;
        private Label label6;
        private CheckedListBox SupportedWLVersions_CLB;
        private Label label5;
        private TextBox ModAuthor_TB;
        private Label label4;
        private TextBox ModName_TB;
        private Label label2;
        private ListBox ModList_LB;
        private Button CreateModPack_Button;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}