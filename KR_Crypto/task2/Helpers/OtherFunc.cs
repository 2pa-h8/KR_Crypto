using System;

namespace Helpers.task2
{
    class OtherFunc
    {
        static public string sumR0andX(string r0, string x)
        {
            long sum = Convert.ToInt64(r0, 2) + Convert.ToInt64(x, 2);

            string sum_str = Convert.ToString(sum, 2);

            if (sum_str.Length == 33)
                sum_str = sum_str.Substring(1);

            return sum_str;
        }

        // преобразование в блоке подстановки
        static public string tableConversion(string str)
        {
            string final_result = "";
            string[] arrBites = new string[str.Length / 4];

            for (int i = 0; i < str.Length / 4; i++)
            {
                arrBites[i] = str.Substring(i * 4, 4);
            }

            for (int i = 0; i < arrBites.Length; i++)
            {
                int y = Convert.ToInt32(arrBites[i], 2);
                int x = 8 - i;

                int numbInTable = getNumberFromTable(x, y);

                string result = Convert.ToString(numbInTable, 2);
                string resultWithPadding;

                switch (result.Length)
                {
                    case 1:
                        resultWithPadding = "000" + result;
                        break;

                    case 2:
                        resultWithPadding = "00" + result;
                        break;

                    case 3:
                        resultWithPadding = "0" + result;
                        break;

                    default:
                        resultWithPadding = result;
                        break;
                }

                final_result += resultWithPadding;
            }

            return final_result;
        }

        public static int[] TABLEGOST28147_89 = {
            // 0  1   2  3  4  5  6   7
            1, 13, 4, 6, 7, 5, 14, 4,       // 0
            15, 11, 11, 12, 13, 8, 11, 10,  // 1
            13, 4, 10, 7, 10, 4, 4, 9,      // 2
            0, 1, 0, 1, 1, 13, 12, 2,       // 3
            5, 3, 7, 5, 0, 10, 6, 13,       // 4
            7, 15, 2, 15, 8, 3, 13, 8,      // 5
            10, 5, 1, 13, 9, 4, 15, 0,      // 6
            4, 9, 13, 8, 15, 2, 10, 14,     // 7
            9, 0, 3, 4, 14, 14, 2, 6,       // 8
            2, 10, 6, 10, 4, 15, 3, 11,     // 9
            3, 14, 8, 9, 6, 12, 8, 1,       // 10
            14, 7, 5, 14, 12, 7, 1, 12,     // 11
            6, 6, 9, 0, 11, 6, 0, 7,        // 12
            11, 8, 12, 3, 2, 0, 7, 15,      // 13
            8, 2, 15, 11, 5, 9, 5, 5,       // 14
            12, 12, 14, 2, 3, 11, 9, 3      // 15
        };

        // получение элемента из таблицы согласно номерам строки и столбца
        static public int getNumberFromTable(int x, int y)
        {
            int ind = y * 8 + (8 - x);
            return TABLEGOST28147_89[ind];
        }

        static public string shiftLeft11(string biteStr)
        {
            return biteStr.Substring(11) + biteStr.Substring(0, 11);
        }

        static public string XOR(string str1, string str2)
        {
            string result = "";
            for (int i = 0; i < str2.Length; i++)
                result += (byte)(str2[i] ^ str1[i]);

            return result;
        }
    }
}