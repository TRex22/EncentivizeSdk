using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class MemberInput
    {
        public long StructureId { get; set; }
        public int MemberStatusId { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string ExternalReferenceCode { get; set; }
        public int MemberTypeId { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
