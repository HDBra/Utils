﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;


namespace Com.Utility.Commons
{
    /// <summary>
    /// MySql的帮助类，需要添加引用MySql.Data.dll
    /// </summary>
    public class MySqlHelper
    {
        #region 单件实例
        /// <summary>
        /// 私有的构造函数
        /// </summary>
        private MySqlHelper()
        {

        }

        /// <summary>
        /// MySqlHelper的单件实例
        /// </summary>
        private static MySqlHelper _instance;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string _connectionString = "Server=localhost;Database=bbs;Uid=root;Pwd=558276344;Port=3306;CharSet=UTF8";
      
        /// <summary>
        /// 获取使用默认连接字符串的SqlHelper唯一实例
        /// </summary>
        /// <returns></returns>
        public static MySqlHelper GetInstance()
        {
            //如果_instance为null，则构建一个实例
            return _instance ?? (_instance = new MySqlHelper());
        }

        /// <summary>
        /// 设置连接字符串，并返回该连接字符串的唯一MySql实例
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static MySqlHelper GetInstance(string connString)
        {
            if(_instance == null)
            {
                //创建实例
                _instance = new MySqlHelper();
            }

            if(!string.IsNullOrEmpty(connString))
            {
                //设置连接字符串
                _instance._connectionString = connString;
            }

            return _instance;
        }

        #endregion

        #region 测试连接是否畅通

        /// <summary>
        /// 测试数据库连接是否畅通
        /// </summary>
        /// <returns>返回true，表示数据库连接畅通；返回false，表示数据库连接不畅通</returns>
        public bool IsConnectionActive()
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(_connectionString);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                if(ex != null)
                {
                    
                }
                return false;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region 执行sql语句

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns> </returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, MySqlParameter[] parameters)
        {
            int count = 0;
            using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using(MySqlCommand command = new MySqlCommand(sql,conn))
                {
                    command.CommandType = commandType;
                    if(parameters != null)
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    conn.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            return count;
        }


        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(sql, CommandType.Text, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql, CommandType commandType)
        {
            return ExecuteDataSet(sql, commandType, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql, CommandType commandType, MySqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using(MySqlCommand command = new MySqlCommand(sql,conn))
                {
                    command.CommandType = commandType;
                    if(parameters != null)
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(ds);
                }
            }
            return ds;
        }



        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using(MySqlCommand command = new MySqlCommand(sql,conn))
                {
                    command.CommandType = commandType;
                    if(parameters != null)
                    {
                        //clear是为了调试使用的
                        command.Parameters.Clear();
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


        /// <summary>
        /// ExecuteReader执行一查询，返回一<c>SqlDataReader</c>对象实例（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns></returns>
        /// <remarks>
        /// <example>
        /// 返回值SqlDataReader使用完毕后，应关闭。
        /// <code>
        /// MySqlDataReader sdr = object.ExecuteReader(sql);
        /// while(sdr.Read())
        /// {
        /// }
        /// sdr.Close();
        /// </code>
        /// </example>
        /// </remarks>
        public MySqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteReader执行一查询，返回一SqlDataReader对象实例（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public MySqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>
        /// ExecuteReader执行一查询，返回MySqldataReader对象实例(3)
        /// </summary>
        /// <param name="sql">要执行的sql语句或者存储过程</param>
        /// <param name="commandType">要执行的查询类型</param>
        /// <param name="parameters">参数数组</param>
        /// <returns></returns>
        /// <example>
        /// 返回值SqlDataReader使用完毕后，应关闭。
        /// <code>
        /// MySqlDataReader sdr = object.ExecuteReader(sql);
        /// while(sdr.Read())
        /// {
        /// }
        /// sdr.Close();
        /// </code>
        /// </example>
        public MySqlDataReader ExecuteReader(string sql,CommandType commandType,MySqlParameter[] parameters)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(sql,conn);
            command.CommandType = commandType;
            if(parameters != null)
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            conn.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }


        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（1）,如果为空，返回null.
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }


        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql, CommandType commandType, MySqlParameter[] parameters)
        {
            object result = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using(MySqlCommand command = new MySqlCommand(sql,conn))
                {
                    command.CommandType = CommandType.Text;
                    if(parameters != null)
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    conn.Open();
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        /// <summary>
        /// 返回当前连接的数据库中所有用户创建的数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            DataTable dt = null;
            using(MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                dt = conn.GetSchema("Tables");
            }
            return dt;
        }

        #endregion
    }
}
