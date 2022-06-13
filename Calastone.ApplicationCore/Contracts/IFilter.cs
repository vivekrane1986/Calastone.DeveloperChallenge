using System.Collections.Generic;

namespace Calastone.ApplicationCore.Contracts
{
    public interface IFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source);
               
    }
}
