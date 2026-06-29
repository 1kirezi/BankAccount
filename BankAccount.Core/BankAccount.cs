namespace BankAccount.Core;

public class BankAccount
{
    private decimal _balance = 0;

    public void Deposit(decimal amount)
    {
        ValidateNonNegative(amount, nameof(amount), "Deposit amount cannot be negative.");
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        ValidateNonNegative(amount, nameof(amount), "Withdrawal amount cannot be negative.");
        
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        
        _balance -= amount;
    }

    public decimal GetBalance() => _balance;

    private static void ValidateNonNegative(decimal amount, string paramName, string message)
    {
        if (amount < 0)
            throw new ArgumentException(message, paramName);
    }
}