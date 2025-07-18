using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace ukol_2
{
    class Merge
    {
        public static void Sort<T>(T[] a, int finalDepth)
        where T : IComparable
        {
            Sort(a, 0, a.Length, 0, finalDepth);
        }

        public static void Sort<T>(T[] a, int low, int high, int depth, int finalDepth)
            where T : IComparable
        {
            int N = high - low;
            if (N <= 1)
                return;

            int mid = low + N / 2;

            if(depth < finalDepth)
            { 
                depth++;
                var thread1 = new Thread(() => Sort(a, low, mid, depth, finalDepth));
                thread1.Start();

                var thread2 = new Thread(() => Sort(a, mid, high, depth, finalDepth));
                thread2.Start();

                thread1.Join();
                thread2.Join();
            }
            else
            {
                depth++;
                Sort(a, low, mid, depth, finalDepth);
                Sort(a, mid, high, depth, finalDepth);
            }

            T[] aux = new T[N];
            int i = low, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) aux[k] = a[j++];
                else if (j == high) aux[k] = a[i++];
                else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
                else aux[k] = a[i++];
            }

            for (int k = 0; k < N; k++)
            {
                a[low + k] = aux[k];
            }
        }
    }

    public static class GetRandom
	{
		public static int[] GetRandomArray(int count)
		{
			Random random = new Random();
			int[] values = new int[count];

			for (int i = 0; i < count; ++i)
				values[i] = random.Next();

			return values;
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetRandom.GetRandomArray(10000000);
            Stopwatch sw = Stopwatch.StartNew();
            Merge.Sort<int>(array, 0); // Degradace na sekvencni
            sw.Stop();
            Console.WriteLine("Cas behu v hloubce 0: {0}ms", sw.Elapsed.TotalMilliseconds);

            array = GetRandom.GetRandomArray(10000000);
            sw.Restart();
            Merge.Sort<int>(array, 1); // hloubka 1
            sw.Stop();
            Console.WriteLine("Cas behu v hloubce 1: {0}ms", sw.Elapsed.TotalMilliseconds);

            array = GetRandom.GetRandomArray(10000000);
            sw.Restart();
            Merge.Sort<int>(array, 2); // hloubka 2
            sw.Stop();
            Console.WriteLine("Cas behu v hloubce 2: {0}ms", sw.Elapsed.TotalMilliseconds);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
