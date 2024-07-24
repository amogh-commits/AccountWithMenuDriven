using System;
using AccountWithMenuDriven;

namespace AccountProject
{
    internal class Program
    {
    
        public static void Main(string[] args)
        {
            AccountManager.accounts=SerialDeserial.DeserializeData();
            Console.WriteLine("Welcome to the Bank Management System!");
            AccountManager.RoleSelection();
            SerialDeserial.SerializeData(AccountManager.accounts);
        }

    }
}
