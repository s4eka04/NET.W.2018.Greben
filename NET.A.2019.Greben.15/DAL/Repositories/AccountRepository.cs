using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// List where stored all accounts
        /// </summary>
        private List<Account> accounts = new List<Account>();

        /// <summary>
        /// Add Account to list
        /// </summary>
        /// <param name="account"></param>
        public void Create(Account account)
        {
            accounts.Add(account);
        }

        /// <summary>
        /// Remove Account from list
        /// </summary>
        /// <param name="account"></param>
        public void Close(Account account)
        {
            accounts.Remove(account);
        }

        /// <summary>
        /// Get account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Found Account </returns>
        public Account Get(int id)
        {
            return accounts.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Get All Account from List
        /// </summary>
        /// <returns> Accounts</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
