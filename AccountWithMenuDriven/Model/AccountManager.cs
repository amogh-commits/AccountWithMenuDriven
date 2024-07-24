using System;
using System.Collections.Generic;
using AccountProject; 

namespace AccountWithMenuDriven
{
    internal class AccountManager
    {
        public static List<Account> accounts = new List<Account>(); 

        public static void RoleSelection()
        {
            while (true)
            {
                Console.WriteLine("\nSelect login type:");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int loginChoice = int.Parse(Console.ReadLine());

                switch (loginChoice)
                {
                    case 1:
                        UserMenu();
                        break;
                    case 2:
                        AdminMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void UserMenu()
        {
            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. Access Account");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    AccessAccount();
                    break;
                case 2:
                    Console.WriteLine("Exiting User Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        public static void AccessAccount()
        {
            Console.WriteLine("Enter the Account Id you want to access: ");
            int userInputForAccountId = int.Parse(Console.ReadLine());

            Account selectedAccount = accounts.Find(account => account.AccountId == userInputForAccountId);

            if (selectedAccount == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine("Enter the action you want to perform. 1. Deposit 2. Withdraw 3. Check Details");
            int userInputForAction = int.Parse(Console.ReadLine());

            switch (userInputForAction)
            {
                case 1:
                    Console.WriteLine("Enter amount to Deposit: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    selectedAccount.Deposit(depositAmount);
                    break;
                case 2:
                    Console.WriteLine("Enter amount to Withdraw: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    selectedAccount.Withdraw(withdrawAmount);
                    break;
                case 3:
                    selectedAccount.PrintAccountDetails();
                    break;
                default:
                    Console.WriteLine("Invalid action selected.");
                    break;
            }
        }

        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Display All Accounts");
                Console.WriteLine("3. Find Account by ID");
                Console.WriteLine("4. Update Account");
                Console.WriteLine("5. Remove Account");
                Console.WriteLine("6. Clear All Accounts");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int adminChoice = int.Parse(Console.ReadLine());

                switch (adminChoice)
                {
                    case 1:
                        AddNewAccount();
                        break;
                    case 2:
                        DisplayAllAccounts();
                        break;
                    case 3:
                        FindAccountById();
                        break;
                    case 4:
                        UpdateAccount();
                        break;
                    case 5:
                        RemoveAccount();
                        break;
                    case 6:
                        ClearAllAccounts();
                        break;
                    case 7:
                        Console.WriteLine("Exiting Admin Menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void AddNewAccount()
        {
            Console.WriteLine("Enter Account ID:");
            int accountId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Account Name:");
            string accountName = Console.ReadLine();

            Console.WriteLine("Enter Bank Name:");
            string bankName = Console.ReadLine();

            Console.WriteLine("Enter Aadhar Number:");
            string aadharNumber = Console.ReadLine();

            Console.WriteLine("Enter Initial Balance:");
            double initialBalance = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountId, accountName, bankName, aadharNumber, initialBalance);
            accounts.Add(newAccount); // Add to List instead of resizing array

            Console.WriteLine("New account added successfully.");
        }

        public static void DisplayAllAccounts()
        {
            Console.WriteLine("\nAll Accounts:");
            foreach (var account in accounts)
            {
                account.PrintAccountDetails();
                Console.WriteLine();
            }
        }

        public static void FindAccountById()
        {
            Console.WriteLine("Enter Account ID:");
            int accountId = int.Parse(Console.ReadLine());

            Account foundAccount = accounts.Find(account => account.AccountId == accountId);

            if (foundAccount != null)
            {
                foundAccount.PrintAccountDetails();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void UpdateAccount()
        {
            Console.WriteLine("Enter Account ID:");
            int accountId = int.Parse(Console.ReadLine());

            Account foundAccount = accounts.Find(account => account.AccountId == accountId);

            if (foundAccount != null)
            {
                Console.WriteLine("Enter new Account Name:");
                foundAccount.AccountName = Console.ReadLine();

                Console.WriteLine("Enter new Bank Name:");
                foundAccount.AccountBankName = Console.ReadLine();

                Console.WriteLine("Enter new Aadhar Number:");
                foundAccount.AccountAadharNumber = Console.ReadLine();

                Console.WriteLine("Enter new Balance:");
                foundAccount.AccountBalance = double.Parse(Console.ReadLine());

                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void RemoveAccount()
        {
            Console.WriteLine("Enter Account ID to remove:");
            int accountId = int.Parse(Console.ReadLine());

            Account accountToRemove = accounts.Find(account => account.AccountId == accountId);

            if (accountToRemove != null)
            {
                accounts.Remove(accountToRemove);
                Console.WriteLine("Account removed successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void ClearAllAccounts()
        {
            accounts.Clear();
            Console.WriteLine("All accounts cleared successfully.");
        }
    }
}
