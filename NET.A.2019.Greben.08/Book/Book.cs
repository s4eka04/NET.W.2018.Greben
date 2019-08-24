using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAT.A._2019.Greben._08
{
    public class Book: IEquatable<Book>, IComparer<Book>
    {
        
        public int Id { get; private set; }  //  so that no one changes id
        public string Author { get; private set; }
        public string Name { get; private set; }
        public string PublishingHouse { get; private  set; }

        private int yearPublish;
        public int YearPublish
        {
            get { return yearPublish; }
            set
            {
                if (value > DateTime.Now.Year)
                    throw new Exception("Inccorect date, now is " + DateTime.Now.Year);  //The book may not be published in the future
                yearPublish = value;
            }
        }

        public int NumberOfPages { get; private set; }
        public decimal Price { get;  private set; }

        public Book()
        {

        }

        public Book(int id,string author, string name, string publish, int year, int pages, decimal price)
        {
            Id = id;
            Author = author;
            Name = name;
            PublishingHouse = publish;
            YearPublish = year;
            NumberOfPages = pages;
            Price = price;
        }
        public override string ToString()
        {
            string str = "Id: " + Id +
                "\nAuthor: " + this.Author +
                "\nName: "+this.Name +
                "\nPublishing house: " + this.PublishingHouse +
                "\nYear publish: " + this.YearPublish +
                "\nNumber of pages: " +this.NumberOfPages +
                "\nPrice: " + this.Price + '\n';
            return str;
        }

        public override int GetHashCode()
        {
            return (Int32.MaxValue - (YearPublish * NumberOfPages - Convert.ToInt32(Price))); // what came to mind
        }

        public override bool Equals(object obj) // needed to compare it with null 
        {
            if (!(obj is Book))
                return false;
            return this.Equals((Book)obj);
        }

        public static bool operator == (Book b1, Book b2)
        {
            return b1.Equals((object)b2);
        }
        

        public static bool operator != (Book b1, Book b2)
        {
            return !b1.Equals((object)b2);
        }

        public bool Equals(Book b1)
        {
            if (b1 == null || this == null)
                return false;
            if (b1.GetHashCode() != this.GetHashCode())
                return false;
            if (Object.ReferenceEquals(this, b1))
                return true;
            if (this.Id != b1.Id)
                return false;
            return true;
        }

 
        public int Compare(Book b1, Book b2)
        {
            if (b1.Id > b2.Id)
                return 1;
            if (b1.Id < b2.Id)
                return -1;
            else
                return 0;
        }
    }
}
