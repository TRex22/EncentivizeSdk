using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using NLog;
using Entelect.Encentivize.Sdk.Exceptions;
using Entelect.Encentivize.Sdk.Dto;


namespace Entelect.Encentivize.Sdk
{

    public class EncentivizeSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseUrl { get; set; }
    }

    public class EncentivizeClient : IEncentivizeClient
    {

        EncentivizeSettings _settings { get; set; }
        Logger logger = LogManager.GetCurrentClassLogger();

        public EncentivizeClient(EncentivizeSettings settings)
        {
            _settings = settings;
        }

        #region Members

        public Member GetMemberByExternalReference(string externalReference)
        {
            var client = GetClient(); 
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("externalReferenceCode", externalReference);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public Member GetMemberByMobileNumber(string mobileNumber)
        {
            var client = GetClient();
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("mobileNumber", mobileNumber);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<PagedResult<Member>>(request);
 
            return response.Data.Data.FirstOrDefault();
        }

        public Member GetMemberByEmailAddress(string emailAddress)
        {
            var client = GetClient();
            var request = new RestRequest("members", Method.GET);
            request.AddParameter("emailAddress", emailAddress);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);

            return response.Data != null ? response.Data.Data.FirstOrDefault() : null;
        }

        public PagedResult<Member> GetMembers(int? pageSize, int? pageNumber)
        {
            var client = GetClient();
            var request = new RestRequest("members", Method.GET);

            request.RequestFormat = DataFormat.Json;

            if (pageSize != null)
            {
                request.AddParameter("$PageSize", pageSize);
            }

            if (pageNumber != null)
            {
                request.AddParameter("$PageNo", pageNumber);
            }
            
            var response = client.Execute<PagedResult<Member>>(request);

            return response.Data;
        }



        public void UpdateMember(MemberInput member, long encentivizeMemberId)
        {
            var client = GetClient(); 
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
        }

        public void UpdateMember(MemberUpdate member, long encentivizeMemberId)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + encentivizeMemberId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content);
        }

        public void AddMember(MemberInput member)
        {
            var client = GetClient(); 
            var request = new RestRequest("members", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(member);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
        }

        public Member GetMe()
        {
            var client = GetClient();
            var request = new RestRequest("members/me", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<Member>(request);
            return response.Data; 
        }

        public void ResetPasswordPin(long memberId)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("members/{0}/passwordPinReset",memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
        }

        #endregion 

        #region Groups


        public List<MemberGroup> GetGroups()
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
            return response.Data.Data;
        }


        public MemberGroupDetails AddGroup(MemberGroup memberGroup)
        {
            var client = GetClient();
            var request = new RestRequest("Groups", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute<MemberGroupDetails>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content);
            return response.Data; 

        }

        public void UpdateGroup(MemberGroup memberGroup, int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("Groups/" + groupId, Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroup);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
        }

        public MemberGroup GetMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest(string.Format("groups/{0}",groupId), Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
            return response.Data.Data.FirstOrDefault();
        }

        public void DeleteMemberGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<MemberGroup>>(request);
        }


        public List<Member> GetMembersInGroup(int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("groups", Method.GET);
            request.AddParameter("externalReferenceCode", groupId);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Member>>(request);
            return response.Data.Data;
        }

        public void AddMemberToGroup(MemberGroupInput memberGroupInput, int groupId)
        {
            var client = GetClient();
            var request = new RestRequest("Groups/" + groupId + "/Members", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(memberGroupInput);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
        }

        public void RemoveMemberFromGroup(int groupId, int memberId)
        {

        }

        public void UpdateMemberRole(int groupId, int MemberId, MemberGroupRoles role)
        {

        }
       
        #endregion

        public void AddAdhocPoints(long memberId, MemberAdhocInput adhocInput)
        {
            var client = GetClient(); 
            var request = new RestRequest(string.Format("members/{0}/AdHocPoints",memberId), Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(adhocInput);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 

        }



        #region Achievements

        public MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement)
        {
            var client = GetClient(); 
            var request = new RestRequest("members/" + memberId + "/achievements", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(achievement);
            var response = client.Execute<MemberAchievement>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content); 
            return response.Data; 
        }

        public MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement)
        {
            return AddAchievementForMember(member.MemberId, achievement);
        }

        #endregion

        #region Rewards

        public PagedResult<Reward> GetAvailableRewardsForMember(long memberId)
        {
            var client = GetClient(); 
            var request = new RestRequest("members/" + memberId + "/availableRewards", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<PagedResult<Reward>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content);
            return response.Data; 
        }

        public void RedeemReward(long memberId, long rewardId, int rewardCount)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + memberId + "/redeemReward", Method.POST);
            request.RequestFormat = DataFormat.Json;
            var rewardInput = new RedeemRewardInput
            {
                Quantity = rewardCount,
                RewardId = rewardId
            };

            request.AddBody(rewardInput);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EncentivizeException(response.Content);

        }

        #endregion 

        private RestClient GetClient()
        {
            var client = new RestClient(_settings.BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
            return client;
        }
    }



}
