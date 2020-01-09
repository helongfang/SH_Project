using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Attribute;
using SFProject.Entity.Account;

namespace SFProject.MessageContracts.Account
{
    public class SYSUserInfoResponse : SYSUserInfo
    {
        [EntityPropertyExtension("RowCounts", "RowCounts")]
        public int RowCounts { get; set; }

        [EntityPropertyExtension("RoleID", "RoleID")]
        public int RoleID { get; set; }

        [EntityPropertyExtension("RoleName", "RoleName")]
        public string RoleName { get; set; }
    }
}
