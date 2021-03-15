using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int command;
            bool working = true;
            while(working)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Choose command:\n" +
                    "1 -> Create\n" +
                    "2 -> Read\n" +
                    "3 -> Update\n" +
                    "4 -> Delete\n" +
                    "0 -> Exit");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out command);
                switch(command)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Create");
                            Console.ResetColor();
                            using (PersonContext db = new PersonContext())
                            {
                                Console.Write("Name: ");  string name = Console.ReadLine();
                                Console.Write("City: "); string city = Console.ReadLine();
                                Console.Write("Age: "); int age = Convert.ToInt32(Console.ReadLine());
                                PersonDatum person = new PersonDatum { Name = name, City = city, Age = age };
                                db.PersonData.Add(person);
                                db.SaveChanges();
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Read");
                            Console.ResetColor();
                            using (PersonContext db = new PersonContext())
                            {
                                var person = db.PersonData.ToList();
                                Console.WriteLine("Данные после добавления:");
                                foreach (PersonDatum p in person)
                                {
                                    Console.WriteLine($"{p.Id}.{p.Name}, - {p.City} - {p.Age}");
                                }
                            }

                        }
                        break;
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Update");
                            Console.ResetColor();
                            using (PersonContext db = new PersonContext())
                            {
                                Console.Write("Id:");
                                int id = int.Parse(Console.ReadLine());
                                PersonDatum personDatum = db.PersonData.Find(id);
                                if (personDatum != null)
                                {
                                    Console.Write("Name: "); string name = Console.ReadLine();
                                    Console.Write("City: "); string city = Console.ReadLine();
                                    Console.Write("Age: "); int age = Convert.ToInt32(Console.ReadLine());
                                    personDatum.Name = name;
                                    personDatum.City = city;
                                    personDatum.Age = age;
                                    db.SaveChanges();
                                }
                                Console.WriteLine("\nДанные после редактирования:");
                                var person = db.PersonData.ToList();
                                foreach (PersonDatum p in person)
                                {
                                    Console.WriteLine($"{p.Id}.{p.Name} - {p.City} - {p.Age}");
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Delete");
                            Console.ResetColor();
                            using (PersonContext db = new PersonContext())
                            {
                                Console.Write("Id = "); int id = Convert.ToInt32(Console.ReadLine());

                                PersonDatum person = db.PersonData.Find(id);
                                if (person != null)
                                {
                                    db.PersonData.Remove(person);
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (System.Exception ex)
                                    {
                                        System.Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        }
                        break;
                    case 0:
                        {
                            working = false;
                        }
                        break;
                }

            }
        }
    }
}
