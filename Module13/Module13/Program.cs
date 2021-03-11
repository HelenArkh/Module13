using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

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

       

        // объявим потокобезопасную очередь (полностью идентична обычной очереди, но
        // позволяет безопасный доступ
        // из разных потоков)
        public static ConcurrentQueue<string> words = new ConcurrentQueue<string>();

        // объявим список в виде статической переменной
        public static LinkedList<string> LinkedList = new LinkedList<string>();
        static void Main(string[] args)
        {
            // Добавим несколько элементов
            LinkedList.AddFirst("Лиса");
            LinkedList.AddFirst("Волк");
            LinkedList.AddFirst("Заяц");
            var mouse = LinkedList.AddFirst("Мышь");

            GoOnwards(); //   Прямой проход списка
            GoBackwards(); // Обратный проход списка

            // Вставка нового элемента
            LinkedList.AddAfter(mouse, "Медведь");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Выведем список ещё раз после вставки");
            Console.WriteLine();


            GoOnwards(); //   Прямой проход списка
            GoBackwards(); // Обратный проход списка
        }

        static void GoOnwards()
        {
            LinkedListNode<string> node;

            Console.WriteLine("Элементы коллекции в прямом направлении: ");
            for (node = LinkedList.First; node != null; node = node.Next)
                Console.Write(node.Value + " ");
        }

        static void GoBackwards()
        {
            LinkedListNode<string> node;

            Console.WriteLine("\n\nЭлементы коллекции в обратном направлении: ");
            for (node = LinkedList.Last; node != null; node = node.Previous)
                Console.Write(node.Value + " ");
        }

        // метод, который обрабатывает и разбирает нашу очередь в отдельном потоке
        // ( для выполнения задания изменять его не нужно )
        static void StartQueueProcessing()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    Thread.Sleep(5000);
                    if (words.TryDequeue(out var element))
                        Console.WriteLine("======>  " + element + " прошел очередь");
                }

            }).Start();
        }
    }



        
    }

