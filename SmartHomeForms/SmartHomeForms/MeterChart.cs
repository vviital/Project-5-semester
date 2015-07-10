using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartHome
{
    public class MeterChart
    {

        public Panel NewPanel;
        public TextBox TextBoxResult;
        public TextBox TextBoxAverage;
        public TextBox TextBoxType;
        public Chart Chart1;


        public MeterChart(Panel panel, DateTime time)
        {
            NewPanel = new Panel();
            TextBoxAverage = new TextBox();
            TextBoxResult = new TextBox();
            TextBoxType = new TextBox();
            Init(panel, time);

        }

        private void Init(Panel panel, DateTime time)
        {
            NewPanel.Location = new Point(10, panel.Height+panel.Location.X);
            NewPanel.Name = "panel";
            NewPanel.Width = panel.Width - 37;
            NewPanel.Height = 130;
            NewPanel.BorderStyle = BorderStyle.Fixed3D;

            panel.Controls.Add(NewPanel);

            panel.Height += NewPanel.Height;

            Label label1 = new Label();
            TextBoxType = new TextBox();

            NewPanel.Controls.Add(TextBoxType);
            NewPanel.Controls.Add(label1);

            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Text = "Тип:";

            TextBoxType.Location = new Point(10, 25);
            TextBoxType.Name = "textBox";
            TextBoxType.Text = 0.ToString();
            TextBoxType.ReadOnly = true;


            Label label2 = new Label();
            TextBoxResult = new TextBox();

            NewPanel.Controls.Add(TextBoxResult);
            NewPanel.Controls.Add(label2);

            label2.Location = new Point(10, 45);
            label2.Name = "label2";
            label2.Text = "расход:";

            TextBoxResult.Location = new Point(10, 60);
            TextBoxResult.Name = "textBox1";
            TextBoxResult.Text = 0.ToString();
            TextBoxResult.ReadOnly = true;


            Label label3 = new Label();
            TextBoxAverage = new TextBox();

            NewPanel.Controls.Add(TextBoxAverage);
            NewPanel.Controls.Add(label3);

            label3.Location = new Point(10, 80);
            label3.Name = "label3";
            label3.Text = "среднее:";

            TextBoxAverage.Location = new Point(10, 95);
            TextBoxAverage.Name = "textBox2";
     //       textBoxAVERAGE.Text = time.ReturnAverage(enumer.flow).ToString();
            TextBoxAverage.ReadOnly = true;



            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            Chart1 = new Chart();

            NewPanel.Controls.Add(Chart1);
            chartArea1.Name = "ChartArea1";
            Chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            Chart1.Legends.Add(legend1);
            Chart1.Location = new Point(170, 10);
            Chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            Chart1.Series.Add(series1);
            Chart1.Size = new System.Drawing.Size(230, 110);
            Chart1.Text = "chart1";
            Chart1.Series[0].ChartType = SeriesChartType.Line;
            Chart1.Legends[0].Enabled = false;
            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            Chart1.ChartAreas[0].AxisX.Minimum = 0;
            Chart1.ChartAreas[0].AxisX.Maximum = 60;
            Chart1.ChartAreas[0].AxisX.Interval = 30;
        }

    }
}
