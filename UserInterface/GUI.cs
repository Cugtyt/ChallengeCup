using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);
            List<int> listX = new List<int> { 1, 2, 5, 6, 6, 8, 58, 8, 32 };
            List<int> listY = new List<int> { 5, 5, 4, 7, 57, 8, 8, 7, 32 };

            try
            {
                chart1.Series[0].Points.DataBindXY(listX, listY);
                chart1.Series[0].Points.DataBindY(listY);

                //chart1.Series[0].MarkerColor = Color.Green;               //unknown
                // 设置为折线显示
                chart1.Series[0].ChartType = SeriesChartType.Spline;
                chart1.Series[0].MarkerSize = 5;    
                chart1.Series[0].Color = Color.Orange;
                chart1.Series[0].BorderWidth = 2;
                chart1.Series[0].IsValueShownAsLabel = false;

                // 可以点击，左右查看
                // 显示竖线 红色
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;       
                chart1.ChartAreas[0].CursorX.AutoScroll = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                chart1.ChartAreas[0].AxisX.ScrollBar.Size = 15;
                chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                chart1.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
                chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
                chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                chart1.ChartAreas[0].AxisX.Interval = 10;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.Title = "x title";
                chart1.ChartAreas[0].AxisY.Title = "y title";
                double max = listY[0];
                double min = listY[0];
                foreach (var yValue in listY)
                {
                    if (max < yValue)
                    {
                        max = yValue;
                    }
                    if (min > yValue)
                    {
                        min = yValue;
                    }
                }
                chart1.ChartAreas[0].AxisY.Maximum = max;
                chart1.ChartAreas[0].AxisY.Minimum = min;
                chart1.ChartAreas[0].AxisY.Interval = (max - min) / 10;
                //绑定数据源
                chart1.DataBind();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

