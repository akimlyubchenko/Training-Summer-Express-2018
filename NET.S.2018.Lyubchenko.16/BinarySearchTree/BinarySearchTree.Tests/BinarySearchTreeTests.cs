using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void BinarySearchTreePreInt()
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new int[] { 5 });
            int[] arr = new int[] { 3, 1, 7, 9 };
            for (int i = 0; i < arr.Length; i++)
            {
                actual.Add(arr[i]);
            }

            actual.Add(2);
            actual.Add(8);

            IEnumerable<int> expected = new int[] { 5, 3, 1, 2, 7, 9, 8 };

            CollectionAssert.AreEqual(expected, actual.PreOrder());
        }

        [Test]
        public void BinarySearchTreeInInt()
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new int[] { 5 });
            int[] arr = new int[] { 3, 1, 7, 9 };
            for (int i = 0; i < arr.Length; i++)
            {
                actual.Add(arr[i]);
            }

            actual.Add(2);
            actual.Add(8);

            IEnumerable<int> expected = new int[] { 1, 2, 3, 5, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual.InOrder());
        }

        [Test]
        public void BinarySearchTreePostInt()
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new int[] { 5 });
            int[] arr = new int[] { 3, 1, 7, 9 };
            for (int i = 0; i < arr.Length; i++)
            {
                actual.Add(arr[i]);
            }

            actual.Add(2);
            actual.Add(8);

            IEnumerable<int> expected = new int[] { 2, 1, 3, 8, 9, 7, 5 };

            CollectionAssert.AreEqual(expected, actual.PostOrder());
        }

        [Test]
        public void BinarySearchTreePreString()
        {
            BinarySearchTree<string> actual = new BinarySearchTree<string>();
            actual.Add("f");
            actual.Add("a");
            actual.Add("e");
            actual.Add("j");
            actual.Add("x");
            actual.Add("g");

            IEnumerable<string> expected = new string[] { "f", "a", "e", "j", "g", "x" };

            CollectionAssert.AreEqual(expected, actual.PreOrder());
        }

        [Test]
        public void BinarySearchTreeInOrderBook()
        {
            BinarySearchTree<Book> actual = new BinarySearchTree<Book>();
            Book book1 = new Book("Adams", "asdasdad");
            Book book2 = new Book("Merge", "asdasasdaddad");
            Book book3 = new Book("QuickSort", "asdlj2l3asdad");
            Book book4 = new Book("BinarySearcher", "asdasd32asdasdad");
            actual.Add(book1);
            actual.Add(book2);
            actual.Add(book3);
            actual.Add(book4);

            IEnumerable<Book> expected = new Book[] { book1, book4, book2, book3 };

            CollectionAssert.AreEqual(expected, actual.InOrder());

            //Dont undestand rule width Point, I have some questions
        }
    }
}
