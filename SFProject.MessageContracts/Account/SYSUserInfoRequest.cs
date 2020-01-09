using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Entity.Account;

namespace SFProject.MessageContracts.Account
{
    public class SYSUserInfoRequest : SYSUserInfo
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int RoleID { get; set; }

        public string StartCreateTime { get; set; }

        public string EndCreateTime { get; set; }
    }
}
