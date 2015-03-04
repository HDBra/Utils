using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iFlyTek.ECSS30.Tool.SMSProc;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// ����ʶ��Ķ��Ŵ���
    /// </summary>
    public class SMSProxy
    {
        /// <summary>
        /// ����ʶ���������
        /// </summary>
        public static Dictionary<string, SMSItem> DicItems = new Dictionary<string, SMSItem>();

        /// <summary>
        /// ��������ʶ���������
        /// </summary>
        /// <returns></returns>
        public static bool LoadSMS()
        {
            bool result = false;

            DicItems.Clear();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(ConfigProxy.SMSFile,Encoding.Default);
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] temp = str.Split('\t');
                    SMSItem item = new SMSItem();
                    switch (temp.Length)
                    {
                        case 1:
                            item.UserContent = temp[0];
                            break;
                        case 2:
                            item.UserContent = temp[0];
                            item.BizName = temp[1];
                            break;
                        case 3:
                            item.UserContent = temp[0];
                            item.BizName = temp[1];
                            item.OperaName = temp[2];
                            break;

                    }
                    //����Ԥ����
                    item.UserContent = SMSPreProc.PreProc(item.UserContent);
                    if (item.IsValid && !DicItems.ContainsKey(item.UserContent))
                    {
                        
                        DicItems.Add(item.UserContent, item);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return result;
        }
    }

    /// <summary>
    /// ����ʶ��Ķ�����
    /// </summary>
    public class SMSItem
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string UserContent;

        /// <summary>
        /// ҵ����
        /// </summary>
        public string BizName;

        /// <summary>
        /// ������
        /// </summary>
        public string OperaName;

        public SMSItem()
        {
            UserContent = string.Empty;
            BizName = string.Empty;
            OperaName = string.Empty;
        }

        /// <summary>
        /// �������ݲ�Ϊ�ռ�Ϊ��Ч
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(UserContent);
            }
        }
    }
}
