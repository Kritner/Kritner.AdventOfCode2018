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
        private class Test_CircularList<T> : CircularLinkedList<T>
        {
            public Test_CircularList(LinkedList<T> initialValues, T currentItem)
            {
                List = initialValues;

                CurrentItem = List.Find(currentItem);
            }
        }

        public static IEnumerable<object[]> TestDataCircularCheck =>
            new List<object[]>()
            {
                new object[]
                {
                    new int[] { 0 },
                    0,
                    0
                },
                new object[]
                {
                    new int[] { 0, 1 },
                    1,
                    0
                },
                new object[]
                {
                    new int[] { 0, 2, 1 },
                    2,
                    1
                },
                new object[]
                {
                    new int[] { 0, 2, 1, 3 },
                    3,
                    0
                },
                new object[]
                {
                    new int[] { 0, 4, 2, 1, 3 },
                    4,
                    2
                }
            };

        [Theory]
        [MemberData(nameof(TestDataCircularCheck))]
        public void ShouldReturnProperItemRotatingClockWise(int[] testData, int currentItem, int expectedItem)
        {
            _subject = new Test_CircularList<int>(new LinkedList<int>(testData), currentItem);

            var result = _subject.GetNext(1);

            Assert.Equal(expectedItem, result);
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
                    2,
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
                    4,
                    5,
                    new int[] { 0, 4, 2, 5, 1, 3 }
                }
            };

        [Theory]
        [MemberData(nameof(TestDataAddValuesAndCheck))]
        public void ShouldCreateExpectedArrays(int[] testData, int currentItem, int valueToInsert, int[] expectedItems)
        {
            _subject = new Test_CircularList<int>(new LinkedList<int>(testData), currentItem);

            var insertOnto = _subject.GetNext(1);
            _subject.Add(valueToInsert);

            var resultingArray = _subject.List;

            Assert.Equal(expectedItems, resultingArray);
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
        public void ShouldCounterClockWiseRotate(int[] input, int currentItem, int rotateAmount, int expectedItem)
        {
            _subject = new Test_CircularList<int>(new LinkedList<int>(input), currentItem);

            var result = _subject.GetPrevious(rotateAmount);

            Assert.Equal(expectedItem, result);
        }
    }
}
