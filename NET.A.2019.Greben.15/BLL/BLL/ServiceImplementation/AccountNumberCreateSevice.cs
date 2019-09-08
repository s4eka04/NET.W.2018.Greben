using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreateSevice : IAccountNumberCreateSevice
    {
        /// <summary>
        /// Static Id Account
        /// </summary>
        private static int Id = 0;

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="type"></param>
        /// <param name="sum"></param>
        /// <returns>Created Account</returns>
        public Account CreateAccount(string desc, AccountType type, decimal sum = 0)
        {
            Console.WriteLine(desc);

            Console.WriteLine("Enter your name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your lastname: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();
            Id++;

            Money money = new Money(Id, sum);
            Account account = new Account(Id, desc, firstName, lastName, type, money);

            return account;
        }
    }
}
