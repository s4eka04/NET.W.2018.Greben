using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class MoneyDTO
    {
        /// <summary>
        /// Propetry  Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property Sum On Account
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Property Discount 
        /// </summary>
        public decimal Discount { get; set; }
    }
}
