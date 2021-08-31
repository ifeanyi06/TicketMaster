using System;
using Xunit;
using TicketMaster;
using TicketMaster.Utility;
using TicketMaster.Models;
using System.Collections.Generic;

namespace TicketMasterUnitTests
{
    public class RangeUnitTest
    {
        [Fact]
        public void ValidateRangeShouldReturnTrue()
        {
            Assert.True(TicketMaster.Utility.Range.isValidRange("1-20"));
        }

        [Fact]
        public void ValidateRangeForMismatchedIntegerShouldReturnFalse()
        {
            Assert.False(TicketMaster.Utility.Range.isValidRange("20-1"));
        }

        [Fact]
        public void GetRangeShouldReturnCorrectNumberOfInteger()
        {
            int count = TicketMaster.Utility.Range.GetRange("1-20").Count;
            Assert.Equal(20, count);
        }

        [Fact]
        public void GetRangeShouldReturnCorrectInteger()
        {
            List<int> expected = new List<int>();
            expected.AddRange(new int[5] { 1, 2, 3, 4, 5 });
            List<int> actual = TicketMaster.Utility.Range.GetRange("1-5");
            Assert.Equal(expected, actual);

            expected.Clear();
            actual.Clear();
            expected.AddRange(new int[7] { 3, 4, 5, 6, 7, 8, 9 });
            actual = TicketMaster.Utility.Range.GetRange("3-9");
            Assert.Equal(expected, actual);

        }


    }
}
