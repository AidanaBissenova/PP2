using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void rec(DirectoryInfo dir, string level) //создаю функцию с 2 параметрами
        {
            Console.WriteLine(level + dir.Name); //вывожу отступ и название папки
            level += "   "; //увеличиваю отступ на 3 пробела
            FileSystemInfo[] fs = dir.GetFileSystemInfos(); //беру содержимое папки
            for (int i = 0; i < fs.Length; i++) //создаю цикл
            {
                if (fs[i].GetType() == typeof(FileInfo)) //если это файл то вывожу на консоль отступ и название файла
                {
                    Console.WriteLine(level + fs[i].Name);
                }
                else
                {
                    rec(fs[i] as DirectoryInfo, level); //рекурсивно вызываю функцию
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Acer\source\repos"); //создаю папку и указываю путь на папку
            rec(dir, ""); //вызываю функцию
        }
    }
}