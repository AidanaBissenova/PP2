using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\Acer\source\repos\Week2\Task4\test.txt"; //записываю путь текстового файла как стринг
            string path2 = @"C:\Users\Acer\source\repos\Week2\test.txt";//записываю 2 путь того же текстового файла как другой стринг
            FileInfo fs = new FileInfo(path1); //беру информацию о файле из path1
            fs.CopyTo(path2); //копирую его в path2
            Console.WriteLine("{0} was copied to {1}.", path1, path2); //вывожу на экран что было скопировано из одного пути в другое
            fs.Delete(); //удаляю файл из первого пути
            Console.WriteLine("{0} was successfully deleted.", path1); //вывожу на экран что было успешно удалено из первого пути

        }
    }
}