using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public class MySqlHelper
    {
        public MySqlConnection conn = null;
        DataTable dt = new DataTable();
        int res;

        public MySqlHelper()
        {
            //引用配置文件内容
            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
        }

        private MySqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// 该方法执行带参数的增删改MySql语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改MySql语句或存储过程</param>
        /// <param name="sp">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, MySqlParameter[] sp, CommandType ct)
        {
            using (MySqlCommand cmd = new MySqlCommand(cmdText, GetConn()))
            {
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(sp);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        /// <summary>
        /// 该方法执行不带参数的增删改MySql语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改MySql语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, CommandType ct)
        {
            using (MySqlCommand cmd = new MySqlCommand(cmdText, GetConn()))
            {
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        /// <summary>
        /// 该方法执行带参数的MySql查询语句或存储过程
        /// </summary>
        /// <param name="cmdText">MySql查询语句或存储过程</param>
        /// <param name="sp">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, MySqlParameter[] sp, CommandType ct)
        {
            MySqlCommand cmd = new MySqlCommand(cmdText, GetConn());
            cmd.Parameters.AddRange(sp);
            cmd.CommandType = ct;
            using (MySqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }

        /// <summary>
        /// 该方法执行不带参数的MySql查询语句或存储过程
        /// </summary>
        /// <param name="cmdText">MySql查询语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            MySqlCommand cmd = new MySqlCommand(cmdText, GetConn());
            cmd.CommandType = ct;
            using (MySqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        } 
    }
}
