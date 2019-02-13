using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); //ввод числа и конвертирование ее в тип integer
            string[,] arr = new string[n, n]; //создаем двумерный массив
            for(int i=0; i<n; i++) //создание цикла
            {
                for (int j = 0; j <= i; j++)//создание цикла
                    arr[i, j] = "[*]"; //массив выводит [*] 
            }
            for (int i = 0; i < n; i++) //создание цикла
            {
                for (int j = 0; j <= i; j++) //создание цикла
                    Console.Write(arr[i, j]); //выводим на консоль массив
                Console.WriteLine(); //Выводим для того чтобы пройти на новую строку
            }
        }
    }
}
