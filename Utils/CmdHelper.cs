using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace iFlyTek.ECSS30.Tool.BizAdd
{
    public class CmdHelper
    {

        private Process proc = null;
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        public CmdHelper()
        {
            proc = new Process();
        }
        /// <summary> 
        /// 执行CMD语句 
        /// </summary> 
        /// <param name="cmd">要执行的CMD命令</param> 
        public void RunCmd(string cmd)
        {
            try
            {
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.StandardInput.WriteLine(cmd);
                proc.StandardInput.WriteLine("exit");
                Console.WriteLine("执行停止webservice的输出"+proc.StandardOutput.ReadToEnd());
            }
            finally
            {
                if (proc != null)
                {
                    proc.Close();
                }
            }
        }
        /// <summary> 
        /// 打开软件并执行命令 
        /// </summary> 
        /// <param name="programName">软件路径加名称（.exe文件）</param> 
        /// <param name="cmd">要执行的命令</param> 
        public void RunProgram(string programName, string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = programName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            if (cmd.Length != 0)
            {
                proc.StandardInput.WriteLine(cmd);
            }
            proc.Close();
        }
        /// <summary> 
        /// 打开软件 
        /// </summary> 
        /// <param name="programName">软件路径加名称（.exe文件）</param> 
        public void RunProgram(string programName)
        {
            this.RunProgram(programName, "");
        }
    }


}

