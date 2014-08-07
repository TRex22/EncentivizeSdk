namespace Entelect.Encentivize.Sdk
{
    public interface IRewardClient
    {
        PagedResult<Reward> GetAvailableRewardsForMember(long memberId);
        void RedeemReward(long memberId, long rewardId, int rewardCount);
    }
}