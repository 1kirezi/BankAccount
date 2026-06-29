# BankAccount

A small C# library that models a simple bank account with deposit, withdrawal, and balance operations. The project includes unit tests covering the core behavior and error cases.

## Features

- **Deposit** — Add funds to the account (negative amounts are rejected)
- **Withdraw** — Remove funds when sufficient balance is available
- **Get balance** — Read the current account balance
- **Validation** — Throws clear exceptions for invalid operations:
  - `ArgumentException` when deposit or withdrawal amounts are negative
  - `InvalidOperationException` when a withdrawal exceeds the available balance

## Project structure

```
BankAccount/
├── BankAccount.Core/          # Core library
│   └── BankAccount.cs         # BankAccount class
└── BankAccount.Tests/         # NUnit test project
    └── BankAccountTests.cs
```

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or later

Verify your installation:

```bash
dotnet --version
```

## Getting started

Clone the repository and restore dependencies:

```bash
git clone <repository-url>
cd BankAccount
dotnet restore BankAccount.Tests/BankAccount.Tests.csproj
```

## Running tests

There is no solution file at the repository root, so run tests by pointing `dotnet` at the test project:

```bash
dotnet test BankAccount.Tests/BankAccount.Tests.csproj
```

To run tests with more detail:

```bash
dotnet test BankAccount.Tests/BankAccount.Tests.csproj --verbosity normal
```

## Usage example

```csharp
using BankAccount.Core;

var account = new BankAccount();

account.Deposit(200m);
account.Withdraw(75.50m);

Console.WriteLine(account.GetBalance()); // 124.50
```

## API reference

| Method | Description |
|--------|-------------|
| `Deposit(decimal amount)` | Adds `amount` to the balance. Throws `ArgumentException` if `amount` is negative. |
| `Withdraw(decimal amount)` | Subtracts `amount` from the balance. Throws `ArgumentException` if `amount` is negative, or `InvalidOperationException` if funds are insufficient. |
| `GetBalance()` | Returns the current balance as a `decimal`. New accounts start at `0`. |

## Test coverage

The test suite (`BankAccountTests`) verifies:

- New accounts start with a zero balance
- Deposits increase the balance correctly
- Withdrawals decrease the balance correctly
- Negative deposit and withdrawal amounts throw `ArgumentException`
- Withdrawals exceeding the balance throw `InvalidOperationException`

## License

Add your license here.
