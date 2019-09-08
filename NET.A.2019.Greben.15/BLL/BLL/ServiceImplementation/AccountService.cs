using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        /// <summary>
        /// Member UnitOfWork pattern
        /// </summary>
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Constructor Without params
        /// </summary>
        public AccountService()
        {

        }

        /// <summary>
        /// Initialization variable
        /// </summary>
        /// <param name="unitOfWork"></param>
        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Use mapper for conver our Accounts to AccountDTo
        /// </summary>
        /// <returns> List AccountDTO</returns>
        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Account>, List<AccountDTO>>(unitOfWork.Accounts.GetAllAccounts());
            MapperConfig mapperConfiguration = new MapperConfig(unitOfWork);
            return mapperConfiguration.CreateMapper();

        }

        /// <summary>
        /// Find Money By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MoneyDTO with same Id</returns>
        public MoneyDTO GetMoney(int id)
        {
            Money money = unitOfWork.Money.Get(id);
            if (money == null)
            {
                throw new Exception(" Money not found");
            }

            return new MoneyDTO() { Id = money.Id, Sum = money.SumOnAccount, Discount = money.Disc };

        }

        /// <summary>
        /// Find Account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AccountDTO with same id</returns>
        public AccountDTO GetAccount(int id)
        {
            Account account = unitOfWork.Accounts.Get(id);
            if(account == null)
            {
                throw new Exception("account not found");
            }

            return new AccountDTO() {
                            FirstName = account.FirstName,
                            Id = account.Id,
                            LastName = account.LastName,
                            MoneyDTO = new MoneyDTO() {Id = account.Id, Discount = account.Money.Disc, Sum = account.Money.SumOnAccount }
                                    };
        }


        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="accountType"></param>
        /// <param name="accountNumberCreate"></param>
        public void OpenAccount(string desc, AccountType accountType, IAccountNumberCreateSevice accountNumberCreate)
        {
           unitOfWork.Accounts.Create(accountNumberCreate.CreateAccount(desc, accountType));

        }

        /// <summary>
        /// Withdraw from Account 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void WithdrawAccount(int id, decimal sum)
        {
            unitOfWork.Money.WithdrawAccount(unitOfWork.Accounts.Get(id), sum);
        }

        /// <summary>
        /// Deposit to Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void DepositAccount(int id, decimal sum)
        {
            unitOfWork.Money.DepositAccount(unitOfWork.Accounts.Get(id), sum);
        }


    }
}
