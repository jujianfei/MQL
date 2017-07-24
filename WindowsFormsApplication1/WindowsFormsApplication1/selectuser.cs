using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //引入mysql数据接口

namespace WindowsFormsApplication1
{
    public partial class selectuser : Form
    {
        public selectuser()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            //MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            //sb.Server = "127.0.0.1";
            //sb.Port = 3306; 
            //sb.Database = "login";
            //sb.UserID = "root";
            //sb.Password = "jujianfei";
            //sb.CharacterSet = "utf8";
            //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;//获取配置文件中的连接字符串
            //MySqlConnection conn = new MySqlConnection(connStr); //实例化连接
            //conn.Open();
            MySqlHelper helper = new MySqlHelper();
            MySqlParameter[] sp = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };

            DataTable result = helper.ExecuteQuery("pro_test",sp,CommandType.StoredProcedure);
            //String sql = "select * from user where username='" + name + "' and password='" + password + "'";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //执行结果赋值到dr，dr为只读
            //MySqlDataReader dr = cmd.ExecuteReader();
            if (result.Rows.Count>0) 
            {
                modifyuser f = new modifyuser();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("登录失败！", "温馨提示");
            }
        }
    }
}
