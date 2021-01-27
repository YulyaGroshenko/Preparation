using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Subtitles
{
    class Program
    {
        static void Main()
        {
            Print();
            Subs.Partitioning();
            Subs.TheTextsLast();

        }
        static void Print()
        {
            Console.Write('┌');
            Console.Write(new string('─', 50));
            Console.WriteLine('┐');
            for (int i = 0; i < 15; i++)
            {
                Console.Write('│');
                Console.Write(new string(' ', 50));
                Console.WriteLine('│');
            }
            Console.Write('└');
            Console.Write(new string('─', 50));
            Console.WriteLine('┘');
        }

    }
    class Subs
    {
        string text;
        ConsoleColor color;
        string location;
        DateTime startTime;
        DateTime finishTime;
        TimeSpan timeSpan;

        static string[] line = File.ReadAllLines("file.txt");
        static List<Subs> list = new List<Subs>();

        public static void Partitioning()
        {

            for (int i = 0; i < line.Length; i++)
            {
                Subs subs = new Subs();
                string[] split = line[i].Split(" ");
                subs.startTime = Convert.ToDateTime("00:" + split[0]);
                subs.finishTime = Convert.ToDateTime("00:" + split[2]);
                subs.timeSpan = subs.finishTime.Subtract(subs.startTime);               

                if (split[3].Contains("["))
                {
                    subs.location = split[3].Trim(new char[] { '[', ',' });
                    switch (split[4])
                    {
                        case ("Red]"):
                            subs.color = ConsoleColor.Red;
                            break;
                        case ("Blue]"):
                            subs.color = ConsoleColor.Blue;
                            break;
                        case ("Green]"):
                            subs.color = ConsoleColor.Green;
                            break;
                    }
                }
                string str = null;
                if (subs.color != ConsoleColor.Black)
                {
                    for (int k = 5; k < split.Length; k++)
                    {
                        str = str + split[k] + " ";
                    }
                }
                else
                {
                    for (int k = 3; k < split.Length; k++)
                    {
                        str = str + split[k] + " ";
                    }
                }
                subs.text = str;
                list.Add(subs);
            }
        }
        public static void TheTextsLast()
        {
            for (int i = 1; i < list.Count; i++)
            {
                
                while (list[i-1].startTime.Second == list[i].startTime.Second)
                {
                    LocationDetection();
                    Thread.Sleep(list[i].timeSpan);  
                }
                Console.Clear();
            }
        }
        public static void LocationDetection()
        {
            for (int i = 0; i < list.Count; i++)
            {                
                switch (list[i].location)
                {
                    case "Top":
                        Console.SetCursorPosition(26 - list[i].text.Length, 1); //26 = ширина рамки + 2(границы) / 2  
                        Console.ForegroundColor = list[i].color;
                        Console.WriteLine(list[i].text);
                        break;
                    case "Bottom":
                        Console.SetCursorPosition(26 - list[i].text.Length, 15);
                        Console.ForegroundColor = list[i].color;
                        Console.WriteLine(list[i].text);                                               
                        break;
                    case "Left":
                        Console.SetCursorPosition(51 - list[i].text.Length, 8);
                        Console.ForegroundColor = list[i].color;
                        Console.WriteLine(list[i].text);                        
                        break;
                    case "Right":
                        Console.SetCursorPosition(1, 8);
                        Console.ForegroundColor = list[i].color;
                        Console.WriteLine(list[i].text);
                        break;
                    case null:
                        if (list[i].text.Length < 26)
                        {
                            Console.SetCursorPosition(26 - list[i].text.Length, 15);
                            Console.ForegroundColor = list[i].color;
                            Console.WriteLine(list[i].text);
                        }
                        else
                        {
                            Console.SetCursorPosition((52 - list[i].text.Length) / 2, 15);
                            Console.ForegroundColor = list[i].color;
                            Console.WriteLine(list[i].text);
                        }
                        break;
                }               
            } 
        }
        
       //public static ConsoleColor ColorIt()
       //{
       //    ConsoleColor color = default;
       //    for (int i = 0; i < list.Count; i++)
       //    {                
       //        switch (list[i].color)
       //        {
       //            case (ConsoleColor.Red):
       //                color = ConsoleColor.Red;
       //                break;
       //            case (ConsoleColor.Green):
       //                color = ConsoleColor.Green;
       //                break;
       //            case (ConsoleColor.Blue):
       //                color = ConsoleColor.Blue;
       //                break;
       //            case (ConsoleColor.Black):
       //                color = ConsoleColor.White;
       //                break;
       //        }                    
       //    }
       //    return color;
       //}       
    }
    
    
}
