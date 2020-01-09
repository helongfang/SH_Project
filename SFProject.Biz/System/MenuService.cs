using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Util;
using SFProject.Dao.System;
using SFProject.Entity.System;
using SFProject.MessageContracts;

namespace SFProject.Biz.System
{
   public class MenuService : BaseService
    {
        private MenuAccessor accessor = new MenuAccessor();

        public Response<IEnumerable<SYSMenu>> GetMenuByRoleID(int RoleID)
        {
            Response<IEnumerable<SYSMenu>> response = new Response<IEnumerable<SYSMenu>>();
            try
            {
                response.Result = accessor.GetMenuByRoleID(RoleID);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
                response.Exception = ex;
            }
            return response;
        }

        public Response<IEnumerable<SYSMenu>> GetAllMenuList()
        {
            Response<IEnumerable<SYSMenu>> response = new Response<IEnumerable<SYSMenu>>();
            try
            {
                response.Result = accessor.GetAllMenuList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
                response.Exception = ex;
            }
            return response;
        }

    }
}
