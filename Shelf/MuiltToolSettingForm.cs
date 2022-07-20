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
    public partial class MuiltToolSettingForm : Form
    {
        private ToolDatabase tdb = new ToolDatabase();
        private DataTable toolsData = new DataTable();
        private BindingSource bs = new BindingSource();
        public List<Tool> selectedTools = new List<Tool>();

        public MuiltToolSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得刀具
        /// </summary>
        /// <param name="machineId"></param>
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
                toolsData.Rows.Add(false, tools[i].Id,tools[i].Name, tools[i].Life, tools[i].Remain, tools[i].Warning);
            }
        }

        /// <summary>
        /// 讀取機台
        /// </summary>
        private void LoadMachine()
        {
            List<Machine> machines = new List<Machine>();
            if (!tdb.GetAllMachine(ref machines))
            {
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (Machine m in machines)
            {
                machineList.Items.Add(m);
            }

            machineList.SelectedIndex = 0;
        }

        /// <summary>
        /// DataTable 設定
        /// </summary>
        /// <returns></returns>
        private DataTable ToolsDataTable()
        {
            DataTable dt = new DataTable();

            

            DataColumn dc = new DataColumn();
            dc.ColumnName = "check";
            dc.DataType = dc.DataType = Type.GetType("System.Boolean");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "id";
            dt.Columns.Add(dc);

            dc = new DataColumn();
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

            return dt;
        }

        /// <summary>
        /// 設定 gridview
        /// </summary>
        private void GridViewSetting()
        {
            bs.DataSource = toolsData;
            toolGridView.DataSource = bs;

            //Set column header name
            toolGridView.Columns["check"].CellTemplate = new DataGridViewCheckBoxCell();
            toolGridView.Columns["check"].ReadOnly = false;
            toolGridView.Columns["check"].HeaderText = "";
            toolGridView.Columns["name"].HeaderText = "刀具名稱";
            toolGridView.Columns["life"].HeaderText = "最大磨耗";
            toolGridView.Columns["remain"].HeaderText = "剩餘磨耗";
            toolGridView.Columns["warning"].HeaderText = "警戒值";

            toolGridView.Columns["check"].Width = 50;
            toolGridView.Columns["check"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["life"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["remain"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            toolGridView.Columns["id"].Visible = false;
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
            }

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.FromArgb(241, 241, 241);
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
            cellStyle.SelectionForeColor = Color.Black;
            toolGridView.DefaultCellStyle = cellStyle;
        }

        /// <summary>
        /// 新增勾選刀具
        /// </summary>
        /// <param name="t"></param>
        private void NewSelectedTool(Tool t)
        {
            int height = 30;
            selectedTools.Add(t);

            selectedTools.Sort(delegate (Tool x, Tool y)
            {
                 return x.Id.CompareTo(y.Id);
            });

            PictureBox picClose = new PictureBox();
            picClose.Size = new Size(24, 24);
            picClose.Image = Properties.Resources.close_B;
            picClose.SizeMode = PictureBoxSizeMode.StretchImage;
            picClose.Click += new EventHandler(DeleSelectTool);
            picClose.Tag = selectedTools.Count;
            picClose.Margin = new Padding(3);
            picClose.Cursor = Cursors.Hand;
            deleListPanel.Controls.Add(picClose);

            Label txtTool = new Label();
            txtTool.Text = t.Name;
            txtTool.Font = new Font("微軟正黑體", 18);
            txtTool.Size = new Size(100, height);
            selectToolListPanel.Controls.Add(txtTool);
            for(int i = 0; i < selectedTools.Count; i++)
            {
                if(selectedTools[i].Name == t.Name)
                    selectToolListPanel.Controls.SetChildIndex(txtTool, i);
            }
            selectToolListPanel.Height += height;
            deleListPanel.Height += height;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolName"></param>
        private void RemoveSelectedTool(string toolName)
        {
            for(int i = 0; i < selectedTools.Count; i++)
            {
                if(toolName == selectedTools[i].Name)
                {
                    selectedTools.RemoveAt(i);
                    deleListPanel.Controls.RemoveAt(i);
                    selectToolListPanel.Controls.RemoveAt(i);
                    break;
                }
            }
        }

        private void MuiltToolSettingFormShown(object sender, EventArgs e)
        {
            LoadMachine();
            GridViewSetting();
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
            ClearSelectedTool();
        }

        /// <summary>
        /// 選擇或取消刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.ColumnIndex==0)
            if ((bool)toolGridView.Rows[e.RowIndex].Cells["check"].Value == true)
            {
                toolGridView.Rows[e.RowIndex].Cells["check"].Value = false;
                RemoveSelectedTool(toolGridView.Rows[e.RowIndex].Cells["name"].Value.ToString());
            }
            else
            {
                toolGridView.Rows[e.RowIndex].Cells["check"].Value = true;
                Tool t = new Tool
                {
                    Id = Convert.ToInt32(toolGridView.Rows[e.RowIndex].Cells["Id"].Value),
                    MachineId = (machineList.SelectedItem as Machine).Id,
                    Name = toolGridView.Rows[e.RowIndex].Cells["name"].Value.ToString(),
                    Life = Convert.ToInt32(toolGridView.Rows[e.RowIndex].Cells["life"].Value),
                    Remain = Convert.ToInt32(toolGridView.Rows[e.RowIndex].Cells["remain"].Value),
                    Warning = Convert.ToInt32(toolGridView.Rows[e.RowIndex].Cells["warning"].Value)
                };
                NewSelectedTool(t);
            }
        }

        /// <summary>
        /// 按下刪除圖示取消選擇此刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleSelectTool(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            int num = c.Parent.Controls.GetChildIndex(c);

            deleListPanel.Controls.RemoveAt(num);
            selectToolListPanel.Controls.RemoveAt(num);

            for(int i = 0; i < toolGridView.Rows.Count; i++)
            {
                if (Convert.ToInt32(toolGridView.Rows[i].Cells["id"].Value) == selectedTools[num].Id)
                {
                    toolGridView.Rows[i].Cells["check"].Value = false;
                    break;
                }
            }
            selectedTools.RemoveAt(num);
        }

        /// <summary>
        /// 開啟預覽變更頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSimSettingClick(object sender, EventArgs e)
        {
            if(selectedTools.Count == 0)
            {
                MessageBox.Show("尚未選擇欲修改之刀具", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EditMulitToolsForm edit = new EditMulitToolsForm();
            edit.ShowDialog();
            if (!edit.Send)
                return;
            PreviewEditForm preview = new PreviewEditForm();
            for (int i = 0; i < selectedTools.Count; i++)
            {
                Tool t = new Tool
                {
                    Id = selectedTools[i].Id,
                    MachineId = selectedTools[i].MachineId,
                    Name = selectedTools[i].Name,
                    Life = selectedTools[i].Life,
                    Remain = selectedTools[i].Remain,
                    Warning = selectedTools[i].Warning,
                    LastUpdate = DateTime.Now
                };
                preview.Tools.Add(t);
                if (!string.IsNullOrWhiteSpace(edit.Life))
                    preview.Tools[i].Life = Convert.ToInt32(edit.Life);
                if (!string.IsNullOrWhiteSpace(edit.Remain))
                    preview.Tools[i].Remain = Convert.ToInt32(edit.Remain);
                if (!string.IsNullOrWhiteSpace(edit.Warning))
                    preview.Tools[i].Warning = Convert.ToInt32(edit.Warning);
            }
            preview.Mach = machineList.SelectedItem as Machine;
            preview.act = "edit";

            preview.ShowDialog();
            if (preview.IsUpdate)
            {
                LoadTool((machineList.SelectedItem as Machine).Id);
                if (toolsData.Rows.Count == 0)
                    return;
                GridViewSetting();
                GridViewStyle();
                ClearSelectedTool();
            }
        }

        /// <summary>
        /// 清除選擇刀具
        /// </summary>
        private void ClearSelectedTool()
        {
            selectToolListPanel.Height = 0;
            deleListPanel.Height = 0;
            for (int i = 0; i < toolGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(toolGridView.Rows[i].Cells["check"].Value))
                {
                    toolGridView.Rows[i].Cells["check"].Value = false;
                }
            }
            DisposePanel(deleListPanel);
            DisposePanel(selectToolListPanel);
            selectedTools.Clear();
            btnSelectAll.Tag = "select";
            btnSelectAll.Text = "全選";
        }

        /// <summary>
        /// 清除Panel物件
        /// </summary>
        /// <param name="p"></param>
        private void DisposePanel(FlowLayoutPanel p)
        {
            //while (p.Controls.Count > 0)
            //{
            //    p.Controls.Remove(p.Controls[0]);
            //}
            p.Controls.Clear();
        }
       
        /// <summary>
        /// 執行換刀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeToolClick(object sender, EventArgs e)
        {
            if (selectedTools.Count == 0)
            {
                MessageBox.Show("尚未選擇任何刀具", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PreviewEditForm preview = new PreviewEditForm();
            for (int i = 0; i < selectedTools.Count; i++)
            {
                Tool t = new Tool
                {
                    Id = selectedTools[i].Id,
                    MachineId = selectedTools[i].MachineId,
                    Name = selectedTools[i].Name,
                    Life = selectedTools[i].Life,
                    Remain = selectedTools[i].Life,
                    Warning = selectedTools[i].Warning,
                    LastUpdate = DateTime.Now
                };
                preview.Tools.Add(t);
            }
            preview.Mach = machineList.SelectedItem as Machine;
            preview.act = "change";
            preview.ShowDialog();
            if (preview.IsUpdate)
            {
                LoadTool((machineList.SelectedItem as Machine).Id);
                if (toolsData.Rows.Count == 0)
                    return;
                GridViewSetting();
                GridViewStyle();
                ClearSelectedTool();
            }
        }

        /// <summary>
        /// 刀具全選或取消全選
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectAllClick(object sender, EventArgs e)
        {
            if(btnSelectAll.Tag.ToString() == "select")
            {
                btnSelectAll.Tag = "cancle";
                btnSelectAll.Text = "取消全選";
                for (int i = 0; i < toolGridView.Rows.Count; i++)
                {
                    toolGridView.Rows[i].Cells["check"].Value = true;
                    Tool t = new Tool
                    {
                        Id = Convert.ToInt32(toolGridView.Rows[i].Cells["Id"].Value),
                        MachineId = (machineList.SelectedItem as Machine).Id,
                        Name = toolGridView.Rows[i].Cells["name"].Value.ToString(),
                        Life = Convert.ToInt32(toolGridView.Rows[i].Cells["life"].Value),
                        Remain = Convert.ToInt32(toolGridView.Rows[i].Cells["remain"].Value),
                        Warning = Convert.ToInt32(toolGridView.Rows[i].Cells["warning"].Value)
                    };
                    NewSelectedTool(t);
                }
            }
            else if(btnSelectAll.Tag.ToString() == "cancle")
            {
                btnSelectAll.Tag = "select";
                btnSelectAll.Text = "全選";
                for (int i = 0; i < toolGridView.Rows.Count; i++)
                {
                    toolGridView.Rows[i].Cells["check"].Value = false;
                }
                ClearSelectedTool();
            }
            
        }


        private void BtnClearListClick(object sender, EventArgs e)
        {
            ClearSelectedTool();
            btnSelectAll.Tag = "select";
            btnSelectAll.Text = "全選";
            for (int i = 0; i < toolGridView.Rows.Count; i++)
            {
                toolGridView.Rows[i].Cells["check"].Value = false;
            }
        }

        private void BtnSettingClick(object sender, EventArgs e)
        {
            PreviewEditForm preview = new PreviewEditForm();
            if (selectedTools.Count == 0)
            {
                MessageBox.Show("尚未選擇任何刀具", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < selectedTools.Count; i++)
            {
                Tool t = new Tool
                {
                    Id = selectedTools[i].Id,
                    MachineId = selectedTools[i].MachineId,
                    Name = selectedTools[i].Name,
                    Life = selectedTools[i].Life,
                    Remain = selectedTools[i].Remain,
                    Warning = selectedTools[i].Warning,
                    LastUpdate = DateTime.Now
                };
                preview.Tools.Add(t);
            }
            preview.Mach = machineList.SelectedItem as Machine;
            preview.act = "edit";
            preview.ShowDialog();
            if (!preview.IsUpdate)
                return;

            ClearSelectedTool();
            LoadTool((machineList.SelectedItem as Machine).Id);
            if (toolsData.Rows.Count == 0)
                return;
            GridViewSetting();
            GridViewStyle();
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            if (selectedTools.Count == 0)
            {
                MessageBox.Show("尚未選擇任何刀具", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("確定要刪除選取之刀具嗎，刪除後不可復原", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (!tdb.IsDatabaseConnected())
            {
                MessageBox.Show("資料庫連接失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(Tool t in selectedTools)
            {
                tdb.DeleteTool(t.Name, t.MachineId);
                Log log = new Log
                {
                    MachineId = t.MachineId,
                    Name = t.Name,
                    Life = t.Life,
                    Remain = t.Remain,
                    Warning = t.Warning,
                    CreateTime = DateTime.Now,
                    Mark = "刪除"
                };
                tdb.InsertSystemLog(log);
            }
            ClearSelectedTool();
            LoadTool((machineList.SelectedItem as Machine).Id);
            if (toolsData.Rows.Count == 0)
                return;
            GridViewSetting();
            GridViewStyle();
        }

        private void ToolGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                    e.CellBounds.Width - 2, e.CellBounds.Height - 2,
                    (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
                e.Handled = true;
            }
        }

        private void BtnNewClick(object sender, EventArgs e)
        {
            PreviewEditForm preview = new PreviewEditForm();
            preview.act = "new";
            preview.Mach = machineList.SelectedItem as Machine;
            preview.ShowDialog();
            if (!preview.IsUpdate)
                return;
            ClearSelectedTool();
            LoadTool((machineList.SelectedItem as Machine).Id);
            if (toolsData.Rows.Count == 0)
                return;
            GridViewSetting();
            GridViewStyle();
        }

        private void MuiltToolSettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
