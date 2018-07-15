using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Create and edit bank account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Gets and sets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets and sets the phone number.
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Gets and sets the amount.
        /// </summary>
        public double Amount { get; private set; }

        /// <summary>
        /// Gets and sets the address.
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Gets and sets the gradation.
        /// </summary>
        public string Gradation { get; private set; }

        /// <summary>
        /// Gets and sets the bonus.
        /// </summary>
        public double Bonus { get; private set; }

        /// <summary>
        /// The gradation
        /// </summary>
        private readonly string[] GRADATION = new string[] { "Base", "Silver", "Gold", "Platinum" };

        /// <summary>
        /// Initializes a new account
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="address">The address.</param>
        /// <param name="gradation">The gradation.</param>
        public BankAccount(string name, string phoneNumber, string address, string gradation = "Base")
        {
            Validation(name, phoneNumber, address, gradation);
            Name = string.Copy(name);
            PhoneNumber = string.Copy(phoneNumber);
            Address = string.Copy(address);
            Gradation = gradation;
            Bonus = 0;
            Amount = 0;
        }

        /// <summary>
        /// Refills the or debit amount
        /// </summary>
        /// <param name="money">The money.</param>
        /// <exception cref="System.ArgumentException">Sorry, you do not have enough money</exception>
        public void RefillOrDebit(double money)
        {
            if (Amount + money > 0)
            {
                Amount += money;
                Bonus += money / 100;
            }
            else
            {
                throw new ArgumentException("Sorry, you do not have enough money");
            }
        }

        /// <summary>
        /// Deletes this account
        /// </summary>
        public void Delete()
        {
            Address = null;
            Amount = 0;
            Bonus = 0;
            Gradation = null;
            Name = null;
            PhoneNumber = null;
        }

        /// <summary>
        /// Shows the account
        /// </summary>
        /// <returns> String width information </returns>
        public string ShowAcc()
            => $"Name: {Name}\nPhoneNumber: {PhoneNumber}\nAddress: {Address}\nAmount: {Amount}\nBonuses: {Bonus}\nGradation: {Gradation}\n\n";

        /// <summary>
        /// Validations the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="address">The address.</param>
        /// <param name="gradation">The gradation.</param>
        /// <exception cref="System.ArgumentException">
        /// Checks if information is valid
        /// </exception>
        private void Validation(string name, string phoneNumber, string address, string gradation = "Base")
        {
            Regex regexn = new Regex(@"[a-zA-Z]+\s+[a-zA-Z]+");
            if (!regexn.IsMatch(name))
            {
                throw new ArgumentException("Name must satisfy this rules: Firstname Secondname");
            }

            Regex regexa = new Regex(@"[a-zA-Z]+\s+\d+\s+\d+");
            if (!regexa.IsMatch(address))
            {
                throw new ArgumentException("Address must satisfy this rules: Street 17 123");
            }

            Regex regexp = new Regex(@"\+\d{3}\s\d{2}\s\d{7}");
            if (!regexp.IsMatch(phoneNumber))
            {
                throw new ArgumentException("Number must satisfy this rules: +375 29 1234567");
            }

            for (int i = 0; i < 4; i++)
            {
                if (gradation == this.GRADATION[i])
                {
                    break;
                }

                if (i == 3)
                {
                    throw new ArgumentException("Invalid gradation");
                }
            }
        }
    }

}
