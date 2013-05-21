using System;
using System.Collections.Generic;
using System.Text;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// һϵ�������ı�����ĺ���
    /// </summary>
    public class TextCommonFunctions
    {
        /// <summary>
        /// �ж������ַ����Ƿ���ȫ������
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>�մ���null ����true����ȫ�����ַ���true</returns>
        public static bool IsNumber(string strInput)
        {
            foreach (char ch in strInput)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �ж������ַ����Ƿ���ȫ��Ӣ��(A-Z a-z)
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>�մ���null����true����ȫ��Ӣ���ַ�����true</returns>
        public static bool IsEnglish(string strInput)
        {
            foreach (char ch in strInput)
            {
                if ('A' > ch || ('Z' < ch && 'a' > ch) || ch > 'z')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �ж������ַ����Ƿ���ȫ�����ֻ���Ӣ�����
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>�մ���null ����true</returns>
        public static bool IsNumOrEng(string strInput)
        {
            foreach (char ch in strInput)
            {
                //��������Ҳ������ĸ
                if (('A' > ch || ('Z' < ch && 'a' > ch) || ch > 'z')/*��Ϊ��ĸ*/ &&
                    (ch < '0' || ch > '9')/*��Ϊ����*/
                    )
                {
                    return false;
                }

            }

            return true;
        }

        /// <summary>
        /// �Ƿ���������ַ�
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>null�Ϳմ� ����false</returns>
        public static bool IsContainChinese(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return false;
            }

            string strRex = @"[\u4e00-\u9fa5]";
            return System.Text.RegularExpressions.Regex.IsMatch(strInput, strRex);
        }

        /// <summary>
        /// �ж��Ƿ���ȫ������
        /// </summary>
        /// <param name="strInput">�������</param>
        /// <returns>null�Ϳմ�����true����ȫ�����ķ���true</returns>
        public static bool IsChinese(string strInput)
        {
            if (HanziProxy.DicItems != null)
            {
                foreach (char ch in strInput)
                {
                    if (!HanziProxy.DicItems.ContainsKey(ch))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ȥ���հ�֮���Ƿ�ֻ��0��1���ַ�
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsTrimToOneOrZero(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return true;
            }

            return strInput.Trim().Length <= 1;
        }

        /// <summary>
        /// �ж϶��������Ƿ�����ȫû�����������
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsFullGarbled(string strInput)
        {


            foreach (char c in strInput)
            {
                //������������е�һ���ַ�������ȫ��û�����������
                if (char.IsLetterOrDigit(c) || HanziProxy.DicItems.ContainsKey(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
