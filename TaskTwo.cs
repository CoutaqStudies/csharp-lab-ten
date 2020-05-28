using System;
using System.Collections.Generic;
using System.Text;

namespace LabTen
{
    class TaskTwo
    {
        internal static void Execute()
        {
            int[] coins = new int[100];
            int[] values = {1,2,5,10,20,50,100};
            Random r = new Random();
            for(int i = 0; i < coins.Length; i++)
            {
                coins[i] = values[r.Next(0, values.Length)];
            }
            coins = Sorter.CountingSort(coins, values[0], values[values.Length-1]);
            for (int i = 0; i < coins.Length; i++)
            {
                Console.Write(coins[i]+" ");
            }
        }
    }
}
