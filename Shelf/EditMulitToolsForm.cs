using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shelf
{
    public partial class EditMulitToolsForm : Form
    {
        public List<Tool> tools = new List<Tool>();
        public string Life { get; set; }
        public string Remain { get; set; }
        public string Warning { get; set; }
        public bool Send = false;

        public EditMulitToolsForm()
        {
            InitializeComponent();
        }

        private void BtnSendClick(object sender, EventArgs e)
        {
            Life = txtLife.Text;
            Remain = txtRemain.Text;
            Warning = txtWarning.Text;
            Send = true;
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
