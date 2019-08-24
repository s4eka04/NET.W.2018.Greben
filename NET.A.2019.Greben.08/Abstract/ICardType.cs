using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Abstract
{
    public interface ICardType
    {
        void ChangeCardType(Account account);
    }
}
