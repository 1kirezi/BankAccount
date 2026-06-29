using NUnit.Framework;

namespace BankAccount.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void GetBalance_NewAccount_ReturnsZero()
    {
        var account = new Core.BankAccount();
        Assert.That(account.GetBalance(), Is.EqualTo(0m));
    }

    [Test]
    public void Deposit_ValidAmount_AddsToBalance()
    {
        var account = new Core.BankAccount();
        account.Deposit(100.50m);
        Assert.That(account.GetBalance(), Is.EqualTo(100.50m));
    }

    [Test]
    public void Deposit_NegativeAmount_ThrowsArgumentException()
    {
        var account = new Core.BankAccount();
        Assert.Throws<ArgumentException>(
            () => account.Deposit(-50m),
            "Deposit amount cannot be negative."
        );
    }

    [Test]
    public void Withdraw_ValidAmount_SubtractsFromBalance()
    {
        var account = new Core.BankAccount();
        account.Deposit(200m);
        account.Withdraw(75.50m);
        Assert.That(account.GetBalance(), Is.EqualTo(124.50m));
    }

    [Test]
    public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
    {
        var account = new Core.BankAccount();
        account.Deposit(100m);
        Assert.Throws<InvalidOperationException>(
            () => account.Withdraw(150m),
            "Insufficient funds."
        );
    }

    [Test]
    public void Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        var account = new Core.BankAccount();
        Assert.Throws<ArgumentException>(
            () => account.Withdraw(-30m),
            "Withdrawal amount cannot be negative."
        );
    }
}