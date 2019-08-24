using FIleCabinet.Abstract;
using FIleCabinet.Concret;
using FIleCabinet.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FIleCabinet
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToTextFile = @"C:\Users\s4eka\source\repos\FileCabinet\FIleCabinet\TextFiles\persons.txt";
            string pathToXmlFile = @"C:\Users\s4eka\source\repos\FileCabinet\FIleCabinet\CSVandXMLFiles\persons.xml";
            string pathToCSVFile = @"C:\Users\s4eka\source\repos\FileCabinet\FIleCabinet\CSVandXMLFiles\persons.csv";

            IPersonRepository repository;

            repository = BeginProgramm(pathToTextFile);
            while (repository != null)  
            {
                Console.Write("(1)CreatePerson, (2)ListOfPersons, (3)Stat," +
                    " (4)FindPerson, (5)EditPerson, (6)ExportToCSV, (7)ExportToXML," +
                    "(8) ImportFromXML, (9) ImportFromCSV, (10) Remove by id, (11)Purge, (12)Clear Console, (13) Back: ");
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    if (number == 1)
                        repository.Create();
                    else if (number == 2)
                    {
                        try
                        {
                            ShowListOfPersons(repository.List());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (number == 3)
                        Console.WriteLine("State: " + repository.State() + " records");
                    else if (number == 4)
                    {
                        Console.Write("Enter first name to the finding:");
                        string firstName = Console.ReadLine();

                        Person p = repository.Find(firstName);
                        if (p == null)
                            Console.WriteLine("Person not found");
                        else
                            Console.WriteLine(p);
                    }
                    else if (number == 5)
                    {
                        Console.Write("Edit № (total persons: " + repository.State() + ") : ");
                        if (Int32.TryParse(Console.ReadLine(), out int numberId))
                        {
                            foreach (var p in repository.List())
                            {
                                if (p.IdPerson == numberId)
                                {
                                    repository.Edit(p);
                                    numberId = 0;
                                }
                            }
                            if (numberId != 0)
                                Console.WriteLine("Person with this is Id not found");

                        }
                    }
                    else if (number == 6)
                    {
                        try
                        {
                            repository.ExportCSV(pathToCSVFile);
                            Console.WriteLine("Write to file completion successfully");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                    else if (number == 7)
                    {
                        try
                        {
                            repository.ExportXml(pathToXmlFile);
                            Console.WriteLine("Write to file completion successfully");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                    else if (number == 8)
                    {
                        try
                        {
                            List<Person> persons = repository.ImportXml(pathToXmlFile);
                            repository.AddAllPersonToMemory(persons);
                            Console.WriteLine("Show read date?(y/n):");
                            string answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y")
                                ShowListOfPersons(persons);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (number == 9)
                    {
                        try
                        {
                            List<Person> persons = repository.ImportCSV(pathToCSVFile);
                            repository.AddAllPersonToMemory(persons);
                            Console.WriteLine("Show read date?(y/n):");
                            string answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y")
                                ShowListOfPersons(persons);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (number == 10)
                    {
                        try
                        {
                            Console.WriteLine("Enter id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            repository.RemoveById(id);                
                                
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if(number == 11)
                    {
                        try
                        {
                            repository.Purge();
                            Console.WriteLine("Done");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (number == 12)
                        Console.Clear();
                    else if (number == 13)
                        repository = BeginProgramm(pathToTextFile);
                }
            }

        }


        static void DisplayInfoAboutPersons(List<Person> persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine("#" + item.IdPerson + ", " + item.FirstName + ", " + item.LastName + '\n');
            }
        }

        static IPersonRepository BeginProgramm(string pathToTextFile)
        {
            try
            {
                Console.Write("Choose what to use(enter number): (1)list or (2)file and if you want to exit(3): ");
                if (Int32.TryParse(Console.ReadLine(), out int inputNumber))
                {
                    if (inputNumber == 1)
                        return new PersonRepositoryUsingMemory();
                    else if (inputNumber == 2)
                        return new PersonRepositoryUsingFile(pathToTextFile);
                    else if (inputNumber == 3)
                        return null;
                }
                else
                {
                    throw new Exception("Incorrectly entered value");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return null;
        }
        static void ShowListOfPersons(List<Person> persons)
        {
            if (persons == null || persons.Count == 0)
                throw new Exception("List empty !");
            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }
        }

      
    }
}
