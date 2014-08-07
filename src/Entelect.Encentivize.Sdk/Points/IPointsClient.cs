namespace Entelect.Encentivize.Sdk.Points
{
    public interface IPointsClient
    {
        void AddAdhocPoints(long memberId, MemberAdhocInput adhocInput);
    }
}