using System.Collections.Generic;
using System.Linq;
using BucketNetting.Model;

namespace BucketNetting.Services
{
    public class AllocateToBucketService : IAllocateToBucketService
    {
        public List<Bucket> Allocate(Portfolio portfolio)
        {
            var buckets = new List<Bucket>()
            {
                new()
                {
                    Id = 1,
                    Assets = new()
                },
                new()
                {
                    Id = 2,
                    Assets = new()
                },
                new()
                {
                    Id = 3,
                    Assets = new()
                },
                new()
                {
                    Id = 4,
                    Assets = new()
                }
            };

            foreach (var asset in portfolio.Assets)
            {
                if (asset.Class is Class.Future)
                {
                    var maturity = (asset.MaturityDate - portfolio.DataDate).TotalDays;
                    var totalDays = maturity + maturity / (365 * 4);

                    switch (totalDays)
                    {
                        case >= 0 and < 365 * 2:
                            buckets[0].Assets.Add(asset);
                            break;
                        case > 365 * 2 and < 365 * 7:
                            buckets[1].Assets.Add(asset);
                            break;
                        case > 365 * 7 and < 365 * 15:
                            buckets[2].Assets.Add(asset);
                            break;
                        case > 365 * 15:
                            buckets[3].Assets.Add(asset);
                            break;
                    }
                }
            }

            return buckets;
        }

        public decimal GetMarketValue(List<Bucket> buckets)
        {
            return buckets.SelectMany(x => x.Assets).Sum(y => y.MarketValue);
        }
    }
}
