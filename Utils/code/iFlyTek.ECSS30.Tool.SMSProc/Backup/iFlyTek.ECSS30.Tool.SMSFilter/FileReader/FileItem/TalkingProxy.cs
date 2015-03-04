using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iFlyTek.ECSS30.Tool.SMSProc;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// talking�ļ�����
    /// </summary>
    public class TalkingProxy
    {
        /// <summary>
        /// ���talking����
        /// </summary>
        public static Dictionary<string,TalkingItem> DicItems = new Dictionary<string,TalkingItem>();

        /// <summary>
        /// ����talking
        /// </summary>
        /// <returns></returns>
        public static bool LoadTalking()
        {
            bool result = false;
            DicItems.Clear();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(ConfigProxy.Talking, Encoding.Default);
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    TalkingItem item = new TalkingItem();
                    //����Ԥ����
                    item.UserContent = SMSPreProc.PreProc(str);
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

        /// <summary>
        /// һ��talking����
        /// </summary>
        public class TalkingItem
        {
            /// <summary>
            /// ��������
            /// </summary>
            public string UserContent;

            /// <summary>
            /// �ж��Ƿ���Ч
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
}
