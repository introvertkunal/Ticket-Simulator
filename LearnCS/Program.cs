// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace LearnCS
{

    public class Window
    {
        public Queue<int> Line=new Queue<int>();
    }
    public class TicketCounter
    {
        public static void Simualte(int numberPeople,List<Window> windows)
        {
            int minIndex = 0;
            while (numberPeople != 0)
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
                windows[minIndex].Line.Enqueue(1);
                numberPeople -= 1;

            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Counter {i + 1}: {windows[i].Line.Count} people");
            }

        }

        public static async Task removePeople(List<Window> windows)
        {
            await Task.Delay(1000);
            Boolean isRunning = true;
            while (isRunning)
            {
                isRunning = false;
                for (int i = 0; i < windows.Count; i++)

                {
                    if (windows[i].Line.Count != 0)
                    {
                        if (windows[i].Line.Count == 1)
                        {
                            windows[i].Line.Dequeue();
                            isRunning = true;
                        }
                        else
                        {
                            windows[i].Line.Dequeue();
                            windows[i].Line.Dequeue();
                            isRunning = true;
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Number of People Waiting in window {i + 1} is {windows[i].Line.Count}");
                }
            }
                
            
        }

        public static async Task Main(String[] args)

        {
            
            Window w1 = new Window();
            Window w2 = new Window();
            Window w3 = new Window();
            Window w4 = new Window();

            List<Window> windows = new List<Window>();
            windows.Add(w1);
            windows.Add(w2);
            windows.Add(w3);
            windows.Add(w4);

            int[] numberPeople = new int[5] { 13,25,10,20,34 };

            int minIndex = 0;
            while (numberPeople[0] != 0)
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
                windows[minIndex].Line.Enqueue(1);
                numberPeople[0] -= 1;

            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Counter {i + 1}: {windows[i].Line.Count} people");
            }

            var removePeopleTask = removePeople(windows);

            for (int i=1;i< numberPeople.Length; i++)
            {
                await Task.Delay(1000);
                Simualte(numberPeople[i], windows);
            }
            //Console.WriteLine("Enter the number of people:");
            //long numberOfPeople = long.Parse(Console.ReadLine());


            //int minIndex = 0;
            //while (numberOfPeople != 0)
            //{
            //    long min = windows[minIndex].Line.Count;
            //    for (int i = 3; i >= 0; i--)
            //    {
            //        if (windows[i].Line.Count <= min)
            //        {
            //            min = windows[i].Line.Count;
            //            minIndex = i;
            //        }
            //    }
            //    windows[minIndex].Line.Enqueue(1);
            //    numberOfPeople -= 1;

            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"Counter {i + 1}: {windows[i].Line.Count} people");
            //}

        }
    }
}







