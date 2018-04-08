using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Nonogram
{
    [TestFixture()]
    public class IdentifyBlocksTests
    {
        Game testGame;
        public IdentifyBlocksTests()
        {
            GameData options = new GameData(new List<List<ClueData>>(), new List<List<ClueData>>(), 1, 30);
            testGame = new Game(options);
            //set some cells to black
            //this gives 4 blocks of 4,3,1 and 5
            for (int i = 0; i < 30;i++)
            {
                testGame.Grid().GetCell(i, 0).AutoValue = "clear";    
            }
            for (int i = 0; i < 8; i++)
            {
                testGame.Grid().GetCell(i, 0).AutoValue = "black";
            }
            for (int i = 9; i < 12; i++)
            {
                testGame.Grid().GetCell(i, 0).AutoValue = "black";
            }
                testGame.Grid().GetCell(14, 0).AutoValue = "black";
            for (int i = 16; i < 21; i++)
            {
                testGame.Grid().GetCell(i, 0).AutoValue = "black";
            }

            for (int i = 27; i < 30; i++)
            {
                testGame.Grid().GetCell(i, 0).AutoValue = "black";
            }
        }

        [Test()]
        public void IdentifyBlocksGetsCorrectBlockCount()
        {
            List<Block> blockData = AutoUtilities.GetBlockInfo(testGame.Grid(), 0, true);
            Assert.AreEqual(5,blockData.Count);
        }

        [Test()]
        public void FirstBlockHasLengthEight()
        {
            List<Block> blockData = AutoUtilities.GetBlockInfo(testGame.Grid(), 0, true);
            Assert.AreEqual(8, blockData[0].BlockLength);
        }

        [Test()]
        public void ThirdBlockStartsAtFourteen()
        {
            List<Block> blockData = AutoUtilities.GetBlockInfo(testGame.Grid(), 0, true);
            Assert.AreEqual(14, blockData[2].BlockStart);
        }

        [Test()]
        public void IdentifyBlocksCorrectlyIdentifiesBlockAtEndOfRow()
        {
            List<Block> blockData = AutoUtilities.GetBlockInfo(testGame.Grid(), 0, true);
            Assert.AreEqual(27, blockData[4].BlockStart);
        }

        [Test()]
        public void IdentifyBlocksCorrectlyIdentifiesBlockAtStartOfRow()
        {
            List<Block> blockData = AutoUtilities.GetBlockInfo(testGame.Grid(), 0, true);
            Assert.AreEqual(0, blockData[0].BlockStart);
        }
    }
}
