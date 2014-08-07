using System;

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
