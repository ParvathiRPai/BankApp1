using System;

namespace BankApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Royal Bank of Canada");
            while (true)
            { 
                Console.WriteLine("0 Exit");
            Console.WriteLine("1 Create Account");
            Console.WriteLine("2 Deposit money");
            Console.WriteLine("3 Withdraw money");
            Console.WriteLine("4 print all accounts");
                Console.WriteLine("5. Print all transactions");
            Console.Write("Please select an option");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    return;
                case "1":
                        try
                        {
                            Console.Write("Email address");
                            var email = Console.ReadLine();
                            var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                            for (int i = 0; i < accountTypes.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                            }
                            Console.Write("select an account type: ");
                            var accountTypeOption = Convert.ToInt32(Console.ReadLine());
                            var accountType = Enum.Parse<TypeOfAccount>(accountTypes[accountTypeOption - 1]);
                            Console.WriteLine("amount to deposit");
                            var initialDeposit = Convert.ToDecimal(Console.ReadLine());
                            var account = Bank.CreateAccount(email, accountType, initialDeposit);
                            Console.WriteLine($"An:{account.AccountNumber}, AT:{account.AccountType}, B:{account.Balance} ");
                        }
                        catch(FormatException fx)
                        {
                            Console.WriteLine($"Error: {fx.Message}");
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("Incorrect acount type");
                        }
                        catch(ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error:{ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("something went wrong try again");
                        }
                    break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amounnt to deposit");
                        var amount=Convert.ToInt32(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit Completed successfully");
                        break;
                    case "3":
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account Number");
                            accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amounnt to WithDraw");
                            amount = Convert.ToInt32(Console.ReadLine());
                            Bank.WithDraw(accountNumber, amount);
                            Console.WriteLine("WithDraw Completed successfully");
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("out of range exception");
                        }
                        catch(NSFException)
                        {
                            Console.WriteLine(" no sufficient fund");
                        }
                        catch
                        {
                            Console.WriteLine("something went wrong try again");
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.WriteLine("Account Number");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetTransactions(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"TT:{transaction.TypeOfTransaction},TD:{transaction.TrasactionDate},TA{transaction.Amount}");
                        }
                        break;
                    default:
                        break;
                }

           }

        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"An:{acnt.AccountNumber}, AT:{acnt.AccountType}, B:{acnt.Balance} ");
            }
        }
    }
}
