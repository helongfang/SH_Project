using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFProject.Common.ExtensionMethods;
using SFProject.Entity.DataBaseEntity;
using SFProject.MessageContracts.Account;

namespace SFProject.Dao.Account
{
    public class AccoutAccessor : BaseAccessor
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>用户对象</returns>
        public SYSUserInfoResponse VerificationLogin(string UserName, string Password)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(BaseAccessor.TMSSqlConnection))
            {
                SqlCommand cmd = new SqlCommand("Proc_SYSUserInfoLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters[0].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters[1].SqlDbType = SqlDbType.NVarChar;
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            return dt.ConvertToEntity<SYSUserInfoResponse>();
        }

        /// <summary>
        /// 根据条件获取用户列表
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <returns>用户列表</returns>
        public IEnumerable<SYSUserInfoResponse> GetUserList(SYSUserInfoRequest request)
        {
            string where = GetUserListCondition(request);
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, where, ParameterDirection.Input),
                new DbParam("@PageIndex",DbType.Int32, request.PageIndex,ParameterDirection.Input),
                new DbParam("@PageSize",DbType.Int32, request.PageSize,ParameterDirection.Input)
            };
            return this.ExecuteDataTable("Proc_GetUserList", dbParams).ConvertToEntityCollection<SYSUserInfoResponse>();
        }

        /// <summary>
        /// 拼接用户查询条件
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <returns>请求条件字符串</returns>
        private string GetUserListCondition(SYSUserInfoRequest request)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(request.UserName))
            {
                sb.Append(" AND sui.UserName LIKE '%" + request.UserName + "%'");
            }
            if (!string.IsNullOrEmpty(request.CompanyName))
            {
                sb.Append(" AND sui.CompanyName LIKE '%" + request.CompanyName + "%'");
            }
            if (request.UserType != -1)
            {
                sb.Append(" AND sui.UserType = " + request.UserType);
            }
            if (!string.IsNullOrEmpty(request.StartCreateTime))
            {
                sb.Append(" AND sui.CreateTime >='" + request.StartCreateTime + "'");
            }
            if (!string.IsNullOrEmpty(request.EndCreateTime))
            {
                sb.Append(" AND sui.CreateTime <='" + request.EndCreateTime + " 23:59:59'");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        public void UpdateSYSUserInfo(SYSUserInfoRequest request)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_UpdateUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", request.ID);
                cmd.Parameters[0].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@UserName", request.UserName);
                cmd.Parameters[1].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Password", request.Password);
                cmd.Parameters[2].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@CompanyName", request.CompanyName);
                cmd.Parameters[3].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@BusinessContact", request.BusinessContact);
                cmd.Parameters[4].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@FinancialContact", request.FinancialContact);
                cmd.Parameters[5].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters[6].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Tel", request.Tel);
                cmd.Parameters[7].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Address", request.Address);
                cmd.Parameters[8].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@State", request.State);
                cmd.Parameters[9].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters[10].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@RoleID", request.RoleID);
                cmd.Parameters[11].SqlDbType = SqlDbType.Int;
                cmd.CommandTimeout = 600;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除用户信息（软删除，标记状态为9表示删除）
        /// </summary>
        /// <param name="ID">用户ID</param>
        public void DeleteSYSUserInfo(string IDs)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_DeleteUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDs", IDs);
                cmd.Parameters[0].SqlDbType = SqlDbType.VarChar;
                cmd.CommandTimeout = 600;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="request"></param>
        public void AddSYSUserInfo(SYSUserInfoRequest request)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", request.UserName);
                cmd.Parameters[0].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Password", request.Password);
                cmd.Parameters[1].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@CompanyName", request.CompanyName);
                cmd.Parameters[2].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@BusinessContact", request.BusinessContact);
                cmd.Parameters[3].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@FinancialContact", request.FinancialContact);
                cmd.Parameters[4].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Email", request.Email);
                cmd.Parameters[5].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Tel", request.Tel);
                cmd.Parameters[6].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Address", request.Address);
                cmd.Parameters[7].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@State", request.State);
                cmd.Parameters[8].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters[9].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@RoleID", request.RoleID);
                cmd.Parameters[10].SqlDbType = SqlDbType.Int;
                cmd.CommandTimeout = 600;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 验证用户名称的唯一性
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool CheckNameIsExist(string UserName, int ID)
        {
            bool isExist = false;
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_CheckNameIsExist", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters[0].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters[1].SqlDbType = SqlDbType.Int;
                cmd.CommandTimeout = 600;
                conn.Open();
                isExist = (int)cmd.ExecuteScalar() > 0 ? true : false;
            }
            return isExist;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="ID">用户ID</param>
        /// <param name="Password">新密码</param>
        public void UpdateUserPassword(int ID, string Password)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_UpdateUserPassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters[0].SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@NewPassword", Password);
                cmd.Parameters[0].SqlDbType = SqlDbType.VarChar;
                cmd.CommandTimeout = 600;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns>用户信息</returns>
        public SYSUserInfoResponse GetUserInfoByUserID(int UserID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(BaseAccessor.TMSSqlConnection))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetUserInfoByUserID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters[0].SqlDbType = SqlDbType.Int;
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            return dt.ConvertToEntity<SYSUserInfoResponse>();
        }
    }
}
