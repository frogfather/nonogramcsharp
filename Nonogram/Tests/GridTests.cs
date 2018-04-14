using NUnit.Framework;
using System;
namespace Nonogram.Tests
{
    [TestFixture()]
    public class GridTests
    {
        Grid testGrid = new Grid(8, 6);
        Grid fullGrid = new Grid(2, 2);
        public GridTests()
        {            
            testGrid.GetCell(0,0).AutoValue = "cross";
            testGrid.GetCell(0,1).AutoValue = "cross";
            testGrid.GetCell(0,7).AutoValue = "cross";
            testGrid.GetCell(0,6).AutoValue = "cross";
            fullGrid.GetCell(0,0).AutoValue = "cross";
            fullGrid.GetCell(0,1).AutoValue = "cross";
            fullGrid.GetCell(1,0).AutoValue = "cross";
            fullGrid.GetCell(1,1).AutoValue = "cross";
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

    }
}
