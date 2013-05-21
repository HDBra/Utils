using System;   
using System.Collections.Generic;   
using System.Linq;   
using System.Text;   
using System.Text.RegularExpressions;   
  
namespace Common   
{   
    /// <summary>   
    /// �ַ���������   
    /// </summary>   
    public class StringHelper   
    {   
        public StringHelper()   
        {   
  
        }   
  
        /// <summary>
        /// ��Ч���ַ�����Ҫ��ȡ��Դ�ַ����е�\r\n����ֹ�ƻ������
        /// </summary>
        private const string InvalidPunction = "\r\n\t ";

        /// <summary>
        /// ��Nullת��ΪEmpty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string NullToEmptyAndTrim(string source)
        {
            if(source == null)
            {
                return string.Empty;
            }
            source = source.Trim();
            if(source == string.Empty)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char ch in source)
            {
                //ȥ����Ч�ַ�����Ҫ��\r\n����ֹ�ƻ�������ĸ�ʽ
                if(InvalidPunction.IndexOf(ch) >= 0)
                {
                    continue;
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }

  
        /// <summary>   
        /// ����ʱ������ʾ�Ի���   
        /// </summary>   
        /// <param name="str_Control_Name">����ؼ�idֵ</param>   
        /// <param name="str_Form_Name">��idֵ</param>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <returns>string</returns>   
        public static string JsIsNull(string str_Control_Name, string str_Form_Name, string str_Prompt)   
        {   
            return  "<script language=\"javascript\">alert('" + str_Prompt + "');document." + str_Form_Name + "." + str_Control_Name + ".focus(); document." + str_Form_Name + "." + str_Control_Name + ".select();</" + "script>";   
        }   
  
  
        /// <summary>   
        /// ����ʱ������ʾ�Ի���   
        /// </summary>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <returns>string</returns>   
        public static string JsIsNull(string str_Prompt)   
        {   
            return  "<script language=\"javascript\">alert('" + str_Prompt + "');</" + "script>";   
        }   
  
  
        /// <summary>   
        /// �رնԻ���   
        /// </summary>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <returns>string</returns>   
        public static string  CloseParent(string str_Prompt)   
        {   
            return  "<script language=\"javascript\">alert('" + str_Prompt + "');window.parent.close();</" + "script>";   
        }   
  
        /// <summary>   
        /// ����ʱ������ʾ�Ի���--�رմ���   
        /// </summary>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <param name="isReLoad">trueΪ�ϸ������Զ�ˢ��</param>   
        /// <returns>string</returns>   
        public static string JsIsNull(string str_Prompt, bool isReLoad)   
        {   
            if (isReLoad)   
            {   
                return  "<script language=\"javascript\">alert('" + str_Prompt + "');opener.window.document.location.reload();window.close();</" + "script>";   
            }   
            else  
            {   
                return  "<script language=\"javascript\">alert('" + str_Prompt + "');window.close();</" + "script>";   
            }   
        }   
  
        /// <summary>   
        ///�Ƿ�رմ���   
        /// </summary>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <param name="isClose">trueΪ�ر�</param>   
        /// <returns>string</returns>   
        public static string  JsIsClose(string str_Prompt,  bool isClose)   
        {   
            if (!isClose)   
            {   
                return  "<script language=\"javascript\">alert('" + str_Prompt + "');</" + "script>";   
            }   
            else  
            {   
                return  "<script language=\"javascript\">alert('" + str_Prompt + "');window.close();opener.window.document.location.reload();</" + "script>";   
            }   
        }   
  
        /// <summary>   
        /// ������Ϣ����װ����   
        /// </summary>   
        /// <param name="str_Prompt">��ʾ��Ϣ</param>   
        /// <param name="reLoadPath">��װ·��</param>   
        /// <returns>string</returns>   
        public static string  JsIsReLoad(string str_Prompt, string reLoadPath)   
        {   
            return  "<script language=\"javascript\">alert('" + str_Prompt + "');this.window.document.location.reload('" + reLoadPath + "');</" + "script>";   
        }   
  
        /// <summary>   
        /// ��װ����   
        /// </summary>   
        /// <param name="reLoadPath">��ʾ��Ϣ</param>   
        /// <returns>string</returns>   
        public static string  JsIsReLoad(string reLoadPath)   
        {   
            return  "<script language=\"javascript\">this.window.document.location.reload('" + reLoadPath + "');</" + "script>";   
        }   
  
        /// <summary>   
        /// ���һ��16λʱ�������   
        /// </summary>   
        /// <returns>���������</returns>   
        public static string GetDataRandom()   
        {   
            string strData = DateTime.Now.ToString();   
            strData = strData.Replace(":", "");   
            strData = strData.Replace("-", "");   
            strData = strData.Replace(" ", "");   
            Random r = new Random();   
            strData = strData + r.Next(100000);   
            return strData;   
        }   
  
        /// <summary>   
        ///  ���ĳ���ַ���������ַ����г��ֵĴ���   
        /// </summary>   
        /// <param name="strOriginal">Ҫ������ַ�</param>   
        /// <param name="strSymbol">����</param>   
        /// <returns>����ֵ</returns>   
        public static int GetStrCount(string strOriginal, string strSymbol)   
        {   
            int count = 0;   
            for (int i = 0; i < (strOriginal.Length - strSymbol.Length + 1); i++)   
            {   
                if (strOriginal.Substring(i, strSymbol.Length) == strSymbol)   
                {   
                    count = count + 1;   
                }   
            }   
            return count;   
        }   
  
        /// <summary>   
        /// ���ĳ���ַ���������ַ�����һ�γ���ʱǰ�������ַ�   
        /// </summary>   
        /// <param name="strOriginal">Ҫ������ַ�</param>   
        /// <param name="strSymbol">����</param>   
        /// <returns>����ֵ</returns>   
        public static string GetFirstStr(string strOriginal, string strSymbol)   
        {   
            int strPlace = strOriginal.IndexOf(strSymbol);   
            if (strPlace != -1)   
                strOriginal = strOriginal.Substring(0, strPlace);   
            return strOriginal;   
        }   
  
        /// <summary>   
        /// ���ĳ���ַ���������ַ������һ�γ���ʱ���������ַ�   
        /// </summary>   
        /// <param name="strOriginal">Ҫ������ַ�</param>   
        /// <param name="strSymbol">����</param>   
        /// <returns>����ֵ</returns>   
        public static string GetLastStr(string strOriginal, string strSymbol)   
        {   
            int strPlace = strOriginal.LastIndexOf(strSymbol) + strSymbol.Length;   
            strOriginal = strOriginal.Substring(strPlace);   
            return strOriginal;   
        }   
  
        /// <summary>   
        /// ��������ַ�֮���һ�γ���ʱǰ�������ַ�   
        /// </summary>   
        /// <param name="strOriginal">Ҫ������ַ�</param>   
        /// <param name="strFirst">��ǰ�ĸ��ַ�</param>   
        /// <param name="strLast">����ĸ��ַ�</param>   
        /// <returns>����ֵ</returns>   
        public static string GetTwoMiddleFirstStr(string strOriginal, string strFirst, string strLast)   
        {   
            strOriginal = GetFirstStr(strOriginal, strLast);   
            strOriginal = GetLastStr(strOriginal, strFirst);   
            return strOriginal;   
        }   
  
        /// <summary>   
        ///  ��������ַ�֮�����һ�γ���ʱ�������ַ�   
        /// </summary>   
        /// <param name="strOriginal">Ҫ������ַ�</param>   
        /// <param name="strFirst">��ǰ�ĸ��ַ�</param>   
        /// <param name="strLast">����ĸ��ַ�</param>   
        /// <returns>����ֵ</returns>   
        public static string GetTwoMiddleLastStr(string strOriginal, string strFirst, string strLast)   
        {   
            strOriginal = GetLastStr(strOriginal, strFirst);   
            strOriginal = GetFirstStr(strOriginal, strLast);   
            return strOriginal;   
        }   
  
        /// <summary>   
        /// �����ݿ�����¼ʱ,��������ʾ   
        /// </summary>   
        /// <param name="strContent">Ҫ������ַ�</param>   
        /// <returns>��������ֵ</returns>   
        public static string GetHtmlFormat(string strContent)   
        {   
            strContent = strContent.Trim();   
  
            if (strContent == null)   
            {   
                return "";   
            }   
            strContent = strContent.Replace("<", "<");   
            strContent = strContent.Replace(">", ">");   
            strContent = strContent.Replace("\n", "<br />");   
            return (strContent);   
        }   
  
        /// <summary>   
        /// ������֮�󣬻���ַ���   
        /// </summary>   
        /// <param name="str">�ַ���1</param>   
        /// <param name="checkStr">�ַ���2</param>   
        /// <param name="reStr">���֮��Ҫ���ص��ַ���</param>   
        /// <returns>�����ַ���</returns>   
        public static string GetCheckStr(string str, string checkStr, string reStr)   
        {   
            if (str == checkStr)   
            {   
                return reStr;   
            }   
            return "";   
        }   
  
        /// <summary>   
        /// ������֮�󣬻���ַ���   
        /// </summary>   
        /// <param name="str">��ֵ1</param>   
        /// <param name="checkStr">��ֵ2</param>   
        /// <param name="reStr">���֮��Ҫ���ص��ַ���</param>   
        /// <returns>�����ַ���</returns>   
        public static string GetCheckStr(int str, int checkStr, string reStr)   
        {   
            if (str == checkStr)   
            {   
                return reStr;   
            }   
            return "";   
        }   
        /// <summary>   
        /// ������֮�󣬻���ַ���   
        /// </summary>   
        /// <param name="str"></param>   
        /// <param name="checkStr"></param>   
        /// <param name="reStr"></param>   
        /// <returns></returns>   
        public static string GetCheckStr(bool str, bool checkStr, string reStr)   
        {   
            if (str == checkStr)   
            {   
                return reStr;   
            }   
            return "";   
        }   
        /// <summary>   
        /// ������֮�󣬻���ַ���   
        /// </summary>   
        /// <param name="str"></param>   
        /// <param name="checkStr"></param>   
        /// <param name="reStr"></param>   
        /// <returns></returns>   
        public static string GetCheckStr(object str, object checkStr, string reStr)   
        {   
            if (str == checkStr)   
            {   
                return reStr;   
            }   
            return "";   
        }   
        /// <summary>   
        /// ��ȡ��߹涨�����ַ���,����������endStr����   
        /// </summary>   
        /// <param name="str">���ȡ�ַ���</param>   
        /// <param name="length">��ȡ����</param>   
        /// <param name="endStr">���������������ַ�������"..."</param>   
        /// <returns>���ؽ�ȡ�ַ���</returns>   
        public static string GetLeftStr(string str, int length, string endStr)   
        {   
            string reStr;   
            if (length < GetStrLength(str))   
            {   
                reStr = str.Substring(0, length) + endStr;   
            }   
            else  
            {   
                reStr = str;   
            }   
            return reStr;   
        }   
  
        /// <summary>   
        /// ��ȡ��߹涨�����ַ���,����������...����   
        /// </summary>   
        /// <param name="str">���ȡ�ַ���</param>   
        /// <param name="length">��ȡ����</param>   
        /// <returns>���ؽ�ȡ�ַ���</returns>   
        public static string GetLeftStr(string str, int length)   
        {   
            string reStr;   
            if (length < str.Length)   
            {   
                reStr = str.Substring(0, length) + "...";   
            }   
            else  
            {   
                reStr = str;   
            }   
            return reStr;   
        }   
  
        /// <summary>   
        /// ��ȡ��߹涨�����ַ���,����������...����   
        /// </summary>   
        /// <param name="str">���ȡ�ַ���</param>   
        /// <param name="length">��ȡ����</param>   
        /// <param name="subcount">�����������ұ߼��ٵ��ַ�����</param>   
        /// <returns>���ؽ�ȡ�ַ���</returns>   
        public static string GetLeftStr(string str, int length,int subcount)   
        {   
            string reStr;   
            if (length < str.Length)   
            {   
                reStr = str.Substring(0, length-subcount) + "...";   
            }   
            else  
            {   
                reStr = str;   
            }   
            return reStr;   
        }   
  
        /// <summary>   
        /// ���˫�ֽ��ַ������ֽ���   
        /// </summary>   
        /// <param name="str">Ҫ�����ַ���</param>   
        /// <returns>�����ֽ���</returns>   
        public static int GetStrLength(string str)   
        {   
            ASCIIEncoding n = new ASCIIEncoding();   
            byte[] b = n.GetBytes(str);   
            int l = 0;  // l Ϊ�ַ���֮ʵ�ʳ���   
            for (int i = 0; i < b.Length; i++)   
            {   
                if (b[i] == 63)  //�ж��Ƿ�Ϊ���ֻ�ȫ�ŷ���   
                {   
                    l++;   
                }   
                l++;   
            }   
            return l;   
        }   
  
        /// <summary>   
        /// ��ȥHTML��ǩ   
        /// </summary>   
        /// <param name="text">����HTML��ʽ���ַ���</param>   
        /// <returns>string</returns>   
        public static string RegStripHtml(string text)   
        {   
            string reStr;   
            string RePattern = @"<\s*(\S+)(\s[^>]*)?>";   
            reStr = Regex.Replace(text, RePattern, string.Empty, RegexOptions.Compiled);   
            reStr = Regex.Replace(reStr, @"\s+", string.Empty, RegexOptions.Compiled);   
            return reStr;   
        }   
  
        /// <summary>   
        /// ʹHtmlʧЧ,���ı���ʾ   
        /// </summary>   
        /// <param name="str">ԭ�ַ���</param>   
        /// <returns>ʧЧ���ַ���</returns>   
        public static string ReplaceHtml(string str)   
        {   
            str = str.Replace("<", "<");   
            return str;   
        }   
  
  
        /// <summary>   
        /// ����������   
        /// </summary>   
        /// <param name="Length">������ֵĳ���</param>   
        /// <returns>���س���Ϊ Length �ġ�<see cref="System.Int32"/> ���͵������</returns>   
        /// <example>   
        /// Length ���ܴ���9,����Ϊʾ����ʾ����ε��� GetRandomNext��<br />   
        /// <code>   
        ///  int le = GetRandomNext(8);   
        /// </code>   
        /// </example>   
        public static int GetRandomNext(int Length)   
        {   
            if (Length > 9)   
                throw new System.IndexOutOfRangeException("Length�ĳ��Ȳ��ܴ���10");   
            Guid gu = Guid.NewGuid();   
            string str = "";   
            for (int i = 0; i < gu.ToString().Length; i++)   
            {   
                if (isNumber(gu.ToString()[i]))   
                {   
                    str += ((gu.ToString()[i]));   
                }   
            }   
            int guid = int.Parse(str.Replace("-", "").Substring(0, Length));   
            if (!guid.ToString().Length.Equals(Length))   
                guid = GetRandomNext(Length);   
            return guid;   
        }   
  
        /// <summary>   
        /// ����һ�� bool ֵ��ָ���ṩ��ֵ�ǲ�������   
        /// </summary>   
        /// <param name="obj">Ҫ�жϵ�ֵ</param>   
        /// <returns>true[������]false[��������]</returns>   
        /// <remarks>   
        ///  isNumber��ֻ���ж���(��)��������� obj ΪС���򷵻� false;   
        /// </remarks>   
        /// <example>   
        /// �����ʾ����ʾ���ж� obj �ǲ���������<br />   
        /// <code>   
        ///  bool flag;   
        ///  flag = isNumber("200");   
        /// </code>   
        /// </example>   
        public static bool isNumber(object obj)   
        {   
            //Ϊָ����������ʽ��ʼ�������� Regex ���ʵ��   
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^-?(\d*)$");   
            //��ָ���������ַ��������� Regex ���캯����ָ����������ʽƥ����   
            System.Text.RegularExpressions.Match mc = rg.Match(obj.ToString());   
            //ָʾƥ���Ƿ�ɹ�   
            return (mc.Success);   
        }   
  
        /// <summary>   
        /// ������ʾ   
        /// </summary>   
        /// <param name="str">ԭ�ַ���</param>   
        /// <param name="findstr">�����ַ���</param>   
        /// <param name="cssclass">Style</param>   
        /// <returns>string</returns>   
        public static string OutHighlightText(string str, string findstr, string cssclass)   
        {   
            if (findstr != "")   
            {   
                string text1 = "<span class=\"" + cssclass + "\">%s</span>";   
                str = str.Replace(findstr, text1.Replace("%s", findstr));   
            }   
            return str;   
        }   
  
        /// <summary>   
        /// �Ƴ��ַ�����βĳЩ�ַ�   
        /// </summary>   
        /// <param name="strOriginal">Ҫ�������ַ���</param>   
        /// <param name="startStr">Ҫ���ַ����ײ��Ƴ����ַ���</param>   
        /// <param name="endStr">Ҫ���ַ���β���Ƴ����ַ���</param>   
        /// <returns>string</returns>   
        public static string RemoveStartOrEndStr(string strOriginal, string startStr,string endStr)   
        {   
            char[] start=startStr.ToCharArray();   
            char[] end=endStr.ToCharArray();   
            return strOriginal.TrimStart(start).TrimEnd(end);   
        }   
  
        /// <summary>   
        /// ɾ��ָ��λ��ָ�������ַ���   
        /// </summary>   
        /// <param name="strOriginal">Ҫ�������ַ���</param>   
        /// <param name="startIndex">��ʼɾ���ַ���λ��</param>   
        /// <param name="count">Ҫɾ�����ַ���</param>   
        /// <returns>string</returns>   
        public static string RemoveStr(string strOriginal,int startIndex, int count)   
        {   
            return strOriginal.Remove(startIndex, count);   
        }   
  
        /// <summary>   
        /// ���������ַ���   
        /// </summary>   
        /// <param name="strOriginal">Ҫ�������ַ���</param>   
        /// <param name="totalWidth">����ַ����е��ַ���</param>   
        /// <param name="paddingChar">�����ַ�</param>   
        /// <returns>string</returns>   
        public static string LeftPadStr(string strOriginal, int totalWidth, char paddingChar)   
        {   
            if(strOriginal.Length<totalWidth)   
                return strOriginal.PadLeft(totalWidth, paddingChar);   
            return strOriginal;   
        }   
  
        /// <summary>   
        /// ���ұ�����ַ���   
        /// </summary>   
        /// <param name="strOriginal">Ҫ�������ַ���</param>   
        /// <param name="totalWidth">����ַ����е��ַ���</param>   
        /// <param name="paddingChar">�����ַ�</param>   
        /// <returns>string</returns>   
        public static string RightPadStr(string strOriginal, int totalWidth, char paddingChar)   
        {   
            if (strOriginal.Length < totalWidth)   
                return strOriginal.PadRight(totalWidth, paddingChar);   
            return strOriginal;   
        }   
    }   
}  
