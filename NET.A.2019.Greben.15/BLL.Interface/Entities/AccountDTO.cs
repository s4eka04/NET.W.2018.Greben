using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class AccountDTO
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int  Id { get;  set; }

        /// <summary>
        /// Property Name
        /// </summary>
        public string FirstName { get;  set; }

        /// <summary>
        /// Property Last Name
        /// </summary>
        public string LastName { get;  set; }

        /// <summary>
        /// Propectry Money
        /// </summary>
        public MoneyDTO MoneyDTO { get; set; }

        /// <summary>
        /// Property Account Type
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public  AccountDTO()
        {
            MoneyDTO = new MoneyDTO();
        }

        /// <summary>
        /// Ovveride ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "Account #" + Id + "\nName: " + FirstName + "\n Last Name: " + LastName + "\nSun on Account: " + MoneyDTO.Sum + "\nDiscount: " + MoneyDTO.Discount + "\n" + "Type: " + AccountType + "\n";
            return str;
        }

    }
}
