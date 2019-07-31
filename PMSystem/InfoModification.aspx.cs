using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class InfoModification : System.Web.UI.Page
    {
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;" + "AttachDbFilename='|DataDirectory|\\PMS.mdf';";
        protected void Page_Load(object sender, EventArgs e)
        {
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
                UpdatePanel2.Visible = false;
                Li2.Visible = false;
                Li4.Visible = false;
                Li6.Visible = false;
                Li8.Visible = false;
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            TextBox9.Enabled = false;
            if (!Page.IsPostBack)
            {
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", ""));

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
                ShowData();
                ShowData1();
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

        //显示资料至GridView
        void ShowData()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd;
                string sql = "SELECT * FROM employee";
                TextBox9.Visible = false;
                if (Session["permission"].ToString().Equals("D"))
                {
                    sql += " where departID='" + Session["departID"] + "'";
                    TextBox9.Visible = true;
                    TextBox9.Text = getDepName(Session["departID"].ToString());
                    DropDownList1.Visible = false;

                }
                cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
        }

        //修改员工信息               
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                string sqlupdate = "";
                string s1 = "", s2, s3, s4, s5;
                cn.ConnectionString = sqlconn; cn.Open();
                try
                {
                    sqlupdate = "UPDATE employee set  ";
                    if (TextBox1.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('员工代号不能为空！！')", true);
                        return;
                    }

                    if (TextBox2.Text != "")
                        s1 = "ename=N'" + TextBox2.Text + "'";

                    if (DropDownList1.Text != "")
                    {
                        s2 = " departID ='" + DropDownList1.SelectedValue + "'";
                        if (s1 != "") s1 += ",";
                        s1 += s2;
                    }

                    if (TextBox3.Text != "")
                    {
                        s3 = "age='" + TextBox3.Text + "'";
                        if (s1 != "") s1 += ",";
                        s1 += s3;
                    }

                    if (TextBox4.Text != "")
                    {
                        s4 = "password='" + TextBox4.Text + "'";
                        if (s1 != "") s1 += ",";
                        s1 += s4;
                    }

                    if (DropDownList2.Text != "")
                    {
                        s5 = " permission ='" + DropDownList2.SelectedValue + "'";
                        if (Session["eid"].ToString().Equals(TextBox1.Text.Trim()))
                        {
                            Session["permission"] = DropDownList2.SelectedValue;
                            Response.Redirect("Home.aspx");
                        }
                        if (s1 != "") s1 += ",";
                        s1 += s5;
                    }
                    s1 += "where eid = '" + TextBox1.Text + "' ";
                    sqlupdate += s1;
                    if (Session["permission"].ToString() == "D")
                    {
                        sqlupdate += " AND departID='" + Session["departID"].ToString() + "'";
                    }
                    SqlCommand cmd = new SqlCommand(sqlupdate, cn);
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)//判断受影响的行数是否为0
                    {
                        throw new Exception("输入数据有误，请重新输入数据！！");
                    }
                    Label7.Text = "修改成功";
                }
                catch (Exception ex)
                {
                    Label7.Text = "修改失败,请重新输入数据";
                }
                ShowData();
            }
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

        void ShowData1()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM  department", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView2.DataSource = dr;
                GridView2.DataBind();
                Cleartxtbox();
            }
        }

        //修改部门信息               
        protected void btnUpdate_Click2(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                string set = "";
                cn.ConnectionString = sqlconn; cn.Open();
                try
                {
                    if (TextBox6.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('部门代号不能为空！！')", true);
                        return;
                    }

                    string sqlupdate = "UPDATE department set  ";
                    if (TextBox7.Text != "")
                        set += " dname=N'" + TextBox7.Text + "' ";
                    if (TextBox8.Text != "")
                    {
                        if (set != "")
                            set += " , ";
                        set += " director=' " + Convert.ToInt32(TextBox8.Text) + "'";
                    }
                    sqlupdate += set + " where did='" + TextBox6.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlupdate, cn);
                    int a = cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('修改成功！')", true);
                    Label11.Text = "";
                }
                catch (Exception ex)
                {
                    Label11.Text = ex.Message;
                }
                ShowData1();
            }
        }

        public void Cleartxtbox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList2.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }
    }
}