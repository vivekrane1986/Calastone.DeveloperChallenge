// See https://aka.ms/new-console-template for more information

using Calastone.ApplicationCore;
using Calastone.ApplicationCore.Contracts;
using Calastrone.Infra;
using System.Reflection;

IFileParser fileParser = new TextFileParser();

Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
string filePath =  Path.Combine(Directory.GetCurrentDirectory(), "testSample.txt"); // $"{AppContext.BaseDirectory}/../../sampleTest.txt";

var fileContentByWords = fileParser.ReadFileContent(filePath);

FilterChain filterChain = new FilterChain(fileContentByWords);

FilterByLength filter1 = new FilterByLength();
filter1.MinFilterLength = 3;

FilterByChars filter2 = new FilterByChars();
filter2.CharactersToFilterString= new char[] { 't'};

FilterVowel filter3 = new FilterVowel();

filterChain.AddFilter(filter1);
filterChain.AddFilter(filter2);
filterChain.AddFilter(filter3);

filterChain.Execute();

Console.WriteLine(String.Join(' ',filterChain.Result.ToArray()));

