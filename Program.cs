using System;
using System.Collections;
using System.IO;

namespace file
{
	class Program
	{
		static void Main(string[] args)
		{

            //FileHelper.WriteText(@"C:\Users\Guram\Desktop\TEST\G10.txt", "text1   text2 text3\r\ntext4 text5\r\ntext6 text7 text8 text9\r\ntext9 text10");
            //FileHelper.EnumerateFile(@"C:\Users\Guram\Desktop\TEST\G10.txt", @"C:\Users\Guram\Desktop\TEST\G10_2.txt");
            //int countwords = FileHelper.Countwords(@"C:\Users\Guram\Desktop\TEST\G10.txt");
            ////Console.WriteLine(countwords);
            //Console.WriteLine(symbolcount);
            string readtext = FileHelper.ReadText(@"C:\Users\Guram\Desktop\TEST\G10.txt");
            ArrayList arrayList = new ArrayList()
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            while (readtext.Length > 0)
            {
                Console.WriteLine(readtext[0] + "-----");
                int temcount = 0;
                for (int i = 0; i < readtext.Length; i++)
                {
                    if (readtext[0] == readtext[i] && arrayList.Contains(readtext[0]))
                    {
                        temcount++;
                    }
                }
                Console.WriteLine(temcount);
                readtext = readtext.Replace(readtext[0].ToString(), string.Empty);
            }

        }
    }

}