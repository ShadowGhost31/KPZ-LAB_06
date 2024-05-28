// src/ATMState.cs
using System;

namespace ATMProject
{
    public abstract class ATMState
    {
        protected ATM _atm;

        protected ATMState(ATM atm)
        {
            _atm = atm;
        }

        public abstract void Deposit(Card card, decimal amount);
        public abstract void Withdraw(Card card, decimal amount);
        public abstract void CheckBalance(Card card);
        public abstract void Transfer(Card cardFrom, Card cardTo, decimal amount);
    }
}
