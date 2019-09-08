using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        /// <summary>
        /// List where stored all Money
        /// </summary>
        List<Money> monies = new List<Money>();

        /// <summary>
        /// Property Money
        /// </summary>
        public Money Money { get; private set; }

        /// <summary>
        /// Add Money to List
        /// </summary>
        /// <param name="money"></param>
        public void Create(Money money)
        {
            monies.Add(money);
        }

        /// <summary>
        /// Remove money from List
        /// </summary>
        /// <param name="money"></param>
        public void Close(Money money)
        {
            monies.Remove(money);
        }

        /// <summary>
        /// Get Money by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>found Money</returns>
        public Money Get(int id)
        {
            return monies.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Deposit money to Account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="sum"></param>
        public void DepositAccount(Account account, decimal sum)
        {
            account.Money.AddSum(sum);
        }

        /// <summary>
        /// Withdraw money from Account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="sum"></param>
        public void WithdrawAccount(Account account, decimal sum)
        {
            account.Money.DrawSum(sum);
        }
    }
}
