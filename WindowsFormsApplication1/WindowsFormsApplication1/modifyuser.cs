using MySql.Data.MySqlClient;
/*
 *==================
 *创建人：琚建飞
 *创建时间：2017/7/8 19:28:21
 *说明：
 *==================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class modifyuser : Form
    {
        public modifyuser()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;//获取配置文件中的连接字符串
            MySqlConnection conn = new MySqlConnection(connStr); //实例化连接
            conn.Open();

            String sql = "update user set password='"+password+"' where username='"+name+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //执行结果赋值到dr，dr为只读
            int dr = cmd.ExecuteNonQuery();
            if (dr > 0)
            {
                MessageBox.Show("更新成功！", "温馨提示");
            }
            else
            {
                MessageBox.Show("更新失败！", "温馨提示");
            }
        }
    }
}
