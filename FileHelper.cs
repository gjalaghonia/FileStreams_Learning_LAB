using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file
{
	static class FileHelper
	{
		public static int Countwords(string inputFilePath)
		{
            int index = 0;
			int counter = 0;
            string countText = ReadText(inputFilePath);
			while (index < countText.Length-1)
			{
				if (countText[index] == ' ' || countText[index] == '\n' || countText[index] == '\r' || countText[index] == '\t')
				{
					counter++;
				}
				index++;
			}
            return counter;
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
