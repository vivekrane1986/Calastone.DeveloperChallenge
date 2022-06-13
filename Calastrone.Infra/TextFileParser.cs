using Calastone.ApplicationCore.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace Calastrone.Infra
{
    public class TextFileParser : IFileParser
    {
        public IEnumerable<string> ReadFileContent(string filePath)
        {
            var fileWords = new List<string>();

            try
            {
                using (var mappedFile = MemoryMappedFile.CreateFromFile(filePath))
                {
                    using (var stream = mappedFile.CreateViewStream())
                    {
                        using (var streamReader = new StreamReader(stream, ASCIIEncoding.ASCII))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                fileWords.AddRange(streamReader.ReadLine().Split(' '));
                            }
                        }
                    }
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return fileWords;

        }

        
        
    }
}