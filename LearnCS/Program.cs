// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace LearnCS
{

    class Window
    {
        public Queue<int> Line=new Queue<int>();
        public int counter;
    }
    public class TicketCounter
    {
        public static void Main(String[] args)

        {
            

            Window w1 = new Window();
            Window w2 = new Window();
            Window w3 = new Window();
            Window w4 = new Window();

            Console.WriteLine($"{w1.Line.Count}");
            Console.WriteLine($"{w2.Line.Count}");
            Console.WriteLine($"{w3.Line.Count}");
            Console.WriteLine($"{w4.Line.Count}");

            int[] counter = new int[4];

            List<Window> windows = new List<Window>();
            windows.Add(w1);
            windows.Add(w2);
            windows.Add(w3);
            windows.Add(w4);


            //Console.WriteLine("Enter the number of people:");
            //long numberOfPeople = long.Parse(Console.ReadLine());
            //Window minCounter;
            //while (numberOfPeople != 0)
            //{
            //    long min = w1.counter;
            //    foreach(var window in windows)
            //    {
            //        if (window!=w1 && window.counter <= min){
            //            min = window.counter;
            //            minCounter = window;
            //        }
            //    }

            //    numberOfPeople -= 1;
            //}


            //int minIndex = 0;
            //while (numberOfPeople != 0)
            //{
            //    long min = windows.w1.counter ;
            //    for(int i = 3; i >=0; i--)
            //    {
            //        if (counter[i] <= min)
            //        {
            //            min = counter[i]; 
            //            minIndex = i;
            //        }
            //    }
            //    Console.WriteLine(minIndex);
            //    counter[minIndex] += 1;
            //    numberOfPeople -= 1;

            //}

            //for(int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"Counter {i + 1}: {counter[i]} people");
            //}

        }
    }
}







