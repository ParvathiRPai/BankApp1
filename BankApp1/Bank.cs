using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp1
{
    static class Bank
    {
        /// <summary>
        ///  Create Account with the bank
        /// </summary>
        /// <param name="email">Email Address of account</param>
        /// <param name="AccountType">Type of account</param>
        /// <param name="initialAmount">Initial Deposit</param>
        /// <returns>newly created account</returns>
        public static Account CreateAccount(string email, TypeOfAccount AccountType=TypeOfAccount.checking, decimal initialAmount=0)
        {
            var account = new Account
            {
                EmailAddress = email,
                AccountType = AccountType,
            };
            if(initialAmount>0)
            {
                account.Deposit(initialAmount);
            }
            return account;
        }
    }
}
