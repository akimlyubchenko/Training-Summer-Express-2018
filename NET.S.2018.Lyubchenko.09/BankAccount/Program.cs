using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount.BankAccount user1 = new BankAccount.BankAccount("Ivan Ivanovich", "+375 29 1234567", "Kuprevicha 17 123", "Gold");
            Console.Write(user1.ShowAcc());
            user1.RefillOrDebit(123.123);
            user1.RefillOrDebit(123.123);
            user1.RefillOrDebit(-40.123);
            Console.Write(user1.ShowAcc());
            user1.Delete();
            Console.Write(user1.ShowAcc());

            BankAccount.BankAccount user2 = new BankAccount.BankAccount("Akim Ivanovich", "+375 29 1265567", "Korolia 1 13", "Platinum");
            Console.Write(user2.ShowAcc());
            user2.RefillOrDebit(12323.123);
            user2.RefillOrDebit(123.123);
            user2.RefillOrDebit(-40.123);
            Console.Write(user2.ShowAcc());
            user1.Delete();
            Console.Write(user2.ShowAcc());

            BankAccount.BankAccount user3 = new BankAccount.BankAccount("Mary Ivanovich", "+375 29 1265567", "Korolia 1 13", "Platinum");
            Console.Write(user3.ShowAcc());
            user3.RefillOrDebit(12.123);
            user3.RefillOrDebit(-123.123);//Exception
            Console.Write(user3.ShowAcc());
            Console.ReadKey();
        }
    }
}
