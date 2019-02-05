using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); //ввод числа и конвертирование ее в тип integer
            int[] a = new int[n]; //создание массива с элементами числового значения
            int[] res = new int[n]; //создание еще одного массива
            string[] s = Console.ReadLine().Split(); //создание массива с элементами типа стринга и разделение их через пробелы
            int cnt = 0; //создание переменной счётчика
            bool isPrime = true; //создвние переменной типа bool
            for(int i=0; i<n; i++) //создание цикла
            {
                isPrime = true;
                a[i] = Convert.ToInt32(s[i]); //конвертирую элемент стрингового массива и сохраняю как элемент типа integer
                if (a[i] == 1) //если элемент массива будет равен 1б то пропустить его
                    continue;
                for(int j=2; j < a[i]; j++) // создаю еще один цикл
                {
                    if (a[i] % j == 0) //проверяю, что число является prime
                        isPrime = false; //число является не prime-ом если делится на числа стоящие перед ним(начиная с 2-х)
                }
                if(isPrime == true) //но если число делится только на себя и на 1, то оно является prime-ом
                {
                    res[cnt] = a[i];//записываем prime number как элемент нового массива
                    cnt++; //считаем количество prime numbers
                }
            }
            Console.WriteLine(cnt); //выводим количество prime numbers
            for(int i=0; i<cnt; i++) //создаем цикл 
            {
                Console.Write(res[i] + " "); //выводим на консоль эти простые числа через пробел в одной строке
            }
        }
    }
}
