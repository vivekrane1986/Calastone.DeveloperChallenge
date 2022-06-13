
using NUnit.Framework;
using System;

namespace Calastrone.Infra.Tests
{
    [TestFixture]
    public class FileParserTest
    {
        [Test]
        public void ValidateFileReadSuccess()
        {            
            TextFileParser textFileParser = new TextFileParser();
            string filePath = $"{AppContext.BaseDirectory}/../../sampleTest.txt";
            var data=textFileParser.ReadFileContent(filePath);

            Assert.IsNotNull(data);
        }
    }
}
