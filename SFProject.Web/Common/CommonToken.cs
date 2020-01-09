using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFProject.Web.Common
{
    public class CommonToken
    {
        private static readonly string SecretKey = "NE6ebBJzFsfGLFCQMagppxHutApzZXSq4f8XIATgwNDI0MDQxMDE0IiwiVXNlcklkIjoxLCJVc2VyTmFtZSI6Im";//这个服务端加密秘钥 属于私钥\

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static string GetToken(TokenInfo M)
        {
            var jwtcreated =
               Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds + 5);
            var jwtcreatedOver =
            Math.Round((DateTime.UtcNow.AddHours(1) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds + 5);//TOKEN声明周期半小时
            var payload = new Dictionary<string, dynamic>
                {
                    {"iss", M.iss},//非必须。issuer 请求实体，可以是发起请求的用户的信息，也可是jwt的签发者。
                    {"iat", jwtcreated},//非必须。issued at。 token创建时间，unix时间戳格式
                    {"exp", jwtcreatedOver},//非必须。expire 指定token的生命周期。unix时间戳格式
                    {"aud", M.aud},//非必须。接收该JWT的一方。
                    {"sub", M.sub},//非必须。该JWT所面向的用户
                    {"jti", M.jti},//非必须。JWT ID。针对当前token的唯一标识
                    {"UserId", M.UserId},//自定义字段 用于存放当前登录人账户信息
                    {"UserName", M.UserName},//自定义字段 用于存放当前登录人账户信息
                    {"UserPwd", M.UserPwd},//自定义字段 用于存放当前登录人登录密码信息
                    {"CompanyID", M.CompanyID},//自定义字段 用于存放当前登录人登录权限信息
                    {"UserRole", M.UserRole},
                    {"UserType", M.UserType},//自定义字段 用于存放当前登录人登录权限信息
                    {"OpUserID",M.OpUserID},
                    {"OpIsSupperAdmin",M.OpIsSupperAdmin},
                    {"OpAccount",M.OpAccount}
                };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(payload, SecretKey); ;
        }

        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string VerifyingToken(string token)
        {
            TokenResult tokenResult = new TokenResult();
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                tokenResult.Code = "200";
                tokenResult.Data = "200";
                tokenResult.TokenInfo = new JsonNetSerializer().Deserialize<TokenInfo>(decoder.Decode(token, SecretKey, verify: true));
            }
            catch (TokenExpiredException)
            {
                tokenResult.Code = "401";
                tokenResult.Data = "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                tokenResult.Code = "402";
                tokenResult.Data = "Token has invalid signature";
            }
            catch
            {
                tokenResult.Code = "403";
                tokenResult.Data = "Token has invalid Token";
            }
            return new JsonNetSerializer().Serialize(tokenResult);
        }

    }

    /// <summary>
    /// 解析结果类
    /// </summary>
    public class TokenResult
    {
        public string Data { get; set; }
        public string Code { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }

    /// <summary>
    /// 请求获取Token类
    /// </summary>
    public class TokenInfo
    {
        public string iss { get; set; }
        public string aud { get; set; }
        public string sub { get; set; }
        public string jti { get; set; }
        public long UserId { get; set; }
        public string CompanyID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserRole { get; set; }
        public string UserType { get; set; }
        public string OpUserID { get; set; }
        public bool OpIsSupperAdmin { get; set; }
        public string OpAccount { get; set; }
        public int Status { get; set; }

    }
}