using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMM
{
    public partial class CustomMsgBox : Form
    {
        Form myParent = null;
        public CustomMsgBox()
        {
            InitializeComponent();
        }

        private void Keep_Button_Click(object sender, EventArgs e)
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                myParent.Enabled = true;
            });
            this.DialogResult = DialogResult.Yes;
        }

        private void KeepAll_Button_Click(object sender, EventArgs e)
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                myParent.Enabled = true;
            });
            this.DialogResult = DialogResult.Continue;
        }

        private void Remove_Button_Click(object sender, EventArgs e)
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                myParent.Enabled = true;
            });
            this.DialogResult= DialogResult.No;
        }

        private void RemoveAll_Button_Click(object sender, EventArgs e)
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                myParent.Enabled = true;
            });
            this.DialogResult = DialogResult.Cancel;
        }

        public void InactiveMod(string ModName, Form myParent_)
        {
            myParent = myParent_;
            ModName_Label.Text = ModName;
            ModName_Label.Left = this.Width / 2 - ModName_Label.Width / 2;
        }
    }
}
