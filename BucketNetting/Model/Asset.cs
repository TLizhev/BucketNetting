using System;

namespace BucketNetting.Model
{
    public class Asset
    {
        public string Id { get; set; }
        public Class Class { get; set; }
        public decimal MarketValue { get; set; }
        public DateTime MaturityDate { get; set; }
        //enum for type of asset
    }

    public enum Class
    {
        Future,
        Equity
    }
}