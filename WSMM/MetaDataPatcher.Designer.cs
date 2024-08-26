namespace WSMM
{
    partial class MetaDataPatcher
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
            Close_Button = new PictureBox();
            Separator_1 = new PictureBox();
            TitlePanel = new Panel();
            ByLuckyLabel = new Label();
            TitleLabel = new Label();
            label1 = new Label();
            WLMMPath_TB = new TextBox();
            WLMMPathBrowse_Button = new Button();
            WLMMCurrentMetaData_TB = new TextBox();
            PatchMetaData_TB = new TextBox();
            label2 = new Label();
            ApplyPatch_Button = new Button();
            openFileDialog1 = new OpenFileDialog();
            PasteData_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)Icon_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).BeginInit();
            TitlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // Icon_PB
            // 
            Icon_PB.Image = Properties.Resources.WLMM_Small_Icon;
            Icon_PB.Location = new Point(5, 5);
            Icon_PB.Name = "Icon_PB";
            Icon_PB.Size = new Size(70, 70);
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
            Close_Button.Location = new Point(602, 5);
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
            Separator_1.Location = new Point(84, 38);
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
            TitlePanel.Location = new Point(-1, -1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(661, 40);
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
            TitleLabel.Location = new Point(196, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(268, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "WLMM - MetaData Patcher";
            TitleLabel.MouseDown += TitlePanel_MouseDown;
            TitleLabel.MouseMove += TitlePanel_MouseMove;
            TitleLabel.MouseUp += TitlePanel_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(234, 64);
            label1.Name = "label1";
            label1.Size = new Size(190, 21);
            label1.TabIndex = 9;
            label1.Text = "Select .wlmm file to patch:";
            // 
            // WLMMPath_TB
            // 
            WLMMPath_TB.AllowDrop = true;
            WLMMPath_TB.BackColor = Color.FromArgb(75, 68, 138);
            WLMMPath_TB.BorderStyle = BorderStyle.FixedSingle;
            WLMMPath_TB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WLMMPath_TB.ForeColor = SystemColors.ActiveCaption;
            WLMMPath_TB.Location = new Point(24, 91);
            WLMMPath_TB.Name = "WLMMPath_TB";
            WLMMPath_TB.Size = new Size(612, 27);
            WLMMPath_TB.TabIndex = 10;
            WLMMPath_TB.Text = "None";
            WLMMPath_TB.TextAlign = HorizontalAlignment.Center;
            WLMMPath_TB.DragDrop += WLMMPath_TB_DragDrop;
            WLMMPath_TB.DragEnter += WLMMPath_TB_DragEnter;
            // 
            // WLMMPathBrowse_Button
            // 
            WLMMPathBrowse_Button.BackColor = Color.FromArgb(75, 68, 138);
            WLMMPathBrowse_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            WLMMPathBrowse_Button.FlatStyle = FlatStyle.Flat;
            WLMMPathBrowse_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WLMMPathBrowse_Button.ForeColor = SystemColors.ActiveCaption;
            WLMMPathBrowse_Button.Location = new Point(557, 65);
            WLMMPathBrowse_Button.Name = "WLMMPathBrowse_Button";
            WLMMPathBrowse_Button.Size = new Size(79, 22);
            WLMMPathBrowse_Button.TabIndex = 29;
            WLMMPathBrowse_Button.Text = "Browse...";
            WLMMPathBrowse_Button.UseVisualStyleBackColor = false;
            WLMMPathBrowse_Button.Click += WLMMPathBrowse_Button_Click;
            // 
            // WLMMCurrentMetaData_TB
            // 
            WLMMCurrentMetaData_TB.BackColor = Color.FromArgb(75, 68, 138);
            WLMMCurrentMetaData_TB.BorderStyle = BorderStyle.FixedSingle;
            WLMMCurrentMetaData_TB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WLMMCurrentMetaData_TB.ForeColor = SystemColors.ActiveCaption;
            WLMMCurrentMetaData_TB.Location = new Point(24, 124);
            WLMMCurrentMetaData_TB.Multiline = true;
            WLMMCurrentMetaData_TB.Name = "WLMMCurrentMetaData_TB";
            WLMMCurrentMetaData_TB.ReadOnly = true;
            WLMMCurrentMetaData_TB.ScrollBars = ScrollBars.Vertical;
            WLMMCurrentMetaData_TB.Size = new Size(612, 81);
            WLMMCurrentMetaData_TB.TabIndex = 30;
            WLMMCurrentMetaData_TB.Text = "ModName = Empty Mod\r\nModAuthor = Lucky\r\nModVersion = v.1.0\r\nSupportedWLVersions = 2024.08.22_Shipping_Full_Build_1\r\nModURL = None";
            // 
            // PatchMetaData_TB
            // 
            PatchMetaData_TB.BackColor = Color.FromArgb(75, 68, 138);
            PatchMetaData_TB.BorderStyle = BorderStyle.FixedSingle;
            PatchMetaData_TB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PatchMetaData_TB.ForeColor = SystemColors.ActiveCaption;
            PatchMetaData_TB.Location = new Point(24, 242);
            PatchMetaData_TB.Multiline = true;
            PatchMetaData_TB.Name = "PatchMetaData_TB";
            PatchMetaData_TB.ScrollBars = ScrollBars.Vertical;
            PatchMetaData_TB.Size = new Size(612, 81);
            PatchMetaData_TB.TabIndex = 34;
            PatchMetaData_TB.Text = "ModName = Empty Mod\r\nModAuthor = Lucky\r\nModVersion = v.1.0\r\nSupportedWLVersions = 2024.08.22_Shipping_Full_Build_1\r\nModURL = None";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(287, 217);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 31;
            label2.Text = "Patch data:";
            // 
            // ApplyPatch_Button
            // 
            ApplyPatch_Button.BackColor = Color.FromArgb(75, 68, 138);
            ApplyPatch_Button.Enabled = false;
            ApplyPatch_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            ApplyPatch_Button.FlatStyle = FlatStyle.Flat;
            ApplyPatch_Button.Font = new Font("Segoe UI", 12F);
            ApplyPatch_Button.ForeColor = SystemColors.ActiveCaption;
            ApplyPatch_Button.Location = new Point(242, 339);
            ApplyPatch_Button.Name = "ApplyPatch_Button";
            ApplyPatch_Button.Size = new Size(175, 31);
            ApplyPatch_Button.TabIndex = 35;
            ApplyPatch_Button.Text = "Apply Patch";
            ApplyPatch_Button.UseVisualStyleBackColor = false;
            ApplyPatch_Button.Click += ApplyPatch_Button_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = ".wlmm files (*.wlmm)|*.wlmm";
            // 
            // PasteData_Button
            // 
            PasteData_Button.BackColor = Color.FromArgb(75, 68, 138);
            PasteData_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            PasteData_Button.FlatStyle = FlatStyle.Flat;
            PasteData_Button.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasteData_Button.ForeColor = SystemColors.ActiveCaption;
            PasteData_Button.Location = new Point(463, 216);
            PasteData_Button.Name = "PasteData_Button";
            PasteData_Button.Size = new Size(173, 22);
            PasteData_Button.TabIndex = 36;
            PasteData_Button.Text = "Paste Data from Clipboard";
            PasteData_Button.UseVisualStyleBackColor = false;
            PasteData_Button.Click += PasteData_Button_Click;
            // 
            // MetaDataPatcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 34, 81);
            ClientSize = new Size(658, 385);
            ControlBox = false;
            Controls.Add(PasteData_Button);
            Controls.Add(ApplyPatch_Button);
            Controls.Add(PatchMetaData_TB);
            Controls.Add(label2);
            Controls.Add(WLMMCurrentMetaData_TB);
            Controls.Add(WLMMPathBrowse_Button);
            Controls.Add(WLMMPath_TB);
            Controls.Add(label1);
            Controls.Add(Icon_PB);
            Controls.Add(Close_Button);
            Controls.Add(Separator_1);
            Controls.Add(TitlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MetaDataPatcher";
            Text = "MetaDataPatcher";
            Load += MetaDataPatcher_Load;
            ((System.ComponentModel.ISupportInitialize)Icon_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)Close_Button).EndInit();
            ((System.ComponentModel.ISupportInitialize)Separator_1).EndInit();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
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
        private Label label1;
        private TextBox WLMMPath_TB;
        private Button WLMMPathBrowse_Button;
        private TextBox WLMMCurrentMetaData_TB;
        private TextBox PatchMetaData_TB;
        private Label label2;
        private Button ApplyPatch_Button;
        private OpenFileDialog openFileDialog1;
        private Button PasteData_Button;
    }
}