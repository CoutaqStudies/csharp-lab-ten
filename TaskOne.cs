using Coutaq;
using Medallion;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabTen
{
    class TaskOne
    {
        internal static void Execute()
        {
            EasyTimer timer = new EasyTimer();
            String times = String.Empty;
            String time = String.Empty;
            int[] ints = new int[100000];
            for(int i =0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            ints.Shuffle();
            AddText("Merge", ref times);
            #region Merge
            timer.Start();
            ints = Sorter.MergeSort(ints);
            SaveTime("Random: ", ref times, ref timer);
            timer.Start();
            ints = Sorter.MergeSort(ints);
            SaveTime("Ascending: ", ref times, ref timer);
            ints.Reverse();
            timer.Start();
            ints = Sorter.MergeSort(ints);
            SaveTime("Descending: ", ref times, ref timer);
            #endregion
            AddText("Heap", ref times);
            ints.Shuffle();
            #region Heap
            timer.Start();
            ints = Sorter.HeapSort(ints);
            SaveTime("Random: ", ref times, ref timer);
            timer.Start();
            ints = Sorter.HeapSort(ints);
            SaveTime("Ascending: ", ref times, ref timer);
            ints.Reverse();
            timer.Start();
            ints = Sorter.HeapSort(ints);
            SaveTime("Descending: ", ref times, ref timer);
            #endregion
            AddText("Quick", ref times);
            ints.Shuffle();
            #region Quick
            timer.Start();
            Sorter.QuickSort(ints, 0, ints.Length - 1);
            SaveTime("Random: ", ref times, ref timer);
            timer.Start();
            Sorter.QuickSort(ints, 0, ints.Length - 1);
            SaveTime("Ascending: ", ref times, ref timer);
            ints.Reverse();
            timer.Start();
            Sorter.QuickSort(ints, 0, ints.Length - 1);
            SaveTime("Descending: ", ref times, ref timer);
            #endregion
            FileExpert.SaveToRelativePath("sorted.dat", times.Trim());
        }
        public static void SaveTime(String text, ref String times, ref EasyTimer timer)
        {
            String time = timer.Time(text);
            Console.WriteLine(time);
            times += "\n"+time;
            times.Trim();
        }
        public static void AddText(String text, ref String times)
        {
            Console.WriteLine(text);
            times += "\n" + text;
            times.Trim();
        }
    }
}
