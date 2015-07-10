using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba1.Resources;

namespace Laba1
{
    public partial class Form1 : Form
    {
        Handler handler = new Handler();

        public Form1()
        {
            InitializeComponent();
        }

        private void maker_Click(object sender, EventArgs e)
        {
            if (this.handler == null) this.handler = new Handler();
            this.handler.SetAddressRange(this.NetworkTextBox.Text, this.MaskTextBox.Text);
            this.handler.MakeNetWork();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Int32.Parse(this.HostNumberTextBox.Text);
                this.handler.Add(count);
            }
            catch
            {
                MessageBox.Show("Введите корректное значение количества хостов!!!");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.handler.Clear();
        }
    }
}
