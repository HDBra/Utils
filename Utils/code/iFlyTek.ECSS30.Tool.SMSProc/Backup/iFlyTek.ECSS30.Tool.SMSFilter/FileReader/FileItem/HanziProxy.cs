using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// ���ֵĴ���
    /// </summary>
    public class HanziProxy
    {
        /// <summary>
        /// ���溺�ִʵ�
        /// </summary>
        public static Dictionary<char, HanziItem> DicItems = new Dictionary<char, HanziItem>();

        /// <summary>
        /// ���غ��ֱ�
        /// </summary>
        public static bool LoadHanzi()
        {
            bool result = false;
            DicItems.Clear();
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(ConfigProxy.HanZi, Encoding.Default);
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] temp = str.Split('\t');
                    HanziItem item = new HanziItem();
                    switch (temp.Length)
                    {
                        case 1:
                            item.Hanzi = (!string.IsNullOrEmpty(temp[0]) && temp[0].Length > 0) ? temp[0][0] : ' ';
                            break;
                        case 2:
                            item.Hanzi = (!string.IsNullOrEmpty(temp[0]) && temp[0].Length > 0) ? temp[0][0] : ' ';
                            if (!long.TryParse(temp[1], out item.Count))
                            {
                                item.Count = 0;
                            }
                            break;
                    }
                    if (item.IsValid && !DicItems.ContainsKey(item.Hanzi))
                    {
                        DicItems.Add(item.Hanzi, item);
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
    /// һ��������
    /// </summary>
    public class HanziItem
    {
        /// <summary>
        /// ����
        /// </summary>
        public char Hanzi;

        /// <summary>
        /// ͳ�ƴ���
        /// </summary>
        public long Count;

        /// <summary>
        /// ���캯��
        /// </summary>
        public HanziItem()
        {
            Hanzi = ' ';
            Count = 0;
        }

        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Hanzi != ' ' && Count >= 0;
            }
        }
    }
}
