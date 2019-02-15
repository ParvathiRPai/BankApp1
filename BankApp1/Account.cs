using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp1
{
    enum TypeOfAccount
    {
        savings, 
        checking,
        CD,
        Loan
    }
    class Account
    {
        //private static int lastAccountNumber = 0;
        #region Properties
        public int AccountNumber { get; set; }
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get;}
        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion

        #region constructor
        public Account()
        {
            //AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }
        #endregion
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        #region methods
        public void Deposit(decimal amount)
        {
            Balance = Balance + amount;
        }
        public void WithDraw(decimal amount)
        {
            if(amount > Balance)
            {
                throw new NSFException("Not sufficient funds");
            }
            Balance = Balance - amount;
        }
        #endregion
    }
}
