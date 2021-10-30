using Helpers;
using System;

namespace task1
{
    class Program
    {      
        static void Main(string[] args) // МЕТОД DES
        {
            Console.WriteLine("Введите сообщения из 8 символов");

            string message_text = Console.ReadLine().ToUpper();
            string message = Convertion.StrToBinaryStr(message_text);

            Console.WriteLine("Введите ключ из 8 символов");
            string key_text = Console.ReadLine().ToUpper();
            string key = Convertion.StrToBinaryStr(key_text);

            Console.WriteLine("Исходное сообщение           " + message);
            Console.WriteLine("Исходный ключ                " + key + '\n');

            string FirstPermutation = OtherFunc.Transposition(message.Substring(0, 64), OtherFunc.arr);
            Console.WriteLine("Сообщение после перестановки " + FirstPermutation + '\n');

            string r0 = FirstPermutation.Substring(32, FirstPermutation.Length / 2);
            Console.WriteLine("R0                           " + r0);
            string l0 = FirstPermutation.Substring(0, FirstPermutation.Length / 2);
            Console.WriteLine("L0                           " + l0 + '\n');

            string r0ext = OtherFunc.Transposition(r0, OtherFunc.table);
            Console.WriteLine("R расширенный                " + r0ext);
            string keyConv = OtherFunc.KeyGenerator(key);
            Console.WriteLine("Измененный ключ              " + keyConv);
            string xor = OtherFunc.XOR(r0ext, keyConv);
            Console.WriteLine("Суммирование                 " + xor + '\n');

            string STrans = OtherFunc.Spermutation(xor);
            Console.WriteLine("После S перестановки         " + STrans);
            string PTrans = OtherFunc.Transposition(STrans, OtherFunc.tableP);
            Console.WriteLine("После P перестановки         " + PTrans);

            string r1 = OtherFunc.XOR(PTrans, l0);
            Console.WriteLine("R1                           " + r1);

            Console.WriteLine("Сумма строк                  " + r0 + r1);
            string result = OtherFunc.Transposition(r0 + r1, OtherFunc.arrP);
            Console.WriteLine("Последняя перестановка       " + result + '\n');

        }
        
    }
}