using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); //создаю переменную и даю значение
            int[] ar1 = new int[n]; //создаю массив с типом integer
            int[] ar2 = new int[n * 2]; //создаю массив с типом integer у которого размер в 2 раза больше предыдущего массива
            string[] s = Console.ReadLine().Split(); //создаю стринговый массив
            for (int i = 0; i < n; i++)
            {
                ar1[i] = Convert.ToInt32(s[i]); //конвертирую элементы стрингового массива и записываю как элемент массива типа integer
            }
            int j = 0;
            for (int i = 0; i < ar1.Length; i++)
            {
                ar2[j++] = ar1[i]; //два раза выводим элементы массива
                ar2[j++] = ar1[i];
            }
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.Write(ar2[i] + " "); //выводим элементы нового массива
            }



        }
    }
}