using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NoCashState : ATMState
    {
        public NoCashState(ATM atm) : base(atm) { }

        public override void Deposit(Card card, decimal amount)
        {
            var account = _atm.GetAccount(card);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"\tDeposited {amount:C} to account {account.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public override void Withdraw(Card card, decimal amount)
        {
            Console.WriteLine("ATM has no cash to dispense.");
        }

        public override void CheckBalance(Card card)
        {
            var account = _atm.GetAccount(card);
            if (account != null)
            {
                Console.WriteLine($"\tAccount {account.AccountNumber} balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public override void Transfer(Card cardFrom, Card cardTo, decimal amount)
        {
            var accountFrom = _atm.GetAccount(cardFrom);
            var accountTo = _atm.GetAccount(cardTo);

            if (accountFrom != null && accountTo != null && accountFrom.Balance >= amount)
            {
                accountFrom.Withdraw(amount);
                accountTo.Deposit(amount);
                Console.WriteLine($"\tTransferred {amount:C} from account {accountFrom.AccountNumber} to account {accountTo.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Transfer failed. Check the accounts and balance.");
            }
        }
    }
}
