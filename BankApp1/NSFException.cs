using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp1
{
    class NSFException : Exception
    {
        public NSFException(): base("Not sufficient funds")
        {

        }
        public NSFException(string message): base(message)
        {

        }
    }
}
