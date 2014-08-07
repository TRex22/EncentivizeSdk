using Entelect.Encentivize.Sdk.Exceptions;
using RestSharp;

namespace Entelect.Encentivize.Sdk
{
    public class AchievementClient: EncentivizeClientBase, IAchievementClient
    {
        public AchievementClient(EncentivizeSettings settings) 
            : base(settings)
        {
        }

        public MemberAchievement AddAchievementForMember(long memberId, AchievementInput achievement)
        {
            var client = GetClient();
            var request = new RestRequest("members/" + memberId + "/achievements", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(achievement);
            var response = client.Execute<MemberAchievement>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new CreationFailedException(response.Content);
            return response.Data;
        }

        public MemberAchievement AddAchievementForMember(Member member, AchievementInput achievement)
        {
            return AddAchievementForMember(member.MemberId, achievement);
        }
    }
}