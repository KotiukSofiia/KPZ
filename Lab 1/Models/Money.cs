using System;

namespace Lab1.Models
{
    public class Money
    {
        public int WholePart { get; }
        public int Cents { get; }
        public string Currency { get; }

        public Money(int wholePart, int cents, string currency)
        {
            WholePart = wholePart;
            Cents = cents;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{WholePart}.{Cents:D2} {Currency}";
        }
    }
}

