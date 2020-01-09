using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SFProject.Common.Util
{
    public class EmailHelper
    {
        public static readonly string Email = ConfigurationManager.AppSettings["SenderMail"].ToString().Trim();
        public static readonly string EmailPWD = ConfigurationManager.AppSettings["SenderPWD"].ToString().Trim();
        public static readonly string Host = ConfigurationManager.AppSettings["Host"].ToString().Trim();
        public static readonly string UserName = ConfigurationManager.AppSettings["UserName"].ToString().Trim();

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="EmailTo">收件人</param>
        /// <param name="CCEmail">抄送人</param>
        /// <param name="Subject">主题</param>
        /// <param name="Body">内容</param>
        /// <param name="FilePath">附件</param>
        /// <returns></returns>
        public static string Send(List<string> EmailTo, List<string> CCEmail, string Subject, string Body, List<string> FilePath)
        {
            string result = "";
            SmtpClient mail = new SmtpClient();
            //发送方式
            mail.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp服务器
            mail.Host = Host;
            //用户名凭证          
            mail.Credentials = new System.Net.NetworkCredential(UserName, EmailPWD);
            //邮件信息
            MailMessage message = new MailMessage();
            try
            {
                //收件人
                foreach (string ReceiverEmail in EmailTo)
                {
                    if (ReceiverEmail.ToString().Trim() != "")
                    {
                        if (!message.To.Contains(new MailAddress(ReceiverEmail)))
                        {
                            message.To.Add(ReceiverEmail.ToString());
                        }
                    }
                }

            }
            catch { }

            try
            {
                //抄送人
                foreach (string CCEmailItem in CCEmail)
                {
                    if (CCEmailItem.ToString().Trim() != "")
                    {
                        if (!message.CC.Contains(new MailAddress(CCEmailItem)))
                        {
                            message.CC.Add(CCEmailItem.ToString());
                        }
                    }
                }

            }
            catch { }
            //添加抄送人

            //发件人
            message.From = new MailAddress(Email);

            //主题
            message.Subject = Subject;
            //内容
            message.Body = Body;
            //正文编码
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //设置为HTML格式
            message.IsBodyHtml = true;
            //优先级
            message.Priority = MailPriority.Normal;
            try
            {
                foreach (string FileNamePath in FilePath)
                {
                    message.Attachments.Add(new Attachment(FileNamePath));
                }
            }
            catch { }
            try
            {
                mail.Send(message);
                result = "发送成功";
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
        }
    }
}
