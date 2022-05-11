﻿using System;
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
        public List<NewData> datas = new List<NewData>();
        
        Point loc = new Point(8, 139);
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            datas.Add(newData1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewData d = new NewData();
            d.Location = loc;
            d.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(d);
            datas.Add(d);
            loc.Y += 89;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
