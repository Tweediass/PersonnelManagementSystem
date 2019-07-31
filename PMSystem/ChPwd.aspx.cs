using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class ChPwd : System.Web.UI.Page
    {
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\PMS.mdf';";//连接数据库字符串
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["permission"] == null || Session["eid"] == null)
                Response.Redirect("Login.aspx");
            if (Session["permission"].ToString().Equals("U"))
            {
                Li9.Visible = false;
                Li10.Visible = false;
                Li11.Visible = false;
                Li7.Visible = false;
                Li8.Visible = false;
            }
            if (Session["permission"].ToString().Equals("D"))
            {
                Li2.Visible = false;
                Li4.Visible = false;
                Li6.Visible = false;
                Li8.Visible = false;
            }
        }

        protected void confirm(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string id = Session["eid"].ToString();
                string newP = TextBox1.Text.Trim();
                string newP2 = TextBox2.Text.Trim();
                if (!newP.Equals(newP2))
                {
                    tips.Text = "密码不匹配。";
                    return;
                }
                string oldP = TextBox0.Text.Trim();
                string sql = string.Format("UPDATE employee SET password='{0}' WHERE eid='{1}' AND password=N'{2}'", newP, id, oldP);
                SqlCommand cmd = new SqlCommand(sql, cn);
                int affRows = cmd.ExecuteNonQuery();
                if (affRows == 0)//判断受影响的行数是否为0
                {
                    tips.Text = "修改密码失败，请重新输入。";
                }
                else
                {
                    tips.Text = "修改密码成功。";
                }
            }
        }

        protected void cancel(object sender, EventArgs e)
        {
            TextBox0.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}