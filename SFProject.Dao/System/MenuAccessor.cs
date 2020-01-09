using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.ExtensionMethods;
using SFProject.Entity.DataBaseEntity;
using SFProject.Entity.System;

namespace SFProject.Dao.System
{
    public class MenuAccessor : BaseAccessor
    {
        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns>菜单列表</returns>
        public IEnumerable<SYSMenu> GetMenuByRoleID(int RoleID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@RoleID", DbType.Int32, RoleID, ParameterDirection.Input)
            };
            return this.ExecuteDataTable("Proc_GetMenuByRoleID", dbParams).ConvertToEntityCollection<SYSMenu>();
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns>菜单列表</returns>
        public IEnumerable<SYSMenu> GetAllMenuList()
        {
            return this.ExecuteDataTable("Proc_GetAllMenu").ConvertToEntityCollection<SYSMenu>();
        }
    }
}
