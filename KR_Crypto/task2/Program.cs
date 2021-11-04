using System;
using Helpers.task2;

namespace task2
{
    class Program
    {
        static void Main(string[] args) // Метод ГОСТ
        {
            Console.WriteLine("Введите собщения из 8 символов:");
            string msg = Console.ReadLine().ToUpper().Substring(0, 8);

            Console.WriteLine("Введите ключ из 4 cимвола:");
            string x0 = Console.ReadLine().ToUpper().Substring(0, 4);

            msg = Convertion.StrToBinaryStr(msg);
            x0 = Convertion.StrToBinaryStr(x0);

            Console.WriteLine("Исходное сообщение:       " + msg);
            Console.WriteLine("Подключ X0:               " + x0 + "\n");

            string l0 = msg.Substring(0, 32);

            string r0 = msg.Substring(32, 32);

            Console.WriteLine("L:                        " + l0);
            Console.WriteLine("R:                        " + r0 + "\n");

            string sum = OtherFunc.sumR0andX(r0, x0);

            Console.WriteLine("Сумма R и подключа X:     " + sum + "\n");

            string tableConvString = OtherFunc.tableConversion(sum);

            Console.WriteLine("Преобразование" + "\nв блоке подстановки:      " + tableConvString + "\n");

            string shiftedStr = OtherFunc.shiftLeft11(tableConvString);

            Console.WriteLine("Сдвинутая" + "\nпоследовательность:       " + shiftedStr + "\n");


            Console.WriteLine("L1:                       " + r0);
            string result = OtherFunc.XOR(l0, shiftedStr);
            Console.WriteLine("R1:                       " + result);
        }
    }
}