using System;
using System.Text;

namespace WorkWithMoney
{
    public class Money
    {
        private decimal hryvnias;

        public Money(int hryvnias, int kopeck)
        {
            this.hryvnias = hryvnias + kopeck * 0.01m;
        }

        public Money(decimal hryvnias)
        {
            this.hryvnias = hryvnias;
        }

        public decimal Hryvnias
        {
            get
            {
                return hryvnias;
            }
        }

        public int Kopeck
        {
            get
            {
                return (int)((this.Hryvnias - Math.Floor(this.Hryvnias)) * 100);
            }
        }

        public static Money Create(int hryvnias, int kopeck)
        {
            return new Money(hryvnias, kopeck);
        }

        public Money Add(Money otherMoney)
        {
            decimal sumHryvniasDecimal = this.Hryvnias + otherMoney.Hryvnias;
            return new Money(sumHryvniasDecimal);
        }

        public Money Subtract(Money otherMoney)
        {
            decimal hryvniasTotalDecimal = this.Hryvnias - otherMoney.Hryvnias;
            return new Money(hryvniasTotalDecimal);
        }



        public int AmountInKopeck()
        {
            return (int)this.hryvnias * 100 + this.Kopeck;
        }


        public static Money FromKopeck(int kopeck)
        {
            int hryvnias = kopeck / 100;
            int kopeckRemainder = kopeck % 100;
            return new Money(hryvnias, kopeckRemainder);
        }

        public override string ToString()
        {
            int kop = this.Kopeck;
            decimal hryvnia = Math.Floor(this.hryvnias);
            return $"{hryvnia:F0} грн {kop:F0} коп";
        }
    }
}

