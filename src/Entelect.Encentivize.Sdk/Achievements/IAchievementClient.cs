using Entelect.Encentivize.Sdk.Members;

namespace Entelect.Encentivize.Sdk.Achievements
{
    public interface IAchievementClient
    {
        MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement);
        MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement); 
    }
}