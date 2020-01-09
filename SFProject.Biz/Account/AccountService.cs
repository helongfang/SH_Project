using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.Util;
using SFProject.Dao.Account;
using SFProject.MessageContracts;
using SFProject.MessageContracts.Account;

namespace SFProject.Biz.Account
{
    public class AccountService : BaseService
    {
        private AccoutAccessor accessor = new AccoutAccessor();

        public SYSUserInfoResponse VerificationLogin(string UserName, string Password)
        {
            try
            {
                return accessor.VerificationLogin(UserName, Password);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public Response<IEnumerable<SYSUserInfoResponse>> GetUserList(SYSUserInfoRequest request)
        {
            Response<IEnumerable<SYSUserInfoResponse>> response = new Response<IEnumerable<SYSUserInfoResponse>>();
            try
            {
                response.Result = accessor.GetUserList(request);
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

        public Response<bool> UpdateSYSUserInfo(SYSUserInfoRequest request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                accessor.UpdateSYSUserInfo(request);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<bool> DeleteSYSUserInfo(string IDs)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                accessor.DeleteSYSUserInfo(IDs);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<bool> AddSYSUserInfo(SYSUserInfoRequest request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                accessor.AddSYSUserInfo(request);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<bool> CheckNameIsExist(SYSUserInfoRequest request)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.IsSuccess = accessor.CheckNameIsExist(request.UserName, request.ID);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<bool> UpdateUserPassword(int ID, string Password)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                accessor.UpdateUserPassword(ID, Password);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public SYSUserInfoResponse GetUserInfoByUserID(int UserID)
        {
            try
            {
                return accessor.GetUserInfoByUserID(UserID);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
    }
}
