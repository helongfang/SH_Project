using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Attribute;

namespace SFProject.Entity.System
{
   public class SYSMenu
    {
        [EntityPropertyExtension("ID", "ID")]
        public int ID { get; set; }

        [EntityPropertyExtension("SuperID", "SuperID")]
        public int SuperID { get; set; }

        [EntityPropertyExtension("MenuName", "MenuName")]
        public string MenuName { get; set; }

        [EntityPropertyExtension("Sort", "Sort")]
        public int Sort { get; set; }

        [EntityPropertyExtension("Link", "Link")]
        public string Link { get; set; }

        [EntityPropertyExtension("Icon", "Icon")]
        public string Icon { get; set; }

        [EntityPropertyExtension("IsValid", "IsValid")]
        public int IsValid { get; set; }
    }
}
