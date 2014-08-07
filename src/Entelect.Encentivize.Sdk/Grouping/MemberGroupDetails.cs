using System;

namespace Entelect.Encentivize.Sdk.Grouping
{
    public class MemberGroupDetails
    {
        public int GroupId { get; set; }
        public int GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Createdby { get; set; }
        public DateTime CreatedDateUct { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDateUct { get; set; }
        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
    }
}
