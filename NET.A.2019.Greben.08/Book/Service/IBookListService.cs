using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAT.A._2019.Greben._08.Abstract
{
    public interface IBookListService
    {
        void AddBook();
        void RemoveBook();

        List<Book> GetBooks();

        Book FindBookByTag(int id);
        Book FindBookByTag(string name, string author);

        Book FindBookByTag( string name, string author,int yearPublish);

        void SortByTag();
        void ShowList();


    }
}
