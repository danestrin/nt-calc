using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NTUtils;

namespace NTUtilsTest;

[TestClass]
public class PrimeUtilsTest
{
    [TestMethod]
    public void TestPrimeSieve()
    {
        int n1 = 30;
        List<int> expected1 = new List<int>() {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29
        };

        int n2 = 0;
        int n3 = 1;
        List<int> empty = new List<int>();

        CollectionAssert.AreEqual(PrimeUtils.PrimeSieve(n1), expected1);
        CollectionAssert.AreEqual(PrimeUtils.PrimeSieve(n2), empty);
        CollectionAssert.AreEqual(PrimeUtils.PrimeSieve(n3), empty);
    }

    [TestMethod]
    public void TestPrimeFactorization()
    {
        int n1 = 30;
        Dictionary<int, int> expected1 = new Dictionary<int, int>() {
            {2, 1},
            {3, 1},
            {5, 1}
        };

        int n2 = 2166;
        Dictionary<int, int> expected2 = new Dictionary<int, int>() {
            {2, 1},
            {3, 1},
            {19, 2}
        };

        int n3 = 47;
        Dictionary<int, int> expected3 = new Dictionary<int, int>() {
            {47, 1}
        };

        int n4 = 32575;
        Dictionary<int, int> expected4 = new Dictionary<int, int>() {
            {5, 2},
            {1303, 1}
        };

        Assert.ThrowsException<ArgumentException>(() => PrimeUtils.PrimeFactorization(0));
        CollectionAssert.AreEqual(PrimeUtils.PrimeFactorization(n1), expected1);
        CollectionAssert.AreEqual(PrimeUtils.PrimeFactorization(n2), expected2);
        CollectionAssert.AreEqual(PrimeUtils.PrimeFactorization(n3), expected3);
        CollectionAssert.AreEqual(PrimeUtils.PrimeFactorization(n4), expected4);
    }

    [TestMethod]
    public void TestIsPrime()
    {
        Assert.IsTrue(PrimeUtils.IsPrime(2));
        Assert.IsFalse(PrimeUtils.IsPrime(843));
        Assert.IsTrue(PrimeUtils.IsPrime(12011));
    }

    [TestMethod]
    public void TestFermatFactorization()
    {
        long n1 = 42;
        long n2 = 6077;
        long n3 = 129001203;

        Tuple<long, long> expected2 = new Tuple<long, long>(103, 59);
        Tuple<long, long> expected3 = new Tuple<long, long>(20389, 6327);

        Assert.ThrowsException<ArgumentException>(() => PrimeUtils.FermatFactorization(n1));
        Assert.AreEqual(PrimeUtils.FermatFactorization(n2), expected2);
        Assert.AreEqual(PrimeUtils.FermatFactorization(n3), expected3);

    }
}