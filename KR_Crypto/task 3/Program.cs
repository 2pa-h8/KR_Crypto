using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace task_3
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

            if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
            {
                int n = p * q;
                Console.WriteLine('\n' + "n: " + n);

                int phi = (p - 1) * (q - 1); //функция Эйлера
                Console.WriteLine("phi: " + phi);

                int d = Calculate_d(phi);
                Console.WriteLine("d: " + d);

                int e = Calculate_e(d, phi);
                Console.WriteLine("e: " + e + '\n');

                Console.WriteLine("Открытый ключ: (" + e + ", " + n + ")");
                Console.WriteLine("Закрытый ключ: (" + d + ", " + n + ")" + '\n');

                List<string> result = RSA_Endoce(msg, e, n);

                StringBuilder sb = new StringBuilder();
                foreach (string item in result)
                    sb.Append(item + " ");
                Console.WriteLine("[ " + sb + "]");

            }
            else
            { 
                Console.WriteLine("p или q - не простые числа!");
            }
        }

        //проверка: простое ли число?
        static bool IsTheNumberSimple(int n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
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
            int e = 10;

            while (true)
            {
                if (((e * d) - 1) % phi == 0)
                    break;
                else
                    e++;
            }

            return e;
        }

        //зашифровать
        static List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            StringBuilder sb = new StringBuilder();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                sb.Append(index+ " ");

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            Console.WriteLine("[ " + sb + "]");

            return result;
        }

    }
}
