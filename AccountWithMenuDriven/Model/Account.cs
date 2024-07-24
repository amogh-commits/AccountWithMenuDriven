using System;

namespace AccountProject
{
    internal class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountBankName { get; set; }
        public string AccountAadharNumber { get; set; }
        public double AccountBalance { get; set; }

        public const double MINIMUM_BALANCE = 500;

        public Account() { }

        public Account(int accountId, string accountName, string accountBankName)
        {
            AccountId = accountId;
            AccountName = accountName;
            AccountBankName = accountBankName;
            AccountBalance = MINIMUM_BALANCE;
        }

        public Account(int accountId, string accountName, string accountBankName, double accountBalance) : this(accountId, accountName, accountBankName)
        {
            if (accountBalance < MINIMUM_BALANCE)
            {
                AccountBalance = MINIMUM_BALANCE;
            }
            else
            {
                AccountBalance = accountBalance;
            }
        }

        public Account(int accountId, string accountName, string accountBankName, string accountAadharNumber) : this(accountId, accountName, accountBankName)
        {
            AccountAadharNumber = accountAadharNumber;
        }

        public Account(int accountId, string accountName, string accountBankName, string accountAadharNumber, double accountBalance) : this(accountId, accountName, accountBankName, accountAadharNumber)
        {
            if (accountBalance < MINIMUM_BALANCE)
            {
                AccountBalance = MINIMUM_BALANCE;
            }
            else
            {
                AccountBalance = accountBalance;
            }
        }

        public void Deposit(double depositAmount)
        {
            AccountBalance += depositAmount;
            Console.WriteLine($"Deposited {depositAmount}. New balance: {AccountBalance}");
        }

        public void Withdraw(double withdrawAmount)
        {
            if (AccountBalance - withdrawAmount < MINIMUM_BALANCE)
            {
                Console.WriteLine("Withdrawal failed. Account balance would fall below minimum balance.");
            }
            else
            {
                AccountBalance -= withdrawAmount;
                Console.WriteLine($"Withdrawn {withdrawAmount}. New balance: {AccountBalance}");
            }
        }

        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account ID: {AccountId}");
            Console.WriteLine($"Account Name: {AccountName}");
            Console.WriteLine($"Account Bank Name: {AccountBankName}");
            Console.WriteLine($"Account Balance: {AccountBalance}");
            Console.WriteLine($"Account Aadhar Number: {AccountAadharNumber}");
        }
    }
}
