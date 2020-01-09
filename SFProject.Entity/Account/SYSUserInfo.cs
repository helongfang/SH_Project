using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Attribute;

namespace SFProject.Entity.Account
{
    public class SYSUserInfo
    {
        [EntityPropertyExtension("ID", "ID")]
        public int ID { get; set; }

        [EntityPropertyExtension("UserName", "UserName")]
        public string UserName { get; set; }

        [EntityPropertyExtension("Password", "Password")]
        public string Password { get; set; }

        [EntityPropertyExtension("CompanyName", "CompanyName")]
        public string CompanyName { get; set; }

        [EntityPropertyExtension("BusinessContact", "BusinessContact")]
        public string BusinessContact { get; set; }

        [EntityPropertyExtension("FinancialContact", "FinancialContact")]
        public string FinancialContact { get; set; }

        [EntityPropertyExtension("Email", "Email")]
        public string Email { get; set; }

        [EntityPropertyExtension("Tel", "Tel")]
        public string Tel { get; set; }

        [EntityPropertyExtension("Address", "Address")]
        public string Address { get; set; }

        [EntityPropertyExtension("State", "State")]
        public int State { get; set; }

        [EntityPropertyExtension("UserType", "UserType")]
        public int UserType { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime CreateTime { get; set; }
    }
}
