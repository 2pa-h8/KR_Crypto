using System;

namespace task_3
{
    class Program
    {
        static void Main(string[] args) // Метод RSA
        {
            Console.WriteLine("Введите сообщение:");
            string msg = Console.ReadLine().ToUpper();

            Console.WriteLine("Введите 2 простых числа p и q:");

            int p = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("==============");

            if (RSAEncrypt.IsTheNumberSimple(p) && RSAEncrypt.IsTheNumberSimple(q))
            {
                int n = p * q;
                Console.WriteLine("n: " + n);

                int phi = (p - 1) * (q - 1); //функция Эйлера
                Console.WriteLine("phi: " + phi);

                int d = RSAEncrypt.Calculate_d(phi);
                Console.WriteLine("d: " + d);

                int e = RSAEncrypt.Calculate_e(d, phi);
                Console.WriteLine("e: " + e);

                Console.WriteLine("==============");

                Console.WriteLine("Открытый ключ: (" + e + ", " + n + ")");
                Console.WriteLine("Закрытый ключ: (" + d + ", " + n + ")");

                Console.WriteLine("==============");

                int[] result_enc = RSAEncrypt.Enсrypt(msg, e, n);

                foreach (var item in result_enc)
                {
                    Console.Write(item.ToString() + "\t");
                }
                Console.WriteLine("----- Зашифрованное сообщение");

                int[] result_dec = RSAEncrypt.Deсrypt(result_enc, d, n);

                foreach (var item in result_dec)
                {
                    Console.Write(item.ToString() + "\t");
                }
                Console.WriteLine("----- Расшифрованное сообщение");

            }
            else
            { 
                Console.WriteLine("p или q - не простые числа!");
            }
        }    
    }
}