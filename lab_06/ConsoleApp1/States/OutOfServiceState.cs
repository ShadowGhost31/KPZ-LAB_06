using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OutOfServiceState : ATMState
    {
        public OutOfServiceState(ATM atm) : base(atm) { }

        public override void Deposit(Card card, decimal amount)
        {
            Console.WriteLine("ATM is out of service.");
        }

        public override void Withdraw(Card card, decimal amount)
        {
            Console.WriteLine("ATM is out of service.");
        }

        public override void CheckBalance(Card card)
        {
            Console.WriteLine("ATM is out of service.");
        }

        public override void Transfer(Card cardFrom, Card cardTo, decimal amount)
        {
            Console.WriteLine("ATM is out of service.");
        }
    }
}
