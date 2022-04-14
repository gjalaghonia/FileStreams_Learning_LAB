using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR07_29032022
{
	static class FileHelper
	{
        public static Dictionary<char, int> PrintSymbols(string inputFilePath)
        {
			string inputText = ReadText(inputFilePath);
			Dictionary<char, int> symbols = new();
            for (int i = 0; i < inputText.Length; i++) 
            {
                if (!IsSymbol(inputText,i))
                {
					continue;
                }

                if (!symbols.TryAdd(inputText[i], 1))
                {
					symbols[inputText[i]] += 1;
                }
			}
			return symbols;

            //foreach (var item in symbols)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public static int CountOfWords(string inputFilePath)
        {
			string inputText = ReadText(inputFilePath);
            if (CountOfSymbols(inputFilePath) == 0)
            {
				return 0;
            }
			int count = 1;
			for (int i = 1; i < inputText.Length; i++)
			{
				if (IsSymbol(inputText, i) && !IsSymbol(inputText, i - 1))
				{
					count++;
				}
			}
			return count;
		}

		public static int CountOfSymbols(string inputFilePath)
		{
			string inputText = ReadText(inputFilePath);
			int count = 0;
			for (int i = 0; i < inputText.Length; i++)
			{
				if (IsSymbol(inputText, i))
				{
					count++;
				}
			}
			return count;
		}

		public static bool IsSymbol(string inputText, int i)
        {
			if (inputText[i] > 47 && inputText[i] < 58 || inputText[i] > 64 && inputText[i] < 91 || inputText[i] > 96 && inputText[i] < 123)
			{
				return true;
			}
			return false;
		}

		public static void EnumerateFile(string inputFilePath, string outputFilePath)
		{
			string inputText = ReadText(inputFilePath);
			string outputText = "";

			int index = 1;
			outputText += index.ToString() + ". ";
			for (int i = 0; i < inputText.Length; i++)
			{
				if (inputText[i] == '\r')
				{
					index++;
					outputText += "\r\n";
					outputText += index.ToString() + ". ";
					i++;
					continue;
				}
				outputText += inputText[i];
			}

			WriteText(outputFilePath, outputText);
		}

		public static string ReadText(string path)
		{
			FileStream fileStream = new FileStream(path, FileMode.Open);
			byte[] data = new byte[fileStream.Length];
			fileStream.Read(data, 0, data.Length);
			fileStream.Close();

			return GetString(data);
		}

		public static void WriteText(string path, string text)
		{
			FileStream fileStream = new FileStream(path, FileMode.Create);
			byte[] data = GetBytes(text);
			fileStream.Write(data, 0, data.Length);
			fileStream.Close();
		}

		private static byte[] GetBytes(string text)
		{
			byte[] buffer = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				buffer[i] = (byte)text[i];
			}
			return buffer;
		}

		private static string GetString(byte[] data)
		{
			char[] buffer = new char[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				buffer[i] = (char)data[i];
			}
			return new string(buffer);
		}
	}
}
