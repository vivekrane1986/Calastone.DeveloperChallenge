using Calastone.ApplicationCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calastone.ApplicationCore
{
    public class FilterVowel : IFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var filterdList = source.ToList();
            Regex rgx = new Regex("[^a-zA-Z]");
            foreach (var data in source)
            {
                string item = rgx.Replace(data,"");
                var worldLength = item.Length;

                string centerText = null;
                var startIndex = worldLength % 2 == 0 ? (worldLength / 2)-1 : (worldLength / 2);

                try
                {
                    centerText = item.Substring(startIndex, worldLength <= 3 ? 1 : 2);
                    if (Regex.Matches(centerText, "[aeiou]", RegexOptions.IgnoreCase).Count() > 0)
                    {
                        filterdList.Remove(data);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"String is too small to find 2 middle words");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"String is too small to find 2 middle words");
                }
            }

            return filterdList;
        }
    }
}
