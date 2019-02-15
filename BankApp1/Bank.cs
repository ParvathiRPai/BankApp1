using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp1
{
    static class Bank
    {
        private static BankModel db = new BankModel();
        //private static List<Account> accounts = new List<Account>();
        /// <summary>
        ///  Create Account with the bank
        /// </summary>
        /// <param name="email">Email Address of account</param>
        /// <param name="AccountType">Type of account</param>
        /// <param name="initialAmount">Initial Deposit</param>
        /// <returns>newly created account</returns>
        public static Account CreateAccount(string email, TypeOfAccount AccountType=TypeOfAccount.checking, decimal initialAmount=0)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), " email reqired");
            }
            var account = new Account
            {
                EmailAddress = email,
                AccountType = AccountType,
            };
            if(initialAmount>0)
            {
                account.Deposit(initialAmount);
            }
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static void Deposit(int accountNumber, decimal amaount)
        {
            var account = db.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            if(account==null)
            {
                return;
            }
            account.Deposit(amaount);
            var transaction = new Transaction
            {
                TrasactionDate = DateTime.Now,
                TypeOfTransaction = TrasnactionType.credit,
                Description = "Bank deposit",
                Amount = amaount,
               AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void WithDraw(int accountNumber, decimal amaount)
        {
            var account = db.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            if (account == null)
            {
                return;
            }
            account.WithDraw(amaount);
            var transaction = new Transaction
            {
                TrasactionDate = DateTime.Now,
                TypeOfTransaction = TrasnactionType.debit,
                Description = "withdraw",
                Amount = amaount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static IEnumerable<Account> GetAllAccounts()
        {
            return db.Accounts;
        }
        public static IEnumerable<Transaction> GetTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TrasactionDate);
        }
    }
}
