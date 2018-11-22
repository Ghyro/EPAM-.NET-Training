using System;
using BLL.BankFactory;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountTests_Moq
    {
        [Test]
        [TestCase(1, "Frank ", "Gallagher", 0, 0, AccountType.Base)]
        [TestCase(2, "Jesse", "Pinkman", 0, 0, AccountType.Gold)]
        [TestCase(3, "Walter", "White", 0, 0, AccountType.Platinum)]
        public void AccountTest_ThreeAccounts_ToReplenishmentMoneyFromAccount_Moq(int id, string name, string surname, decimal amount, int bonus, AccountType accountType)
        {
            // Arrange
            Mock<IBonus> mockWithraw = new Mock<IBonus>();
            Mock<IBonus> mockReplenishment = new Mock<IBonus>();

            // Act
            mockWithraw.Setup(m => m.GetBonusPoints(It.IsAny<AccountDTO>(), It.IsAny<decimal>()))
                .Returns<AccountDTO, decimal>((account, balance) => account.BonusPointToWithdraw);
            
            mockReplenishment.Setup(m => m.GetBonusPoints(It.IsAny<AccountDTO>(), It.IsAny<decimal>()))
                .Returns<AccountDTO, decimal>((account, balance) => account.BonusPointToReplenishment);

            IBankAccountFactory bankAccount = new BankAccountFactory()
            {
                Withdraw = mockWithraw.Object,
                Replenishment = mockReplenishment.Object
            };

            AccountDTO accountDTO = bankAccount.GetAccount(id, name, surname, amount, bonus, accountType);
            accountDTO.ReplenishmentMoney(100500);

            // Assert
            Assert.AreEqual(100500, accountDTO.Amount);
        }

        [Test]
        [TestCase(1, "Frank", "Gallagher", 0, 0, AccountType.Base)]
        [TestCase(2, "Jesse", "Pinkman", 0, 0, AccountType.Gold)]
        [TestCase(3, "Walter", "White", 0, 0, AccountType.Platinum)]
        public void AccountTest_ThreeAccounts_ToWithdrayMoneyFromAccount_Moq(int id, string name, string surname, decimal amount, int bonus, AccountType accountType)
        {
            // Arrange
            Mock<IBonus> mockWithraw = new Mock<IBonus>();
            Mock<IBonus> mockReplenishment = new Mock<IBonus>();

            // Act
            mockWithraw.Setup(m => m.GetBonusPoints(It.IsAny<AccountDTO>(), It.IsAny<decimal>()))
                .Returns<AccountDTO, decimal>((account, balance) => account.BonusPointToWithdraw);
            
            mockReplenishment.Setup(m => m.GetBonusPoints(It.IsAny<AccountDTO>(), It.IsAny<decimal>()))
                .Returns<AccountDTO, decimal>((account, balance) => account.BonusPointToReplenishment);

            IBankAccountFactory bankAccount = new BankAccountFactory()
            {
                Withdraw = mockWithraw.Object,
                Replenishment = mockReplenishment.Object
            };

            AccountDTO accountDTO = bankAccount.GetAccount(id, name, surname, amount, bonus, accountType);
            accountDTO.ReplenishmentMoney(100500);
            accountDTO.WithdrawMoney(100500);

            // Assert
            Assert.AreEqual(0, accountDTO.Amount);
        }        
    }
}
