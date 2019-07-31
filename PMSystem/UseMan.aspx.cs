using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class _default : System.Web.UI.Page
    {
        string s = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\PMS.mdf'; ";

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
            if (!IsPostBack)
                datashow("select * from employee");
        }

        //删除按钮
        protected void Button4_Click(object sender, EventArgs e)
        {
            string command = null;
            if (TextBox1.Text.Trim() != "")
            {
                command = "delete employee where eid='" + TextBox1.Text + "'";
                command += " AND eid != '" + Session["eid"].ToString() + "'";
                operation(command);
                datashow("select * from employee");
                Cleartxtbox();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('操作失败，请输入数据')", true);
                return;
            }

        }

        //批量删除按钮
        protected void Button8_Click(object sender, EventArgs e)
        {
            string sql = " delete  from employee where eid in (";
            bool cbx = false;
            List<String> where = new List<string>();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                cbx = ((CheckBox)GridView1.Rows[i].FindControl("cbxId")).Checked;
                if (cbx)//如果被选中
                {
                    //假设把每一行的id放在第二列
                    where.Add(GridView1.Rows[i].Cells[1].Text.Trim());//这就是所在行的id，赋值给了myid
                }
            }
            if (where.Count > 0)
            {
                string wh = string.Join(" ,", where.ToArray());
                sql = sql + wh + ")";
                sql += " AND eid != '" + Session["eid"].ToString() + "'";
                operation(sql);
                datashow("select * from employee");
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('操作失败，请检查')", true);
                return;
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
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('操作失败，请检查')", true);
            }
            sql.Close();
        }

        public void datashow(string command)
        {
            SqlConnection sql = new SqlConnection(s);
            sql.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sql);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
        }

        //查询按钮
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMan.aspx");
        }

        //添加用户
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMan.aspx");
        }

        //删除用户
        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        //用户信息修改
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMan.aspx");
        }

        //文本框清空
        public void Cleartxtbox()
        {
            TextBox1.Text = "";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}