using Data;
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
    /// <summary>
    /// 用户界面类
    /// 
    /// 控制界面的显示
    /// </summary>
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主要用于chart控件的绘图
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);
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

        /// <summary>
        /// 浏览文件按钮点击事件
        /// 
        /// 显示打开文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseFileBtn_Click(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("BrowseFileBtn click");
#endif
            openFileDialog.ShowDialog();
            filePathComboBox.Text = openFileDialog.FileName;
            showFileData();
            
        }

        /// <summary>
        /// 浏览文件菜单点击事件
        /// 
        /// 使用浏览文件按钮点击事件一样处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <see cref="browseFileBtn"/>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browseFileBtn_Click(sender, e);
        }

        private void showFileData()
        {
            #region alpha test
            // 使用DataSource设定数据测试
            //Data.DataSource ds = new Data.DataSource();
            #endregion

            #region beta test
            // 使用文件读取的数据
            DataSource ds = FileControl.FileControl.ReadData(filePathComboBox.Text);
            #endregion
            try
            {
                #region alpha test
                //Series s1 = new Series();
                //s1.ChartType = SeriesChartType.Spline;
                //s1.Points.DataBindY(ds.Chanels[0]);
                //Series s2 = new Series();
                //s2.ChartType = SeriesChartType.Spline;
                //s2.Points.DataBindY(ds.Chanels[1]);
                //chart.Series.Add(s1);
                //chart.Series.Add(s2);
                #endregion

                #region beta test
                Series[] dataSeries = new Series[ds.Chanels.Length];
#if DEBUG
                Console.WriteLine("chanels.length is " + ds.Chanels.Length);
#endif
                for (int i = 0; i < dataSeries.Length; i++)
                {
                    dataSeries[i] = new Series();
                    dataSeries[i].ChartType = SeriesChartType.Spline;
                    dataSeries[i].Points.DataBindY(ds.Chanels[i]);
                    chart.Series.Add(dataSeries[i]);
                }
                #endregion
                //chart1.Series[0].MarkerColor = Color.Green;               //unknown
                // 设置为折线显示
                //chart1.Series[0].ChartType = SeriesChartType.Spline;
                //chart1.Series[0].MarkerSize = 5;    
                //chart1.Series[0].Color = Color.Orange;
                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[0].IsValueShownAsLabel = false;

                // 可以点击，左右查看
                // 显示竖线 红色
                //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;       
                //chart1.ChartAreas[0].CursorX.AutoScroll = true;
                // 设置能左右查看未显示的数据
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                // 设置滚动条位置在图表外
                chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                // 设置滚动条大小
                chart.ChartAreas[0].AxisX.ScrollBar.Size = 15;
                //chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                //chart1.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
                //chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
                //chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                // 设置x轴间隔
                chart.ChartAreas[0].AxisX.Interval = ds.XInterval();
                //设置竖直标线
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //chart1.ChartAreas[0].AxisX.Title = "x title";
                //chart1.ChartAreas[0].AxisY.Title = "y title";

                // 设置y轴最大值 
                //chart.ChartAreas[0].AxisY.Maximum = 1600;
                // 设置y轴最小值
                chart.ChartAreas[0].AxisY.Minimum = 1530;
                // 设置y轴单位长
                //chart.ChartAreas[0].AxisY.Interval = 0.01;
                //绑定数据源
                chart.DataBind();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}

