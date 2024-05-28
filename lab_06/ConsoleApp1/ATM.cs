using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMProject
{
    public class ATM
    {
        private ATMState _currentState;
        private decimal _cashInMachine;
        private List<Account> _accounts;

        public ATM(decimal initialCash)
        {
            if (initialCash < 0) throw new ArgumentOutOfRangeException(nameof(initialCash), "Initial cash must be non-negative.");
            _cashInMachine = initialCash;
            _currentState = new NormalState(this);
            _accounts = new List<Account>();
        }

        public void SetState(ATMState state)
        {
            _currentState = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void AddAccount(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            _accounts.Add(account);
        }

        public void Deposit(Card card, decimal amount)
        {
            _currentState.Deposit(card, amount);
        }

        public void Withdraw(Card card, decimal amount)
        {
            _currentState.Withdraw(card, amount);
        }

        public void CheckBalance(Card card)
        {
            _currentState.CheckBalance(card);
        }

        public void Transfer(Card cardFrom, Card cardTo, decimal amount)
        {
            _currentState.Transfer(cardFrom, cardTo, amount);
        }

        public void DispenseCash(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Dispense amount must be positive.");
            if (amount <= _cashInMachine)
            {
                _cashInMachine -= amount;
                Console.WriteLine($"Dispensed {amount:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds in ATM.");
                SetState(new NoCashState(this));
            }
        }

        public decimal GetCashInMachine()
        {
            return _cashInMachine;
        }

        public Account GetAccount(Card card)
        {
            return _accounts.FirstOrDefault(a => a.Card.Equals(card));
        }
    }
}