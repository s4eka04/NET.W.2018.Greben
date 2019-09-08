using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IMoneyRepository
    {
        void Create(Money money);
        void Close(Money money);
        Money Get(int id);
        void DepositAccount(Account account, decimal sum);
        void WithdrawAccount(Account account, decimal sum);
    }
}
