using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.SqlServer.Server;

namespace SFProject.Entity.DataBaseEntity
{
   public class IdsForInt64 : SqlDataRecord
    {
        public IdsForInt64(long id)
          : base(s_metadata)
        {
            SetInt64(0, id);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID",SqlDbType.BigInt)
        };
    }
}
