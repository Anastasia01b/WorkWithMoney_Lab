using NUnit.Framework;
using System;
using WorkWithMoney;

namespace MoneyTestProject
{
    [TestFixture]
    public class MoneyTests
    {
        [TestCase(21, 10, "21 ��� 10 ���")]
        [TestCase(12, 5, "12 ��� 5 ���")]
        [TestCase(0, 99, "0 ��� 99 ���")]
        [TestCase(113, 86, "113 ��� 86 ���")]
        [TestCase(20, 1, "20 ��� 1 ���")]
        public void ValidInputMoney(int hr, int kop, string expected)
        {
            Money result = new Money(hr, kop);
            string resultString = result.ToString(); 

            Assert.AreEqual(expected, resultString);
        }

        [TestCase(20, 40, 10, 50, 30, 90, "30 ��� 90 ���")]
        [TestCase(50, 88, 1, 99, 52, 87, "52 ��� 87 ���")]
        [TestCase(0, 98, 100, 99, 101, 97, "101 ��� 97 ���")]
        [TestCase(80, 10, 5, 17, 85, 27, "85 ��� 27 ���")]
        [TestCase(7, 82, 12, 18, 20, 0, "20 ��� 0 ���")]
        public void AddMoney(int hr1, int kop1, int hr2, int kop2, int sumHr, int sumKop, string expected)
        {
            Money moneyOne = new Money(hr1, kop1);
            Money moneyTwo = new Money(hr2, kop2);
            Money result = moneyOne.Add(moneyTwo);

            string resultString = result.ToString(); 

            Assert.AreEqual(expected, resultString);
        }

        [TestCase(40, 60, 18, 70, 21, 90, "21 ��� 90 ���")]
        [TestCase(16, 5, 10, 36, 5, 69, "5 ��� 69 ���")]
        [TestCase(88, 80, 13, 75, 75, 5, "75 ��� 5 ���")]
        [TestCase(5, 90, 3, 89, 2, 1, "2 ��� 1 ���")]
        [TestCase(26, 30, 15, 95, 10, 35, "10 ��� 35 ���")]
        public void SubMoney(int hr1, int kop1, int hr2, int kop2, int subHr, int subKop, string expected)
        {
            Money moneyOne = new Money(hr1, kop1);
            Money moneyTwo = new Money(hr2, kop2);
            Money result = moneyOne.Subtract(moneyTwo);

            string resultString = result.ToString(); 

            Assert.AreEqual(expected, resultString);
        }

        [TestCase(10, 50, 1050)]
        [TestCase(2, 98, 298)]
        [TestCase(0, 78, 78)]
        [TestCase(68, 45, 6845)]
        [TestCase(20, 15, 2015)]
        public void AmountInKopeck(int hr, int kop, int allKop)
        {
            Money money = new Money(hr, kop);
            int totalInKopeck = (int)money.AmountInKopeck();

            Assert.AreEqual(allKop, totalInKopeck);
        }

        [TestCase(1050, 10, 50, "10 ��� 50 ���")]
        [TestCase(298, 2, 98, "2 ��� 98 ���")]
        [TestCase(78, 0, 78, "0 ��� 78 ���")]
        [TestCase(6845, 68, 45, "68 ��� 45 ���")]
        [TestCase(2015, 20, 15, "20 ��� 15 ���")]
        public void FromKopeck(int allKop, int hr, int kop, string expected)
        {
            Money money = Money.FromKopeck(allKop);

            string resultString = money.ToString();
            Assert.AreEqual(expected, resultString);
        }


        [TestCase(10, 60, "10 ��� 60 ���")]
        [TestCase(40, 99, "40 ��� 99 ���")]
        [TestCase(78, 20, "78 ��� 20 ���")]
        [TestCase(50, 10, "50 ��� 10 ���")]
        [TestCase(2015, 29, "2015 ��� 29 ���")]
        public void ToString(int hr, int kop, string expected)
        {
            Money money = new Money(hr, kop);
            string stringMoney = money.ToString();
            Assert.AreEqual(expected, stringMoney);
        }
    }
}
