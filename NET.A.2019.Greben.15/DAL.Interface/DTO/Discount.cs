using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public static class Discount
    {
      /// <summary>
      /// Get Discount from Sum
      /// </summary>
      /// <param name="sum"></param>
      /// <returns></returns>
        public static decimal SetDiscount(decimal sum)
        {
           return (sum / 50m); // discount 2%
        }
    }
}
