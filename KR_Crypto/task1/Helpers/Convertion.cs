using System.Collections.Generic;

namespace Helpers.task1
{
    class Convertion
    {
        static Dictionary<char, int> Alphabet = new Dictionary<char, int>()
        {
            { 'А', 192 }, { 'Б', 193 }, { 'В', 194 }, { 'Г', 195 }, { 'Д', 196 }, { 'Е', 197 }, { 'Ж', 198 }, { 'З', 199 }, { 'И', 200 }, { 'Й', 201 },
            { 'К', 202 }, { 'Л', 203 }, { 'М', 204 }, { 'Н', 205 }, { 'О', 206 }, { 'П', 207 }, { 'Р', 208 }, { 'С', 209 }, { 'Т', 210 }, { 'У', 211 },
            { 'Ф', 212 }, { 'Х', 213 }, { 'Ц', 214 }, { 'Ч', 215 }, { 'Ш', 216 }, { 'Щ', 217 }, { 'Ъ', 218 }, { 'Ы', 219 }, { 'Ь', 220 }, { 'Э', 221 },
            { 'Ю', 222 }, { 'Я', 223 }, { ' ', 32}
        };

        static public string StrToBinaryStr(string message_text)
        {
            string message = "";

            for (int i = 0; i < message_text.Length; i++)
            {
                //if (message_text[i] != ' ')                
                //    message += Convert.ToString(dict33[message[i]], 2);            
                //else
                //    message += "00010000";

                if (message_text[i] != ' ')
                    message += System.Convert.ToString(Alphabet[message_text[i]], 2);
                else
                    message += "00" + System.Convert.ToString(Alphabet[message_text[i]], 2);
            }

            return message;
        }

    }
}