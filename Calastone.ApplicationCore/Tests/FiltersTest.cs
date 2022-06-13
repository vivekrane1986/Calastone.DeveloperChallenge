using NUnit.Framework;
using System.Collections.Generic;

namespace Calastone.ApplicationCore.Tests
{
    [TestFixture]
    public class FiltersTest
    {
        [Test]
        public void TestVowelFilterSuccess()
        {
            //Setup
            List<string> sampleSource = new List<string>() { "clean", "what", "currently", "the", "rather", "wHat", "ClEan" };
            List<string> expectedResult = new List<string>() { "the", "rather" };
            //Act
            FilterVowel filter = new FilterVowel();
            var actual = filter.Filter(sampleSource);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }

        [Test]
        public void FilterByLengthSuccess()
        {
            //Setup
            List<string> sampleSource = new List<string>() { "the", "it", "I", "rather", "ClEan" };
            List<string> expectedResult = new List<string>() { "the", "rather" , "ClEan" };
            //Act
            FilterByLength filter = new FilterByLength();
            filter.MinFilterLength = 3;
            var actual = filter.Filter(sampleSource);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }

        [Test]
        public void FilterByCharactersSuccess()
        {
            //Setup
            List<string> sampleSource = new List<string>() { "the", "iT", "I", "rather", "ClEan" };
            List<string> expectedResult = new List<string>() { "I","ClEan" };
            //Act
            FilterByChars filter = new FilterByChars();
            filter.CharactersToFilterString = new char[] {'t'};
            var actual = filter.Filter(sampleSource);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }
    }
}
