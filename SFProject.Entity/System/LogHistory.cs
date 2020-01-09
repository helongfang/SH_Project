using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Attribute;

namespace SFProject.Entity.System
{
   public class LogHistory
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("Time", "Time")]
        public DateTime Time { get; set; }

        [EntityPropertyExtension("Action", "Action")]
        public string Action { get; set; }
    }
}
