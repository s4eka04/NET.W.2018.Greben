using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Abstract;

namespace BankAccount
{
    public class BonusLogik: IBonusLogic 
    {
        public int CalсulateBonus(Account account,decimal sum)
        {
            return ((int)sum / (10 - (int)account.CardType));
        }

         
    }
}
