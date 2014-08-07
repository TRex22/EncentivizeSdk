using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class MemberGroupType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgramId { get; set; }
        public int GroupCreationId { get; set; }
        public int GroupLevel { get; set; }
    }
}
