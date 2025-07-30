// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace LearnCS
{

    class Window
    {
        public Queue<int> Line=new Queue<int>();
    }
    public class TicketCounter
    {
        public static void Main(String[] args)

        {
            

            Window w1 = new Window();
            Window w2 = new Window();
            Window w3 = new Window();
            Window w4 = new Window();

            //int[] counter = new int[4];

            List<Window> windows = new List<Window>();
            windows.Add(w1);
            windows.Add(w2);
            windows.Add(w3);
            windows.Add(w4);


            Console.WriteLine("Enter the number of people:");
            long numberOfPeople = long.Parse(Console.ReadLine());


            int minIndex = 0;
            while (numberOfPeople != 0)
            {
                long min = windows[minIndex].Line.Count;
                for (int i = 3; i >= 0; i--)
                {
                    if (windows[i].Line.Count <= min)
                    {
                        min = windows[i].Line.Count;
                        minIndex = i;
                    }
                }
                Console.WriteLine(minIndex);
                windows[minIndex].Line.Enqueue(1);
                numberOfPeople -= 1;

            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Counter {i + 1}: {windows[i].Line.Count} people");
            }

        }
    }
}







