using System;

namespace task_5
{
    class Program
    {

        static void Main(string[] args) // Метод ЕЦП
        {
            Console.WriteLine("Введите 2 простых числа p и q:");

            int p = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Console.ReadLine());      
            int n = p * q;

            int phi = (p - 1) * (q - 1); //функция Эйлера
            int d = EDSAssist.Calculate_d(phi);
            int e = EDSAssist.Calculate_e(d, phi);

            Console.WriteLine();

            Console.WriteLine("Введите значение хэша из четвёртого задания: ");
            int HashFunc = Convert.ToInt32(Console.ReadLine()); ;
            
            Console.WriteLine("phi: " + phi);
            Console.WriteLine("d: " + d);
            Console.WriteLine("e: " + e);

            Console.WriteLine();

            Console.WriteLine("В итоге:");
            Console.WriteLine("Открытый ключ: (" + e + ", " + n + ")");
            Console.WriteLine("Закрытый ключ: (" + d + ", " + n + ")");

            Console.WriteLine();

            int result1 = EDSAssist.eds(HashFunc, d, n);
            int result2 = EDSAssist.eds(result1, e, n);

            Console.WriteLine("Результат: " + result1);
            Console.WriteLine("Проверка: " + result2);

        }
    }
}