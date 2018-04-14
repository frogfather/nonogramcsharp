using NUnit.Framework;
using System;
namespace Nonogram.Tests
{
    [TestFixture()]
    public class GridTests
    {
        Grid testGrid = new Grid(8, 6);
        Grid fullGrid = new Grid(2, 2);
        Grid spaceGrid = new Grid(10,2);
        public GridTests()
        {            
            testGrid.GetCell(0,0).AutoValue = "cross";
            testGrid.GetCell(0,1).AutoValue = "cross";
            testGrid.GetCell(0,6).AutoValue = "cross";
            testGrid.GetCell(0,7).AutoValue = "cross";

            fullGrid.GetCell(0,0).AutoValue = "cross";
            fullGrid.GetCell(0,1).AutoValue = "cross";
            fullGrid.GetCell(1,0).AutoValue = "cross";
            fullGrid.GetCell(1,1).AutoValue = "cross";

            spaceGrid.GetCell(0,1).AutoValue = "cross";
            spaceGrid.GetCell(0,4).AutoValue = "cross";
            spaceGrid.GetCell(0,8).AutoValue = "cross";
        }

        [Test()]
        public void ColCountIsSix()
        {
            int colCount;
            colCount = testGrid.GetLength(false);
            Assert.AreEqual(6, colCount);
        }
        [Test()]
        public void RowCountIsEight()
        {
            int rowCount;
            rowCount = testGrid.GetLength(true);
            Assert.AreEqual(8, rowCount);
        }


        [Test()]
        public void FirstFreeSpaceIsTwo()
        {
            int freePos;
            freePos = testGrid.GetFirstFreeCell(0, false);
            Assert.AreEqual(2,freePos);
        }

        [Test()]
        public void LastFreeSpaceIsFive()
        {
            int freePos;
            freePos = testGrid.GetLastFreeCell(0, false);
            Assert.AreEqual(5, freePos);
        }

        [Test()]
        public void FirstReturnsNegOneIfNoFree()
        {
            int freePos;
            freePos = fullGrid.GetFirstFreeCell(0, false);
            Assert.AreEqual(-1, freePos);
        }
        [Test()]
        public void LastReturnsNegOneIfNoFree()
        {
            int freePos;
            freePos = fullGrid.GetLastFreeCell(0, false);
            Assert.AreEqual(-1, freePos);
        }
        [Test()]
        public void SpaceCountIsFour()
        {
            int spaceCount;
            spaceCount = spaceGrid.GetSpaces(0, false).getSpaceCount();
            Assert.AreEqual(4, spaceCount);
        }
        [Test()]
        public void FirstSpaceAtZero()
        {
            int spacePos;
            spacePos = spaceGrid.GetSpaces(0, false).getSpace(0).SpaceStart;
            Assert.AreEqual(0, spacePos);

        }

        [Test()]
        public void SecondSpaceAtTwo()
        {
            int spacePos;
            spacePos = spaceGrid.GetSpaces(0, false).getSpace(1).SpaceStart;
            Assert.AreEqual(2, spacePos);

        }
        [Test()]
        public void ThirdSpaceAtFive()
        {
            int spacePos;
            spacePos = spaceGrid.GetSpaces(0, false).getSpace(2).SpaceStart;
            Assert.AreEqual(5, spacePos);
        }
        
        [Test()]
        public void FourthSpaceLengthIsOne()
        {
            int spaceLength;
            spaceLength = spaceGrid.GetSpaces(0, false).getSpace(3).SpaceLength;
            Assert.AreEqual(1, spaceLength);
        }

    }
}
