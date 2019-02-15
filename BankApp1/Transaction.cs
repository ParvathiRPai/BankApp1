using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApp1
{
    enum TrasnactionType
    {
        credit, debit
    }
    class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TrasactionDate { get; set; }
        public TrasnactionType TypeOfTransaction { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }

    }
}
