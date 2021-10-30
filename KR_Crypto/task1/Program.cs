using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "ШИЛОВА  ";
            string key = "МАРИЯ   ";

            //message = ConvertToBinary(message);
            message = "1101100011001000110010111100111011000010110000000001000000010000";
            Console.WriteLine("Исходное сообщение           " + message);
            //key = ConvertToBinary(key);
            key = "1100110011000000110100001100100011011111000100000001000000010000";
            Console.WriteLine("Исходный ключ                " + key + '\n');

            string FirstPermutation = Transposition(message.Substring(0, 64), arr);
            Console.WriteLine("Сообщение после перестановки " + FirstPermutation + '\n');

            string r0 = FirstPermutation.Substring(32, FirstPermutation.Length / 2);
            Console.WriteLine("R0                           " + r0);
            string l0 = FirstPermutation.Substring(0, FirstPermutation.Length / 2);
            Console.WriteLine("L0                           " + l0 + '\n');

            string r0ext = Transposition(r0, table);
            Console.WriteLine("R расширенный                " + r0ext);
            string keyConv = KeyGenerator(key);
            Console.WriteLine("Измененный ключ              " + keyConv);
            string xor = XOR(r0ext, keyConv);
            Console.WriteLine("Суммирование                 " + xor + '\n');

            string STrans = Spermutation(xor);
            Console.WriteLine("После S перестановки         " + STrans);
            string PTrans = Transposition(STrans, tableP);
            Console.WriteLine("После P перестановки         " + PTrans);
            string sum = l0 + PTrans;
            Console.WriteLine("Сумма строк                  " + sum);
            string result = Transposition(sum, arrP);
            Console.WriteLine("Последняя перестановка       " + result + '\n');

        }


        static string ConvertToBinary(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string char_binary = Convert.ToString(input[i], 2);

                while (char_binary.Length < 8)
                    char_binary = "0" + char_binary;

                output += char_binary;
            }

            return output;
        }

        static string XOR(string str1, string str2)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str2.Length; i++)
                sb.Append((byte)(str2[i] ^ str1[i]));
            return sb.ToString();
        }

        static string Transposition(string str, int[] array)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(str[array[i] - 1]);
            }
            return sb.ToString();
        }

        static string Spermutation(string text)
        {

            StringBuilder sb = new StringBuilder();
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                int row = Convert.ToInt32(Convert.ToString(text.Substring(j, 1)) + Convert.ToString(text.Substring(j + 5, 1)), 2);
                int coloumn = Convert.ToInt32(Convert.ToString(text.Substring(j + 1, 4)), 2);

                sb.Append(Convert.ToString(S[i][row, coloumn], 2).PadLeft(4, '0'));
                j += 6;
            }

            return sb.ToString();
        }


        static string KeyGenerator(string key)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(key);
            for (int j = 0; j < 2; j++)
            {
                for (int i = 1; i < sb.Length; i++)
                {
                    if (i % 7 == 0)
                    {
                        sb.Remove(i, 1);
                    }
                }
            }
            
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }



        //EXTENSION
        static readonly int[] table = { 32, 1, 2, 3, 4, 5,
                                        4, 5, 6, 7, 8, 9,
                                        8, 9, 10, 11, 12, 13,
                                        12, 13, 14, 15, 16, 17,
                                        16, 17, 18, 19, 20, 21,
                                        20, 21, 22, 23, 24, 25,
                                        24, 25, 26, 27, 28, 29,
                                        28, 29, 30, 31, 32, 1};

        //P_TRANSFORMATION 
        static readonly int[] tableP = {16, 7, 20, 21, 29, 12, 28, 17,
                                        1, 15, 23, 26, 5, 18, 31, 10,
                                        2, 8, 24, 14, 32, 27, 3, 9,
                                        19, 13, 30, 6, 22, 11, 4, 25};

        static readonly int[][,] S = new int[8][,]
            {
                new int[,] { {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                             {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                             {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                             {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }},

                new int[,] { {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                             {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                             {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                             {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }},

                new int[,] { {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                             {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                             {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                             {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }},

                new int[,] { {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                             {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                             {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                             {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }},

                new int[,] { {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                             {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                             {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                             {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }},

                new int[,] { {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                             {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                             {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                             {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }},

                new int[,] { {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                             {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                             {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                             {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }},

                new int[,] { {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                             {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                             {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                             {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }}
            };

        //INITIAL_PERMUTATION
        static readonly int[] arr = { 58, 50, 42, 34, 26, 18, 10, 2,
                                      60, 52, 44, 36, 28, 20, 12, 4,
                                      62, 54, 46, 38, 30, 22, 14, 6,
                                      64, 56, 48, 40, 32, 24, 16, 8,
                                      57, 49, 41, 33, 25, 17, 9,  1,
                                      59, 51, 43, 35, 27, 19, 11, 3,
                                      61, 53, 45, 37, 29, 21, 13, 5,
                                      63, 55, 47, 39, 31, 23, 15, 7 };

        //LAST_PERMUTATION
        static readonly int[] arrP = {40, 8, 48, 16, 56, 24, 64, 32,
                                      39, 7, 47, 15, 55, 23, 63, 31,
                                      38, 6, 46, 14, 54, 22, 62, 30,
                                      37, 5, 45, 13, 53, 21, 61, 29,
                                      36, 4, 44, 12, 52, 20, 60, 28,
                                      35, 3, 43, 11, 51, 19, 59, 27,
                                      34, 2, 42, 10, 50, 18, 58, 26,
                                      33, 1, 41,  9, 49, 17, 57, 25 };
    }
}