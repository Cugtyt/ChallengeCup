using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCup.Data
{
    class DataSource
    {
        /// <summary>
        /// x轴和y轴数据
        /// </summary>
        public List<float> X { get; private set; }
        public List<float> Y { get; private set; }

        /// <summary>
        /// 测试数据填充
        /// </summary>
        public DataSource()
        {
            X = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Y = new List<float> { 5, 5, 4, 7, 57, 8, 8, 7, 32 };
        }

        /// <summary>
        /// 传入x轴和y轴数据初始化
        /// </summary>
        /// <param name="x">x轴数据</param>
        /// <param name="y">y轴数据</param>
        public DataSource(List<float> x, List<float> y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 计算x轴的数据间隔
        /// </summary>
        /// <returns>返回x轴数据间隔</returns>
        public float XInterval()
        {
            return X.Max() / 10;
        }
        
        /// <summary>
        /// 计算y轴的数据间隔
        /// </summary>
        /// <returns>y轴数据间隔</returns>
        public float YInterval()
        {
            return Y.Average() / 4;
        }

        /// <summary>
        /// 计算y轴的最大显示范围
        /// </summary>
        /// <returns>y轴最大显示范围</returns>
        public float MaxY()
        {
            return Y.Average() * 4;
        }
    }
}
