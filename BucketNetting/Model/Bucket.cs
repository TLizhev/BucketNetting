using System.Collections.Generic;

namespace BucketNetting.Model
{
    public class Bucket
    {
        public int Id { get; set; }
        public List<Asset> Assets { get; set; }
    }
}
