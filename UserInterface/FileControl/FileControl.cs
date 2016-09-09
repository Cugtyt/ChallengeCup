using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileControl
{
    static class FileControl
    {
        /// <summary>
        /// 文件名和文件路径
        /// </summary>
        public static string FileName { get; private set; }
        public static string FilePath { get; set; }

        /// <summary>
        /// 从文件中读取数据
        /// </summary>
        /// <returns>读取的数据</returns>
        public static Chanel[] ReadData()
        {
            string path = Path.Combine(FilePath, FileName);
            if (File.Exists(path))
            {
                Chanel[] chanels;
                using (StreamReader reader = new StreamReader(path))
                {
                    // 读取通道个数
                    int chanelNumber = int.Parse(reader.ReadLine());
                    chanels = new Chanel[chanelNumber];
                    // 使用正则表达式匹配浮点数
                    string text = reader.ReadToEnd();
                    string pattern = @"\d+\.\d+";
                    MatchCollection match = Regex.Matches(text, pattern);
                    // 为每个通道添加数据
                    for (int i = 0; i < match.Count; i++)
                    {
                        chanels[i % chanelNumber].Data.Add(float.Parse(match[i].ToString()));
                    }   
                }
                return chanels;
            }
            // 文件不存在
            return null;
        }

      
        /// <summary>
        /// 将数据写入文件
        /// </summary>
        /// <param name="chanels">需要写入的数据数组</param>
        public static void WriteData(Chanel[] chanels)
        {
            //使用日期作为文件名称
            string path = Path.Combine(FilePath, DateTime.Now.ToString().Replace(' ', '-'));
            using (StreamWriter writer = new StreamWriter(path))
            {
                // 写入通道个数
                writer.WriteLine(chanels.Length);
                for (int i = 0; i < chanels[0].Data.Count; i++)
                {
                    foreach (var item in chanels)
                    {
                        writer.Write(item.Data[i] + "\t");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
