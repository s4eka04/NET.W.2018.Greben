using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Enum Account Type
    /// </summary>
    public enum AccountType
    {
        Base = 1,
        Gold,
        Silver
    }
    public class Account
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Property Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Property Name
        /// </summary>
        public string  FirstName { get; private set; }

        /// <summary>
        /// Property Last name
        /// </summary>
        public string  LastName { get; private set; }


        /// <summary>
        /// Property Money On Account
        /// </summary>
        public Money Money { get; private set; }

        /// <summary>
        /// Property Account Type
        /// </summary>
        public AccountType AccountType { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="type"></param>
        /// <param name="money"></param>
        public Account(int id, string number, string name, string lastName, AccountType type, Money money)
        {
            Id = id;
            Description = number;
            FirstName = name;
            LastName = lastName;
            AccountType = type;
            Money = money;
        }
    }
}
