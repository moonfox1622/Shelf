using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class SettingPageForm : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable toolsData = new DataTable();
        private BindingSource bs = new BindingSource();

        public SettingPageForm()
        {
            InitializeComponent();
        }

        private void SettingShown(object sender, EventArgs e)
        {
            LoadMachine();
            GridViewSetting();
        }
        private void LoadMachine()
        {
            List<Machine> machines = new List<Machine>();
            if (!tdb.GetAllMachine(ref machines))
            {
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            foreach(Machine m in machines)
            {
                machineList.Items.Add(m);
            }

            machineList.SelectedIndex = 0;
        }

        /// <summary>
        /// 讀取刀具資料
        /// </summary>
        /// <param name="machineId">機台名稱</param>
        private void LoadTool(int machineId)
        {
            List<Tool> tools = new List<Tool>();
            toolsData.Clear();
            toolsData = ToolsDataTable();
            if (!tdb.GetToolByMachineId(ref tools, machineId))
            {
                MessageBox.Show("查無刀具資料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            for (int i = 0; i < tools.Count; i++)
            {
                toolsData.Rows.Add(tools[i].Name, tools[i].Life, tools[i].Remain, tools[i].Warning, "設定", "換刀", "刪除");
            }
        }

        /// <summary>
        /// DataTable 設定
        /// </summary>
        /// <returns></returns>
        private DataTable ToolsDataTable()
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "name";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "life";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "remain";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "warning";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "setting";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "change";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "delete";
            dt.Columns.Add(dc);

            return dt;
        }

        private void GridViewSetting()
        {
            bs.DataSource = toolsData;
            toolGridView.DataSource = bs;

            //Set column header name
            toolGridView.Columns["name"].HeaderText = "刀具名稱";
            toolGridView.Columns["life"].HeaderText = "最大磨耗";
            toolGridView.Columns["remain"].HeaderText = "剩餘磨耗";
            toolGridView.Columns["warning"].HeaderText = "警戒值";
            toolGridView.Columns["setting"].HeaderText = "設定";
            toolGridView.Columns["change"].HeaderText = "換刀";
            toolGridView.Columns["delete"].HeaderText = "刪除";

            int width = 80;
            
            toolGridView.Columns["setting"].Width = width;
            toolGridView.Columns["change"].Width = width;
            toolGridView.Columns["delete"].Width = width;

            toolGridView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["life"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["remain"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["setting"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["change"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["delete"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        
        public void GridViewStyle()
        {
            //Set Cell warning, setting as buttonCell
            foreach (DataGridViewRow row in toolGridView.Rows)
            {

                if (Convert.ToInt32(row.Cells["remain"].Value) <= Convert.ToInt32(row.Cells["warning"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(151, 21, 64);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                DataGridViewCellStyle btnStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(223, 224, 227),
                    ForeColor = Color.Black,
                    SelectionBackColor = Color.FromArgb(223, 224, 227),
                    SelectionForeColor = Color.Black,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("微軟正黑體", 14, FontStyle.Bold)
                };
                DataGridViewButtonCell settingButtonCell = new DataGridViewButtonCell
                {
                    FlatStyle = FlatStyle.Popup,
                    Style = btnStyle

                };
                DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell
                {
                    FlatStyle = FlatStyle.Popup,
                    Style = btnStyle

                };
                DataGridViewButtonCell changeButtonCell = new DataGridViewButtonCell
                {
                    FlatStyle = FlatStyle.Popup,
                    Style = btnStyle

                };
                row.Cells["setting"] = settingButtonCell;
                row.Cells["delete"] = deleteButtonCell;
                row.Cells["change"] = changeButtonCell;
            }

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.FromArgb(241, 241, 241);
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
            cellStyle.SelectionForeColor = Color.Black;
            toolGridView.DefaultCellStyle = cellStyle;
        }

        /// <summary>
        /// 更換機台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MachineChange(object sender, EventArgs e)
        {
            LoadTool((machineList.SelectedItem as Machine).Id);
            Bitmap picture = (Bitmap)Properties.Resources.ResourceManager.GetObject((machineList.SelectedItem as Machine).Picture);
            picMachine.Image = picture;
            txtMachDescrible.Text = (machineList.SelectedItem as Machine).Describe;
            if (toolsData.Rows.Count == 0)
                return;
            GridViewSetting();
            GridViewStyle();
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (col == 4 && row != -1)
            {
                Edit(row);
            }else if(col == 5 && row != -1)
            {
                Change(row);
            }
            else if(col == 6 && row != -1)
            {
                Delete(row);
            }
            
        }

        private void Edit(int row)
        {
            EditForm editPadge = new EditForm
            {
                machineId = (machineList.SelectedItem as Machine).Id,
                name = toolGridView[0, row].Value.ToString()
            };
            editPadge.ShowDialog();
            Tool t = new Tool();
            tdb.GetToolByName(toolGridView[0, row].Value.ToString(), (machineList.SelectedItem as Machine).Id, ref t);
            toolGridView.Rows[row].Cells["name"].Value = t.Name;
            toolGridView.Rows[row].Cells["life"].Value = t.Life;
            toolGridView.Rows[row].Cells["remain"].Value = t.Remain;
            toolGridView.Rows[row].Cells["warning"].Value = t.Warning;
            GridViewStyle();
        } 

        private void Change(int row)
        {
            if (MessageBox.Show("確定要對「" + toolGridView.Rows[row].Cells["name"].Value + "」進行更換嗎？", "換刀", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int beforeChangeLife = Convert.ToInt32(toolGridView.Rows[row].Cells["remain"].Value.ToString());
                Tool t = new Tool();
                if (!tdb.GetToolByName(toolGridView.Rows[row].Cells["name"].Value.ToString(), (machineList.SelectedItem as Machine).Id, ref t))
                    return;
                t.Remain = t.Life;
                t.StartTime = DateTime.Now;
                t.EndTime = DateTime.Now;
                
                    
                if (!tdb.ChangeTool(t))
                {
                    MessageBox.Show("更換失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Log log = new Log
                {
                    MachineId = (machineList.SelectedItem as Machine).Id,
                    Name = t.Name,
                    Life = t.Life,
                    Remain = t.Remain,
                    Warning = t.Warning,
                    CreateTime = DateTime.Now,
                    Mark = "換刀"
                };
                if (!tdb.InsertSystemLog(log))
                {
                    MessageBox.Show("紀錄更換歷史失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                

                toolGridView.Rows[row].Cells["remain"].Value = t.Life;
                GridViewStyle();
                MessageBox.Show("更換成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Delete(int row)
        {
            if (MessageBox.Show("確定要刪除「" + toolGridView.Rows[row].Cells["name"].Value + "」嗎？", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Tool t = new Tool();
                if (!tdb.GetToolByName(toolGridView.Rows[row].Cells["name"].Value.ToString(), (machineList.SelectedItem as Machine).Id, ref t))
                    return;
                if (!tdb.DeleteTool(t.Name, t.MachineId))
                {
                    MessageBox.Show("刪除失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                toolGridView.Rows.Remove(toolGridView.Rows[row]);
                Log log = new Log
                {
                    MachineId = (machineList.SelectedItem as Machine).Id,
                    Name = t.Name,
                    Life = t.Life,
                    Remain = t.Remain,
                    Warning = t.Warning,
                    CreateTime = DateTime.Now,
                    Mark = "刪除"
                };
                if (!tdb.InsertSystemLog(log))
                {
                    MessageBox.Show("紀錄更換歷史失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("刪除成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNewToolClick(object sender, EventArgs e)
        {
            NewToolForm newTool = new NewToolForm();
            newTool.machineId = (machineList.SelectedItem as Machine).Id;
            newTool.ShowDialog();
            if (!newTool.hasNew)
                return;
            Tool t = newTool.tool;
            toolsData.Rows.Add(t.Name, t.Life, t.Remain, t.Warning, "設定", "換刀", "刪除");
            GridViewStyle();
        }

       
    }
}