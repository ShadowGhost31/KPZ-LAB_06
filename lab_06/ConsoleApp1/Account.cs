// src/Account.cs
using System;

namespace ATMProject
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public Card Card { get; private set; }

        public Account(string accountNumber, decimal initialBalance, Card card)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentNullException(nameof(accountNumber), "Номер рахунку не може бути порожнім.");

            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Початковий баланс повинен бути невід'ємним.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
            Card = card ?? throw new ArgumentNullException(nameof(card), "Картка не може бути порожньою.");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума депозиту повинна бути позитивною.");

            Balance += amount;
            Console.WriteLine($"\tДепозит {amount}. Новий баланс: {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума зняття повинна бути позитивною.");

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"\tЗнято {amount}. Новий баланс: {Balance}");
            }
            else
            {
                Console.WriteLine($"\tНедостатньо коштів для зняття {amount}. Поточний баланс: {Balance}");
            }
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (toAccount == null)
                throw new ArgumentNullException(nameof(toAccount), "Цільовий рахунок не може бути порожнім.");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума переказу повинна бути позитивною.");

            if (Balance >= amount)
            {
                Balance -= amount;
                toAccount.Deposit(amount);
                Console.WriteLine($"\tПереказано {amount} на рахунок {toAccount.AccountNumber}. Новий баланс: {Balance}");
            }
            else
            {
                Console.WriteLine($"\tНедостатньо коштів для переказу {amount}. Поточний баланс: {Balance}");
            }
        }

        public Memento SaveState()
        {
            return new Memento(AccountNumber, Balance);
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер рахунку: {AccountNumber}");
            Console.WriteLine($"Номер картки: {Card.CardNumber}");
            Console.WriteLine($"Баланс: {Balance:C}");
        }

        public void RestoreState(Memento memento)
        {
            if (memento == null)
                throw new ArgumentNullException(nameof(memento), "Memento не може бути порожнім.");

            Balance = memento.Balance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (AccountNumber?.GetHashCode() ?? 0);
                hash = hash * 23 + Balance.GetHashCode();
                hash = hash * 23 + (Card?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
