using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Data
    {
        /// <summary>
        /// x轴和y轴名称
        /// </summary>
        public string XName { get; set; } = "x name";
        public string YName { get; set; } = "y name";
        /// <summary>
        /// x轴和y轴数据
        /// </summary>
        public List<float> X { get; private set; }
        public List<float> Y { get; private set; }
        /// <summary>
        /// 每个通道的数据
        /// </summary>
        public Chanel[] Chanels { get; private set; }
        public int XParts { get; set; } = 10;
        public int YParts { get; set; } = 8;


        /// <summary>
        /// 测试数据填充
        /// </summary>
        public Data()
        {
            X = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Y = new List<float> { 5, 5, 4, 7, 57, 8, 8, 7, 32 };
        }

        /// <summary>
        /// 传入x轴和y轴数据初始化
        /// </summary>
        /// <param name="x">x轴数据</param>
        /// <param name="y">y轴数据</param>
        //public Data(List<float> x, List<float> y)
        //{
        //    X = x;
        //    Y = y;
        //}

        /// <summary>
        /// Chanel数据初始化
        /// </summary>
        /// <param name="c"></param>
        /// 尚未使用
        public Data(Chanel[] c)
        {
            Chanels = c;
        }

        /// <summary>
        /// 计算x轴的数据间隔
        /// </summary>
        /// <returns>返回x轴数据间隔</returns>
        public float XInterval()
        {
            return (int)X.Max() / YParts; ;
        }

        /// <summary>
        /// 计算y轴的数据间隔
        /// y轴最大值 / 间隔数
        /// </summary>
        /// <returns>y轴数据间隔</returns>
        public int YInterval()
        {
            float max = 0;
            foreach (Chanel item in Chanels)
            {
                max = (item.Data.Max() > max) ? item.Data.Max() : max;
            }
            return (int)max / YParts;
        }

        /// <summary>
        /// 计算y轴的最大显示范围
        /// 数据间隔 * 间隔数 * 2， 可以让数据显示在中间
        /// </summary>
        /// <returns>y轴最大显示范围</returns>
        public float MaxY()
        {
            return YInterval() * YParts * 2;
        }
    }
}
