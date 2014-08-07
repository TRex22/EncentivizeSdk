using Entelect.Encentivize.Sdk.Dto;

namespace Entelect.Encentivize.Sdk
{
    public interface IPointsClient
    {
        void AddAdhocPoints(long memberId, MemberAdhocInput adhocInput);
    }
}