using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAT.A._2019.Greben._08.Abstract;
using NAT.A._2019.Greben._08.Service;



namespace NAT.A._2019.Greben._08
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookListService service = new BookListService("file1.dat");
            while(true)
            {
                try
                {
                    int number = 0;
                    Console.Write("(1)Add Book, (2) Remove Book, (3)Show Books, (4)Find Book, (5)Sort by tag:    ");
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (number == 1)
                        service.AddBook();
                    if (number == 2)
                        service.RemoveBook();
                    if(number == 3)
                    {
                        service.ShowList();
                    }

                    if(number == 4)
                    {
                        Console.Write("(1)Find by Id, (2) Find by Name and Author name," +
                            " (3) Find by  Name and Author name and year of publish:   ");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {
                            Console.Write("Enter Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            service.FindBookByTag(id);
                        }
                        if(number == 2)
                        {
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Author name: ");
                            string author = Console.ReadLine();
                            service.FindBookByTag(name, author);
                        }
                        if(number == 3)
                        {
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Author name: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter year of publish: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            service.FindBookByTag(name, author, year);
                        }
                    }
                    if (number == 5)
                        service.SortByTag();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            
        }

       
    }
}
