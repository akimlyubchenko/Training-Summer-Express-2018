using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Customer.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("nrcp", ExpectedResult = "Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("ncp", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("n", ExpectedResult = "Jeffrey Richter")]
        [TestCase("r", ExpectedResult = "1,000,000.00")]
        public string Customer_SomeCondition_Result(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return customer.ToString(format);
        }
    }
}
