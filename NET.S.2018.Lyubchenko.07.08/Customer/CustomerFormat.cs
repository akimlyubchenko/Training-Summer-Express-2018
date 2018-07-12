using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    /// <summary>
    /// Format changer
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class CustomerFormat : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg)
            => Format(format, arg, CultureInfo.InvariantCulture);
        /// <summary>
        /// Change format of Customer
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg"> Customer instance </param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns> Changed description </returns>
        /// <exception cref="FormatException">Customer</exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NRCP";
            }

            if (arg.GetType() != typeof(Customer))
            {
                throw new FormatException($"argument must be equal {nameof(Customer)} type");
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.InvariantCulture;
            }

            Customer customer = (Customer)arg;
            switch (format)
            {
                case "NRCP":
                    return $"{customer.Name}, {customer.ContactPhone}, {customer.Revenue.ToString("N", formatProvider)}";
                case "N":
                    return $"{customer.Name}";
                case "CP":
                    return $"{customer.ContactPhone}";
                case "R":
                    return $"{customer.Revenue.ToString("C2", formatProvider)}";
                case "NCP":
                    return $"{customer.Name}, {customer.ContactPhone}";
                case "NR":
                    return $"{customer.Name}, {customer.Revenue.ToString("C3", formatProvider)}";
                case "RCP":
                    return $"{customer.ContactPhone}, {customer.Revenue.ToString("C", formatProvider)}";
                default:
                    throw new FormatException(nameof(format));
            }
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object , if the <see cref="T:System.IFormatProvider" /> 
        /// implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
            => formatType == typeof(ICustomFormatter) ? this : null;

    }
}
