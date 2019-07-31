using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class InfoDeletion : System.Web.UI.Page
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
                div1.Visible = false;
                Li2.Visible = false;
                Li4.Visible = false;
                Li6.Visible = false;
                Li8.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                if (Session["permission"].ToString().Equals("A"))
                {
                    DropDownList1.Visible = false;
                    DropDownList2.Visible = false;
                }
                else
                {
                    DropDownList5.Visible = false;
                    DropDownList6.Visible = false;
                }
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", ""));
                this.DropDownList2.DataBind();
                this.DropDownList2.Items.Insert(0, new ListItem("--请选择--", ""));
                this.DropDownList3.DataBind();
                this.DropDownList3.Items.Insert(0, new ListItem("--请选择--", ""));
                this.DropDownList4.DataBind();
                this.DropDownList4.Items.Insert(0, new ListItem("--请选择--", ""));
                this.DropDownList5.DataBind();
                this.DropDownList5.Items.Insert(0, new ListItem("--请选择--", ""));
                this.DropDownList6.DataBind();
                this.DropDownList6.Items.Insert(0, new ListItem("--请选择--", ""));
                ShowData();
                ShowData1();
            }
        }

        //员工表批量删除
        protected void btnDelete_Click4(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string sql = " delete  from employee where eid in (";
                bool cbx = false;
                List<String> where = new List<string>();

                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    cbx = ((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked;

                    if (cbx)//如果被选中
                    {
                        //假设把每一行的id放在第一列
                        where.Add(GridView1.Rows[i].Cells[1].Text.Trim());//这就是所在行的id，赋值给了myid
                    }
                }
                if (where.Count > 0)
                {
                    string wh = string.Join(" ,", where.ToArray());
                    sql = sql + wh + ")";
                    if (Session["permission"].ToString().Equals("D"))
                    {
                        sql += " AND departID='" + Session["departID"].ToString() + "'";
                    }
                    sql += " AND eid != '" + Session["eid"].ToString() + "'";
                    try
                    {
                        SqlCommand com = new SqlCommand(sql, cn);
                        int num = com.ExecuteNonQuery();
                        if (num == 0)
                        {
                            throw new Exception("操作失败，请检查");
                        }
                        Response.Redirect("InfoDeletion.aspx");
                    }
                    catch (Exception exc)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('操作失败，请检查')", true);
                    }
                }
                else
                {
                    return;
                }
                ShowData();
            }
        }

        //员工表单条删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                if (Session["permission"].ToString().Equals("D"))
                {
                    string sqldelete = "";
                    try
                    {
                        if ((DropDownList1.Text != "") && (DropDownList2.Text != ""))
                            sqldelete = "delete from employee where  eid ='" + DropDownList1.SelectedValue + "' and ename='" + DropDownList2.SelectedValue + "' ";
                        else if (DropDownList1.Text != "")
                            sqldelete = "delete from employee where eid='" + DropDownList1.SelectedValue + "'";
                        else if (DropDownList2.Text != "")
                            sqldelete = "delete from employee where ename=N'" + DropDownList2.SelectedValue + "'";
                        sqldelete += " AND departID='" + Session["departID"].ToString() + "' AND eid != '" + Session["eid"].ToString() + "'";
                        Label5.Text = "";
                        SqlCommand cmd = new SqlCommand(sqldelete, cn);
                        int a = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Label5.Text = ex.Message;
                    }
                }
                if (Session["permission"].ToString().Equals("A"))
                {
                    string sqldelete = "";
                    try
                    {
                        if ((DropDownList5.Text != "") && (DropDownList6.Text != ""))
                            sqldelete = "delete from employee where  eid ='" + DropDownList5.SelectedValue + "' and ename='" + DropDownList6.SelectedValue + "' ";
                        else if (DropDownList5.Text != "")
                            sqldelete = "delete from employee where eid='" + DropDownList5.SelectedValue + "'";
                        else if (DropDownList6.Text != "")
                            sqldelete = "delete from employee where ename=N'" + DropDownList6.SelectedValue + "'";
                        sqldelete += " AND eid != '" + Session["eid"].ToString() + "'";
                        SqlCommand cmd = new SqlCommand(sqldelete, cn);
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            throw new Exception("删除失败，请重新输入数据！");
                        }
                        Response.Redirect("InfoDeletion.aspx");
                    }
                    catch (Exception ex)
                    {
                        Label5.Text = ex.Message;
                    }
                }
                ShowData();
            }
        }

        //部门表单条删除
        protected void btnDelete_Click3(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string sql = " delete  from department where did in (";
                bool cbx = false;
                List<String> where = new List<string>();
                for (int i = 0; i < this.GridView2.Rows.Count; i++)
                {
                    cbx = ((CheckBox)GridView2.Rows[i].FindControl("cbSelect")).Checked;

                    if (cbx)//如果被选中
                    {
                        //假设把每一行的id放在第一列
                        where.Add(GridView2.Rows[i].Cells[1].Text.Trim());//这就是所在行的id，赋值给了myid
                    }
                }
                if (where.Count > 0)
                {
                    string wh = string.Join(" ,", where.ToArray());
                    sql = sql + wh + ")";
                    SqlCommand com = new SqlCommand(sql, cn);
                    try
                    {
                        int num = com.ExecuteNonQuery();
                        Response.Redirect("InfoDeletion.aspx");
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('操作失败，请检查一下')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('操作失败，请检查')", true);
                    return;
                }
                ShowData1();
            }
        }

        //部门表单条删除
        protected void btnDelete_Click2(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string sqldelete = "";
                try
                {
                    if ((DropDownList3.Text != "") && (DropDownList4.Text != ""))
                        sqldelete = "delete from department where  did ='" + DropDownList3.SelectedValue + "' and dname='" + DropDownList4.SelectedValue + "' ";
                    if (DropDownList3.Text != "")
                        sqldelete = "delete from department where did='" + DropDownList3.SelectedValue + "'";
                    if (DropDownList4.Text != "")
                        sqldelete = "delete from department where dname=N'" + DropDownList4.SelectedValue + "'";
                    Label1.Text = "";
                    SqlCommand cmd = new SqlCommand(sqldelete, cn);
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        throw new Exception("删除失败，请重新输入数据！");
                    }
                    Response.Redirect("InfoDeletion.aspx");
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message + "#" + sqldelete;
                }
                ShowData1();
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
                cmd = new SqlCommand("SELECT dname FROM department where did='" + did + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    depName = dr[0].ToString();
                }
            }
            return depName;
        }

        void ShowData()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd;
                string sql = "SELECT * FROM employee";
                TextBox6.Visible = false;
                Label9.Visible = false;
                if (Session["permission"].ToString().Equals("D"))
                {
                    sql += " where departID='" + Session["departID"] + "'";
                    Label9.Visible = true;
                    TextBox6.Visible = true;
                    TextBox6.Text = getDepName(Session["departID"].ToString());
                }
                cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
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
            }
        }
    }
}