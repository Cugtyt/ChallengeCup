using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// DataSource class
    /// 
    /// store the data which will be shown in chart
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// name of x and y
        /// </summary>
        public string XName { get; set; } = "x name";
        public string YName { get; set; } = "y name";
        // for test
        public List<float> X { get; private set; }
        /// <summary>
        /// chanels' data
        /// </summary>
        public List<float>[] Chanels { get; private set; }
        /// <summary>
        /// x轴和y轴需要显示的区间数
        /// </summary>
        //public int XParts { get; set; } = 10;
        //public int YParts { get; set; } = 8;

        public static DataSource ds = null;

        /// <summary>
        /// 测试数据填充
        /// </summary>
        public DataSource()
        {
            X = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Y = new List<float> { 5, 5, 4, 7, 57, 8, 8, 7, 32 };
            Chanels = new List<float>[]
            {
                new List<float> {1.5f, 2.0f, 1.8f, 4.5f, 3.2f, 4.3f, 2.8f, 5.1f },
                new List<float> {2.5f, 3.3f, 4.8f, 5.6f, 4.9f, 6.7f, 8.2f, 6.8f }
            };
        }

        /// <summary>
        /// initial chanels
        /// </summary>
        /// <param name="c"></param>
        private DataSource(List<float>[] c)
        {
            Chanels = c;
        }

        /// <summary>
        /// use singleton pattern
        /// 
        /// for there always will be one DataSource to show in chart
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static DataSource GetInstance(List<float>[] c)
        {
            return (ds != null) ? ds : new DataSource(c);
        }

        /// <summary>
        /// calculate interval of x
        /// </summary>
        /// <returns>interval of x</returns>
        public float XInterval()
        {
            return 10;
        }
        
        /// <summary>
        /// calculate interval of y
        /// 
        /// </summary>
        /// <returns>y轴数据间隔</returns>
        public int YInterval()
        {
            //float max = 0;
            //foreach (Chanel item in Chanels)
            //{
            //    max = (item.Data.Max() > max) ? item.Data.Max() : max;
            //}
            //return (int)max / YParts;


            //测试数据
            return 8;
        }

        /// <summary>
        /// 计算y轴的最大显示范围
        /// 
        /// 数据最大值 * 2
        /// </summary>
        /// <returns>y轴最大显示范围</returns>
        public float MaxY()
        {
            float maxY = 0;
            foreach (var c in Chanels)
            {
                maxY = (c.Max() > maxY) ? c.Max() : maxY;
            }
            return maxY;
        }

        ///// <summary>
        ///// 用于测试输出Chanels里的数据
        ///// </summary>
        ///// <returns>生成的数据</returns>
        //public override string ToString()
        //{
        //    StringBuilder s = new StringBuilder();
        //    foreach (var chanel in Chanels)
        //    {
        //        s.Append(chanel.ToString());
        //    }
        //    return s.ToString();
        //}
    }
}
