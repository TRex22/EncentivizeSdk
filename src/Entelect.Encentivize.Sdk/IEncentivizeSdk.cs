using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entelect.Encentivize.Sdk.Dto;

namespace Entelect.Encentivize.Sdk
{
    public interface IEncentivizeClient
    {
        Member GetMemberByExternalReference(string externalReference);
        Member GetMemberByMobileNumber(string mobileNumber);
        Member GetMemberByEmailAddress(string emailAddress);
        PagedResult<Member> GetMembers(int? pageSize, int? pageNumber);
        Member GetMe();

        void ResetPasswordPin(long memberId); 

        void UpdateMember(MemberInput customer, long encentivizeMemberId);

        //This update includes Earn/Burn properties
        void UpdateMember(MemberUpdate customer, long encentivizeMemberId);
        void AddMember(MemberInput customer);
        MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement);
        MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement); 

        PagedResult<Reward> GetAvailableRewardsForMember(long memberId);
        void RedeemReward(long memberId, long rewardId, int rewardCount);

        
        List<MemberGroup> GetGroups();
        MemberGroupDetails AddGroup(MemberGroup memberGroup);
        void UpdateGroup(MemberGroup memberGroup, int groupId);
        MemberGroup GetMemberGroup(int groupId);
        void DeleteMemberGroup(int groupId);

        List<Member> GetMembersInGroup(int groupId);
        void AddMemberToGroup(MemberGroupInput membergroup, int groupId);
        void RemoveMemberFromGroup(int groupId, int memberId);
        void UpdateMemberRole(int groupId, int MemberId, MemberGroupRoles role);

        void AddAdhocPoints(long memberId, MemberAdhocInput adhocInput);


    }
}
