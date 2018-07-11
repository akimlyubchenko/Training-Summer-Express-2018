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
    public class Customer : IFormattable
    {
        public string Name
        {
            get;
            private set;
        }

        public string ContactPhone
        {
            get;
            private set;
        }

        public decimal Revenue
        {
            get;
            private set;
        }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Validator(name, contactPhone, revenue);
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        public override string ToString()
            => $"{Name} {ContactPhone} {Revenue}";

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "nrcp";
            }

            return IFormatProviderToString(format.ToLowerInvariant(), formatProvider);
        }

        public string ToString(string format)
            => ToString(format, CultureInfo.InvariantCulture);

        private string IFormatProviderToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "nrcp":
                    return $"{Name}, {Revenue.ToString("n", formatProvider)}, {ContactPhone}";
                case "n":
                    return $"{Name}";
                case "cp":
                    return $"{ContactPhone}";
                case "r":
                    return $"{Revenue.ToString("n", formatProvider)}";
                case "ncp":
                    return $"{Name}, {ContactPhone}";
                case "nr":
                    return $"{Name}, {Revenue.ToString("n", formatProvider)}";
                case "rcp":
                    return $"{Revenue.ToString("n", formatProvider)}, {ContactPhone}";
                default:
                    throw new FormatException(nameof(format));
            }
        }

        private void Validator(string name, string contactPhone, decimal revenue)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} must contain name");
            }

            if (!Regex.IsMatch(name , @"^([A-Z][a-z]*\s)*[A-Z][a-z]*$"))
            {
                throw new FormatException($"{nameof(name)} must have only symbols a(A) - z(Z)");
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