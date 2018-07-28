using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class Book : IComparable<Book>
    {
        private readonly string name;
        private readonly string containsText;

        public Book(string bookName, string text)
        {
            name = bookName;
            containsText = text;
        }

        public int CompareTo(Book other)
            => name.CompareTo(other.name);
    }
}
