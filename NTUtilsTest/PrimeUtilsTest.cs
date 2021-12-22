using Microsoft.VisualStudio.TestTools.UnitTesting;
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
}