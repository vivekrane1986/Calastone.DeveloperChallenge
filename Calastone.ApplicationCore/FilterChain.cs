using Calastone.ApplicationCore.Contracts;
using System.Collections.Generic;

namespace Calastone.ApplicationCore
{
    public class FilterChain
    {
        private List<IFilter> _filters;
        private readonly IEnumerable<string> _source;

        public IEnumerable<string> Result { get; private set; }

        public FilterChain(IEnumerable<string> source)
        {
            _filters = new List<IFilter>();
            _source = source;
        }

        public void AddFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public void Execute()
        {
            Result = _source;
            foreach (var filter in _filters)
            {
                Result = filter.Filter(Result);
            }
        }


    }
}
