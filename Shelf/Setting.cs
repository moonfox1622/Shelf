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
        public int id { get; set; }
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
            Info info = new Info { id = this.id };
            info.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(info);

            picInfo.BorderStyle = BorderStyle.Fixed3D;
        }

        private void InfoPage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Info info = new Info { id = this.id};
            info.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(info);

            picInfo.BorderStyle = BorderStyle.Fixed3D;
            picChange.BorderStyle = BorderStyle.None;
            picEdit.BorderStyle = BorderStyle.None;
        }

        private void ChangePage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Change change = new Change { id = this.id };
            change.Dock = DockStyle.Fill;
            settingPanel.Controls.Add(change);

            picInfo.BorderStyle = BorderStyle.None;
            picChange.BorderStyle = BorderStyle.Fixed3D;
            picEdit.BorderStyle = BorderStyle.None;
        }

        private void EditPage(object sender, EventArgs e)
        {
            settingPanel.Controls.Clear();
            Edit edit = new Edit { id = this.id };
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
            tdb.GetToolById(id, ref t);
            if (MessageBox.Show("確定要刪除「" + t.name + "」嗎", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (tdb.DeleteTool(id))
                {
                    tdb.HistoryInsert(t, '6');
                    isDelete = true;
                    this.Close();
                }
            }
        }

        
    }
}
