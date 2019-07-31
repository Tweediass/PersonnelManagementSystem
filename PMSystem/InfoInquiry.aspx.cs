using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class infoInquiry : System.Web.UI.Page
    {
        static int flag = 0;
        static string sql = "";
        String sqlconn = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\PMS.mdf'; ";
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
            if (!Page.IsPostBack)
            {
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", ""));
                Display("select eid,ename,departID,age from employee ");
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
            }
        }

        //隐藏控件
        protected void Button1_Click1(object sender, EventArgs e)
        {
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            tr4.Visible = true;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            flag = 0;
            sql = "select eid,ename,departID,age from employee";
            Display(sql);
            Cleartxtbox();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = true;
            tr6.Visible = true;
            tr7.Visible = true;
            flag = 1;
            sql = "select * from department";
            Display(sql);
            Cleartxtbox();
        }

        //查询
        protected void Button3_Click(object sender, EventArgs e)
        {

            List<string> wheres = new List<string>();
            if (TextBox1.Text != "")
            {
                wheres.Add(" eid ='" + TextBox1.Text + "'");
            }
            if (TextBox2.Text != "")
            {
                wheres.Add(" ename =N'" + TextBox2.Text + "'");
            }
            if (DropDownList1.SelectedValue != "")
            {
                wheres.Add(" departID ='" + DropDownList1.SelectedValue + "'");
            }
            if (TextBox4.Text != "")
            {
                wheres.Add(" age ='" + TextBox4.Text + "'");
            }
            if (TextBox5.Text != "")
            {
                wheres.Add(" did ='" + TextBox5.Text + "'");
            }
            if (TextBox6.Text != "")
            {
                wheres.Add(" dname =N'" + TextBox6.Text + "'");
            }
            if (TextBox7.Text != "")
            {
                wheres.Add(" director ='" + TextBox7.Text + "'");
            }
            //判断用户是否选择了条件
            if (flag == 0)
            {
                sql = "select eid,ename,departID,age from employee";
            }
            else
            {
                sql = "select * from department";
            }
            if (wheres.Count > 0)
            {
                string wh = string.Join(" and ", wheres.ToArray());
                sql = sql + " where" + wh;
            }
            Display(sql);
            Cleartxtbox();
        }

        public void Display(String s)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand(s, cn);
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        throw new Exception("输入数据有误，请重新输入数据！！");
                    }
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
                catch (Exception exc)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exc.Message + "')", true);
                }
            }
        }

        public void Cleartxtbox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList1.SelectedValue = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }
    }
}