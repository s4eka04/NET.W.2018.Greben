using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleCabinet.Entites
{
    public class Person
    {
      //  private static int Id { get; set; }

        public int IdPerson { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person(int id, string firstName, string lastName, DateTime dateTime)
        {
            IdPerson = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateTime;

        }
        public Person(int count)
        {
            IdPerson = ++count;
        }
        public override string ToString()
        {
   
            return "Person №: " + IdPerson + "\nFirst Name: " +
                    FirstName + "\nLast Name: " + LastName + "\nDate of Birth: " + DateOfBirth.Day + '/' +
                    DateOfBirth.Month + '/' + DateOfBirth.Year + '\n';
        }
    }
}
