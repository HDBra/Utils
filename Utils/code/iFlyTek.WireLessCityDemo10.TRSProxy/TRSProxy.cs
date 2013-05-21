using System;
using System.Data;
using System.Configuration;
using iFlyTek.SMSS10.Common.NLSMS;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace iFlyTek.ECSS30.WirelessCity.LotteryFlows
{
    /// <summary>
    /// ������trs��ͨ��
    /// </summary>
    public static class TRSProxy
    {
        /// <summary>
        /// ��ȡʶ����
        /// </summary>
        /// <param name="toRouteContent">�û���������</param>
        /// <param name="config">TRS�������������� </param>
        /// <returns></returns>
        public static NLSMSResult_Route Route(string toRouteContent,TRSConfig config)
        {
            NLSMSResult_Route routeResult = null;
            try
            {
                routeResult = Get_RouteResult();

                if(toRouteContent==null || string.IsNullOrEmpty(toRouteContent.Trim()) || config == null || !config.IsValid)
                {
                    routeResult.ResultTime = DateTime.Now;
                    routeResult.ResultCode = NLSMSResultCode.InvalidParam;
                    //WriteLog_RecRoute(requestID, toRouteContent, routeResult);
                    return routeResult;
                }

                //���������trs
                Route_Engine(ref routeResult,toRouteContent,config);
                return routeResult;
            }
            catch (Exception ex)
            {
                //ErrorProxy.AddError(ex.ToString());
                //LogWriter.WriteLogSystem(LogLevel.Error, "ʶ�������쳣:" + ex.ToString());
                //LogHelper.WriteSystemLog(LogLevel.Error, "ʶ�������쳣��"+ex.ToString());
                if(routeResult != null)
                {
                    routeResult.ResultTime = DateTime.Now;
                    routeResult.ResultCode = NLSMSResultCode.Routing_RecDllFailed;
                    routeResult.RecType = NLRecType.RecFail;
                    routeResult.IsMultiRouteResult = false;
                    routeResult.IsSuccess = false;
                    routeResult.ResultDesc = "����ʶ��dll���ش���";
                    routeResult.RouteResultItems = new NLSMSResult_Route.RouteResultItem[0];
                }
                return routeResult;
            }

        }

        /// <summary>
        /// ��������gettrs
        /// </summary>
        /// <param name="routeResult"></param>
        private static void Route_Engine(ref NLSMSResult_Route routeResult,string usercontent,TRSConfig config)
        {
            routeResult = new NLSMSResult_Route();
            IPEndPoint endPoint = null;
            Socket socket = null;

            try
            {
                //Encoding encode = Encoding.Default;
                //Ĭ����gb2312�����
                endPoint = new IPEndPoint(IPAddress.Parse(config.TRSIP), config.TRSPort);
                //����socket�������ӷ�������
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.SendTimeout = config.SendTimeout;
                socket.ReceiveTimeout = config.ReceiveTimeout;
                socket.Connect(endPoint);

                //����Ҫ���͵���Ϣ
                StringBuilder buff = new StringBuilder();
                //����request-line
                buff.Append("POST ").Append("/trs_recognize").Append(" HTTP/1.0\r\n");

                //��������ͷ

                Byte[] bodyBytes = new byte[0];
                //����Ƿ���Ҫ���ݰ���

                buff.Append(string.Format("content-length: {0}\r\n", 0));
                buff.Append(string.Format("usrname: {0}\r\n", config.TRSUserName));
                buff.Append(string.Format("password: {0}\r\n", config.TRSPassword));
                buff.Append(string.Format("usercontent: {0}\r\n", usercontent));

                //blank-line
                buff.Append("\r\n");

                //û��request-body
                //����ı��뷽ʽȡ���ڷ������˵ı��뷽ʽ//Encoding.GetEncoding("gb2312") �� Encoding.Default
                Byte[] sendBytes = Encoding.Default.GetBytes(buff.ToString());
                socket.Send(sendBytes);
                //��ŷ������˷��ص��ַ�
                byte[] recvBytes = new byte[1024];
                //ʵ�ʽ��յ����ַ���
                int ibytes;
                //���յ����ַ���
                string recvStr = string.Empty;
                do
                {
                    ibytes = socket.Receive(recvBytes, recvBytes.Length, SocketFlags.None);
                    //����ı��뷽ʽȡ���ڷ������˵ı��뷽ʽ//Encoding.GetEncoding("gb2312")
                    recvStr += Encoding.Default.GetString(recvBytes, 0, ibytes);
                }
                while (ibytes != 0);
                //�������ص��ַ���
                RecongnizeResult result = RecongnizeResult.ParseResponse(recvStr);
                routeResult.RecType = RecongnizeResult.GetRecType(result.HeadProcesstype);
                RecongnizeResult.ParseRoute(result, ref routeResult);

            }
            catch (Exception ex)
            {
                throw new Exception("����trs�����쳣",ex);
            }
            finally
            {
                if (socket != null)
                {
                    //�ر�����
                    socket.Close();
                }
            }
        }

        /// <summary>
        /// ����һ������Ľ��
        /// </summary>
        /// <returns></returns>
        private static NLSMSResult_Route Get_RouteResult()
        {
            NLSMSResult_Route routeResult = new NLSMSResult_Route();
            routeResult.RecType = NLRecType.InvalidRecType;
            routeResult.IsMultiRouteResult = false;
            routeResult.IsSuccess = false;
            routeResult.ResultCode = NLSMSResultCode.Routing_Exception;
            routeResult.ResultTime = DateTime.Now;
            routeResult.EngineNodeName = string.Empty;

            return routeResult;
        }
    }
}
