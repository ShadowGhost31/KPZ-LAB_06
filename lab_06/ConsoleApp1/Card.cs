// src/Card.cs
using System;

namespace ATMProject
{
    public class Card
    {
        public string CardNumber { get; private set; }

        public Card(string cardNumber)
        {
            CardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
        }

        public override bool Equals(object obj)
        {
            return obj is Card card && CardNumber == card.CardNumber;
        }

        public override int GetHashCode()
        {
            return CardNumber.GetHashCode();
        }
    }
}
