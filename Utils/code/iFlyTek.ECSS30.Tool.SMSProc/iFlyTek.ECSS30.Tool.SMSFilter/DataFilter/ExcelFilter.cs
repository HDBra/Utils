using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using iFlyTek.ECSS30.Tool.SMSProc;
using System.Data;
using System.IO;

namespace iFlyTek.ECSS30.Tool.SMSFilter
{
    /// <summary>
    /// Excel����Դ������
    /// </summary>
    public class ExcelFilter
    {
        /// <summary>
        /// ���ж��ŵ�����
        /// </summary>
        public static int SumCount = 0;

        /// <summary>
        /// ʶ���������
        /// </summary>
        public static int RecCount = 0;
        /// <summary>
        /// ��ʶ��������
        /// </summary>
        public static int RefuseCount = 0;

        #region Ӧ��ʶ���û��ʶ��Ķ���
        /// <summary>
        /// Ӧ��ʶ���û��ʶ��Ķ�����Ŀ
        /// </summary>
        public static int SMSCount = 0;

        /// <summary>
        /// string����Ԥ����֮��������� int������ų��ֵĴ���
        /// </summary>
        public static Dictionary<string, int> SMSDic = new Dictionary<string, int>();
        /// <summary>
        /// ����Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> SMSList = new List<string>();
        #endregion

        #region ����
        /// <summary>
        /// ���ֵ���Ŀ
        /// </summary>
        public static int DanziCount = 0;
        /// <summary>
        /// string����Ԥ����֮��������� int������ų��ֵĴ���
        /// </summary>
        public static Dictionary<string, int> DanziDic = new Dictionary<string, int>();
        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> DanziList = new List<string>();
        #endregion

        #region Empty����
        /// <summary>
        /// �ն��ŵ���Ŀ
        /// </summary>
        public static int EmptyCount = 0;

        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> EmptyList = new List<string>();

        #endregion

        #region ��������

        /// <summary>
        /// ����������Ŀ
        /// </summary>
        public static int LongSMSCount = 0;

        /// <summary>
        /// ���������ݣ�����Ԥ����֮ǰ������
        /// </summary>
        public static List<string> LongSMSList = new List<string>();
        #endregion

        #region �����ֶ���

        /// <summary>
        /// �����ֵĶ��ŵ���Ŀ
        /// </summary>
        public static int PureNumSMSCount = 0;

        /// <summary>
        /// string Ԥ����֮��Ķ��� int���ŵ���Ŀ
        /// </summary>
        public static Dictionary<string, int> PureNumDic = new Dictionary<string, int>();

        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> PureNumList = new List<string>();
        #endregion

        #region ��ȫ����
        /// <summary>
        /// ��ȫ����Ķ�����Ŀ
        /// </summary>
        public static int FullGarbledCount = 0;

        /// <summary>
        /// string Ԥ����֮��ĵĶ��� int ���ŵ���Ŀ
        /// </summary>
        public static Dictionary<string, int> FullGarbledDic = new Dictionary<string, int>();

        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> FullGarbledList = new List<string>();
        #endregion

        #region �����ھ�ʶ���еĶ���
        /// <summary>
        /// �����ھ�ʶ���еĶ��ŵ���Ŀ
        /// </summary>
        public static int SMSRefuseCount = 0;

        /// <summary>
        /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
        /// </summary>
        public static Dictionary<string, int> SMSRefuseDic = new Dictionary<string, int>();

        /// <summary>
        /// string Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> SMSRefuseList = new List<string>();
        #endregion

        #region ������talking.txt���еĶ���
        /// <summary>
        /// ������talking.txt���еĶ���
        /// </summary>
        public static int SMSTalkingCount = 0;

        /// <summary>
        /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
        /// </summary>
        public static Dictionary<string, int> SMSTalkingDic = new Dictionary<string, int>();

        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> SMSTalkingList = new List<string>();
        #endregion

        #region ��Ϊ��������Ķ���

        /// <summary>
        /// �������͵Ķ��ŵ���Ŀ
        /// </summary>
        public static int OtherCount = 0;

        /// <summary>
        /// string Ԥ����֮��Ķ��� int ���ŵ���Ŀ
        /// </summary>
        public static Dictionary<string, int> OtherDic = new Dictionary<string, int>();

        /// <summary>
        /// Ԥ����֮ǰ�Ķ���
        /// </summary>
        public static List<string> OtherList = new List<string>();

