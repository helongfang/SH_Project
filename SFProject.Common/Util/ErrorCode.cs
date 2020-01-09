using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFProject.Common.Util
{
    public enum ErrorCode : int
    {
        Unknown = 0,
        Argument = 1,
        Technical = 2,
        DataEffective = 3,
        Permission = 4,
        NoAuditor = 5,
    }
}
