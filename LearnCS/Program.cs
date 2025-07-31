using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TicketSimulator
{   
    public class Window
    {
        public Queue<int> Line = new Queue<int>();
    }
    public class TicketCounter
    {
        public static void Stimulate(int numberPeople, List<Window> windows)
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
            Console.WriteLine($"\n-------People Distributed among queue--------");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Counter {i + 1}: {windows[i].Line.Count} people");
            }
        }

        public static void removePeople(List<Window> windows)
        {
            for (int i = 0; i < 4; i++)
            {
                if (windows[i].Line.Count > 0)
                    windows[i].Line.Dequeue();
                if (windows[i].Line.Count > 0)
                    windows[i].Line.Dequeue();
            }
        }
        public static void printPeople(List<Window> windows, int minute)
        {
            Console.WriteLine($"\n----------Minute {minute}-------------");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"The Number of People waiting in counter {i + 1} are: {windows[i].Line.Count}");
                double waitingTime = ((windows[i].Line.Count + 1) * 30.0) / 60.0;
                Console.WriteLine($"The Last Person is waiting in Counter {i + 1} about {waitingTime} Minute");
            }
        }

        public static async Task Main(string[] args)
        {
            Window w1 = new Window();
            Window w2 = new Window();
            Window w3 = new Window();
            Window w4 = new Window();

            List<Window> windows = new List<Window> { w1, w2, w3, w4 };

            int minute = 0;
            string filePath = "C:\\Users\\Kunal Singh\\Desktop\\numberofpeople.txt.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (int.TryParse(line, out int numberPeople))
                    {
                        Stimulate(numberPeople, windows);
                        removePeople(windows);
                        printPeople(windows, ++minute);
                        await Task.Delay(1000);
                    }
                }
            }
            while (w1.Line.Count > 0 || w2.Line.Count > 0 || w3.Line.Count > 0 || w4.Line.Count > 0)
            {
                removePeople(windows);
                printPeople(windows, ++minute);
                await Task.Delay(1000);
            }
        }
    }
}