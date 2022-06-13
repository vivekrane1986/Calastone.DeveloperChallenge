using Calastone.ApplicationCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calastone.ApplicationCore
{
    public class FilterByChars : IFilter
    {
        public char[] CharactersToFilterString { get; set; }
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var filteredList = source.ToList();
            Regex rgx = new Regex("[^a-zA-Z]");

            if (CharactersToFilterString!=null && CharactersToFilterString.Any())
            {
                string filterText = new string( CharactersToFilterString);
                foreach (var data in source)
                {
                    var item = rgx.Replace(data, "");
                    if (Regex.Matches(item, filterText, RegexOptions.IgnoreCase).Count() > 0)
                    {
                        filteredList.Remove(data);
                    }
                }
            }else
            {
                throw new ArgumentOutOfRangeException("Please provide characters to filter string");
            }

            return filteredList;
            
        }
    }
}
