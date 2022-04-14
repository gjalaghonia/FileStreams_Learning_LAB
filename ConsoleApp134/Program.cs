using System;
using System.IO;

namespace GR07_29032022
{
	class Program
	{
		static void Main(string[] args)
		{
            /*FileHelper.EnumerateFile(@"C:\streams\streamFile\Output.txt", @"C:\streams\streamFile\Input.txt");*/     // task 1.

            /*Console.WriteLine(FileHelper.CountOfSymbols(@"C:\streams\streamFile\Output.txt"));*/     //task 2.1.

            /*Console.WriteLine(FileHelper.CountOfWords(@"C:\streams\streamFile\Output.txt"));*/    //task 2.2.

            FileHelper.PrintSymbols(@"C:\streams\streamFile\Output.txt");    //task 3.
        }
    }
}
