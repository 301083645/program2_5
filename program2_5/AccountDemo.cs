using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace program2_5
{
    class AccountDemo
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            Account account = new Account("Eunbee");
            account.AddUser("Christina");
            Console.WriteLine(account);
            accounts.Add(account);
            accounts.Add(new Account("Ravleen", 700));
            accounts.Add(new Account("Hussam", 350));
            accounts.Add(new Account("Robinpreet", 350));
            int count = 1;
            foreach (Account item in accounts)
            {
                Console.WriteLine($"{count++,3:d2}  {item}");
            }

            Account.SetPrimeRate(0.019);
            count = 1;
            //accounts[2].SetPremium(0.2); // hussam
            foreach (Account item in accounts)
            {
                Console.WriteLine($"{count++,3:d2}  {item}");
            }
        }
    }

    class Account
    {
        static double PRIME_RATE = 0.02;

        public double Premium { get; private set; }
        public string Names {
            get { return string.Join(",", names); } 
        }
        List<string> names = new List<string>();
        double balance;

        public double Balance { get => balance * (PRIME_RATE + Premium); }

        public Account(string name, double balance = 500)
        {
            names.Add(name);
            this.balance = balance;
            Premium = 0.01;
        }

        public override string ToString()
        {
            return $"{Names}{Balance:C}";
           // return string.Format("{0} {1:C}", Names, Balance);
        }

        public void AddUser(string name)
            => names.Add(name);

        public void Deposit(double amount) => balance += amount;

        public static void SetPrimeRate(double rate)
        {
            PRIME_RATE = rate;
        }

        public void SetPremium(double premium)
        {
            Premium = premium;
        }
    }
}
