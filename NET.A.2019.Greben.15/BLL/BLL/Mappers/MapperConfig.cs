using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class MapperConfig
    {
        /// <summary>
        /// member UnitOfWork pattern 
        /// </summary>
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unit"></param>
        public MapperConfig(IUnitOfWork unit)
        {
            unitOfWork =  unit;
        }

        /// <summary>
        /// Convert Account to AccountDTO
        /// </summary>
        /// <returns> List AccountDTO</returns>
        public IEnumerable<AccountDTO> CreateMapper()
        {
            IEnumerable<Account> accounts =  unitOfWork.Accounts.GetAllAccounts();

            foreach(var item in accounts)
            {
                yield return new AccountDTO()
                {   Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MoneyDTO = new MoneyDTO() { Id = item.Money.Id, Discount = item.Money.Disc, Sum = item.Money.SumOnAccount },
                    AccountType = item.AccountType
                };
            }
        }
        
    }
}
