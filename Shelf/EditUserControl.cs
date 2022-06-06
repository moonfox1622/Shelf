﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class EditUserControl : UserControl
    {
        public int id { get; set; }
        public string name { get; set; }
        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();

        public EditUserControl()
        {
            InitializeComponent();
        }

        private void EditLoad(object sender, EventArgs e)
        {
            tdb.GetToolByName(this.name, ref tool);
            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            txtRemain.Value = tool.remain;
            txtAlarm.Value = tool.warning;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名稱不可為空白", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("壽命不可小於剩餘壽命","警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tdb.CheckRepeatName(tool.id, txtName.Text))
            {
                MessageBox.Show("名稱重複", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("確定要修改嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            tool = new Tool
            {
                name = txtName.Text,
                life = Convert.ToInt32(txtLife.Value),
                remain = Convert.ToInt32(txtRemain.Value),
                warning = Convert.ToInt32(txtAlarm.Value)
            };

            if (tdb.EditTool(tool))
            {
                //tdb.HistoryInsert(tool, '5');
                MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void txtAlarm_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRemain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLife_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}