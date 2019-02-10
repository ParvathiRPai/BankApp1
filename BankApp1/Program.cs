using System;

namespace BankApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Royal Bank of Canada");
            Console.WriteLine("0 Exit");
            Console.WriteLine("1 Create Account");
            Console.WriteLine("2 Deposit money");
            Console.WriteLine("3 Withdraw money");
            Console.WriteLine("4 print all accounts");
            Console.Write("Please select an option");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    return;
                case "1":
                    Console.Write("Email address");
                    var email = Console.ReadLine();
                    var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                    for(int i=0; i<accountTypes.Length;i++)
                    {
                        Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                    }
                    Console.Write("select an account type: ");
                    var accountTypeOption = Console.ReadLine();
                    break;

                default:
                    break;
            }



        }
    }
}
