using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Money
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Property sum on Account
        /// </summary>

        private decimal sumOnAccount;

        /// <summary>
        /// Check Sum
        /// </summary>
        public decimal SumOnAccount
        {
            get { return sumOnAccount; }
            private set
            {
                if (value < 0)
                {
                    sumOnAccount = 0;
                }

                sumOnAccount = value;
            }
        }
        
        /// <summary>
        /// Property Discount
        /// </summary>
        public decimal Disc { get;  set; }

        /// <summary>
        /// Consctructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public Money(int id, decimal sum)
        {
            Id = id;
            SumOnAccount = sum;
            Setdiscount();
        }

        /// <summary>
        /// Deposit sum On Account
        /// </summary>
        /// <param name="sum"></param>
        public void AddSum(decimal sum)
        {
            SumOnAccount += sum;
            Setdiscount();
        }

        /// <summary>
        /// Withdraw sum from Account
        /// </summary>
        /// <param name="sum"></param>
        public void DrawSum(decimal sum)
        {
            SumOnAccount = SumOnAccount - sum + Disc;
        }

        /// <summary>
        /// Set Discount
        /// </summary>
        public void Setdiscount()
        {
            Disc = Discount.SetDiscount(SumOnAccount);
        }
    }
}
