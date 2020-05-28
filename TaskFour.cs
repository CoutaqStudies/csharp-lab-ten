using System;
using System.Collections.Generic;
using System.Text;

namespace LabTen
{
    class TaskFour
    {
       public static void Execute()
        {
            int[,] matrix =
            {
                { 0, 100, 300, 50},
                { 100, 0, 250, 70},
                { 300, 250, 0, 120},
                { 50, 70, 120, 0},
            };
            Graph graph = new Graph(matrix, 4);
            var g = graph.FindCities(0);
            foreach(int city in g)
            {
                Console.WriteLine(city);
            }
        }
    }
}
