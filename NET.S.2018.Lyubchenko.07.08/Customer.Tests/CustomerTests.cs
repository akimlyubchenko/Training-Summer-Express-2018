using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Customer.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        [TestCase("NRCP", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
        [TestCase("NCP", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("N", ExpectedResult = "Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "1,000,000.00")]
        public string Customer_SomeCondition_Result(string format)
            => customer.ToString(format);

        [TestCase("NRCP", "en-US", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
        [TestCase("NR", "en-GB", ExpectedResult = "Jeffrey Richter, 1,000,000.00")]
        [TestCase("NCP", "en-US", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("RCP", "en-CA", ExpectedResult = "+1 (425) 555-0100, 1,000,000.00")]
        [TestCase("N", "ru-RU", ExpectedResult = "Jeffrey Richter")]
        [TestCase("R", "fr-CA", ExpectedResult = "1 000 000,00")]
        [TestCase("CP", "ru-RU", ExpectedResult = "+1 (425) 555-0100")]
        [TestCase(null, "ru-RU", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100, 1 000 000,00")]
        [TestCase("", "en-US", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
        public string Customer_SomeConditionWidthFormatProvider_Result(string format, string formatProvider)
            => customer.ToString(format, CultureInfo.GetCultureInfo(formatProvider));

        [TestCase("NR", ExpectedResult = "Jeffrey Richter, ¤1,000,000.000")]
        [TestCase("RCP", ExpectedResult = "+1 (425) 555-0100, ¤1,000,000.00")]
        public string CustomerFormat_Condition_DoneString(string format)
        {
            CustomerFormat customerformat = new CustomerFormat();
            return customerformat.Format(format, new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000)).ToString();
        }

        [TestCase("NRCP", "en-US", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
        [TestCase("NR", "en-GB", ExpectedResult = "Jeffrey Richter, £1,000,000.000")]
        [TestCase("NCP", "en-US", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("RCP", "en-CA", ExpectedResult = "+1 (425) 555-0100, $1,000,000.00")]
        [TestCase("N", "ru-RU", ExpectedResult = "Jeffrey Richter")]
        [TestCase("R", "fr-CA", ExpectedResult = "1 000 000,00 $")]
        [TestCase("CP", "ru-RU", ExpectedResult = "+1 (425) 555-0100")]
        [TestCase("NR", "ru-RU", ExpectedResult = "Jeffrey Richter, 1 000 000,000 ₽")]
        public string CustomerFormat_ConditionWidthFormatProvider_DoneString(string format, string formatProvider)
        {
            CustomerFormat customerformat = new CustomerFormat();
            return customerformat.Format(format, new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000),
                                                              CultureInfo.GetCultureInfo(formatProvider)).ToString();
        }
    }
}
