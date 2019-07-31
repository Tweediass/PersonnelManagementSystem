using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class userManAndLog : System.Web.UI.Page
    {
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
                Response.Redirect("Home.aspx");
                Li2.Visible = false;
                Li4.Visible = false;
                Li6.Visible = false;
                Li8.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", ""));
                showdata("select * from employee ");
            }
        }
        static string mode = "query";
        string s = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\PMS.mdf'; ";

        //取消按钮，点击清空文本框
        protected void Button6_Click(object sender, EventArgs e)
        {
            Cleartxtbox();
        }

        //文本框清空
        public void Cleartxtbox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedIndex = -1;
            DropDownList2.SelectedIndex = -1;
        }

        //增加用户
        protected void Button1_Click(object sender, EventArgs e)
        {
            //使按钮识别哪一个模式
            mode = "insert";
            Button4.Text = "保存";
            Label7.Text = "现在是用户添加模式";
            showdata("select * from employee ");
            Cleartxtbox();
            Hidetr(true);
        }

        //删除用户
        protected void Button5_Click(object sender, EventArgs e)
        {
            mode = "delete";
            Button4.Text = "删除";
            Label7.Text = "现在是删除用户模式";
            showdata("select * from employee ");
            Cleartxtbox();
            Hidetr(false);
            Response.Redirect("UseMan.aspx");
        }

        //修改用户信息
        protected void Button3_Click(object sender, EventArgs e)
        {
            mode = "alert";
            Button4.Text = "保存";
            Label7.Text = "现在是用户信息修改模式";
            Cleartxtbox();
            showdata("select * from employee ");
            Hidetr(true);

        }

        //保存按钮、删除按钮功能
        protected void Button4_Click(object sender, EventArgs e)
        {
            string command = null;
            string wh = null;
            //query模式
            if (mode == "query")
            {
                wh = Choosetxt();
                if (!string.IsNullOrEmpty(wh))
                    command = "select * from employee where " + wh;
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('不能为空，请检查')", true);
                    return;
                }
                showdata(command);
            }
            //insert模式
            else if (mode == "insert")
            {
                //判断是否为空
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && DropDownList2.SelectedValue.Trim() != "")
                {
                    if (DropDownList1.SelectedValue.Trim() == "")
                    {
                        command = string.Format("INSERT INTO [dbo].[employee] " +
                                                        "([eid], [ename], [departID], [age], [password], [permission]) " +
                                                        "VALUES ('{0}', N'{1}', null , '{2}', '{3}', '{4}')", TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox3.Text.Trim(), TextBox4.Text.Trim(), DropDownList2.SelectedValue);
                    }
                    else
                    {
                        command = string.Format("insert into employee(eid,ename,departID,age,password,permission) " +
                            "values('{0}',N'{1}','{2}','{3}','{4}','{5}')",
                            TextBox1.Text.Trim(), TextBox2.Text.Trim(), DropDownList1.SelectedValue, TextBox3.Text.Trim(), TextBox4.Text.Trim(), DropDownList2.SelectedValue);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('不能为空，请检查')", true);
                    return;
                }
            }
            //delete模式
            else if (mode == "delete")
            {
                command = "delete employee where eid='" + TextBox1.Text + "'";

            }
            //修改用户信息
            else if (mode == "alert")
            {
                if (TextBox1.Text.Trim() != "")
                {
                    wh = Choosetxt();
                    if (!DropDownList2.SelectedValue.Equals(""))
                    {
                        if (Session["eid"].ToString().Equals(TextBox1.Text.Trim()))
                        {
                            Session["permission"] = DropDownList2.SelectedValue;
                            Response.Redirect("Home.aspx");
                        }
                    }
                    command += "update employee set " + wh + "where eid=" + TextBox1.Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('请输入用户账号')", true);
                    return;
                }
            }
            if (mode != "")
            {
                if (mode != "query")
                {
                    operation(command);
                    showdata("select * from employee");
                }
                Cleartxtbox();
            }
        }

        //执行SQL语句
        public void operation(string command)
        {
            SqlConnection sql = new SqlConnection(s);
            sql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sql);
            try
            {
                int exc = sqlCommand.ExecuteNonQuery();
                if (exc == 0)
                {
                    throw new Exception("修改失败");
                }
            }
            catch (Exception b)
            {
                string erromessage = b.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + "修改失败" + "')", true);
            }
            sql.Close();
        }

        //输出表的信息
        public void showdata(string command)
        {

            SqlConnection sql = new SqlConnection(s);
            sql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sql);
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("没有这个人");
                }
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
            catch (Exception s)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + s.Message + "')", true);
            }
            sql.Close();
        }

        //隐藏控件
        public void Hidetr(bool i)
        {
            tr1.Visible = i;
            tr2.Visible = i;
            tr3.Visible = i;
            tr4.Visible = i;
            tr5.Visible = i;
        }

        //多条件查询和修改textbox的选值
        public string Choosetxt()
        {
            string wh = null;
            List<string> wheres = new List<string>();
            //判断文本框是否为空，不为空则填入数据
            if (mode == "query")
            {
                if (TextBox1.Text.Trim() != "")
                    wheres.Add(" eid = '" + TextBox1.Text.Trim() + "'");
            }
            if (TextBox2.Text.Trim() != "")//ename
            {
                wheres.Add("ename = N'" + TextBox2.Text.Trim() + "'");
            }
            if (DropDownList1.SelectedItem.Value != "")//did
            {
                wheres.Add(" departID='" + DropDownList1.SelectedItem.Value + "'");
            }
            if (TextBox3.Text.Trim() != "")//age
            {
                wheres.Add("age='" + TextBox3.Text.Trim() + "'");
            }
            if (TextBox4.Text.Trim() != "")//passwd
            {
                wheres.Add("password ='" + TextBox4.Text.Trim() + "'");
            }
            if (DropDownList2.SelectedValue != "")//permission
            {
                wheres.Add("permission ='" + DropDownList2.SelectedValue + "'");
            }
            if (wheres.Count > 0)
            {
                if (mode == "query")
                {
                    wh = string.Join(" and ", wheres.ToArray());

                }
                else if (mode == "alert")
                {
                    wh = string.Join(" ,", wheres.ToArray());
                }
            }
            return wh;
        }

        //查询用户信息
        protected void Button7_Click(object sender, EventArgs e)
        {
            mode = "query";
            Button4.Text = "查询";
            Label7.Text = "现在是用户查询模式";
            Cleartxtbox();
            Hidetr(true);
            showdata("select * from employee ");
        }
    }
}