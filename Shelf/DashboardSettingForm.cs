﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class DashboardSettingForm : Form
    {
        public int carouselSpeed { get; set; }
        public int machineId { get; set; }
        public string machineName { get; set; }

        ToolDatabase tdb = new ToolDatabase();
        public DashboardSettingForm()
        {
            InitializeComponent();
        }

        private void DashboardSettingFormShown(object sender, EventArgs e)
        {
            LoadMachine();
            if (carouselSpeed > 0)
            {
                checkCarousel.Checked = true;
                numSpeed.Value = carouselSpeed;
            }
                
            
            foreach(Machine m in machineList.Items)
            {
                if (m.id == machineId)
                    machineList.SelectedItem = m;
            }
        }

        private void BtnConfirmClick(object sender, EventArgs e)
        {
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
            machineId = (machineList.SelectedItem as Machine).id;
            machineName = machineList.SelectedItem.ToString();
        }

        private void SpeedChange(object sender, EventArgs e)
        {
            carouselSpeed = Convert.ToInt32(numSpeed.Value);
        }
    }
}
