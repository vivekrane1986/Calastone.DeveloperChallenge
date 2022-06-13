using Calastone.ApplicationCore.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calastone.ApplicationCore
{
    public class FilterByLength : IFilter
    {
        public int? MinFilterLength { get; set; }

        public int? MaxFilterLength { get; set; }
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var filteredList=source.ToList();
            Regex rgx = new Regex("[^a-zA-Z]");

            foreach (var data in source)
            {
                var item = rgx.Replace(data, "");
                if (MinFilterLength.HasValue && item.Length<MinFilterLength.Value)
                {
                    filteredList.Remove(data);
                }
                if(MaxFilterLength.HasValue && item.Length>MaxFilterLength.Value)
                {
                    filteredList.Remove(data);
                }
            }

            return filteredList;
        }
    }
}
