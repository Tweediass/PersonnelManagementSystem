using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PMSystem
{
    public partial class infoEntry : System.Web.UI.Page
    {
        static int flag = 0;
        String sqlconn = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\PMS.mdf'; ";
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.Enabled = false;
            if (Session["permission"] == null || Session["eid"] == null)
                Response.Redirect("Login.aspx");
            if (Session["permission"].ToString().Equals("U"))
            {
                Response.Redirect("Home.aspx");
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
                Button2.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", ""));
                ShowData("employee");
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                if (Session["permission"].ToString().Equals("D"))
                {
                    departmentDdl_Data_Binding();
                    this.DropDownList2.Items.Insert(0, new ListItem("--请选择--", ""));
                }
                if (Session["permission"].ToString().Equals("A"))
                {
                    departmentDdl_Data_Binding1();
                    this.DropDownList2.Items.Insert(0, new ListItem("--请选择--", ""));
                }
            }
        }

        //绑定数据DropDownList2
        private void departmentDdl_Data_Binding()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                //添加一个默认值
                ListItem item = new ListItem();
                item.Text = "U(普通用户)";
                item.Value = "U";
                ListItem item1 = new ListItem();
                item1.Text = "D(部门主管)";
                item1.Value = "D";
                DropDownList2.Items.Insert(0, item);
                DropDownList2.Items.Insert(1, item1);
                cn.Close();
            }
        }

        private void departmentDdl_Data_Binding1()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                //添加一个默认值
                ListItem item = new ListItem();
                item.Text = "U(普通用户)";
                item.Value = "U";
                ListItem item1 = new ListItem();
                item1.Text = "D(部门主管)";
                item1.Value = "D";
                ListItem item2 = new ListItem();
                item2.Text = "A(管理员)";
                item2.Value = "A";
                DropDownList2.Items.Insert(0, item);
                DropDownList2.Items.Insert(1, item1);
                DropDownList2.Items.Insert(2, item2);
                cn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            tr4.Visible = true;
            tr5.Visible = true;
            tr12.Visible = true;
            tr6.Visible = false;
            tr7.Visible = false;
            tr8.Visible = false;
            flag = 0;
            ShowData("employee");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr12.Visible = false;
            tr6.Visible = true;
            tr7.Visible = true;
            tr8.Visible = true;
            flag = 1;
            ShowData("department");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string depId = DropDownList1.SelectedValue.Trim();
                if (Session["permission"].ToString().Equals("D"))
                {
                    if (flag == 0)
                    {
                        depId = Session["departID"].ToString();
                    }
                }
                string sqlstr;
                if (flag == 0)
                {
                    if (TextBox1.Text.Trim() == "" || TextBox2.Text.Trim() == "" || TextBox4.Text.Trim() == "" || TextBox5.Text.Trim() == "" || TextBox5.Text.Trim() == "" || DropDownList2.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('文本域不可为空')", true);
                        return;
                    }
                    if (depId == "")
                        sqlstr = string.Format("INSERT INTO [dbo].[employee] " +
                                                        "([eid], [ename], [departID], [age], [password], [permission]) " +
                                                        "VALUES ('{0}', N'{1}', null , '{2}', '{3}', '{4}')", TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox4.Text.Trim(), TextBox5.Text.Trim(), DropDownList2.SelectedValue);
                    else
                        sqlstr = string.Format("INSERT INTO [dbo].[employee] " +
                                "([eid], [ename], [departID], [age], [password], [permission]) " +
                                "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', '{5}')", TextBox1.Text.Trim(), TextBox2.Text.Trim(), depId, TextBox4.Text.Trim(), TextBox5.Text.Trim(), DropDownList2.SelectedValue);
                }
                else
                {
                    if (TextBox6.Text.Trim() != "" && TextBox7.Text.Trim() != "")
                    {
                        if (TextBox8.Text.Trim() == "")
                            sqlstr = string.Format("INSERT INTO [dbo].[department] ([did], [dname], [director]) " +
                            "VALUES ('{0}',  N'{1}', null)", TextBox6.Text.Trim(), TextBox7.Text.Trim());
                        else
                            sqlstr = string.Format("INSERT INTO [dbo].[department] ([did], [dname], [director]) " +
                                "VALUES ('{0}',  N'{1}', '{2}')", TextBox6.Text.Trim(), TextBox7.Text.Trim(), TextBox8.Text.Trim());
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('文本域不可为空')", true);
                        return;
                    }
                }
                Cleartxtbox();
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlstr, cn);
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows == 0)//判断受影响的行数是否为0
                    {
                        throw new Exception("输入数据有误，请重新输入数据！！");
                    }
                    Response.Redirect("InfoEntry.aspx");
                    if (flag == 0)
                        ShowData("employee");
                    else
                        ShowData("department");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('录入失败！请重新输入数据')", true);
                }
            }
        }

        protected void ShowData(string table)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd;
                string sql = "SELECT * FROM " + table;
                TextBox3.Visible = false;
                if (Session["permission"].ToString().Equals("D"))
                {
                    if (flag == 0)
                    {
                        sql += " where departID='" + Session["departID"] + "'";
                        TextBox3.Visible = true;
                        TextBox3.Text = getDepName(Session["departID"].ToString());
                        DropDownList1.Visible = false;
                    }
                }
                cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
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
            TextBox8.Text = "";
        }

        public string getDepName(string did)
        {
            string depName = null;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT dname FROM Department where did='" + did + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    depName = dr[0].ToString();
                }
            }
            return depName;
        }
    }
}