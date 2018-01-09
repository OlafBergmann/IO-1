using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I_O
{
    class Program
    {
        private static int tabLength;
        private static int sumNumber;
        private static int[] numbers = null;
        private static Random rnd;
        private static List<AutoResetEvent> are;
        private static int sum;
        private static List<int> takenIndex;
        

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj wielkoœæ tablicy: ");
            tabLength = Convert.ToInt32(Console.ReadLine());
            takenIndex = new List<int>();

            numbers = new int[tabLength];
            sum = 0;

            fillRandom();
            printTable();

            Console.WriteLine("Podaj ile liczb ma byæ zsumowanych: ");
            sumNumber = Convert.ToInt32(Console.ReadLine());

            if (sumNumber >= tabLength)
            {
                Console.WriteLine("Liczba musi byæ mniejsza od rozmiaru tablicy.");
            }
            else
            {
                //are = new List<AutoResetEvent>();
                //are = new AutoResetEvent(true);
                for (int i = 0; i < sumNumber; i++)
                {
                    //var tempAre = new AutoResetEvent(false);
                    //are.Add(tempAre);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(SumNumbers));
                    Thread.Sleep(200);
                }
                //WaitHandle.WaitAll(are.ToArray());

            }
            Console.WriteLine("Suma: " + sum);
        }

        static void fillRandom()
        {
            rnd = new Random();
            for (int i = 0; i < tabLength; i++)
            {
                numbers[i] = rnd.Next(0, 1000);
            }
        }

        static void printTable()
        {
            for (int i = 0; i < tabLength; i++)
            {
                Console.Write(numbers[i] + "\t");
            }
            Console.WriteLine();
        }

        static void SumNumbers(object obj)
        {
            Console.WriteLine("SumNr");
            object lockObj = new object();
            lock (lockObj)
            {
                Random sRnd = new Random();
                int index = sRnd.Next(1, tabLength - 1);
                sum += numbers[index];
                Console.WriteLine("Indeks, tab {0}, {1}", index, numbers[index]);
            }
            
            //AutoResetEvent sumAre = (AutoResetEvent) obj;
            //sumAre.Set();

            
        }
    }
}