using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMoneyRepository Money { get; }
        IAccountRepository Accounts { get; }

    }
}
