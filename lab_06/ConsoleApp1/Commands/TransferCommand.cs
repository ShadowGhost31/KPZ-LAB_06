using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TransferCommand : ICommand
    {
        private readonly ATM _atm;
        private readonly Card _cardFrom;
        private readonly Card _cardTo;
        private readonly decimal _amount;

        public TransferCommand(ATM atm, Card cardFrom, Card cardTo, decimal amount)
        {
            _atm = atm;
            _cardFrom = cardFrom;
            _cardTo = cardTo;
            _amount = amount;
        }

        public void Execute()
        {
            _atm.Transfer(_cardFrom, _cardTo, _amount);
        }
    }
}
