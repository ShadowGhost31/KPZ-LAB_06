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
        private ATM _atm;
        private Card _cardFrom;
        private Card _cardTo;
        private decimal _amount;

        public TransferCommand(ATM atm, Card cardFrom, Card cardTo, decimal amount)
        {
            _atm = atm;
            _cardFrom = cardFrom;
            _cardTo = cardTo;
            _amount = amount;
        }

        public void Execute()
        {
            var accountFrom = _atm.GetAccount(_cardFrom);
            var accountTo = _atm.GetAccount(_cardTo);

            if (accountFrom != null && accountTo != null && accountFrom.Balance >= _amount)
            {
                string cardFromPrefix = _cardFrom.CardNumber.Substring(0, 4);
                string cardToPrefix = _cardTo.CardNumber.Substring(0, 4);

                if (cardFromPrefix != cardToPrefix)
                {
                    decimal commission = _amount * 0.05m;
                    _amount -= commission;
                    accountFrom.Withdraw(commission);
                }

                accountFrom.Withdraw(_amount);
                accountTo.Deposit(_amount);

                Console.WriteLine($"\tTransferred {_amount:C} from account {_cardFrom.CardNumber} to account {_cardTo.CardNumber}");
            }
            else
            {
                Console.WriteLine("Transfer failed. Check the accounts and balance.");
            }
        }
    }
}
