using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            
            get 
            { 
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        
        }

        private static int accountNumber = 2115824951;

        List<Transaction> transactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance )
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            Number = accountNumber.ToString();
            accountNumber++;
        }
        public void MakeDeposit(decimal amount,DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount), "Amount must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            transactions.Add( deposit );
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount), "Amount must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("No sufficient fund for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
        }
    }
}
