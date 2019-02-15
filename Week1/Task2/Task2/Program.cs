using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name;//переменная name
        public string id;//переменная id
        public int year;//переменная year

        public Student(string name, string id) //конструктор с 2 параметрами
        {
            this.name = name;//чтобы между двум переменами не было конфликта
            this.id = id;
        }
        public Student()//конструктор с 0 параметрами
        {
            name = Console.ReadLine();//вводим name
            id = Console.ReadLine();//вводим id
            year = Convert.ToInt32(Console.ReadLine());//вводим year
        }

        public void PrintInfo()//метод возвращает данные студента
        {
            Console.WriteLine(name);//выводим
            Console.WriteLine(id);
            Console.WriteLine(year);
        }
        public void IncrementOfYear()
        {
            year++;//увеличиваем year на 1
            PrintInfo();//запрашиваем метод PrintInfo
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(); //Иницифлизируем данные с помощью конструктора:0
            s.IncrementOfYear();//метод возвращает данные
        }
    }
}