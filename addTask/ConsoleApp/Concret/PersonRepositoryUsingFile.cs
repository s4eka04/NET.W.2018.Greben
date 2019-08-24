using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using FIleCabinet.Abstract;
using FIleCabinet.Entites;

namespace FIleCabinet.Concret
{
    class PersonRepositoryUsingFile : IPersonRepository
    {
        private string path;
        public PersonRepositoryUsingFile(string path)
        {
            this.path = path;
        }
        public void Create()
        {
            Person creatingPerson = new Person(State());
            FillInTheInformation(creatingPerson);

            try
            {
            

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {

                    sw.WriteLine(creatingPerson.IdPerson);
                    sw.WriteLine(creatingPerson.FirstName);
                    sw.WriteLine(creatingPerson.LastName);
                    sw.WriteLine(creatingPerson.DateOfBirth);
                }
                Console.WriteLine("Record №" + creatingPerson.IdPerson + " is created\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Record isn't created\n");
            }

            Console.WriteLine();

        }

        public List<Person> List()
        {
            return GetListPersons();
        }

        public int State()
        {
            List<Person> persons = GetListPersons();
            return persons.Count;
        }

        public void Edit(Person person)
        {
            Console.WriteLine("Person editing №" + person.IdPerson);
            FillInTheInformation(person);
            List<Person> persons = GetListPersons();
            persons[person.IdPerson - 1] = person;
            ReWrittingAllFile(persons);
            

        }

        public Person Find(string firstName)
        {
            Console.Write("Enter last name to the finding:");
            string lastName = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string _checkFirstName, _checkLastName, checkFirstName, checkLastName;
                    string id;
                    while ((id = sr.ReadLine()) != null)
                    {
                        checkFirstName = sr.ReadLine();
                        checkLastName = sr.ReadLine();
                        _checkFirstName = checkFirstName;
                        _checkLastName = checkLastName;
                        if (_checkFirstName.ToUpper() == firstName.ToUpper()
                            && _checkLastName.ToUpper() == lastName.ToUpper())
                        {
                            DateTime date = Convert.ToDateTime(sr.ReadLine());
                            Person person = new Person(Convert.ToInt32(id), checkFirstName, checkLastName, date);
                            return person;
                        }
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void ExportXml(string path)
        {

            List<Person> persons = GetListPersons();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ExportCSV(string path)
        {
            List<Person> persons = GetListPersons();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Person> ImportXml(string pathToXmlFile)
        {
           
            List<Person> persons = new List<Person>();

                XDocument xdoc = XDocument.Load(pathToXmlFile);
                foreach (XElement element in xdoc.Element("persons").Elements("person"))
                {
                    XElement id = element.Element("idPerson");
                    XElement firstName = element.Element("firstName");
                    XElement lastName = element.Element("lastName");
                    XElement date = element.Element("dateOfBirth"); 

                    if (id == null || firstName == null || lastName == null || date == null)
                        throw new Exception("Uncorrect data import");
                    persons.Add(new Person(Convert.ToInt32(id.Value), firstName.Value, lastName.Value, Convert.ToDateTime(date.Value)));

                }

            return persons;

        }
        public List<Person> ImportCSV(string path)
        {
            List<Person> persons = new List<Person>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
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
            List<Person> pers = GetListPersons();
            foreach (var p in pers)
            {
                if (p.IdPerson == id)
                {
                    checkId = p.IdPerson;
                    pers.Remove(p);
                    break;


                }
            }

            if (checkId != 0)
            {
                ReWrittingAllFile(pers);
                Console.WriteLine("Record №" + checkId + " is removed");
            }
            else
                Console.WriteLine("Person whith №" + id + " not found");

        }
        private void FillInTheInformation(Person person)
        {
            
            if (person == null)
                return;
           
            Console.Write("First Name: ");
            person.FirstName = Console.ReadLine();
                
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
        private List<Person> GetListPersons()
        {
            List<Person> persons = new List<Person>();

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int id = Convert.ToInt32(line);
                    string firstName = sr.ReadLine();
                    string LastName = sr.ReadLine();
                    DateTime date = Convert.ToDateTime(sr.ReadLine());
                    Person person = new Person(id, firstName, LastName, date);
                    persons.Add(person);
                }
            }



            return persons;
        }
        private void ReWrittingAllFile(List<Person> persons)
        {
            int id = 1;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    foreach (var p in persons)
                    {
                        sw.WriteLine(id++);
                        sw.WriteLine(p.FirstName);
                        sw.WriteLine(p.LastName);
                        sw.WriteLine(p.DateOfBirth);
                    }
                }
                Console.WriteLine("Editing try");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error writing to file");
            }
        }
        public void AddAllPersonToMemory(List<Person> persons)
        {
            ReWrittingAllFile(persons);
        }

        public void Purge()
        {
            using(StreamWriter st = new StreamWriter(path, false, Encoding.Default))
            {
                st.Write(string.Empty);
            }
        }
    }

   
}
