using FIleCabinet.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleCabinet.Abstract
{
    public interface IPersonRepository
    {
        void Create();
        List<Person> List();
        int State();

        void Edit(Person person);

        Person Find( string firstName);

        void ExportXml(string path);
        void ExportCSV(string path);

        List<Person> ImportXml(string pathToXmlFile);
        List<Person> ImportCSV(string pathToXmlFile);
        void RemoveById(int id);

        void AddAllPersonToMemory(List<Person> persons);
        void Purge();
    }
}
