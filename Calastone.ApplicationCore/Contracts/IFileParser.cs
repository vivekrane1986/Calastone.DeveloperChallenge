using System.Collections.Generic;

namespace Calastone.ApplicationCore.Contracts
{
    public interface IFileParser
    {
        IEnumerable<string> ReadFileContent(string filePath);
    }
}