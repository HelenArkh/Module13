using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Module13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запускаем бесконечный цикл
            while (true)
            {
                Console.WriteLine("Введите текст:");

                // Сохраняем предложение в строку
                var sentence = Console.ReadLine();
                // сохраняем в массив char
                var characters = sentence.ToCharArray();

            var symbols = new HashSet<char>();

            // добавляем во множество. Сохраняются только неповторяющиеся символы
            foreach (var symbol in characters)
                symbols.Add(symbol);

                // Выводим результат
                Console.WriteLine($"Всего {symbols.Count} уникальных символов");

                // сохраняем знаки препинания в массив Char
                var signs = new[] { ',', ' ', '.' };

            // сохраняем числовые символы в массив Char
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //  Проверяем, есть ли цифры
            bool containsNumbers = symbols.Overlaps(numbers);
            Console.WriteLine($"Коллекция содержит цифры: {containsNumbers}");

            // Отбрасываем знаки препинания и заново считаем
            symbols.ExceptWith(signs);
            Console.WriteLine($"Символов без знаков препинания: {symbols.Count}");

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void PrintCollection(SortedSet<char> ss, string s)
        {
            Console.WriteLine(s);
            foreach (char ch in ss)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
        }

        private static void AddUnique(Contact newContact, List<Contact> phoneBook)
        {
            bool alreadyExists = false;

            // пробегаемся по списку и смотрим, есть ли уже с таким именем
            foreach (var contact in phoneBook)
            {
                if (contact.Name == newContact.Name)
                {
                    //  если вдруг находим  -  выставляем флаг и прерываем цикл
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
                phoneBook.Add(newContact);

            //  сортируем список по имени
            phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (var contact in phoneBook)
                Console.WriteLine(contact.Name + ": " + contact.PhoneNumber);
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
