using BankAccount.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class TypeCard: ICardType
    {
        public void ChangeCardType(Account account)
        {
            if (account.SumOnAccount < 1000m)
                account.CardType = CardType.Base;
            else if (account.SumOnAccount > 1000m && account.SumOnAccount < 10000m)
                account.CardType = CardType.Gold;
            else if (account.SumOnAccount > 10000m)
                account.CardType = CardType.Platinum;
        }
    }
}
