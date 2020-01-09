using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Dao.System;
using SFProject.MessageContracts.System;

namespace SFProject.Biz.System
{
    public class LogService : BaseService
    {
        LogAccessor accessor = new LogAccessor();

        public void Log(LogRequest request)
        {
            if (request == null || request.LogHistory == null)
            {
                ArgumentNullException ex = new ArgumentNullException("EditUser request");
                LogError(ex);
            }
            try
            {
                accessor.Log(request.LogHistory);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
    }
}
