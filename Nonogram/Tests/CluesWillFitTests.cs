using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections;
namespace Nonogram.Tests
{
    [TestFixture()]
    public class CluesWillFitTests
    {
        SpaceData spaceData = new SpaceData(0, 16);
        List<SpaceData> spaceOptions = new List<SpaceData>();
        Spaces spaces1;

        BlockData block1data = new BlockData(2, 2, "black");
        BlockData block2data = new BlockData(5, 2, "black");
        BlockData block3data = new BlockData(10, 3, "black");
        List<BlockData> blockOptions = new List<BlockData>();
        Blocks blocks1;

        ClueData clue1data = new ClueData(3, "black");
        ClueData clue2data = new ClueData(4, "black");
        ClueData clue3data = new ClueData(4, "black");
        List<ClueData> clueOptions = new List<ClueData>();
        Clues clues1;

        public CluesWillFitTests()
        {
            spaceOptions.Add(spaceData);
            spaces1 = new Spaces(spaceOptions);

            blockOptions.Add(block1data);
            blockOptions.Add(block2data);
            blockOptions.Add(block3data);
            blocks1 = new Blocks(blockOptions);

            clueOptions.Add(clue1data);
            clueOptions.Add(clue2data);
            clueOptions.Add(clue3data);
            clues1 = new Clues(clueOptions);

        }

        [Test()]
        public void CluesWillFitInSpaces()
        {
            bool result = Autosolve.CluesWillFitInSpaces(clues1, spaces1, blocks1);
            Assert.IsTrue(result);
        }
    }
}
