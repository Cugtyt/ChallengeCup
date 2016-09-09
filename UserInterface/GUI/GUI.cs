using ChallengeCup.Data;
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


namespace ChallengeCup
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
            
            DataSource ds = new DataSource();
            try
            {
                //chart1.Series[0].Points.DataBindXY(listX, listY);
                chart1.Series[0].Points.DataBindY(ds.Y);

                //chart1.Series[0].MarkerColor = Color.Green;               //unknown
                // 设置为折线显示
                chart1.Series[0].ChartType = SeriesChartType.Spline;
                //chart1.Series[0].MarkerSize = 5;    
                //chart1.Series[0].Color = Color.Orange;
                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[0].IsValueShownAsLabel = false;

                // 可以点击，左右查看
                // 显示竖线 红色
                //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;       
                //chart1.ChartAreas[0].CursorX.AutoScroll = true;
                // 设置能左右查看未显示的数据
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                // 设置滚动条位置在图表外
                chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                // 设置滚动条大小
                chart1.ChartAreas[0].AxisX.ScrollBar.Size = 15;
                //chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                //chart1.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
                //chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
                //chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                // 设置x轴间隔
                chart1.ChartAreas[0].AxisX.Interval = ds.X.Average() / 10;
                //设置竖直标线
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //chart1.ChartAreas[0].AxisX.Title = "x title";
                //chart1.ChartAreas[0].AxisY.Title = "y title";

                chart1.ChartAreas[0].AxisY.Maximum = ds.MaxY();
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Interval = ds.YInterval();
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

