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
    /// FileControl class
    /// 
    /// class is static, read/write DataScorce from/to file
    /// </summary>
    /// <see cref="DataSource"/>
    public static class FileControl
    {
        /// 废弃
        /// <summary>
        /// 文件路径
        /// </summary>
        //public static string FileName { get; set; }
        //public static string FilePath { get; set; }

        /// <summary>
        /// read DataScource form file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>data from file</returns>
        public static DataSource ReadData(string filePath)
        {
#if DEBUG
            Console.WriteLine("file is " + filePath);
#endif
            if (File.Exists(filePath))
            {
#if DEBUG
                Console.WriteLine("file is valid");
#endif
                List<float>[] chanels;
                // begin to read data form file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // read chanels' number
                    int chanelNumber = int.Parse(reader.ReadLine());
#if DEBUG
                    Console.WriteLine("chanel number is " + chanelNumber);
#endif
                    // initial chanels[]
                    chanels = new List<float>[chanelNumber];
                    for (int i = 0; i < chanels.Length; i++)
                    {
                        chanels[i] = new List<float>();
                    }
                    // read all data form file
                    string text = reader.ReadToEnd();
                    #region RegexMatch Abandon
                    // it costs long time, abandon
                    //
                    //                    string pattern = @"\d+\.\d+";
                    //                    MatchCollection match = Regex.Matches(text, pattern);
                    //#if DEBUG
                    //                    Console.WriteLine("match count is " + match.Count);
                    //#endif
                    //                    // 为每个通道添加数据
                    //                    for (int i = 0; i < match.Count; i++)
                    //                    {
                    //#if DEBUG
                    //                        Console.WriteLine("i = " + i + " chanels[" + i % (chanelNumber) + "] add " + float.Parse(match[i].ToString()));
                    //#endif
                    //                        chanels[i % chanelNumber].Add(float.Parse(match[i].ToString()));
                    //                    }
                    #endregion
                    #region SpiltData
                    // it costs less time than RegexMatch
                    string[] data = text.Replace("\r\n", " ")
                        .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
#if DEBUG
                    foreach (var d in data)
                    {
                        Console.WriteLine(d);
                    }
#endif
                    // parse and add data to chanels
                    for (int i = 0; i < data.Length; i++)
                    {
                        chanels[i % chanels.Length].Add(float.Parse(data[i]));
                    }
                    #endregion
                }
                return DataSource.GetInstance(chanels);
            }
            // 文件不存在
            return null;
        }

        /// <summary>
        /// write data to file
        /// </summary>
        /// <param name="data">data to write</param>
        /// <param name="filePath">file path</param>
        public static void WriteData(DataSource data, string filePath)
        {
#if DEBUG
            Console.WriteLine("write file " + filePath);
#endif
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // write number of chanels to file
                writer.WriteLine(data.Chanels.Length);
#if DEBUG
                Console.WriteLine("chanel number is " + data.Chanels.Length);
#endif
                // write data
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
