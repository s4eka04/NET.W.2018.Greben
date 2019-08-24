using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Abstract;
namespace BankAccount
{
    public class RepositoryAccount : IRepositoryAccount
    {
        string pathToFile;

        //the list is needed for temporary storage and change,
        //so as not to read from the file every time because 
        //it is resource-intensive

        List<Account> accounts;
        public RepositoryAccount(string path)
        {
            pathToFile = path;
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))) { }
            accounts = GetAccounts();
        }
        public Account CreateAccount()
        {
            Account acc;
            Console.WriteLine("Creating Account: ");
            Console.Write("Do you have start-up capital? (y/n): ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                FillNameAndLastName(out string name, out string lastName);
                if (CheckOwnerAccount(name, lastName))
                    throw new Exception("Account with such owner exist!");
                Console.Write("Enter start-up capital: ");
                decimal sum = Convert.ToDecimal(Console.ReadLine());
                FileInfo f = new FileInfo(pathToFile);
                int id = 1;
                if (accounts.Count != 0)
                    id = accounts.LastOrDefault().Id + 1;
                acc = new Account(id, name, lastName, sum);
                using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Append,
                            FileAccess.Write, FileShare.None)))
                {
                    
                    bw.Write(acc.Id);
                    bw.Write(acc.Name);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Bonuses);
                    bw.Write(acc.SumOnAccount);
                    bw.Write((int)acc.CardType);
                }
                
                accounts.Add(acc);
                return acc;
            }
            else if (answer == "N")
            {
                FillNameAndLastName(out string name, out string lastName);
                if (CheckOwnerAccount(name, lastName))
                    throw new Exception("Account with such owner exist!");
                FileInfo f = new FileInfo(pathToFile);
                int id = 1;
                if (accounts.Count != 0)
                    id = accounts.LastOrDefault().Id + 1;
                acc = new Account(id, name, lastName);
                using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Append,
                            FileAccess.Write, FileShare.None)))
                {
                    bw.Write(acc.Id);
                    bw.Write(acc.Name);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Bonuses);
                    bw.Write(acc.SumOnAccount);
                    bw.Write((int)acc.CardType);
                }
               
                accounts.Add(acc);
                return acc;
            }
            throw new Exception("Inccoert entered value!");
        }
        public void CloseAccount(int id)
        {
            accounts.Remove(GetAccountById(id));
            ReWrittingAllFile();
            Console.WriteLine("Your account has been closed!");
            
        }
        private void FillNameAndLastName(out string name, out string lastName)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();
        }

        //heck or have an account with the same name and lastname
        private bool CheckOwnerAccount(string name, string lastName)
        {
            foreach (var a in accounts)
            {
                if (a.Name.ToLower() == name.ToLower() && a.LastName.ToLower() == lastName.ToLower())
                    return true;
            }
            return false;
        }
        public Account GetAccount()
        {
            FillNameAndLastName(out string name, out string lastName);
            foreach (var a in accounts)
            {
                if (a.Name.ToLower() == name.ToLower() && a.LastName.ToLower() == lastName.ToLower())
                    return a;
            }
            throw new Exception("Account not  found") ;
        }
        private List<Account> GetAccounts()
        {
            List<Account> acc = new List<Account>();
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {

                while (br.PeekChar() > -1)
                {
                    int id = br.ReadInt32();
                    string name = br.ReadString();
                    string lastname = br.ReadString();
                    int bonus = br.ReadInt32();
                    decimal sum = br.ReadDecimal();
                    int card = br.ReadInt32();

                    acc.Add(new Account(id, name, lastname, bonus, sum, (CardType)card));
                }
            }
            return acc;
        }
        public void Show()
        {
            if (accounts.Count == 0)
                Console.WriteLine("dont have accounts");
            foreach (var a in accounts)
            {
                Console.WriteLine(a);
            }
        }
        public void WithDrawMoney(Account account)
        {
            accounts.Find(a => a.Id == account.Id).Withdraw();
            ReWrittingAllFile();
        }
        public void PutMoney(Account account)
        {
            accounts.Find(a => a.Id == account.Id).Put();
            ReWrittingAllFile();
        }

        //I overwrite the file every time I remove or put money into the account
        private void ReWrittingAllFile()
        {
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Truncate,
                   FileAccess.Write, FileShare.None)))
            {

                foreach (var acc in accounts)
                {
                    
                    bw.Write(acc.Id);
                    bw.Write(acc.Name);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Bonuses);
                    bw.Write(acc.SumOnAccount);
                    bw.Write((int)acc.CardType);
                }
            }
        }

        //since Id is different for all accounts, Id search is the most optimal
        private Account GetAccountById(int id)
        {
            foreach (var a in accounts)
            {
                if (a.Id == id)
                    return a;
            }
            throw new Exception("Account not  found");
        }
    } 
}
