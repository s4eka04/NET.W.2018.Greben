using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    public interface IAccountRepository 
    {
        void Create(Account account);

        void Close(Account account);

        Account Get(int Id);

        IEnumerable<Account> GetAllAccounts();
    }
}
