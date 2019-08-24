using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAT.A._2019.Greben._08.Abstract;

namespace NAT.A._2019.Greben._08.Service
{
    public class BookListService : IBookListService
    {

        string pathToFile ;
        List<Book> books;
        public BookListService(string path)
        {
            pathToFile = path;
            FileInfo f = new FileInfo(pathToFile);
            using(BinaryWriter bw = new BinaryWriter(f.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))) { }
            books = GetBooks();
            
        }
        public void AddBook()
        {

            FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price);
            if (CheckBookInList(author, name, house, year, pages, price))
                throw new Exception("A book with such characteristics exists");

             // id is counted from the last book in the file
            FileInfo f = new FileInfo(pathToFile);
            int id = 1;
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Append,
                        FileAccess.Write, FileShare.None)))
            {
               
                if (books.Count != 0)
                    id = books.LastOrDefault().Id + 1;
                bw.Write(id);
                bw.Write(author);
                bw.Write(name);
                bw.Write(house);
                bw.Write(year);
                bw.Write(pages);
                bw.Write(price);
            }
            Book book = new Book(id, author, name, house, year, pages, price);
            books.Add(book);
            Console.WriteLine("The book created");
        }

        public void RemoveBook()
        {
            FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price);

            if (CheckBookInList(author, name, house, year, pages, price))
            {
                List<Book> bs = new List<Book>();

                foreach (var book in books)
                {
                    if (author == book.Author && name == book.Name &&
                       house == book.PublishingHouse && year == book.YearPublish &&
                       pages == book.NumberOfPages && price == book.Price)
                    {
                        books.Remove(book);
                        Console.WriteLine("The book has been deleted");
                        break;

                    }
                }
                FileInfo f = new FileInfo(pathToFile);
                using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Truncate,
                       FileAccess.Write, FileShare.None)))
                {

                    foreach (var book in books)
                    {
                    bs.Add(book);
                    
                   
                        bw.Write(book.Id);
                        bw.Write(book.Author);
                        bw.Write(book.Name);
                        bw.Write(book.PublishingHouse);
                        bw.Write(book.YearPublish);
                        bw.Write(book.NumberOfPages);
                        bw.Write(book.Price);
                    }
                }
                books = bs;
            }
            else
            {
                throw new Exception("A book this such characteristics not found");
            }
           

        }

        private bool CheckBookInList(string author, string name, string house, int year, int pages, decimal price)
        {
            foreach (var book in books)
            {
                if (author == book.Author && name == book.Name &&
                   house == book.PublishingHouse && year == book.YearPublish &&
                   pages == book.NumberOfPages && price == book.Price)
                {
                    return true;
                }
            }

            return false;
        }
        private void FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price)
        {
           // Console.WriteLine("Creating the book:");
            Console.Write("Author: ");
            author = Console.ReadLine();
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Publishing house: ");
            house = Console.ReadLine();
            Console.Write("Year of publish: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of pages: ");
            pages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            price = Convert.ToDecimal(Console.ReadLine());
        }

        public Book FindBookByTag(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    Console.WriteLine(book);
                    return book;
                }
            }

            throw new Exception("Book not found");
        }

        public Book FindBookByTag(string name, string author)
        {
            foreach (var book in books)
            {
                if (book.Name == name && book.Author == author)
                {
                    Console.WriteLine(book);
                    return book;
                }
            }

            throw new Exception("Book not found");
        }

        public Book FindBookByTag(string name, string author, int yearPublish)
        {
            foreach (var book in books)
            {
                if (book.Name == name && book.Author == author && book.YearPublish == yearPublish)
                {
                    Console.WriteLine(book);
                    return book;
                }
            }

            throw new Exception("Book not found");
        }
       
        public void ShowList()
        {
            foreach(var b in books)
            {
                Console.WriteLine(b);
            }
            if (books.Count == 0)
                Console.WriteLine("List empry !");
        }


        public void SortByTag()
        {

            
            IEnumerable<Book> sortedBook = new  List<Book>();
            Console.Write("Sort by: (1) Id, (2)Name," +
                " (3) Author, (4) Publishing house," +
                " (5) Year of publish," +
                " (6) Number of pages, (7) Price:  ");
            int tag = Convert.ToInt32(Console.ReadLine()); // auxiliary variable to understand how to sort
            Console.WriteLine();
            if (tag == 1)
            {
                sortedBook = from b in books
                             orderby b.Id
                             select b;
            }
            if (tag == 2)
            {
                sortedBook = from b in books
                             orderby b.Name
                             select b;
            }
            if (tag == 3)
            {
                sortedBook = from b in books
                             orderby b.Author
                             select b;
            }
            if (tag == 4)
            {
                sortedBook = from b in books
                             orderby b.PublishingHouse
                             select b;
            }
            if (tag == 5)
            {
                sortedBook = from b in books
                             orderby b.YearPublish
                             select b;
            }
            if (tag == 6)
            {
                sortedBook = from b in books
                             orderby b.NumberOfPages
                             select b;
            }
            if (tag == 7)
            {
                sortedBook = from b in books
                             orderby b.Price
                             select b;
            }

            books = sortedBook.ToList();  //    insert instead of the existing list, the sorted
            Console.WriteLine("Books are sorted !");
        }
        public List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>();
            FileInfo f = new FileInfo(pathToFile);
            using(BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                
                while(br.PeekChar() > -1)
                {
                    int id = br.ReadInt32();
                    string author = br.ReadString();
                    string name = br.ReadString();
                    string house = br.ReadString();
                    int year = br.ReadInt32();
                    int pages = br.ReadInt32();
                    decimal price = br.ReadDecimal();
                    Books.Add(new Book(id, author, name, house, year, pages, price));
                }
            }
            return Books;
        }
    }
}
