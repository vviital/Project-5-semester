using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartHome;

namespace SmartHomeForms
{
    public partial class MainForm : Form
    {
        private House _house;

        private List<MeterChart> _charts = new List<MeterChart>(); 

        public MainForm()
        {
            InitializeComponent();
            CreateHome();
        }

        private void CreateHome()
        {
            var bl = new Builder("TXThome2.txt");
            _house = bl.GetHouse;
            MainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Handler.OnTimerTick(sender,e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _charts.Add(new MeterChart(panel1,DateTime.Now));
        }
    }
}
