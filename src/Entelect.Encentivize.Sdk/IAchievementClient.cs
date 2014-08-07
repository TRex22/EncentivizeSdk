namespace Entelect.Encentivize.Sdk
{
    public interface IAchievementClient
    {
        MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement);
        MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement); 
    }
}