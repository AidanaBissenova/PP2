using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllText(@"C:\Users\Acer\source\repos\Week2\Task2\Task2\input.txt").Split();//считываю строку через инпут файл
            using (StreamWriter file = new StreamWriter(@"C:\Users\Acer\source\repos\Week2\Task2\Task2\output.txt"))//через файл аутпут выводим ответ
            {
                for (int i = 0; i < text.Length; i++) //создаю цикл
                {
                    int a = Convert.ToInt32(text[i]);//конвертируем стринговый массив в интеджер
                    bool prime = true;  // создаю переменную типом булеан 
                    for (int j = 2; j < a; j++) //создаю цикл от 2 до числа
                    {
                        if (a % j == 0) //проверка на прайм 
                            prime = false; 
                    }
                    if (prime == true && a > 1) 
                        file.Write(a + " "); //вывожу простые числа в файле аутпут
                }
            }

        }
    }
}