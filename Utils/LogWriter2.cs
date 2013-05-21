using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Utility
{
    public static class LogWriter
    {
        /// <summary>
        /// �����ݿ��в���һ���µ���־��Ϣ
        /// </summary>
        /// <param name="logType">��־������</param>
        /// <param name="logMessage">��־����Ϣ�����Ȳ�����500</param>
        /// <returns>������Ӱ�������</returns>
        public static int AddLog(LogType logType, string logMessage)
        {
            string sql = "INSERT INTO [Log]([LogTime],[LogType],[LogMessage]) VALUES(@LogTime,@LogType,@LogMessage)";
            //��ʼ��sql����еĲ���
            SqlParameter[] paras = new SqlParameter[3];
            paras[0] = new SqlParameter("@LogTime", SqlDbType.DateTime);
            paras[0].Value = DateTime.Now;
            paras[1] = new SqlParameter("@LogType",SqlDbType.NVarChar);
            paras[1].Value = logType.ToString();
            paras[2] = new SqlParameter("@LogMessage",SqlDbType.NVarChar);
            paras[2].Value = logMessage;
            if (!SqlHelper.GetInstance().IsConnectionActive())
            {
                return -1;
            }
            return SqlHelper.GetInstance().ExecuteNonQuery(sql, CommandType.Text, paras);
        }

        /// <summary>
        /// �ڷ�������ʱ�����ʼ�
        /// </summary>
        /// <param name="title">�ʼ��ı���</param>
        /// <param name="msg">�ʼ�������</param>
        /// <returns>���ͳɹ�������true;ʧ�ܣ�����false��</returns>
        public static bool SendMail(string title, string msg)
        {
            try
            {
                //�ʼ��������������������126����ķ���������
                SmtpClient client = new SmtpClient(ConfigReader.GetValueByKey("smtpClient"));
                client.UseDefaultCredentials = false;
                //���÷���������û������������������
                client.Credentials = new System.Net.NetworkCredential(ConfigReader.GetValueByKey("mailFrom"), DESHelper.MD5Decrypt(ConfigReader.GetValueByKey("password")));
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail = new MailMessage();
                //�����˵�ַ
                mail.From = new MailAddress(ConfigReader.GetValueByKey("mailFrom"));
                //�����ռ��˼���
                mail.To.Add(ConfigReader.GetValueByKey("mailTo"));
                //���ó����˼���
                //mail.CC.Add();
                //�ʼ��ı���
                mail.Subject = title;
                mail.BodyEncoding = System.Text.Encoding.Default;
                //�ʼ�������
                mail.Body = msg;
                //�ʼ��ĸ���
                //if (list != null)
                //{
                //    foreach (Attachment item in list)
                //    {
                //        mail.Attachments.Add(item);
                //    }
                //}
                mail.IsBodyHtml = true;
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                AddLog(LogType.Warning, "���ܷ����ʼ�,�쳣��ϢΪ��"+ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// ��ȡ�����кŵĺ���
        /// </summary>
        /// <returns></returns>
        public static int GetLineNum()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
            return st.GetFrame(0).GetFileLineNumber();
        }

        /// <summary>
        /// ����ļ�������
        /// </summary>
        /// <returns></returns>
        public static string GetFileName()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
            return st.GetFrame(0).GetFileName();
        }

        /// <summary>
        /// ��õ�ǰ������
        /// </summary>
        /// <returns></returns>
        public static string GetFuncName()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
            return st.GetFrame(0).GetMethod().ToString();
        }

    }

    /// <summary>
    /// ������ʾ��־�����ͣ���־����Ҫ�Դ�Verbose��Error��������
    /// </summary>
    public enum LogType
    {
        Verbose,
        Info,
        Debug,
        Warning,
        Error,
        SQL
    }
}
