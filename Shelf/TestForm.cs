using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Shelf
{
    public partial class TestForm : Form
    {
        private delegate void updateGridUI();

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Shown(object sender, EventArgs e)
        {
            initalData();
        }

        private void initalData()
        {
            ToolDatabase tdb = new ToolDatabase();
            List<Tool> tList = new List<Tool>();
            tdb.GetToolByPage(ref tList, 1, 0, 28);

            for(int i = 0; i < 28; i++)
            {
                CircularProgressUserControl ui = new CircularProgressUserControl
                {
                    tool = tList[i]
                };
                ui.Margin = new Padding(10, 0, 0, 0);
                table.Controls.Add(ui);
            }

        }

        private void RunProgressBar()
        {
            while (true)
            {
                Thread.Sleep(100);
            }
        }

                
    }
}
