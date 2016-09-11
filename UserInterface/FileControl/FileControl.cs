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
    /// <summary>
    /// 文件控制类
    /// 
    /// 静态类, 包含ReadData和WriteData两个方法
    /// </summary>
    public static class FileControl
    {
        /// 废弃
        /// <summary>
        /// 文件路径
        /// </summary>
        //public static string FileName { get; set; }
        //public static string FilePath { get; set; }

        /// <summary>
        /// 从文件中读取数据
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>读取的数据</returns>
        public static DataSource ReadData(string filePath)
        {
            //string path = Path.Combine(FilePath, FileName);
#if DEBUG
            Console.WriteLine("file is " + filePath);
#endif
            if (File.Exists(filePath))
            {
#if DEBUG
                Console.WriteLine("file is valid");
#endif
                //Chanel[] chanels;
                List<float>[] chanels;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // 读取通道个数
                    int chanelNumber = int.Parse(reader.ReadLine());
#if DEBUG
                    Console.WriteLine("chanel number is " + chanelNumber);
#endif
                    chanels = new List<float>[chanelNumber];
                    for (int i = 0; i < chanels.Length; i++)
                    {
                        chanels[i] = new List<float>();
                    }
                    // 使用正则表达式匹配浮点数
                    string text = reader.ReadToEnd();
                    string pattern = @"\d+\.\d+";
                    MatchCollection match = Regex.Matches(text, pattern);
#if DEBUG
                    Console.WriteLine("match count is " + match.Count);
#endif
                    // 为每个通道添加数据
                    for (int i = 0; i < match.Count; i++)
                    {
#if DEBUG
                        Console.WriteLine("i = " + i + " chanels[" + i % (chanelNumber) + "] add " + float.Parse(match[i].ToString()));
#endif
                        chanels[i % chanelNumber].Add(float.Parse(match[i].ToString()));
                    }
                }
                //return new DataSource(chanels);
                return DataSource.GetInstance(chanels);
            }
            // 文件不存在
            return null;
        }

        /// <summary>
        /// 将数据写入文件
        /// </summary>
        /// <param name="data">需要写入的数据</param>
        /// <param name="filePath">文件路径</param>
        public static void WriteData(DataSource data, string filePath)
        {
            // 将该功能移到上层控制
            //使用日期作为文件名称
            //string path = Path.Combine(FilePath, DateTime.Now.ToString().Replace(' ', '-'));
#if DEBUG
            Console.WriteLine("write file " + filePath);
#endif
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // 写入通道个数
                writer.WriteLine(data.Chanels.Length);
#if DEBUG
                Console.WriteLine("chanel number is " + data.Chanels.Length);
#endif
                for (int i = 0; i < data.Chanels[0].Count; i++)
                {
                    foreach (var item in data.Chanels)
                    {
                        writer.Write(item[i] + "\t");
                    }
                    writer.WriteLine();
                }
#if DEBUG
                Console.WriteLine("write done");
#endif
            }
        }
    }
}
