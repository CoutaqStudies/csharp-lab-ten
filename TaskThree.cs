using System;
using System.Collections.Generic;
using System.Text;

namespace LabTen
{
    class TaskThree
    {
        public static void Execute()
        {
            int[,] matrix =
            {
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1,0,0,0,0,1,1,0,0,0},
                { 0,1,1,0,0,0,0,0,1,1},
                { 0,0,1,1,0,0,0,0,0,0},
                { 0,0,0,1,1,0,0,0,0,0},
                { 0,0,0,0,1,1,0,0,0,1},
                {0,0,0,0,0,0,1,1,0,0},
                {0,0,0,0,0,0,0,1,1,0}
            };
            Graph graph = new Graph(matrix, 8);
            graph.ShowPath(graph.DFS(0,7));
            Console.WriteLine("\n");
            graph.ShowPath(graph.BFS(0, 7));

        }
      
    }
}
