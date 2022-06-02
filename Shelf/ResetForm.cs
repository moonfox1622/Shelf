using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class ResetForm : Form
    {
        public int resetCount { get; set; }
        public ResetForm()
        {
            InitializeComponent();
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            if(MessageBox.Show("確定是否變更刀具數量?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                resetCount = Convert.ToInt32(numPick.Value);
                this.Close();
            }
        }
    }
}
