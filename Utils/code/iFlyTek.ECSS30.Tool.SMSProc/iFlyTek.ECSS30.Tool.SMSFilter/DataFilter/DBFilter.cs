using System;
using System.Collections.Generic;
using System.Text;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    ///// <summary>
    ///// ���ݿ����ݹ�����
    ///// </summary>
    //public class DBFilter
    //{
    //    /// <summary>
    //    /// ���ж��ŵ�����
    //    /// </summary>
    //    public static int SumCount = 0;

    //    /// <summary>
    //    /// ʶ���������
    //    /// </summary>
    //    public static int RecCount = 0;
    //    /// <summary>
    //    /// ��ʶ��������
    //    /// </summary>
    //    public static int RefuseCount = 0;

    //    #region Ӧ��ʶ���û��ʶ��Ķ���
    //    /// <summary>
    //    /// Ӧ��ʶ���û��ʶ��Ķ�����Ŀ
    //    /// </summary>
    //    public static int SMSCount = 0;

    //    /// <summary>
    //    /// string����Ԥ����֮��������� int������ų��ֵĴ���
    //    /// </summary>
    //    public static Dictionary<string, int> SMSDic = new Dictionary<string, int>();
    //    /// <summary>
    //    /// ����Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> SMSList = new List<string>();
    //    #endregion

    //    #region ����
    //    /// <summary>
    //    /// ���ֵ���Ŀ
    //    /// </summary>
    //    public static int DanziCount = 0;
    //    /// <summary>
    //    /// string����Ԥ����֮��������� int������ų��ֵĴ���
    //    /// </summary>
    //    public static Dictionary<string, int> DanziDic = new Dictionary<string, int>();
    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> DanziList = new List<string>();
    //    #endregion

    //    #region Empty����
    //    /// <summary>
    //    /// �ն��ŵ���Ŀ
    //    /// </summary>
    //    public static int EmptyCount = 0;

    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> EmptyList = new List<string>();

    //    #endregion

    //    #region ��������

    //    /// <summary>
    //    /// ����������Ŀ
    //    /// </summary>
    //    public static int LongSMSCount = 0;

    //    /// <summary>
    //    /// ���������ݣ�����Ԥ����֮ǰ������
    //    /// </summary>
    //    public static List<string> LongSMSList = new List<string>();
    //    #endregion

    //    #region �����ֶ���

    //    /// <summary>
    //    /// �����ֵĶ��ŵ���Ŀ
    //    /// </summary>
    //    public static int PureNumSMSCount = 0;

    //    /// <summary>
    //    /// string Ԥ����֮��Ķ��� int���ŵ���Ŀ
    //    /// </summary>
    //    public static Dictionary<string, int> PureNumDic = new Dictionary<string, int>();

    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> PureNumList = new List<string>();
    //    #endregion

    //    #region ��ȫ����
    //    /// <summary>
    //    /// ��ȫ����Ķ�����Ŀ
    //    /// </summary>
    //    public static int FullGarbledCount = 0;

    //    /// <summary>
    //    /// string Ԥ����֮��ĵĶ��� int ���ŵ���Ŀ
    //    /// </summary>
    //    public static Dictionary<string, int> FullGarbledDic = new Dictionary<string, int>();

    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> FullGarbledList = new List<string>();
    //    #endregion

    //    #region �����ھ�ʶ���еĶ���
    //    /// <summary>
    //    /// �����ھ�ʶ���еĶ��ŵ���Ŀ
    //    /// </summary>
    //    public static int SMSRefuseCount = 0;

    //    /// <summary>
    //    /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
    //    /// </summary>
    //    public static Dictionary<string, int> SMSRefuseDic = new Dictionary<string, int>();

    //    /// <summary>
    //    /// string Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> SMSRefuseList = new List<string>();
    //    #endregion

    //    #region ������talking.txt���еĶ���
    //    /// <summary>
    //    /// ������talking.txt���еĶ���
    //    /// </summary>
    //    public static int SMSTalkingCount = 0;

    //    /// <summary>
    //    /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
    //    /// </summary>
    //    public static Dictionary<string, int> SMSTalkingDic = new Dictionary<string, int>();

    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> SMSTalkingList = new List<string>();
    //    #endregion

    //    #region ��Ϊ��������Ķ���

    //    /// <summary>
    //    /// �������͵Ķ��ŵ���Ŀ
    //    /// </summary>
    //    public static int OtherCount = 0;

    //    /// <summary>
    //    /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
    //    /// </summary>
    //    public static Dictionary<string, int> OtherDic = new Dictionary<string, int>();

    //    /// <summary>
    //    /// Ԥ����֮ǰ�Ķ���
    //    /// </summary>
    //    public static List<string> OtherList = new List<string>();

    //    #endregion

    //    /// <summary>
    //    /// �����ݿ��л�ȡ����
    //    /// </summary>
    //    /// <returns></returns>
    //    public static bool ReadDB()
    //    {
    //        ConfigProxy.
    //    }
    //}
}
