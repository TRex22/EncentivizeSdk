using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class MemberGroup
    {
        public int GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
    }
}
