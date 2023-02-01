using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo hashtable có size là 200
            var h = new HashTable<string>(200);
            //Load data từ file txt (key value tách nhau bởi dấu ,)
            List<string> readLines = File.ReadAllLines(@"E:\Nam4hk1\CTDLGTtttt\data.txt").ToList();
            foreach (string line in readLines)
            {
                string key = line.Split(',')[0];
                string val = line.Split(',')[1];
                if (!h.ContainsKey(key))
                {
                    h.Add(key, val);
                }
            }
            Console.OutputEncoding = Encoding.UTF8; //Hàm này để console hiện dấu tiếng việt ko bị lỗi        
            string s = "";
            while (true)
            {
                Console.WriteLine("Nhập vào từ muốn dịch hoặc nhập 0 để thoát: ");
                s = Console.ReadLine();
                if (s != "0")
                {
                    try
                    {
                        Console.WriteLine(h.Get(s));
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else { break; }
            }
        }
    }
}
