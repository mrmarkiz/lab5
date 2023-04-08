using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Task4
    {
        public static void Run()
        {
            Credit_Card card1 = new Credit_Card(), card2 = new Credit_Card();
            Console.WriteLine("Enter first card's parameters: ");
            card1.Init();
            Console.WriteLine("Enter second card's parameters: ");
            card2.Init();
            string action, card;
            do
            {
                Console.Write("Enter what to do( rise(balance), cut(balance), compare, show, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "rise":
                        Console.Write("Enter which card to work with(first, second): ");
                        card = Console.ReadLine();
                        Console.Write("Enter sum of rising: ");
                        int rise;
                        int.TryParse(Console.ReadLine(), out rise);
                        if (card == "first")
                            card1 = card1 + rise;
                        else if (card == "second")
                            card2 = card2 + rise;
                        break;

                    case "cut":
                        Console.Write("Enter which card to work with(first, second): ");
                        card = Console.ReadLine();
                        Console.Write("Enter sum of cutting: ");
                        int cut;
                        int.TryParse(Console.ReadLine(), out cut);
                        if (card == "first")
                            card1 = card1 - cut;
                        else if (card == "second")
                            card2 = card2 - cut;
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(>, <, ==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch (compare)
                        {
                            case ">":
                                Console.WriteLine($"Result(card1 > card2): {card1 > card2}");
                                break;
                            case "<":
                                Console.WriteLine($"Result(card1 < card2): {card1 < card2}");
                                break;
                            case "==":
                                Console.WriteLine($"Result(card1 == card2): {card1 == card2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(card1 != card2): {card1 != card2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(card1.Equals(card2)): {card1.Equals(card2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("First worker's info:");
                        card1.ShowInfo();
                        Console.WriteLine("Second worker's info:");
                        card2.ShowInfo();
                        break;
                }

            } while (action != "exit");
        }
    }

    class Credit_Card
    {
        private string _initials { get; set; }
        private string _register_country { get; set; }
        private string _cvc { get; set; }
        private int _balance { get; set; }

        public Credit_Card(string initials, string register_country, string cvc, int balance)
        {
            this._initials = initials;
            this._register_country = register_country;
            this._cvc = cvc;
            this._balance = balance;
        }
        public Credit_Card()
        {
            this._initials = "None";
            this._register_country = "None";
            this._cvc = "None";
            this._balance = 0;
        }

        public void Init()
        {
            Console.Write("Enter owner's initials: ");
            this._initials = Console.ReadLine();
            Console.Write("Enter card's register country: ");
            this._register_country = Console.ReadLine();
            Console.Write("Enter card's cvc: ");
            this._cvc = Console.ReadLine();
            Console.Write("Enter card's balance: ");
            int bal;
            int.TryParse(Console.ReadLine(), out bal);
            this._balance = bal;
        }

        public void ShowInfo()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Owner's initials: {this._initials}");
            Console.WriteLine($"Card's register country: {this._register_country}");
            Console.WriteLine($"Card's cvc: {this._cvc}");
            Console.WriteLine($"Card's balance: {this._balance}");
            Console.WriteLine("------------------------------");
        }

        public static Credit_Card operator +(Credit_Card card, int num)
        {
            card._balance += num;
            return card;
        }
        public static Credit_Card operator +(int num, Credit_Card card)
        {
            card._balance += num;
            return card;
        }

        public static Credit_Card operator -(Credit_Card card, int num)
        {
            card._balance -= num;
            return card;
        }
        public static Credit_Card operator -(int num, Credit_Card card)
        {
            card._balance -= num;
            return card;
        }

        public static bool operator ==(Credit_Card card1, Credit_Card card2)
        {
            return card1._cvc == card2._cvc;
        }
        public static bool operator !=(Credit_Card card1, Credit_Card card2)
        {
            return card1._cvc != card2._cvc;
        }

        public static bool operator >(Credit_Card card1, Credit_Card card2)
        {
            return card1._balance > card2._balance;
        }
        public static bool operator <(Credit_Card card1, Credit_Card card2)
        {
            return card1._balance < card2._balance;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Credit_Card))
                return false;

            Credit_Card other = (Credit_Card)obj;
            if (this._initials != other._initials)
                return false;
            if (this._register_country != other._register_country)
                return false;
            if (this._cvc != other._cvc) 
                return false;
            if (this._balance != other._balance)
                return false;
            return true;
        }
    }
}
