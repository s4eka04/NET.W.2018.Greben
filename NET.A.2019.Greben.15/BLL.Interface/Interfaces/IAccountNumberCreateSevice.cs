using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountNumberCreateSevice
    {
        Account CreateAccount(string decs, AccountType account,decimal sum = 0 );
    }
}
