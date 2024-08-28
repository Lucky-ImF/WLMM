namespace WSMM
{
    partial class CustomMsgBox
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
            label20 = new Label();
            Remove_Button = new Button();
            RemoveAll_Button = new Button();
            Keep_Button = new Button();
            KeepAll_Button = new Button();
            ModName_Label = new Label();
            label22 = new Label();
            SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = SystemColors.ActiveCaption;
            label20.Location = new Point(155, 45);
            label20.Name = "label20";
            label20.Size = new Size(224, 21);
            label20.TabIndex = 47;
            label20.Text = "Do you want to keep it loaded?";
            // 
            // Remove_Button
            // 
            Remove_Button.BackColor = Color.FromArgb(75, 68, 138);
            Remove_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            Remove_Button.FlatStyle = FlatStyle.Flat;
            Remove_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Remove_Button.ForeColor = Color.LightCoral;
            Remove_Button.Location = new Point(134, 113);
            Remove_Button.Name = "Remove_Button";
            Remove_Button.Size = new Size(110, 30);
            Remove_Button.TabIndex = 46;
            Remove_Button.Text = "Remove";
            Remove_Button.UseVisualStyleBackColor = false;
            Remove_Button.Click += Remove_Button_Click;
            // 
            // RemoveAll_Button
            // 
            RemoveAll_Button.BackColor = Color.FromArgb(75, 68, 138);
            RemoveAll_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            RemoveAll_Button.FlatStyle = FlatStyle.Flat;
            RemoveAll_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemoveAll_Button.ForeColor = Color.LightCoral;
            RemoveAll_Button.Location = new Point(18, 113);
            RemoveAll_Button.Name = "RemoveAll_Button";
            RemoveAll_Button.Size = new Size(110, 30);
            RemoveAll_Button.TabIndex = 45;
            RemoveAll_Button.Text = "Remove All";
            RemoveAll_Button.UseVisualStyleBackColor = false;
            RemoveAll_Button.Click += RemoveAll_Button_Click;
            // 
            // Keep_Button
            // 
            Keep_Button.BackColor = Color.FromArgb(75, 68, 138);
            Keep_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            Keep_Button.FlatStyle = FlatStyle.Flat;
            Keep_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Keep_Button.ForeColor = Color.ForestGreen;
            Keep_Button.Location = new Point(290, 113);
            Keep_Button.Name = "Keep_Button";
            Keep_Button.Size = new Size(110, 30);
            Keep_Button.TabIndex = 44;
            Keep_Button.Text = "Keep";
            Keep_Button.UseVisualStyleBackColor = false;
            Keep_Button.Click += Keep_Button_Click;
            // 
            // KeepAll_Button
            // 
            KeepAll_Button.BackColor = Color.FromArgb(75, 68, 138);
            KeepAll_Button.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            KeepAll_Button.FlatStyle = FlatStyle.Flat;
            KeepAll_Button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KeepAll_Button.ForeColor = Color.ForestGreen;
            KeepAll_Button.Location = new Point(406, 113);
            KeepAll_Button.Name = "KeepAll_Button";
            KeepAll_Button.Size = new Size(110, 30);
            KeepAll_Button.TabIndex = 43;
            KeepAll_Button.Text = "Keep All";
            KeepAll_Button.UseVisualStyleBackColor = false;
            KeepAll_Button.Click += KeepAll_Button_Click;
            // 
            // ModName_Label
            // 
            ModName_Label.AutoSize = true;
            ModName_Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModName_Label.ForeColor = SystemColors.ActiveCaption;
            ModName_Label.Location = new Point(215, 75);
            ModName_Label.Name = "ModName_Label";
            ModName_Label.Size = new Size(101, 25);
            ModName_Label.TabIndex = 42;
            ModName_Label.Text = "ModName";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ActiveCaption;
            label22.Location = new Point(168, 7);
            label22.Name = "label22";
            label22.Size = new Size(198, 30);
            label22.TabIndex = 41;
            label22.Text = "Inactive Mod Found";
            // 
            // CustomMsgBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(75, 68, 138);
            ClientSize = new Size(534, 159);
            Controls.Add(label20);
            Controls.Add(Remove_Button);
            Controls.Add(RemoveAll_Button);
            Controls.Add(Keep_Button);
            Controls.Add(KeepAll_Button);
            Controls.Add(ModName_Label);
            Controls.Add(label22);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomMsgBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WLMM - Message Box";
            Load += CustomMsgBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label20;
        private Button Remove_Button;
        private Button RemoveAll_Button;
        private Button Keep_Button;
        private Button KeepAll_Button;
        private Label ModName_Label;
        private Label label22;
    }
}