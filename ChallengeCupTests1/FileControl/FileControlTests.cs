using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace FileControl.Tests
{
    [TestClass()]
    public class FileControlTests
    {
        private string TestFilePath = @"C:\Users\Daniel\Desktop\test.txt";

        [TestMethod()]
        public void ReadDataTest()
        {
            string test = "1.5\t1.4\t\n2.1\t2.8\t\n";
            DataSource data = FileControl.ReadData(TestFilePath);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Chanels.Length; i++)
            {
                Console.WriteLine(i + " " + data.Chanels[i]);
            }
            foreach (var c in data.Chanels)
            {
                //sb.Append(c);
                foreach (var item in c)
                {
                    sb.Append(item + "\t");
                }
                sb.Append('\n');
            }
            Assert.AreEqual(sb.ToString(), test);
        }

        [TestMethod()]
        public void WriteDataTest()
        {
            List<float>[] chanels = new List<float>[]
            {
                new List<float> { 1.5f, 1.4f },
                new List<float> { 2.1f, 2.8f }
            };
            DataSource data = DataSource.GetInstance(chanels);
            FileControl.WriteData(data, TestFilePath);
        }
    }
}