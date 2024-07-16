//a
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "Program.cs";
        char targetChar = 'a'; // Kí tự muốn tính số lượng
        Console.WriteLine($"Số dòng: {CountLines(filePath)}");
        Console.WriteLine($"Số kí tự '{targetChar}': {CountCharacter(filePath, targetChar)}");
        Console.WriteLine($"Số từ: {CountWords(filePath)}");
    }

    static int CountLines(string filePath)
    {
        return File.ReadLines(filePath).Count();
    }

    static int CountCharacter(string filePath, char targetChar)
    {
        string content = File.ReadAllText(filePath);
        return content.Count(c => c == targetChar);
    }

    static int CountWords(string filePath)
    {
        string content = File.ReadAllText(filePath);
        var words = Regex.Matches(content, @"\b\w+\b");
        return words.Count;
    }
}

//b
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string readPath = "vd1_read.txt";
        string writePath = "vd1_ghi.txt";
        ReadAndWriteUtf8File(readPath, writePath);
    }

    static void ReadAndWriteUtf8File(string readPath, string writePath)
    {
        string content = File.ReadAllText(readPath, Encoding.UTF8);
        File.WriteAllText(writePath, content, Encoding.UTF8);
    }
}

//c
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string readPath = "vd1_read.txt";
        string writePath = "vd1_ghi.txt";
        ReadAndWriteUtf16File(readPath, writePath);
    }

    static void ReadAndWriteUtf16File(string readPath, string writePath)
    {
        string content = File.ReadAllText(readPath, Encoding.Unicode);
        File.WriteAllText(writePath, content, Encoding.Unicode);
    }
}

//d
using System;
using System.IO;

class Program
{
    static void Main()
    {
        double[,] array = 
        {
            { 1.1, 2.2, 3.3 },
            { 4.4, 5.5, 6.6 }
        };
        string filePath = "a2d.dat";

        WriteBinaryFile(filePath, array);
        double[,] readArray = ReadBinaryFile(filePath, 2, 3);

        // Kiểm tra kết quả
        for (int i = 0; i < readArray.GetLength(0); i++)
        {
            for (int j = 0; j < readArray.GetLength(1); j++)
            {
                Console.Write(readArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void WriteBinaryFile(string filePath, double[,] array)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            writer.Write(rows);
            writer.Write(cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(array[i, j]);
                }
            }
        }
    }

    static double[,] ReadBinaryFile(string filePath, int rows, int cols)
    {
        double[,] array = new double[rows, cols];

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int readRows = reader.ReadInt32();
            int readCols = reader.ReadInt32();

            for (int i = 0; i < readRows; i++)
            {
                for (int j = 0; j < readCols; j++)
                {
                    array[i, j] = reader.ReadDouble();
                }
            }
        }

        return array;
    }
}

