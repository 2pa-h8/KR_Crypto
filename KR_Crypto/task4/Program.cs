using System;
using System.Collections.Generic;

namespace task4
{
    class Program
    {
        static void Main(string[] args) // Метод хэширования
        {
            Console.WriteLine("Введите сообщение:");
            var msg = Console.ReadLine().ToUpper();

            Console.WriteLine("Введите 2 простых числа p и q:");

            int p = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите начальное значение хэша h0: ");
            int h0 = Convert.ToInt32(Console.ReadLine());

            int n = p * q;
            int[] arr = getNumbers(msg);

            Console.WriteLine("Слово " + msg + " Можно представить последовательностью чисел:");
            foreach (int i in arr)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            int result = Hashing.generating(arr, n, h0);
            Console.WriteLine("Хэш-образ: " + result.ToString());
        }

        static public Dictionary<char, int> Alphabet = new Dictionary<char, int>()
        {
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ё', 7 }, { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 }, { 'Й', 11 },
            { 'К', 12 }, { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 }, { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 }, { 'У', 21 },
            { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 }, { 'Э', 31 },
            { 'Ю', 32 }, { 'Я', 33 }
        };

        //Возвращает массив чисел, соответствующий номерам букв в алфавите
        static int[] getNumbers(string msg)
        {
            int[] numbers = new int[msg.Length];

            for (int i = 0; i < msg.Length; i++)
            {
                int index = Alphabet[msg[i]];
                numbers[i] = index;
            }
            return numbers;
        }     
    }
}