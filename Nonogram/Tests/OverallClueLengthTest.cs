using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Nonogram.Tests
{
    [TestFixture()]
    public class OverallClueLengthTests
    {
        Clues testClues;
        Clues colourClues;
        List<ClueData> testClueData;
        List<ClueData> colourClueData;

        public OverallClueLengthTests()
        {
            testClueData = new List<ClueData>();
            testClueData.Add(new ClueData(2,"black"));
            testClueData.Add(new ClueData(5, "black"));
            testClueData.Add(new ClueData(3, "black"));
            testClues = new Clues(testClueData);
            colourClueData = new List<ClueData>();
            colourClueData.Add(new ClueData(2, "red"));
            colourClueData.Add(new ClueData(5, "green"));
            colourClueData.Add(new ClueData(7, "green"));
            colourClueData.Add(new ClueData(2, "red"));
            colourClues = new Clues(colourClueData); 
        }

        [Test()]
        public void OverallClueLengthReturnsCorrectLength()
        {
            Assert.AreEqual(12, testClues.GetoverallClueLength());
        }

        [Test()]
        public void OverallClueLengthReturnsCorrectLengthForColourClues()
        {
            Assert.AreEqual(17, colourClues.GetoverallClueLength());
        }


    }
}
