using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OddEven

{
    class OddEvenThread
    {
        private static AutoResetEvent event1 = new AutoResetEvent(true);
        private static AutoResetEvent event2 = new AutoResetEvent(false);
        static void Main(string[] args)
        {

            var task1 = Task.Factory.StartNew(() => PrintOddNumbers());
            var task2 = Task.Factory.StartNew(() => PrintEvenNumbers());
            Task.WaitAll(task1, task2);
            Console.ReadLine();
        }

        static void PrintOddNumbers()
        {
            int[] numbers = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };
            foreach (var num in numbers)
            {
                event1.WaitOne();
                Console.WriteLine(num);
                event2.Set();
            }
        }

        static void PrintEvenNumbers()
        {
            int[] numbers = new int[] { 2, 4, 6, 8, 10, 12, 14 };
            foreach (var num in numbers)
            {
                event2.WaitOne();
                Console.WriteLine(num);
                event1.Set();
            }
        }
    }
}
