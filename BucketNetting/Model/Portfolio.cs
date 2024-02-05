using System;

namespace BucketNetting.Model
{
    public class Portfolio
    {
        public DateTime DataDate { get; set; }
        public Asset[] Assets { get; set; }
    }
}
