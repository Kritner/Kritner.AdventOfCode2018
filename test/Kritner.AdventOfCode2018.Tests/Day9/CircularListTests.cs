using Kritner.AdventOfCode2018.Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day9
{
    public class CircularListTests
    {
        private Test_CircularList<int> _subject;
        private class Test_CircularList<T> : CircularList<T>
        {
            public Test_CircularList(List<T> initialValues, int currentIndex, int listSize)
                : base(listSize)
            {
                List = initialValues;
                CurrentIndex = currentIndex;
            }
        }

        public static IEnumerable<object[]> TestDataCircularCheck =>
            new List<object[]>()
            {
                new object[]
                {
                    new int[] { 0 },
                    0,
                    1
                },
                new object[]
                {
                    new int[] { 0, 1 },
                    1,
                    1
                },
                new object[]
                {
                    new int[] { 0, 2, 1 },
                    1,
                    3
                },
                new object[]
                {
                    new int[] { 0, 2, 1, 3 },
                    3,
                    1
                },
                new object[]
                {
                    new int[] { 0, 4, 2, 1, 3 },
                    1,
                    3
                }
            };

        [Theory]
        [MemberData(nameof(TestDataCircularCheck))]
        public void ShouldReturnProperIndexRotatingClockWise(int[] testData, int currentIndex, int expectedIndex)
        {
            _subject = new Test_CircularList<int>(testData.ToList(), currentIndex, testData.Length + 1);

            var result = _subject.GetIndexRotatingClockWise(2);

            Assert.Equal(expectedIndex, result);
        }

        public static IEnumerable<object[]> TestDataAddValuesAndCheck =>
            new List<object[]>()
            {
                new object[]
                {
                    new int[] { 0 },
                    0,
                    1,
                    new int[] { 0, 1 }
                },
                new object[]
                {
                    new int[] { 0, 1 },
                    1,
                    2,
                    new int[] { 0, 2, 1 }
                },
                new object[]
                {
                    new int[] { 0, 2, 1 },
                    1,
                    3,
                    new int[] { 0, 2, 1, 3 }
                },
                new object[]
                {
                    new int[] { 0, 2, 1, 3 },
                    3,
                    4,
                    new int[] { 0, 4, 2, 1, 3 }
                },
                new object[]
                {
                    new int[] { 0, 4, 2, 1, 3 },
                    1,
                    5,
                    new int[] { 0, 4, 2, 5, 1, 3 }
                }
            };

        [Theory]
        [MemberData(nameof(TestDataAddValuesAndCheck))]
        public void ShouldCreateExpectedArrays(int[] testData, int currentIndex, int valueToInsert, int[] expectedData)
        {
            _subject = new Test_CircularList<int>(testData.ToList(), currentIndex, testData.Length + 1);

            var indexToInsertOnto = _subject.GetIndexRotatingClockWise(2);
            _subject.Add(indexToInsertOnto, valueToInsert);

            var resultingArray = _subject.UnderlyingList;

            Assert.Equal(expectedData, resultingArray);
        }

        public static IEnumerable<object[]> CounterClockwiseRotate =>
            new List<object[]>()
            {
                new object[]
                {
                    new[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                    4,
                    1,
                    3
                },
                new object[]
                {
                    new[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                    1,
                    1,
                    0
                },
                new object[]
                {
                    new[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                    1,
                    2,
                    7
                },
                new object[]
                {
                    new[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                    1,
                    4,
                    5
                },
            };


        [Theory]
        [MemberData(nameof(CounterClockwiseRotate))]
        public void ShouldCounterClockWiseRotate(int[] input, int currentIndex, int rotateAmount, int expectedIndex)
        {
            _subject = new Test_CircularList<int>(input.ToList(), currentIndex, input.Length + 1);

            var result = _subject.GetIndexRotatingCounterClockWise(rotateAmount);

            Assert.Equal(expectedIndex, result);
        }
    }
}
