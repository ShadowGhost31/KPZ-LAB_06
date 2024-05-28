using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DepositCommand : ICommand
    {
        private readonly ATM _atm;
        private readonly Card _card;
        private readonly decimal _amount;

        public DepositCommand(ATM atm, Card card, decimal amount)
        {
            _atm = atm;
            _card = card;
            _amount = amount;
        }

        public void Execute()
        {
            _atm.Deposit(_card, _amount);
        }
    }
}
