using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 一个通道的数据
    /// </summary>
    public class Chanel
    {
        public List<float> Data { get; set; }

        public Chanel(List<float> data)
        {
            Data = data;
        }

        public Chanel()
        {
            Data = new List<float>();
        }
        /// <summary>
        /// 用于测试输出Data数据
        /// </summary>
        /// <returns>Data生成的字符串</returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var d in Data)
            {
                s.Append(d + "\t");
            }
            s.Append('\n');
            //Console.WriteLine("chanel " + s);
            return s.ToString();
        }
    }
}
