using System;
using System.Collections.Generic;
using System.Numerics;

namespace task_3
{
    class RSAEncrypt
    {
        static public Dictionary<char, int> Alphabet = new Dictionary<char, int>()
        {
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ё', 7 }, { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 }, { 'Й', 11 },
            { 'К', 12 }, { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 }, { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 }, { 'У', 21 },
            { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 }, { 'Э', 31 },
            { 'Ю', 32 }, { 'Я', 33 }
        };

        //проверка: простое ли число?
        public static bool IsTheNumberSimple(int n)
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
        private static bool IsCoprime(int num1, int num2)
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
        static public int Calculate_d(int phi)
        {
            int d = 2;

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
        static public int Calculate_e(int d, int phi)
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

        //зашифровать
        static public int[] Enсrypt(string message, int e, int n)
        {
            int[] result = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                int index = Convert.ToInt32(Alphabet[message[i]]);

                BigInteger bi = BigInteger.ModPow(index, e, n);

                result[i] = (int)bi;
            }

            return result;
        }

        //расшифровать
        static public int[] Deсrypt(int[] data_enc, int d, int n)
        {
            int[] result = new int[data_enc.Length];

            for (int i = 0; i < data_enc.Length; i++)
            {
                BigInteger bi = BigInteger.ModPow(data_enc[i], d, n);

                result[i] = (int)bi;
            }

            return result;
        }
    }
}
