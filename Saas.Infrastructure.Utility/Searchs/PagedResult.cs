using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Infrastructure.Utility.Searchs
{
    public class PagedResult<TItem>
    {
        public PagedResult(IEnumerable<TItem> items, long? count)
        {
            Items = items;
            Count = count;
        }

        public IEnumerable<TItem> Items { get; set; }

        public long? Count { get; set; }
    }
}
