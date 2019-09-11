using NUnit.Framework;
using Day13Lib;
using Day13Test.BSTTestHelper;

namespace Day13Test
{
    [TestFixture]
    public class BSTTest
    {
        [Test]
        public static void PreOrder_Int_Test()
        {
            BinarySearchTree<int> binSearch = new BinarySearchTree<int>();
            binSearch.Add(6);
            binSearch.Add(2);
            binSearch.Add(4);
            binSearch.Add(1);
            binSearch.Add(3);
            binSearch.Add(7);
            binSearch.Add(5);
            binSearch.Add(9);
            binSearch.Add(8);

            CollectionAssert.AreEqual(new int[] { 6, 2, 1, 4, 3, 5, 7, 9, 8}, binSearch.PreOrder());
        }

        [Test]
        public static void InOrder_Int_Test()
        {
            BinarySearchTree<int> binSearch = new BinarySearchTree<int>();
            binSearch.Add(6);
            binSearch.Add(2);
            binSearch.Add(4);
            binSearch.Add(1);
            binSearch.Add(3);
            binSearch.Add(7);
            binSearch.Add(5);
            binSearch.Add(9);
            binSearch.Add(8);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, binSearch.InOrder());
        }

        [Test]
        public static void PostOrder_Int_Test()
        {
            BinarySearchTree<int> binSearch = new BinarySearchTree<int>();
            binSearch.Add(6);
            binSearch.Add(2);
            binSearch.Add(4);
            binSearch.Add(1);
            binSearch.Add(3);
            binSearch.Add(7);
            binSearch.Add(5);
            binSearch.Add(9);
            binSearch.Add(8);
            CollectionAssert.AreEqual(new int[] { 1, 3, 5, 4, 2, 8, 9, 7, 6 }, binSearch.PostOrder());
        }

        [TestCase(5, ExpectedResult = 5)]
        [TestCase(25, ExpectedResult = null)]
        [TestCase(int.MinValue, ExpectedResult = null)]
        public static int? Int32Def_Find_Test(int find)
        {
            BinarySearchTree<int> binSearch = new BinarySearchTree<int>();
            binSearch.Add(6);
            binSearch.Add(2);
            binSearch.Add(4);
            binSearch.Add(1);
            binSearch.Add(3);
            binSearch.Add(7);
            binSearch.Add(5);
            binSearch.Add(9);
            binSearch.Add(8);

            return binSearch.FindNode(find)?.Data;
        }

        [TestCase(5, ExpectedResult = 5)]
        [TestCase(25, ExpectedResult = null)]
        [TestCase(int.MinValue, ExpectedResult = null)]
        public static int? Int32Comp_Find_Test(int find)
        {
            BinarySearchTree<int> binSearch = new BinarySearchTree<int>();
            binSearch.Add(70);
            binSearch.Add(2);
            binSearch.Add(4);
            binSearch.Add(1);
            binSearch.Add(3);
            binSearch.Add(7);
            binSearch.Add(5);
            binSearch.Add(9);
            binSearch.Add(8);

            return binSearch.FindNode(find, new IntHelper())?.Data;
        }

        [TestCase("Af", ExpectedResult = "Af")]
        [TestCase(null, ExpectedResult = null)]
        [TestCase("dddddd", ExpectedResult = null)]
        public static string StringDef_Find_Test(string find)
        {
            BinarySearchTree<string> binSearch = new BinarySearchTree<string>();
            binSearch.Add("Af");
            binSearch.Add("wed");
            binSearch.Add("we");
            binSearch.Add("ewedw");
            binSearch.Add("dw");

            return binSearch.FindNode(find)?.Data;
        }

        [TestCase("Af", ExpectedResult = "Af")]
        [TestCase(null, ExpectedResult = null)]
        [TestCase("dddddd", ExpectedResult = null)]
        public static string StringComp_Find_Test(string find)
        {
            BinarySearchTree<string> binSearch = new BinarySearchTree<string>();
            binSearch.Add("Af");
            binSearch.Add("wed");
            binSearch.Add("we");
            binSearch.Add("ewedt");
            binSearch.Add("dw");

            return binSearch.FindNode(find, new StringHelper())?.Data;
        }
    }
}
