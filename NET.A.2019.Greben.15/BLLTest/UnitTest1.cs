using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace BllTest
{
    [TestClass]
    public class UnitTest1
    {


        Mock<IAccountService> mock = new Mock<IAccountService>();



        [TestMethod]
        public void CreateAccountsAndDepositMoneyTest()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            accounts.Add(new AccountDTO()
            {
                Id = 1,
                FirstName = "Egor",
                LastName = "Greben",
                AccountType = AccountType.Base,
                MoneyDTO = new MoneyDTO() { Id = 1, Sum = 0, Discount = 0 }
            });

            accounts.Add(new AccountDTO()
            {
                Id = 2,
                FirstName = "Vlad",
                LastName = "Greben",
                AccountType = AccountType.Base,
                MoneyDTO = new MoneyDTO() { Id = 2, Sum = 0, Discount = 0 }
            });





            mock.Setup(a => a.GetAccount(It.IsAny<int>())).Returns<int>( a => accounts[a - 1]);
            mock.Setup(a => a.DepositAccount(It.IsAny<int>(), It.IsAny<decimal>())).
                    Callback<int, decimal>((id, sum) =>
                    {
                        accounts[id - 1].MoneyDTO.Sum += sum;
                        accounts[id - 1].MoneyDTO.Discount = (accounts[id - 1].MoneyDTO.Sum / 50m);
                    });
            
            IAccountService accountService = mock.Object;

            Assert.AreEqual(accountService.GetAccount(1).FirstName, "Egor");

            accountService.DepositAccount(1, 100m);
            Assert.AreEqual(accountService.GetAccount(1).MoneyDTO.Sum, 100m );
            Assert.AreEqual(accountService.GetAccount(1).MoneyDTO.Discount, 2m);

            accountService.DepositAccount(1, 100m);
            Assert.AreEqual(accountService.GetAccount(1).MoneyDTO.Sum, 200m);
            Assert.AreEqual(accountService.GetAccount(1).MoneyDTO.Discount, 4m);


        }

    }
}
