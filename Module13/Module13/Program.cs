using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Module13
{
    class Program
    {
        //  Объявим  сортированный  словарь
        private static SortedDictionary<string, Contact> SortedPhoneBook = new SortedDictionary<String, Contact>()
        {
            ["Игорь"] = new Contact(79990000000, "igor@example.com"),
            ["Андрей"] = new Contact(79990000001, "andrew@example.com"),
        };
        static void Main(string[] args)
        {
            // Запустим таймер
            var watchTwo = Stopwatch.StartNew();

            // Выполним вставку
            SortedPhoneBook.TryAdd("Диана", new Contact(79160000002, "diana@example.com"));

            // Выведем результат
            Console.WriteLine($"Вставка в сортированный словарь: {watchTwo.Elapsed.TotalMilliseconds}  мс");
        }



        static void PrintCollection(SortedSet<char> ss, string s)
        {
            Console.WriteLine(s);
            foreach (char ch in ss)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
        }

        
        private static void GetMissing(List<string> months, ArrayList missing)
        {
            // инициализируем массив для 7 нужных нам недостающих элементов
            var missedArray = new string[7];

            // извлекаем эти элементы из ArrayList, и копируем в массив
            missing.GetRange(4, 7).CopyTo(missedArray);

            // Добавляем наш массив в конец списка
            months.AddRange(missedArray);

            // смотрим, что получилось
            foreach (var month in months)
                Console.WriteLine(month);
        }
    }
}
