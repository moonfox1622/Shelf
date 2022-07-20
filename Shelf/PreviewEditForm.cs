using Shelf.Model;
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
    public partial class PreviewEditForm : Form
    {
        public List<Tool> Tools = new List<Tool>();
        public bool IsUpdate { get; set; }
        public Machine Mach { get; set; }
        public string act { get; set; }

        
        ToolDatabase tdb = new ToolDatabase();

        public PreviewEditForm()
        {
            InitializeComponent();
        }

        private void NewToolMode()
        {
            btnNew.Visible = true;
            toolGridView.Columns["delete"].Visible = true;
        }

        /// <summary>
        /// 新增刀具
        /// </summary>
        private void NewTool()
        {
            if (toolGridView.Rows.Count == 0)
            {
                MessageBox.Show("尚未新增任何刀具", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("確定要新增嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            for (int i = 0; i < toolGridView.Rows.Count; i++)
            {
                string name = toolGridView.Rows[i].Cells[1].Value.ToString();
                int life = Convert.ToInt32(toolGridView.Rows[i].Cells[2].Value);
                int remain = Convert.ToInt32(toolGridView.Rows[i].Cells[3].Value);
                int warning = Convert.ToInt32(toolGridView.Rows[i].Cells[4].Value);

                Tools.Add(new Tool
                {
                    Name = name,
                    Life = life,
                    Remain = remain,
                    Warning = warning,
                    LastUpdate = DateTime.Now
                });
            }
            
            foreach (Tool t in Tools)
            {
                
                if (!tdb.InsertTool(t, Mach.Id))
                    return;

                Log log = new Log
                {
                    MachineId = Mach.Id,
                    Name = t.Name,
                    Life = t.Life,
                    Remain = t.Remain,
                    Warning = t.Warning,
                    CreateTime = DateTime.Now,
                    Mark = "新增"
                };
                tdb.InsertSystemLog(log);
                IsUpdate = true;
                this.Close();
            }

        }

        /// <summary>
        /// 修改刀具
        /// </summary>
        private void EditTool()
        {
            ToolDatabase tdb = new ToolDatabase();
            if (MessageBox.Show("確定要修改嗎?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            for (int i = 0; i < toolGridView.Rows.Count; i++)
            {
                string name = toolGridView.Rows[i].Cells[1].Value.ToString();
                int life = Convert.ToInt32(toolGridView.Rows[i].Cells[2].Value);
                int remain = Convert.ToInt32(toolGridView.Rows[i].Cells[3].Value);
                int warning = Convert.ToInt32(toolGridView.Rows[i].Cells[4].Value);

                Tools[i].Name = name;
                Tools[i].Life = life;
                Tools[i].Remain = remain;
                Tools[i].Warning = warning;
                Tools[i].LastUpdate = DateTime.Now;
            }

            foreach (Tool t in Tools)
            {
                if (!tdb.EditTool(t))
                    return;

                string mark = "";
                if (act == "edit")
                    mark = "修改";
                else if (act == "change")
                    mark = "換刀";
                Log log = new Log
                {
                    MachineId = t.MachineId,
                    Name = t.Name,
                    Life = t.Life,
                    Remain = t.Remain,
                    Warning = t.Warning,
                    CreateTime = DateTime.Now,
                    Mark = mark
                };
                tdb.InsertSystemLog(log);
                IsUpdate = true;
                this.Close();
            }
        }

        /// <summary>
        /// 取消更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 送出修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnComfirmClick(object sender, EventArgs e)
        {
            if (!tdb.IsDatabaseConnected())
            {
                MessageBox.Show("資料庫連線失敗", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckError())
            {
                MessageBox.Show("資料出現錯誤，請檢查資料正確性。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            
            //執行新增或是修改
            if (act == "new")
                NewTool();
            else if (act == "edit" || act == "change")
                EditTool();
        }

        /// <summary>
        /// FormShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMuiltToolsFormShown(object sender, EventArgs e)
        {
            txtMachine.Text = Mach.Name;
            foreach (DataGridViewColumn c in toolGridView.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (act == "new")
            {
                NewToolMode();
                return;
            }
            for(int i = 0; i < Tools.Count; i++)
            {
                toolGridView.Rows.Add("X", Tools[i].Name, Tools[i].Life, Tools[i].Remain, Tools[i].Warning);
                if(Tools[i].Life < Tools[i].Remain || Tools[i].Warning > Tools[i].Life)
                {
                    toolGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    toolGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    toolGridView.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(151, 21, 64);
                    toolGridView.Rows[i].DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
            
            toolGridView.Columns["name"].ReadOnly = true;
            toolGridView.Columns["delete"].ReadOnly = true;

        }

        private void ToolGridViewCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //檢查最大磨耗值、剩餘磨耗值、警告值輸入是否為數字
            try
            {
                if (e.ColumnIndex != 1)
                    Convert.ToInt32(toolGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
            catch
            {
                toolGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
            }

            //檢查刀具名稱是否重複
            Tool tmp = new Tool();
            if (e.ColumnIndex == 1 && act == "new" && toolGridView.Rows[e.RowIndex].Cells[1].Value != null)
            {
                if (tdb.GetToolByName(toolGridView.Rows[e.RowIndex].Cells[1].Value.ToString(), Mach.Id, ref tmp))
                {
                    MessageBox.Show(toolGridView.Rows[e.RowIndex].Cells[1].Value.ToString() + " 名稱重複", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                    return;
                }
            }

            //檢查欄位是否為空
            int row = e.RowIndex;
            if (toolGridView.Rows[e.RowIndex].Cells[1].Value == null || toolGridView.Rows[e.RowIndex].Cells[2].Value == null || toolGridView.Rows[e.RowIndex].Cells[3].Value == null || toolGridView.Rows[e.RowIndex].Cells[4].Value == null)
            {
                toolGridView.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                toolGridView.Rows[row].DefaultCellStyle.ForeColor = Color.White;
                toolGridView.Rows[row].DefaultCellStyle.SelectionBackColor = Color.FromArgb(151, 21, 64);
                toolGridView.Rows[row].DefaultCellStyle.SelectionForeColor = Color.White;
                return;
            }

            
            //檢查最大磨耗值是否大於等於剩餘磨耗值及警告值
            int life = Convert.ToInt32(toolGridView.Rows[row].Cells[2].Value);
            int remain = Convert.ToInt32(toolGridView.Rows[row].Cells[3].Value);
            int warning = Convert.ToInt32(toolGridView.Rows[row].Cells[4].Value);

            if (life < remain || life < warning)
            {
                toolGridView.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                toolGridView.Rows[row].DefaultCellStyle.ForeColor = Color.White;
                toolGridView.Rows[row].DefaultCellStyle.SelectionBackColor = Color.FromArgb(151, 21, 64);
                toolGridView.Rows[row].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                toolGridView.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(241, 241, 241);
                toolGridView.Rows[row].DefaultCellStyle.ForeColor = Color.Black;
                toolGridView.Rows[row].DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                toolGridView.Rows[row].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 檢查
        /// </summary>
        /// <returns></returns>
        private bool CheckError()
        {
            bool status = true;
            foreach(DataGridViewRow row in toolGridView.Rows)
            {
                
                if(row.Cells["name"].Value == null || row.Cells["life"].Value == null || row.Cells["remain"].Value == null || row.Cells["warning"].Value == null)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(151, 21, 64);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                    status = false;
                }
            }
            return status;
        }

        private void BtnNewClick(object sender, EventArgs e)
        {
            toolGridView.Rows.Add("X");
            
        }

        private void ToolGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0)
                return;
            toolGridView.Rows.Remove(toolGridView.Rows[e.RowIndex]);

        }

        private void PreviewEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
