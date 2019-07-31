using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class PerInfo : System.Web.UI.Page
    {
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\PMS.mdf';";//连接数据库字符串
        string depID = "";
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
            getDepartment(getEmployee());
        }

        public string getEmployee()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string id = Session["eid"].ToString();
                string sql = string.Format("SELECT * FROM employee WHERE eid='{0}'", id);
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    eid.Text += dr[0].ToString();
                    ename.Text += dr[1].ToString();
                    depID = dr[2].ToString();
                    departID.Text += dr[2].ToString();
                    age.Text += dr[3].ToString();
                    password.Text += dr[4].ToString();
                    permission.Text += dr[5].ToString();
                }
            }
            return depID;
        }

        public void getDepartment(string depID)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string sql = string.Format("SELECT * FROM department WHERE did='{0}'", depID);
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    did.Text += dr[0].ToString();
                    dname.Text += dr[1].ToString();
                    director.Text += dr[2].ToString();
                }
            }
        }
    }
}