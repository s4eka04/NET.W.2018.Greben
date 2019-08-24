using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Abstract
{
    public interface IRepositoryAccount
    {
        Account CreateAccount();
        void CloseAccount(int id);
        void Show();
        Account GetAccount();
        void WithDrawMoney(Account account);
        void PutMoney(Account account);

    }
}
