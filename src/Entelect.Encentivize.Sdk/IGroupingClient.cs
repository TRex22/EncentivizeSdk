using System.Collections.Generic;

namespace Entelect.Encentivize.Sdk
{
    public interface IGroupingClient
    {
        List<MemberGroup> GetGroups();
        MemberGroupDetails AddGroup(MemberGroup memberGroup);
        void UpdateGroup(MemberGroup memberGroup, int groupId);
        MemberGroup GetMemberGroup(int groupId);
        void DeleteMemberGroup(int groupId);
        List<Member> GetMembersInGroup(int groupId);
        void AddMemberToGroup(MemberGroupInput membergroup, int groupId);
        void RemoveMemberFromGroup(int groupId, int memberId);
        void UpdateMemberRole(int groupId, int MemberId, MemberGroupRoles role);
    }
}