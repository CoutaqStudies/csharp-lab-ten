using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Numerics;

namespace LabTen
{
    public class Graph
    {
        private int Verticies;
        private int[,] Matrix;
        public Graph(int[,] matrix, int verticies)
        {
            Verticies = verticies;
            Matrix = matrix;
        }
        public void ShowPath(Stack<int> stack)
        {
            int cnt = 0;
            foreach (int i in stack)
            {
                Console.Write((cnt == 0) ? Convert.ToString(i + 1) : "->" + (i + 1));
                cnt++;
            }
        }
        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            int[] vPath = new int[Verticies];
            int[] checkedv = new int[Verticies];
            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < Verticies; j++)
                {
                    if (Matrix[i, j] == 1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }

        public Stack<int> DFS(int startPos, int endPos)
        {
            Stack<int> st = new Stack<int>();

            int[] vPath = new int[Verticies];
            int[] checkedv = new int[Verticies];

            st.Push(startPos);
            checkedv[startPos] = 1;

            while (st.Count>0)
            {
                int i = st.Pop();

                for (int j = Verticies - 1; j >= 0; j--)
                {
                    if (Matrix[i, j] == 1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        st.Push(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }
        public HashSet<int> FindCities(int startPos, int distance = 0)
        {
            if (distance > 200)
                return null;
            HashSet<int> st = new HashSet<int>();
            int[] vPath = new int[Verticies];
            int[] checkedv = new int[Verticies];

            for(int i = 0; i< Verticies; i++)
            {
                if(Matrix[startPos, i]+distance<200 && i != startPos)
                {
                    st.Add(i);
                    distance += Matrix[startPos, i];
                    foreach (int city in FindCities(i, distance))
                    {
                        
                        if (!st.Contains(city) && city != startPos)
                        {
                            st.Add(city);
                        }
                    }
                }
            }
            return st;
        }

        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }

    }

}