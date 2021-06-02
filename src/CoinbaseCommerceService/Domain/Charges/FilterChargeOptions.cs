using System;
using System.Collections.Generic;

namespace CoinbaseCommerceService.Domain.Charges
{
    public class FilterChargeOptions
    {
        public SortBy SortBy = SortBy.Desc;

        public Guid? StartingAfterId = null;

        public Guid? EndingBeforeId = null;

        public uint Limit = 25;

        public Dictionary<string, object> GetQuery()
        {
            return new()
            {
                {"order", SortBy.ToString()},
                {"starting_after", StartingAfterId},
                {"ending_before", EndingBeforeId},
                {"limit", Limit},
            };
        }
    }
}