        #endregion

        /// <summary>
        /// ��ȡExcel����
        /// </summary>
        /// <returns></returns>
        public static bool ReadExcel()
        {
            Workbook workbook = null;
            Cells cells = null;

            try
            {
                workbook = new Workbook();
                workbook.Open(ConfigProxy.InputFile);
                cells = workbook.Worksheets[0].Cells;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            try
            {
                //3�� ��1�� �û����� �ڶ��� ҵ���� ���� ������
                for (int i = 1; i < cells.Rows.Count; i++)
                {
                    if (i % 1000 == 0)
                    {
                        Console.WriteLine("���ڴ����"+i+"����");
                    }

                    InputItem item = new InputItem();
                    item.UserContent = cells.Rows[i][0].Value == null ? string.Empty : cells.Rows[i][0].Value.ToString().Trim();
                    item.BizName = cells.Rows[i][1].Value == null ? string.Empty : cells.Rows[i][1].Value.ToString().Trim();
                    item.OperaName = cells.Rows[i][2].Value == null ? string.Empty : cells.Rows[i][2].Value.ToString().Trim();

                    //����������1
                    SumCount++;
                    if (item.IsRec)
                    {
                        //���������Ѿ�ʶ��
                        RecCount++;
                        continue;
                    }
                    else
                    {
                        //δʶ��
                        RefuseCount++;
                    }
                    //����Ԥ����֮ǰ�Ķ���
                    string temp = item.UserContent;
                    //��������Ԥ����
                    item.UserContent = SMSPreProc.PreProc(item.UserContent);

                    #region �ն���
                    //�ն���
                    if (string.IsNullOrEmpty(item.UserContent))
                    {
                        EmptyCount++;
                        EmptyList.Add(temp);
                        continue;
                    }
                    #endregion

                    #region Ӧ��ʶ���û��ʶ��Ķ���
                    //Ӧ��ʶ���û��ʶ��
                    if (SMSProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSCount++;
                        //����Ѿ�ͳ�ƹ�����Ŀ��1
                        if (SMSDic.ContainsKey(item.UserContent))
                        {
                            SMSDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSDic.Add(item.UserContent, 1);
                        }
                        SMSList.Add(temp);
                        continue;
                    }
                    #endregion

                    #region ������
                    int length = ConfigProxy.SMSMaxLen;

                    if (temp.Length > length)
                    {
                        LongSMSCount++;
                        LongSMSList.Add(temp);
                        continue;
                    }

                    #endregion

                    #region ���ֶ���
                    if (item.UserContent.Length <= 1)
                    {
                        DanziCount++;
                        //����Ԥ����֮ǰ�Ķ�������
                        DanziList.Add(temp);
                        if (DanziDic.ContainsKey(item.UserContent))
                        {
                            DanziDic[item.UserContent]++;
                        }
                        else
                        {
                            DanziDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region �����ֶ���
                    if (TextCommonFunctions.IsNumber(item.UserContent))
                    {
                        PureNumSMSCount++;
                        PureNumList.Add(temp);
                        if (PureNumDic.ContainsKey(item.UserContent))
                        {
                            PureNumDic[item.UserContent]++;
                        }
                        else
                        {
                            PureNumDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ��ȫ����
                    if (TextCommonFunctions.IsFullGarbled(item.UserContent))
                    {
                        FullGarbledCount++;
                        //����Ԥ����֮ǰ�Ķ���
                        FullGarbledList.Add(temp);
                        if (FullGarbledDic.ContainsKey(item.UserContent))
                        {
                            FullGarbledDic[item.UserContent]++;
                        }
                        else
                        {
                            FullGarbledDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ������SMSRefuse.txt��ʶ���еĶ���
                    if (SMSRefuseProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSRefuseCount++;
                        SMSRefuseList.Add(temp);
                        if (SMSRefuseDic.ContainsKey(item.UserContent))
                        {
                            SMSRefuseDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSRefuseDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ������Talking.txt�еĶ���
                    if (TalkingProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSTalkingCount++;
                        SMSTalkingList.Add(temp);
                        if (SMSTalkingDic.ContainsKey(item.UserContent))
                        {
                            SMSTalkingDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSTalkingDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region �������͵Ķ��ţ���Ϊ��������

                    OtherCount++;
                    OtherList.Add(temp);
                    if (OtherDic.ContainsKey(item.UserContent))
                    {
                        OtherDic[item.UserContent]++;
                    }
                    else
                    {
                        OtherDic.Add(item.UserContent, 1);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;

        }

        /// <summary>
        /// �����ݿ��ж�ȡ����
        /// </summary>
        /// <returns></returns>
        public static bool ReadFromDb()
        {
            DataTable dt = null;
            try
            {
                dt = SqlHelper.GetInstance(ConfigProxy.ConnectionString).ExecuteDataTable(ConfigProxy.SelectSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine("��ȡ���ݿ�ʧ��"+ex.ToString());
                return false;
            }
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i % 100 == 0)
                    {
                        Console.WriteLine("���ڴ����" + i + "����");
                    }
                    InputItem item = new InputItem();
                    item.UserContent = dt.Rows[i][0] == null ? string.Empty : dt.Rows[i][0].ToString().Trim();
                    item.BizName = dt.Rows[i][1] == null ? string.Empty : dt.Rows[i][1].ToString().Trim();
                    item.OperaName = dt.Rows[i][2] == null ? string.Empty : dt.Rows[i][2].ToString().Trim();

                    //����������1
                    SumCount++;
                    if (item.IsRec)
                    {
                        //���������Ѿ�ʶ��
                        RecCount++;
                        continue;
                    }
                    else
                    {
                        //δʶ��
                        RefuseCount++;
                    }
                    //����Ԥ����֮ǰ�Ķ���
                    string temp = item.UserContent;
                    //��������Ԥ����
                    item.UserContent = SMSPreProc.PreProc(item.UserContent);

                    #region �ն���
                    //�ն���
                    if (string.IsNullOrEmpty(item.UserContent))
                    {
                        EmptyCount++;
                        EmptyList.Add(temp);
                        continue;
                    }
                    #endregion

                    #region Ӧ��ʶ���û��ʶ��Ķ���
                    //Ӧ��ʶ���û��ʶ��
                    if (SMSProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSCount++;
                        //����Ѿ�ͳ�ƹ�����Ŀ��1
                        if (SMSDic.ContainsKey(item.UserContent))
                        {
                            SMSDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSDic.Add(item.UserContent, 1);
                        }
                        SMSList.Add(temp);
                        continue;
                    }
                    #endregion

                    #region ������
                    int length = ConfigProxy.SMSMaxLen;

                    if (temp.Length > length)
                    {
                        LongSMSCount++;
                        LongSMSList.Add(temp);
                        continue;
                    }

                    #endregion

                    #region ���ֶ���
                    if (item.UserContent.Length <= 1)
                    {
                        DanziCount++;
                        //����Ԥ����֮ǰ�Ķ�������
                        DanziList.Add(temp);
                        if (DanziDic.ContainsKey(item.UserContent))
                        {
                            DanziDic[item.UserContent]++;
                        }
                        else
                        {
                            DanziDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region �����ֶ���
                    if (TextCommonFunctions.IsNumber(item.UserContent))
                    {
                        PureNumSMSCount++;
                        PureNumList.Add(temp);
                        if (PureNumDic.ContainsKey(item.UserContent))
                        {
                            PureNumDic[item.UserContent]++;
                        }
                        else
                        {
                            PureNumDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ��ȫ����
                    if (TextCommonFunctions.IsFullGarbled(item.UserContent))
                    {
                        FullGarbledCount++;
                        //����Ԥ����֮ǰ�Ķ���
                        FullGarbledList.Add(temp);
                        if (FullGarbledDic.ContainsKey(item.UserContent))
                        {
                            FullGarbledDic[item.UserContent]++;
                        }
                        else
                        {
                            FullGarbledDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ������SMSRefuse.txt��ʶ���еĶ���
                    if (SMSRefuseProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSRefuseCount++;
                        SMSRefuseList.Add(temp);
                        if (SMSRefuseDic.ContainsKey(item.UserContent))
                        {
                            SMSRefuseDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSRefuseDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region ������Talking.txt�еĶ���
                    if (TalkingProxy.DicItems.ContainsKey(item.UserContent))
                    {
                        SMSTalkingCount++;
                        SMSTalkingList.Add(temp);
                        if (SMSTalkingDic.ContainsKey(item.UserContent))
                        {
                            SMSTalkingDic[item.UserContent]++;
                        }
                        else
                        {
                            SMSTalkingDic.Add(item.UserContent, 1);
                        }
                        continue;
                    }
                    #endregion

                    #region �������͵Ķ��ţ���Ϊ��������

                    OtherCount++;
                    OtherList.Add(temp);
                    if (OtherDic.ContainsKey(item.UserContent))
                    {
                        OtherDic[item.UserContent]++;
                    }
                    else
                    {
                        OtherDic.Add(item.UserContent, 1);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }


        /// <summary>
        /// ��������浽Excel��
        /// </summary>
        public static void SaveAsExcel()
        {
            string outputFile = "ͳ�ƽ��_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            Workbook workbook = new Workbook();
            
            //workbook.Open(outputFile);
            #region Ӧ��ʶ���û��ʶ��Ķ���
            {
                workbook.Worksheets.Clear();
                workbook.Worksheets.Add();
                workbook.Worksheets[0].Name = "Ӧ��ʶ���û��ʶ��Ķ���";
                workbook.Worksheets[0].Cells.Rows[0][0].PutValue("��������");
                workbook.Worksheets[0].Cells.Rows[0][1].PutValue("ҵ����");
                workbook.Worksheets[0].Cells.Rows[0][2].PutValue("������");
                workbook.Worksheets[0].Cells.Rows[0][3].PutValue("���ִ���");
                int i = 1;
                foreach (string str in SMSDic.Keys)
                {
                    workbook.Worksheets[0].Cells.Rows[i][0].PutValue(str);
                    if (SMSProxy.DicItems.ContainsKey(str))
                    {
                        workbook.Worksheets[0].Cells.Rows[i][1].PutValue(SMSProxy.DicItems[str].BizName);
                        workbook.Worksheets[0].Cells.Rows[i][2].PutValue(SMSProxy.DicItems[str].OperaName);
                    }
                    workbook.Worksheets[0].Cells.Rows[i][3].PutValue(SMSDic[str]);
                    i++;
                }
               
            }
            #endregion

            #region ���ֶ��Ż��߿ն���
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[1].Name = "���ֶ��Ż��߿ն���";
                workbook.Worksheets[1].Cells.Rows[0][0].PutValue("��������");
                workbook.Worksheets[1].Cells.Rows[0][1].PutValue("���ִ���");
                int i = 1;
                foreach (string str in EmptyList)
                {
                    workbook.Worksheets[1].Cells.Rows[i][0].PutValue(str);
                    workbook.Worksheets[1].Cells.Rows[i][1].PutValue("Ԥ����֮��Ϊ��");
                    i++;
                }
                foreach (string str in DanziDic.Keys)
                {
                    workbook.Worksheets[1].Cells.Rows[i][0].PutValue(str);
                    workbook.Worksheets[1].Cells.Rows[i][1].PutValue(DanziDic[str]);
                    i++;
                }
            }
            #endregion

            #region ��������
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[2].Name = "���ų��ȳ���" + ConfigProxy.SMSMaxLen;
                workbook.Worksheets[2].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in LongSMSList)
                {
                    workbook.Worksheets[2].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region ��ȫ����
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[3].Name = "��ȫ����";
                workbook.Worksheets[3].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in FullGarbledList)
                {
                    workbook.Worksheets[3].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region ������
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[4].Name = "������";
                workbook.Worksheets[4].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in PureNumList)
                {
                    workbook.Worksheets[4].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region �����ھ�ʶ���еĶ���
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[5].Name = "�����ھ�ʶ���еĶ���";
                workbook.Worksheets[5].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in SMSRefuseList)
                {
                    workbook.Worksheets[5].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region ������talking���еĶ���
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[6].Name = "������talking���еĶ���";
                workbook.Worksheets[6].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in SMSTalkingList)
                {
                    workbook.Worksheets[6].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region ����
            {
                workbook.Worksheets.Add();
                workbook.Worksheets[7].Name = "����";
                workbook.Worksheets[7].Cells.Rows[0][0].PutValue("��������");
                int i = 1;
                foreach (string str in OtherList)
                {
                    workbook.Worksheets[7].Cells.Rows[i][0].PutValue(str);
                    i++;
                }
            }
            #endregion

            #region ͳ�ƽ��
            workbook.Worksheets.Add();
            workbook.Worksheets[8].Name = "ͳ�ƽ��";
            workbook.Worksheets[8].Cells.Rows[0][0].PutValue("��ʶ���ŷ���");
            workbook.Worksheets[8].Cells.Rows[0][1].PutValue("ͳ�ƴ���");
            workbook.Worksheets[8].Cells.Rows[0][2].PutValue("��ռ����");

            if (RefuseCount > 0)
            {
                //Ӧ��ʶ���û��ʶ��
                workbook.Worksheets[8].Cells.Rows[1][0].PutValue("Ӧ��ʶ���û��ʶ��");
                workbook.Worksheets[8].Cells.Rows[1][1].PutValue(SMSCount);
                workbook.Worksheets[8].Cells.Rows[1][2].PutValue((double)SMSCount / RefuseCount);
                //�ն���
                workbook.Worksheets[8].Cells.Rows[2][0].PutValue("�ն���");
                workbook.Worksheets[8].Cells.Rows[2][1].PutValue(EmptyCount);
                workbook.Worksheets[8].Cells.Rows[2][2].PutValue((double)EmptyCount / RefuseCount);
                //���ֶ���
                workbook.Worksheets[8].Cells.Rows[3][0].PutValue("���ֶ���");
                workbook.Worksheets[8].Cells.Rows[3][1].PutValue(DanziCount);
                workbook.Worksheets[8].Cells.Rows[3][2].PutValue((double)DanziCount / RefuseCount);
                //��������
                workbook.Worksheets[8].Cells.Rows[4][0].PutValue("���ų��ȳ���" + ConfigProxy.SMSMaxLen);
                workbook.Worksheets[8].Cells.Rows[4][1].PutValue(LongSMSCount);
                workbook.Worksheets[8].Cells.Rows[4][2].PutValue((double)LongSMSCount / RefuseCount);
                //��ȫ����
                workbook.Worksheets[8].Cells.Rows[5][0].PutValue("��ȫ����");
                workbook.Worksheets[8].Cells.Rows[5][1].PutValue(FullGarbledCount);
                workbook.Worksheets[8].Cells.Rows[5][2].PutValue((double)FullGarbledCount / RefuseCount);
                //������
                workbook.Worksheets[8].Cells.Rows[6][0].PutValue("������");
                workbook.Worksheets[8].Cells.Rows[6][1].PutValue(PureNumSMSCount);
                workbook.Worksheets[8].Cells.Rows[6][2].PutValue((double)PureNumSMSCount / RefuseCount);
                //�����ھ�ʶ���еĶ���
                workbook.Worksheets[8].Cells.Rows[7][0].PutValue("�����ھ�ʶ���еĶ���");
                workbook.Worksheets[8].Cells.Rows[7][1].PutValue(SMSRefuseCount);
                workbook.Worksheets[8].Cells.Rows[7][2].PutValue((double)SMSRefuseCount / RefuseCount);
                //������talking���еĶ���
                workbook.Worksheets[8].Cells.Rows[8][0].PutValue("������talking���еĶ���");
                workbook.Worksheets[8].Cells.Rows[8][1].PutValue(SMSTalkingCount);
                workbook.Worksheets[8].Cells.Rows[8][2].PutValue((double)SMSTalkingCount / RefuseCount);
                //����
                workbook.Worksheets[8].Cells.Rows[9][0].PutValue("����");
                workbook.Worksheets[8].Cells.Rows[9][1].PutValue(OtherCount);
                workbook.Worksheets[8].Cells.Rows[9][2].PutValue((double)OtherCount / RefuseCount);
                //�ϼ�
                workbook.Worksheets[8].Cells.Rows[10][0].PutValue("�ϼ�");
                workbook.Worksheets[8].Cells.Rows[10][1].PutValue(RefuseCount);
                workbook.Worksheets[8].Cells.Rows[10][2].PutValue((double)RefuseCount / RefuseCount);
            }

            #endregion
            workbook.Save(outputFile);
        }

        /// <summary>
        /// ��������������ݿ���
        /// </summary>
        public static void SaveAsTxt()
        {
            string outputFile = "ͳ�ƽ��_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (!Directory.Exists(outputFile))
            {
                Directory.CreateDirectory(outputFile);
            }

            #region Ӧ��ʶ���û��ʶ��Ķ���
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("��������\tҵ����\t������\t���ִ���");
                foreach (string str in SMSDic.Keys)
                {
                    sb.Append(str + "\t");
                    if (SMSProxy.DicItems.ContainsKey(str))
                    {
                        sb.Append(SMSProxy.DicItems[str].BizName + "\t");
                        sb.Append(SMSProxy.DicItems[str].OperaName + "\t");
                    }
                    sb.Append(SMSDic[str] + "\r\n");
                }
                string filename = ".\\" + outputFile + "\\" + "Ӧ��ʶ��û��ʶ��Ķ���.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ���ֶ��Ż��߿ն���
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("�ն���");
                foreach (string str in EmptyList)
                {
                    if (str != null)
                    {
                        sb.AppendLine(str);
                    }
                }
                string filename = ".\\" + outputFile + "\\" + "�ն���.txt";
                FileHelper.WriteFile(sb.ToString(), filename);

                StringBuilder sb2 = new StringBuilder();
                sb2.AppendLine("����");
                foreach (string str in DanziList)
                {
                    sb2.AppendLine(str);
                }
                string filename2 = ".\\" + outputFile + "\\" + "����.txt";
                FileHelper.WriteFile(sb.ToString(), filename2);
            }
            #endregion

            #region ��������
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("���ų��ȳ���" + ConfigProxy.SMSMaxLen);
                foreach (string str in LongSMSList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "���ų���.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ��ȫ����
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("��ȫ����");
                foreach (string str in FullGarbledList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "��ȫ����.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ������
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("������");
                foreach (string str in PureNumList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "������.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region �����ھ�ʶ���еĶ���
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("�����ھ�ʶ���еĶ���");
                foreach (string str in SMSRefuseList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "�����ھ�ʶ���еĶ���.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ������talking���еĶ���
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("������talking���еĶ���");
                foreach (string str in SMSTalkingList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "������talking���еĶ���.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ����
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("����");
                foreach (string str in OtherList)
                {
                    sb.AppendLine(str);
                }
                string filename = ".\\" + outputFile + "\\" + "����.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion

            #region ͳ�ƽ��
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("��ʶ���ŷ���\tͳ�ƴ���\t��ռ����");
                if (RefuseCount > 0)
                {
                    sb.AppendLine("Ӧ��ʶ���û��ʶ��\t" + SMSCount + "\t" + ((double)SMSCount / RefuseCount));
                    sb.AppendLine("�ն���\t" + EmptyCount + "\t" + ((double)EmptyCount / RefuseCount));
                    sb.AppendLine("���ֶ���\t" + DanziCount + "\t" + ((double)DanziCount / RefuseCount));
                    sb.AppendLine("���ų��ȳ���" + ConfigProxy.SMSMaxLen + "\t" + LongSMSCount + "\t" + ((double)LongSMSCount / RefuseCount));
                    sb.AppendLine("��ȫ����\t" + FullGarbledCount + "\t" + ((double)FullGarbledCount / RefuseCount));
                    sb.AppendLine("������\t" + PureNumSMSCount + "\t" + ((double)PureNumSMSCount / RefuseCount));
                    sb.AppendLine("�����ھ�ʶ���еĶ���\t" + SMSRefuseCount + "\t" + ((double)SMSRefuseCount / RefuseCount));
                    sb.AppendLine("������talking���еĶ���\t" + SMSTalkingCount + "\t" + ((double)SMSTalkingCount / RefuseCount));
                    sb.AppendLine("����\t" + OtherCount + "\t" + ((double)OtherCount / RefuseCount));
                    sb.AppendLine("�ϼ�\t" + RefuseCount + "\t" + ((double)RefuseCount / RefuseCount));
                }
                string filename = ".\\" + outputFile + "\\" + "ͳ�ƽ��.txt";
                FileHelper.WriteFile(sb.ToString(), filename);
            }
            #endregion
        }

    }


    /// <summary>
    /// һ��������
    /// </summary>
    public class InputItem
    {
        /// <summary>
        /// �û���������
        /// </summary>
        public string UserContent;

        /// <summary>
        /// ҵ����
        /// </summary>
        public string BizName;

        /// <summary>
        /// ���캯��
        /// </summary>
        public InputItem()
        {
            UserContent = string.Empty;
            BizName = string.Empty;
            OperaName = string.Empty;
        }

        /// <summary>
        /// ������
        /// </summary>
        public string OperaName;

        /// <summary>
        /// �������Ƿ���Ч
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(UserContent);
            }
        }

        /// <summary>
        /// �ж϶��������Ƿ�ʶ��
        /// </summary>
        public bool IsRec
        {
            get
            {
                return BizName == null ? false : !string.IsNullOrEmpty(BizName.Trim());
            }
        }

    }


}
