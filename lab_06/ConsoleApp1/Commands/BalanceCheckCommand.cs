using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BalanceCheckCommand : ICommand
    {
        private readonly ATM _atm;
        private readonly Card _card;

        public BalanceCheckCommand(ATM atm, Card card)
        {
            _atm = atm;
            _card = card;
        }

        public void Execute()
        {
            _atm.CheckBalance(_card);
        }
    }
}
