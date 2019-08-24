using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Abstract;

namespace BankAccount
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string nameFile = "Account.dat";
            IRepositoryAccount repo = new RepositoryAccount(nameFile);
            int number = 0;
            Account account = new Account();

            while (true)
            {
                while (true)
                {
                    try
                    {

                        Console.Write("(1) Create account, (2) Find Account by name and last name, (3) Show accountes:");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {
                            account = repo.CreateAccount();
                            if (account == null)
                                throw new Exception(" Account not created");
                            break;
                        }
                        if (number == 2)
                        {
                            account = repo.GetAccount();
                            break;
                        }
                        if (number == 3)
                        {
                            repo.Show();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
                Console.WriteLine("*********** Welcom, " + account.Name + " **************!");
                while (true)
                {
                    try
                    {

                        Console.Write("(1) Put money, (2) Withdraw money, (3) Show my account, (4) Close account, (5) Exit: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                            repo.PutMoney(account);
                        if (number == 2)
                            repo.WithDrawMoney(account);
                        if (number == 3)
                            account.ShowAccount();
                        if (number == 4)
                        {
                            repo.CloseAccount(account.Id);
                            break;
                        }
                        if (number == 5)
                            break;


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
            }
        }

    }
}
