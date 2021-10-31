using System;
using System.Numerics;

namespace task_5
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

            int phi = (p - 1) * (q - 1); //функция Эйлера
            int d = Calculate_d(phi);
            int e = Calculate_e(d, phi);

            int HashFunc = hashEncoder(arr, n, h0);
            Console.WriteLine('\n'+"Хэш-образ: " + HashFunc.ToString()+ '\n');
            
            Console.WriteLine("phi: " + phi);
            Console.WriteLine("d: " + d);
            Console.WriteLine("e: " + e + '\n');

            Console.WriteLine("Открытый ключ: (" + e + ", " + n + ")");
            Console.WriteLine("Закрытый ключ: (" + d + ", " + n + ")" + '\n');

            int result = eds(HashFunc,d,n);
            int test = eds(result, e,n);

            Console.WriteLine("Результат: " + result);
            Console.WriteLine("Проверка: " + test);

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

        //Проверка: взаимно ли простые числа?
        public static bool IsCoprime(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1 == 1;
            }
            else
            {
                if (num1 > num2)
                {
                    return IsCoprime(num1 - num2, num2);
                }
                else
                {
                    return IsCoprime(num2 - num1, num1);
                }
            }
        }

        //вычисление параметра d. d должно быть взаимно простым с phi
        static int Calculate_d(int phi)
        {
            Random rnd = new Random();
            int d = rnd.Next(1, phi);

            for (int i = d; i < phi - 1; i++)
            {
                if (IsCoprime(phi, i))
                {
                    d = i;
                    break;
                }
            }
            return d;
        }

        //вычисление параметра e
        static int Calculate_e(int d, int phi)
        {
            int e = 1;

            while (true)
            {
                if (((e * d) - 1) % phi == 0)
                    break;
                else
                    e++;
            }

            return e;
        }

        static int hashEncoder(int[] arr, int n, int h0)
        {
            BigInteger eBig = new BigInteger(2);
            BigInteger nBig = new BigInteger((int)n);
            BigInteger m;
            BigInteger sum;

            BigInteger h1 = new BigInteger(h0 + arr[0]);
            BigInteger h = BigInteger.ModPow(h1, eBig, nBig);

            for (int i = 1; i < arr.Length; i++)
            {
                m = new BigInteger(arr[i]);
                sum = h + m;
                h = BigInteger.ModPow(sum, eBig, nBig);
            }

            return (int)h;
        }

        static int eds(int x, int y, int z)
        {
            BigInteger xBig = new BigInteger((int)x);
            BigInteger yBig = new BigInteger((int)y);
            BigInteger zBig = new BigInteger((int)z);
            BigInteger r = BigInteger.ModPow(xBig, yBig, zBig);
            
            return (int)r;
        }
    }
}
