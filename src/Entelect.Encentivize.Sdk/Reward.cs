using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class Reward
    {
        public long RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsCost { get; set; }
        public string TermsAndConditions { get; set; }
        public string PrimaryImageUrl { get; set; }
    }
}
