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
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Variable 
        /// </summary>
        private IAccountRepository accountRepository;

        /// <summary>
        /// Variable
        /// </summary>
        private IMoneyRepository moneyRepository;

        /// <summary>
        /// Return implementation IMoneyRepository
        /// </summary>
        public IMoneyRepository Money
        {
            get
            {
                if(moneyRepository == null)
                {
                    moneyRepository = new MoneyRepository();
                }

                return moneyRepository;
            }
        }

        /// <summary>
        /// Return implementation IAccountRepository
        /// </summary>
        public IAccountRepository Accounts
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new AccountRepository();
                }

                return accountRepository;
            }
        }

        /// <summary>
        /// not implemented method Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose();
        }
    }
}
