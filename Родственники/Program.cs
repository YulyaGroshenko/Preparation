using System;
using System.IO;
using System.Collections.Generic;

namespace Родственники
{
    class Person
    {
        public int id;
        public string firstName;
        public string lastName;
        public string birthDate;
        public bool parent = false;

    }
    class Program
    {
        static string[] line = File.ReadAllLines(@"C:\Users\Юля\Desktop\File.txt");
        static List<Person> people = new List<Person>();

        static void Main()
        {
            SortOfPeople();
            Console.Write("Введите ФИ или ID 1-ого человека: ");
            var fisrt = Console.ReadLine();
            Console.Write("Введите ФИ или ID 2-ого человека: ");
            var second = Console.ReadLine();

        }
        static void SortOfPeople()
        {
            string[] instruction = line[0].Split(";");
            int num = 0;
            for (int i = 1; !string.IsNullOrWhiteSpace(line[i]); i++)
            {
                string[] dataString = line[i].Split(";");
                Person person = new Person();
                
                for (int k = 0; k < 4; k++) 
                {
                    switch (instruction[k])
                    {
                        case ("Id"):
                            person.id = Convert.ToInt32(dataString[k]);
                            break;
                        case ("FirstName"):
                            person.firstName = dataString[k];
                            break;
                        case ("LastName"):
                            person.lastName = dataString[k];
                            break;
                        case ("BirthDate"):
                            person.birthDate = dataString[k];
                            break;
                    }
                }
                people.Add(person);
                num = i + 1;
            }

            for (int i = num; i < line.Length; i++)
            {
                string[] relationString = line[i].Split("=");
                string[] peopleId = relationString[0].Split("<->");
                int id1 = int.Parse(peopleId[0]);
                int id2 = int.Parse(peopleId[1]);
                switch (relationString[1])
                {
                    case ("spouse"):
                        people[id1 - 1].parent = true;
                        people[id2 - 1].parent = true;
                        break;
                    case ("parent"):
                        people[id1 - 1].parent = true;
                        break;
                }
            }

        }
        
        

    }
    
}
