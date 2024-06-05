// src/Memento.cs
using System;

namespace ATMProject
{
    public class Memento
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Memento(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            Balance = balance;
        }
    }
}
