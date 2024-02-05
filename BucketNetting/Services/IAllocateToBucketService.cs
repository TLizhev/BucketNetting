using System.Collections.Generic;
using BucketNetting.Model;

namespace BucketNetting.Services
{
    public interface IAllocateToBucketService
    {
        List<Bucket> Allocate(Portfolio portfolio);
        void GetMarketValue(List<Bucket> buckets);
    }
}
