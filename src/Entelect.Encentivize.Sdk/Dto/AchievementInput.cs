using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class AchievementInput
    {
        public long AchievementId { get; set; }
        public int? OverriddenPoints { get; set; }
        public DateTime DateAchievementEarnedUtc { get; set; }
        public string Comment { get; set; }
    }
}
