using BankAccount.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public enum CardType
    {
        Base = 2,
        Gold,
        Platinum
    }
    public class Account
    {
        private IBonusLogic bonusLogic = new BonusLogik();   // to further change the calculation of bonuses
        private ICardType cardType = new TypeCard();       // and type of card


        //fields
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private  set; }
        public int Bonuses { get; private set; }
        public decimal SumOnAccount { get;private set; }
        public CardType CardType;


        //constructors
        public Account()
        {

        }
        public Account(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            CardType = CardType.Base;
        }
        public Account(int id, string name, string lastName, decimal sumOnAccount): this(id, name,lastName)
        {
            
            SumOnAccount = sumOnAccount;
            CheckCard();
            PutBonuses(SumOnAccount);
        }
        public Account(int id, string name, string lastName, int bonus, decimal sum, CardType card) 
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Bonuses = bonus;
            SumOnAccount = sum;
            CardType = card;
        }

        // methods for working with an account
        private void WithdrawBonuses(decimal sum)
        {
            Bonuses -= bonusLogic.CalсulateBonus(this, sum);
            if (Bonuses < 0)
                Bonuses = 0;
        }
        private void PutBonuses(decimal sum)
        {
            Bonuses += bonusLogic.CalсulateBonus(this, sum);
        }
        public void Withdraw()
        {
            Console.Write("Enter sum which you want to withdraw:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            if (sum > SumOnAccount)
                throw new Exception("Not enough money in the account!");
            else
            {
                SumOnAccount -= sum + (Bonuses / 10);
                WithdrawBonuses(sum);
                cardType.ChangeCardType(this);
                Console.WriteLine("You withdrawed: " + sum);
            }

        }
        public void Put()
        {
            Console.Write("Enter sum which you want to put:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            SumOnAccount += sum +(Bonuses/10);
            PutBonuses(sum);
            Console.WriteLine("You put: " + sum);
            cardType.ChangeCardType(this);
        }
        public override string ToString()
        {
            string str = "\nId: " + Id + "\nName: " + Name + "\nLast Name: " + LastName + "\nBonus: " + Bonuses + "\nSum on account: " + SumOnAccount + "\nCard: " + CardType;
            return str;
        }
        public void ShowAccount()
        {
            Console.WriteLine(this);
        }
       
    }
}
