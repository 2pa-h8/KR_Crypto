using System;
using System.Numerics;
using System.Text;

namespace task4
{
    class Program
    {
        static readonly char[] characters = new char[] { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0' };

        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение:");
            var msg = Console.ReadLine();

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
                Console.WriteLine(i);
            }

            int result = hashEncoder(arr, n, h0);
            Console.WriteLine("Хэш-образ: " + result.ToString());


        }

        //Возвращает массив чисел, соответствующий номерам букв в алфавите
        static int[] getNumbers(string msg)
        {
            int[] numbers = new int[msg.Length];

            for (int i = 0; i < msg.Length; i++)
            {
                int index = Array.IndexOf(characters, msg[i]);
                numbers[i] = index;
            }
            return numbers;
        }

        static int hashEncoder(int[] arr, int n, int h0)
        {
            StringBuilder sb = new StringBuilder();
            BigInteger eBig = new BigInteger(2);
            BigInteger nBig = new BigInteger((int)n);
            BigInteger m;
            BigInteger sum;

            BigInteger h1 = new BigInteger(h0+arr[0]);
            BigInteger h = BigInteger.ModPow(h1, eBig,nBig);

            for (int i = 1; i < arr.Length; i++)
            {
                m = new BigInteger(arr[i]);
                sum = h + m;
                h = BigInteger.ModPow(sum, eBig, nBig);
            }
            
            return (int)h;
        }

    }
}
