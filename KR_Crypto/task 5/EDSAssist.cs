using System.Numerics;

namespace task_5
{
    class EDSAssist
    {
        //Проверка: взаимно ли простые числа?
        static public bool IsCoprime(int num1, int num2)
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

        static public int eds(int x, int y, int z)
        {
            return (int)BigInteger.ModPow(x, y, z);
        }
    }
}