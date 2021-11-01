using System;
using System.Numerics;

namespace task4
{
    class Hashing
    {
        static public int generating(int[] arr, int n, int h0)
        {
            BigInteger M;
            BigInteger sum;
            BigInteger H = new BigInteger(h0);
            Console.WriteLine($"H0 = {H}");

            for (int i = 0; i < arr.Length; i++)
            {
                M = new BigInteger(arr[i]);
                sum = H + M;
                H = BigInteger.ModPow(sum, 2, n);
                Console.WriteLine($"H{i + 1} = {H}");
            }

            return (int)H;
        }
    }
}