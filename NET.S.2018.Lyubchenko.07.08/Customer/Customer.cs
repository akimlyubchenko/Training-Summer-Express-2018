using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Customer
{
    /// <summary>
    /// create customer's description
    /// </summary>
    /// <seealso cref="System.IFormattable" />
    public class Customer : IFormattable
    {
        /// <summary>
        /// Gets the customer's name.
        /// </summary>
        /// <value>
        /// The input name.
        /// </value>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the customer's contact phone.
        /// </summary>
        /// <value>
        /// The input contact phone.
        /// </value>
        public string ContactPhone
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the customer's revenue.
        /// </summary>
        /// <value>
        /// The input revenue.
        /// </value>
        public decimal Revenue
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new ctor of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="contactPhone">The contact phone.</param>
        /// <param name="revenue">The revenue.</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Validator(name, contactPhone, revenue);
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// Done description
        /// </returns>
        public override string ToString()
            => $"{Name} {ContactPhone} {Revenue}";

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// Done description
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NRCP";
            }

            return IFormatProviderToStringHelper(format.ToUpperInvariant(), formatProvider);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// Done description
        /// </returns>
        public string ToString(string format)
            => ToString(format, CultureInfo.InvariantCulture);

        /// <summary>
        /// is the format provider to string helper.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns> Done string which return description </returns>
        /// <exception cref="FormatException"> Invalid format </exception>
        private string IFormatProviderToStringHelper(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "NRCP":
                    return $"{Name}, {ContactPhone}, {Revenue.ToString("N", formatProvider)}";
                case "N":
                    return $"{Name}";
                case "CP":
                    return $"{ContactPhone}";
                case "R":
                    return $"{Revenue.ToString("N", formatProvider)}";
                case "NCP":
                    return $"{Name}, {ContactPhone}";
                case "NR":
                    return $"{Name}, {Revenue.ToString("N", formatProvider)}";
                case "RCP":
                    return $"{ContactPhone}, {Revenue.ToString("N", formatProvider)}";
                default:
                    throw new FormatException(nameof(format));
            }
        }

        /// <summary>
        /// Validators of the description
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="contactPhone">The contact phone.</param>
        /// <param name="revenue">The revenue.</param>
        /// <exception cref="ArgumentException">
        /// Check if fields is valid
        /// </exception>
        private void Validator(string name, string contactPhone, decimal revenue)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} must contain name");
            }

            if (!Regex.IsMatch(name , @"^([A-Z][a-z]*\s)*[A-Z][a-z]*$"))
            {
                throw new ArgumentException($"{nameof(name)} must have only symbols a(A) - z(Z)");
            }

            if (string.IsNullOrEmpty(contactPhone))
            {
                throw new ArgumentException($"{nameof(contactPhone)} must contain phone");
            }

            if (revenue < 0)
            {
                throw new ArgumentException($"{nameof(revenue)} must be positive");
            }
        }
    }
}