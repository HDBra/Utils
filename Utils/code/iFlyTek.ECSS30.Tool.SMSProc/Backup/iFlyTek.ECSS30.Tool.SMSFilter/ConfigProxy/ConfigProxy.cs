using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// ���ô���
    /// </summary>
    public class ConfigProxy
    {
        /// <summary>
        /// ������󳤶�
        /// </summary>
        public static int SMSMaxLen;

        /// <summary>
        /// ���������ļ�
        /// </summary>
        public static string SMSFile;

        /// <summary>
        /// ������������ļ�
        /// </summary>
        public static string HanZi;

        /// <summary>
        /// talking�ļ�
        /// </summary>
        public static string Talking;

        /// <summary>
        /// �������
        /// </summary>
        public static string Trad2Simp;

        /// <summary>
        /// ��ʶ�����б�
        /// </summary>
        public static string SmsRefuse;

        /// <summary>
        /// ���ݵ���Դ 
        /// 0 ��ʾ����Excel
        /// 1 ��ʾ�������ݿ�
        /// </summary>
        public static string DataSource;

        /// <summary>
        /// ���ݵ����
        /// 0 ��ʾ���Excel
        /// 1 ��ʾ���txt
        /// </summary>
        public static string DataOutput;

        /// <summary>
        /// �����ļ�
        /// </summary>
        public static string InputFile;

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public static string ConnectionString;

        /// <summary>
        /// SELECT���
        /// </summary>
        public static string SelectSQL;

        /// <summary>
        /// ��̬���캯��
        /// </summary>
        static ConfigProxy()
        {
            //��ȡ������󳤶�
            if (!int.TryParse(ConfigurationManager.AppSettings["SMSMaxLen"], out SMSMaxLen))
            {
                SMSMaxLen = 1000000;
            }

            SMSFile = ConfigurationManager.AppSettings["sms"] ?? string.Empty;
            HanZi = ConfigurationManager.AppSettings["hanzi"] ?? string.Empty;
            Talking = ConfigurationManager.AppSettings["talking"] ?? string.Empty;
            Trad2Simp = ConfigurationManager.AppSettings["trad2Simp"] ?? string.Empty;
            SmsRefuse = ConfigurationManager.AppSettings["smsrefuse"] ?? string.Empty;
            DataSource = ConfigurationManager.AppSettings["DataSource"] ?? string.Empty;
            InputFile = ConfigurationManager.AppSettings["InputFile"]??string.Empty;
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"]??string.Empty;
            SelectSQL = ConfigurationManager.AppSettings["SelectSQL"]??string.Empty;
            DataOutput = ConfigurationManager.AppSettings["DataOutput"] ?? string.Empty;
        }

        /// <summary>
        /// �ж��Ƿ���Ч
        /// </summary>
        public static bool IsValid
        {
            get
            {
                return SMSMaxLen > 0 &&
                    File.Exists(SMSFile) && File.Exists(HanZi) &&
                    File.Exists(Talking) && File.Exists(Trad2Simp) &&
                    File.Exists(SmsRefuse)&&File.Exists(InputFile)&&
                    !string.IsNullOrEmpty(ConnectionString)&&
                    !string.IsNullOrEmpty(SelectSQL)&&!string.IsNullOrEmpty(DataSource);
            }
        }

        /// <summary>
        /// �ж����������Ƿ�����Excel
        /// </summary>
        /// <returns></returns>
        public static bool IsInputFromExcel()
        {
            switch (DataSource)
            {
                case "0":
                    return true;
                case "1":
                    return false;
                default:
                    throw new Exception("DataSource���������");
            }
        }


        public static bool IsOutPutToExcel()
        {
            switch (DataOutput)
            {
                case "0":
                    return true;
                case "1":
                    return false;
                default:
                    throw new Exception("DataOutput���������");
            }
        }

    }
}
