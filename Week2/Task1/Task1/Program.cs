using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Acer\source\repos\Week2\Task1\Task1\input.txt");
            for (int i = 0, j = text.Length - 1; i < j; i++, j--)
            {
                if (text[i] != text[j])
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}