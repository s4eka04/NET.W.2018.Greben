using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService 
    {
        void OpenAccount(string Description, AccountType type, IAccountNumberCreateSevice creater);

        IEnumerable<AccountDTO> GetAllAccounts();
        MoneyDTO GetMoney(int id);

        void DepositAccount(int id, decimal sum);

        void WithdrawAccount(int id, decimal sum);

        AccountDTO GetAccount(int id);
       
    }
}
