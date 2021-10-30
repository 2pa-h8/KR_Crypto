using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x = ");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Начало диапазона: ");
            var s = Convert.ToInt32(Console.ReadLine());
            Console.Write("Конец диапазона: ");
            var e = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Взаимно простые числа к числу {0}", x);
            for (int i = s; i < e + 1; i++)
            {
                if (IsCoprime(x, i))
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.ReadLine();
        }

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


    }
}
