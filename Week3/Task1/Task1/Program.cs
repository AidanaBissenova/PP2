using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//библиотека инпут аутпут 
namespace Task1
{
    enum FSIMode// создаем энум
    {
        DirectoryInfo = 1, // Справочник папки с индексом 1
        File = 2        // файл с индексом 2
    }
    class Layer // создаем класс layer
    {
        public DirectoryInfo[] DirectoryContent //член класса в виде массива типа DirectoryInfo для папок
        {
            get;// свойство для получения 
            set;// свойство для присвоения
        }
        public FileInfo[] FileContent // член классас в виде массива типа FileInfo для файлов
        {
            get;//свойство для получения
            set;//свойство для присвоения
        }
        public int SelectedIndex //член класса в виде числа индекс выбранного файли или папки 
        {
            get;
            set;
        }
        void SelectedColor(int i) // метод который выполняет инструкции и аргумент число 
        {
            if (i == SelectedIndex) // проверяет аргумент на равенство индекса выбранного файла или папки
                Console.BackgroundColor = ConsoleColor.Red;// если равны , меняет цвет фона консоли на красный
            else
                Console.BackgroundColor = ConsoleColor.Black; // если не равны меняет цвет фона консоли на черный
        }
        public void Draw() // метода который выполняет инструкции
        {
            Console.BackgroundColor = ConsoleColor.Black; // меняет цвет фона на черный
            Console.Clear();// отчищает консоль 
            for (int i = 0; i < DirectoryContent.Length; ++i) // циклом проходит по всем папкам 
            {
                SelectedColor(i);//вызывает метод для измения цвета выбранной папки
                Console.WriteLine((i + 1) + ". " + DirectoryContent[i].Name);//пишет имена папок нумерация
            }
            Console.ForegroundColor = ConsoleColor.Yellow;//меняет цвет текста консои на желтый
            for (int i = 0; i < FileContent.Length; ++i)//проходит по всех файлам в данной директории
            {
                SelectedColor(i + DirectoryContent.Length);//вызыввает метод для изменения цвета выбранного файла
                Console.WriteLine((i + DirectoryContent.Length + 1) + ". "
                    + FileContent[i].Name);// пишет все файлы с нумерации после папок

            }
            Console.ForegroundColor = ConsoleColor.White;//меняет цвет текста консоли на белый
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Acer\source\repos");
            //создает обЪект класса  DirectoryInfo по указанному пути
            Layer l = new Layer // создает объект класса layer
            {
                DirectoryContent = dir.GetDirectories(),
                //заполняет массив методом который возвращает массив с папками
                FileContent = dir.GetFiles(),
                //заполняет массив который возвращает массив с файлами
                SelectedIndex = 0//приваевает выбраному индексу число 0
            };
            l.Draw();//вызывает мтода который выводит на консоли папки и файлы
            Stack<Layer> history = new Stack<Layer>();//создает стек
            history.Push(l);//добвляет в конец стека обЪект класса layer 
            bool esc = false;//создает переменную bool и присваивает значение ложь
            FSIMode curMode = FSIMode.DirectoryInfo; //создает энум созначение каталогов 
            while (!esc)//цикл пока esc = ложь
            {
                if (curMode == FSIMode.DirectoryInfo) //если энум директория
                    history.Peek().Draw();//то рисует все папки и файлы
                ConsoleKeyInfo consolekeyInfo = Console.ReadKey(); // spravo4nik
                //запрашивает у пользователя нажатии клавиши
                switch (consolekeyInfo.Key)//проверяет нажатые клавиши
                {
                    case ConsoleKey.UpArrow://если клавиша вверх создана
                        if (history.Peek().SelectedIndex > 0)//проверяет если выбранный файл или папка не в вверху
                            history.Peek().SelectedIndex--; //то поднимает выбранный индекс путем декримента
                        break;
                    case ConsoleKey.DownArrow://если клавища нажата вниз
                        if (history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 1 >
                            history.Peek().SelectedIndex)//проверяет если индекс выбранного файла или папки меньше общего количества папок и файлов
                            history.Peek().SelectedIndex++;//понижает выбор вниз путем инкремена выбранного индекса
                        break;
                    case ConsoleKey.Enter://если нажата клавиша интер
                        if (history.Peek().DirectoryContent.Length + history.Peek().
                            FileContent.Length == 0)//если файлов и папок нету то выходит
                            break;
                        int index = history.Peek().SelectedIndex;//если нет, то с верхнего элеиента стэка вытаскивает переменную выбранного индекса
                        if (index < history.Peek().DirectoryContent.Length) //если выбранный индекс на папке
                        {
                            DirectoryInfo d = history.Peek().DirectoryContent[index];//получает инфо о выбранном каталоге 
                            history.Push(new Layer// записывает в стек след элемент класс layer
                            {
                                DirectoryContent = d.GetDirectories(),//папки
                                FileContent = d.GetFiles(),//файла
                                SelectedIndex = 0//выбранный индекс
                            });
                        }
                        else//если выбранный элемент файл
                        {
                            curMode = FSIMode.File;//меняет энум на файл
                            using (FileStream fs = new FileStream(history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].FullName, FileMode.Open, FileAccess.Read))
                            {//использует поток для получения содержания выранного файла
                                using (StreamReader sr = new StreamReader(fs))
                                {//поток для считываения информации с файла
                                    Console.BackgroundColor = ConsoleColor.White;//меняте цвет консоли на белый
                                    Console.ForegroundColor = ConsoleColor.Black;//меняет цвет текста консоле на черный
                                    Console.Clear();//отчищает консоль
                                    Console.WriteLine(sr.ReadToEnd());//пишет в консоль содержания файла

                                }
                            }

                        }
                        break;
                    case ConsoleKey.Backspace://если нажата клавища назад
                        if (curMode == FSIMode.DirectoryInfo)//проверяет если мы в папке
                        {
                            if (history.Count > 1)//проверяет если стек хранит больше 1 элемента
                                history.Pop();//удаляет верхний элемент стека
                        }
                        else
                        {
                            curMode = FSIMode.DirectoryInfo;//если мы в файле
                            Console.ForegroundColor = ConsoleColor.White;//меняет цвет текста консоли на белый
                        }
                        break;
                    case ConsoleKey.Escape://если нажата клава еск
                        esc = true;//меняет перменную на истину и закрывается цикл
                        break;
                    default:
                        break;
                }
            }
        }
    }
}