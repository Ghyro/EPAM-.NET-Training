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
        [TestCase(1, "Frank ", "Gallagher", 0, 0, AccountTypeDTO.Base)]
        [TestCase(2, "Jesse", "Pinkman", 0, 0, AccountTypeDTO.Gold)]
        [TestCase(3, "Walter", "White", 0, 0, AccountTypeDTO.Platinum)]
        public void AccountTest_ThreeAccounts_ToReplenishmentMoneyFromAccount_Moq(int id, string name, string surname, decimal amount, int bonus, AccountTypeDTO accountType)
        {
            // Arrange
            Mock<IBonus> mockWithraw = new Mock<IBonus>();
            Mock<IBonus> mockReplenishment = new Mock<IBonus>();

            // Act
            mockWithraw.Setup(m => m.GetBonusPoints(It.IsAny<BankAccountDTO>(), It.IsAny<decimal>()))
                .Returns<BankAccountDTO, decimal>((account, balance) => account.BonusPointToWithdraw);
            
            mockReplenishment.Setup(m => m.GetBonusPoints(It.IsAny<BankAccountDTO>(), It.IsAny<decimal>()))
                .Returns<BankAccountDTO, decimal>((account, balance) => account.BonusPointToReplenishment);

            IBankAccountFactory bankAccount = new BankAccountFactory()
            {
                Withdraw = mockWithraw.Object,
                Replenishment = mockReplenishment.Object
            };

            BankAccountDTO accountDTO = bankAccount.GetAccount(id, name, surname, amount, bonus, accountType);
            accountDTO.ReplenishmentMoney(100500);

            // Assert
            Assert.AreEqual(100500, accountDTO.Amount);
        }

        [Test]
        [TestCase(1, "Frank", "Gallagher", 0, 0, AccountTypeDTO.Base)]
        [TestCase(2, "Jesse", "Pinkman", 0, 0, AccountTypeDTO.Gold)]
        [TestCase(3, "Walter", "White", 0, 0, AccountTypeDTO.Platinum)]
        public void AccountTest_ThreeAccounts_ToWithdrayMoneyFromAccount_Moq(int id, string name, string surname, decimal amount, int bonus, AccountTypeDTO accountType)
        {
            // Arrange
            Mock<IBonus> mockWithraw = new Mock<IBonus>();
            Mock<IBonus> mockReplenishment = new Mock<IBonus>();

            // Act
            mockWithraw.Setup(m => m.GetBonusPoints(It.IsAny<BankAccountDTO>(), It.IsAny<decimal>()))
                .Returns<BankAccountDTO, decimal>((account, balance) => account.BonusPointToWithdraw);
            
            mockReplenishment.Setup(m => m.GetBonusPoints(It.IsAny<BankAccountDTO>(), It.IsAny<decimal>()))
                .Returns<BankAccountDTO, decimal>((account, balance) => account.BonusPointToReplenishment);

            IBankAccountFactory bankAccount = new BankAccountFactory()
            {
                Withdraw = mockWithraw.Object,
                Replenishment = mockReplenishment.Object
            };

            BankAccountDTO accountDTO = bankAccount.GetAccount(id, name, surname, amount, bonus, accountType);
            accountDTO.ReplenishmentMoney(100500);
            accountDTO.WithdrawMoney(100500);

            // Assert
            Assert.AreEqual(0, accountDTO.Amount);
        }        
    }
}
