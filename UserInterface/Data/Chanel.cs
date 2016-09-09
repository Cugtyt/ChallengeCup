using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// 尚未使用
    /// <summary>
    /// 一个通道的数据
    /// </summary>
    class Chanel
    {
        public List<float> Data { get; set; }

        public Chanel(List<float> data)
        {
            Data = data;
        }
    }
}
