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
        public void GetClueLengthReturnsCorrectLength()
        {
            Assert.AreEqual(12, testClues.GetClueLength());
        }

        [Test()]
        public void GetClueLengthReturnsCorrectLengthForSubrange()
        {
            Assert.AreEqual(5, testClues.GetClueLength(1,2));
        }

        [Test()]
        public void GetClueLengthReturnsCorrectLengthForColourClues()
        {
            Assert.AreEqual(17, colourClues.GetClueLength());
        }



    }
}
