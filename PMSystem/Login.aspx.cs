using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class Login : System.Web.UI.Page
    {
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\PMS.mdf';";//连接数据库字符串
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["permission"] = null;
                Session["eid"] = null;
                Label3.Visible = false;
            }
        }

        //验证输入的账号与密码是否正确
        protected void login(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string id = TextBox0.Text.Trim();
                string pwd = TextBox1.Text.Trim();
                string sql = string.Format("SELECT * FROM employee WHERE eid='{0}' AND password='{1}'", id, pwd);
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    TextBox0.Text = "";
                    Label3.Visible = true;
                }
                else
                {
                    while (dr.Read())
                    {
                        Session["permission"] = dr[5].ToString();
                        Session["eid"] = dr[0].ToString();
                        Session["departID"] = dr[2].ToString();
                    }
                    Response.Redirect("Home.aspx");
                    //Label3.Text = Session["permission"].ToString();
                }
            }
        }
    }
}