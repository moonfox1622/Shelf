using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class DashboardSettingForm : Form
    {
        public int carouselSpeed { get; set; }

        public Machine machine { get; set; }

        ToolDatabase tdb = new ToolDatabase();
        public DashboardSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DashboardSettingFormShown(object sender, EventArgs e)
        {
            LoadMachine();
            if (carouselSpeed > 0)
            {
                checkCarousel.Checked = true;
                numSpeed.Value = carouselSpeed;
            }
            else
            {
                numSpeed.Enabled = false;
            }

            foreach(Machine m in machineList.Items)
            {
                if (m.Id == machine.Id)
                    machineList.SelectedItem = m;
            }
        }

        private void BtnConfirmClick(object sender, EventArgs e)
        {
            carouselSpeed = Convert.ToInt32(numSpeed.Value);
            if (!checkCarousel.Checked)
                carouselSpeed = 0;

            this.Close();
        }

        private void CheckCarouselCheckedChanged(object sender, EventArgs e)
        {
            machineList.Enabled = !checkCarousel.Checked;
            numSpeed.Enabled = checkCarousel.Checked;
        }

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

        }

        private void MachineListSelectedIndexChanged(object sender, EventArgs e)
        {
            machine = machineList.SelectedItem as Machine;
        }

        private void SpeedChange(object sender, EventArgs e)
        {
            carouselSpeed = Convert.ToInt32(numSpeed.Value);
        }

        private void DashboardSettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
