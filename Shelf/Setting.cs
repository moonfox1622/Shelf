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
    public partial class Setting : Form
    {
        public string name { get; set; }
        public bool isDelete { get; set; }
        ToolDatabase tdb = new ToolDatabase();
        public Setting()
        {
            InitializeComponent();
            isDelete = false;
        }

        private void SettingShown(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Info info = new Info { name = this.name };
            info.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(info);

            picInfo.BorderStyle = BorderStyle.Fixed3D;
        }

        private void InfoPage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Info info = new Info { name = this.name};
            info.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(info);

            picInfo.BorderStyle = BorderStyle.Fixed3D;
            picChange.BorderStyle = BorderStyle.None;
            picEdit.BorderStyle = BorderStyle.None;
        }

        private void ChangePage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Change change = new Change { name = this.name };
            change.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(change);

            picInfo.BorderStyle = BorderStyle.None;
            picChange.BorderStyle = BorderStyle.Fixed3D;
            picEdit.BorderStyle = BorderStyle.None;
        }

        private void EditPage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Edit edit = new Edit { name = this.name };
            edit.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(edit);

            picInfo.BorderStyle = BorderStyle.None;
            picChange.BorderStyle = BorderStyle.None;
            picEdit.BorderStyle = BorderStyle.Fixed3D;
        }

        /// <summary>
        /// 刪除刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTool(object sender, EventArgs e)
        {
            Tool t = new Tool();
            tdb.GetToolByName(name, ref t);
            if (MessageBox.Show("確定要刪除「" + t.name + "」嗎", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (tdb.DeleteTool(name))
                {
                    tdb.HistoryInsert(t, '6');
                    isDelete = true;
                    this.Close();
                }
            }
        }

        
    }
}
