using FIleCabinet.Abstract;
using FIleCabinet.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FIleCabinet.Concret
{
    public class PersonRepositoryUsingMemory : IPersonRepository
    {
        private List<Person> persons;

        public PersonRepositoryUsingMemory()
        {
            persons = new List<Person>();
        }
        public void Create()
        {
 
            Person creatingPerson = new Person(State());
            FillInTheInformation(creatingPerson);
            if (creatingPerson == null)
            {
                Console.WriteLine("Record isn't created");
            }
            else
            {
                persons.Add(creatingPerson);
                Console.WriteLine("Record №" + creatingPerson.IdPerson + " is created");
            }

            Console.WriteLine();
        }

        public List<Person> List()
        {
            if (persons.Count != 0)
                return persons;
            else
                return null;
        }

        public int State()
        {
            return persons.Count;
        }

        public void Edit(Person person)
        {
            Console.WriteLine("Person editing №" + person.IdPerson);
            FillInTheInformation(person);
        }

        public Person Find(string firstName)
        {
            foreach (var item in persons)
            {
                if (firstName.ToUpper() == item.FirstName.ToUpper())
                    return item;
            }
            return null;
        }

        private void FillInTheInformation(Person person)
        {
           
            if (person == null)
                return;
           
                Console.Write("First Name: ");
                person.FirstName  = Console.ReadLine();
          
            
                Console.Write("Last Name: ");
                person.LastName = Console.ReadLine();
               
            while (true)
            {
                try
                {

                    Console.Write("Date of birth(month/day/year): ");
                    person.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                    if (person.DateOfBirth.Year >= DateTime.Now.Year ||
                        person.DateOfBirth.Year <= DateTime.Now.Year - 100)
                    {
                        throw new Exception("Incorrect year, please try again, now is " + DateTime.Now.Year);
                    }
                    break;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            }
        }

        public void ExportXml(string path)
        {
            try
            {

                using (FileStream fs = new FileStream(path, FileMode.Truncate))
                {
                    XDocument xDoc = new XDocument();



                    XElement personsElem = new XElement("persons");



                    foreach (var p in persons)
                    {
                        XElement elem = new XElement("person");
                        XElement id = new XElement("idPerson", p.IdPerson.ToString());
                        XElement firstName = new XElement("firstName", p.FirstName);
                        XElement lastName = new XElement("lastName", p.LastName);
                        XElement date = new XElement("dateOfBirth", p.DateOfBirth.ToString());

                        elem.Add(id, firstName, lastName, date);

                        personsElem.Add(elem);

                    }

                    xDoc.Add(personsElem);
                    xDoc.Save(fs);
                    fs.Flush();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ExportCSV(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var p in persons)
                    {
                        string stringOnFIle = p.IdPerson.ToString() + "," +
                                              p.FirstName.ToString() + "," +
                                              p.LastName.ToString() + "," +
                                              p.DateOfBirth.ToString();

                        sw.WriteLine(stringOnFIle);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Person> ImportXml(string pathToXmlFile)
        {
            List<Person> people = new List<Person>();

            XDocument xdoc = XDocument.Load(pathToXmlFile);
            foreach (XElement element in xdoc.Element("persons").Elements("person"))
            {
                XElement id = element.Element("idPerson");
                XElement firstName = element.Element("firstName");
                XElement lastName = element.Element("lastName");
                XElement date = element.Element("dateOfBirth");

                if (id == null || firstName == null || lastName == null || date == null)
                    throw new Exception("Uncorrect data import");
                people.Add(new Person(Convert.ToInt32(id.Value), firstName.Value, lastName.Value, Convert.ToDateTime(date.Value)));

            }

            return people;
        }

        public List<Person> ImportCSV(string pathToCSVFile)
        {
            List<Person> persons = new List<Person>();
            using (StreamReader sr = new StreamReader(pathToCSVFile, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitString = line.Split(',');
                    if (splitString.Length != 4)         //number of fields in class
                        throw new Exception("Incorrect reading dile");
                    int id = Convert.ToInt32(splitString[0]);
                    string name = splitString[1];
                    string lastName = splitString[2];
                    DateTime date = Convert.ToDateTime(splitString[3]);

                    persons.Add(new Person(id, name, lastName, date));
                }

               
            }

            return persons;
        }

        public void RemoveById(int id)
        {
            int checkId = 0;
            foreach(var p in persons)
            {
                if(p.IdPerson == id)
                {
                    checkId = p.IdPerson;
                    persons.Remove(p);
                    break;
                    
                    
                }
            }

            if (checkId != 0)
            {
                ReWrittingList(persons);
                Console.WriteLine("Record №" + checkId + " is removed");
            }
            else
                Console.WriteLine("Person whith №" + id + " not found");


        }

        public void AddAllPersonToMemory(List<Person> persons)
        {
            this.persons = persons;
        }

        private void ReWrittingList(List<Person> people)
        {
            List<Person> pers = new List<Person>();
            int id = 1;
            foreach(var p in people)
            {
                pers.Add(new Person(id++, p.FirstName, p.LastName, p.DateOfBirth));
                
            }

            persons = pers;
        }

        public void Purge()
        {
           persons = new List<Person>();

        }
    }
}
