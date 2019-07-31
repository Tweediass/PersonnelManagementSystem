using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMSystem
{
    public partial class InfoBrowsing : System.Web.UI.Page
    {
        //连接数据库字符串
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;" + "AttachDbFilename='|DataDirectory|\\PMS.mdf';";
        Boolean flag = false;//标记当前用户是否主管

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["permission"] == null || Session["eid"] == null)//未登录用户
                Response.Redirect("Login.aspx");    //跳转到登录页面
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
            }
            int eid = int.Parse(Session["eid"].ToString());
            if (Session["permission"].ToString().Equals("D"))
            {
                flag = true;
                department_Ddl.SelectedIndex = select_departID(eid);
                department_Ddl.Enabled = false;
            }

            if (!Page.IsPostBack)
            {

                if (flag == true)//用户是部门主管
                {
                    departmentDdl_Data_Binding();//绑定数据到department_Ddl中
                    department_Ddl.SelectedIndex = select_departID(eid);
                    employeeDdl_Data_Binding(select_departID(eid));//绑定数据到employee_Ddl中
                    show_Depdata(select_departID(eid));//显示部门员工信息
                }
                else
                {
                    departmentDdl_Data_Binding();//绑定数据到department_Ddl中
                    employeeDdl_Data_Binding(department_Ddl.SelectedIndex);//绑定数据到employee_Ddl中
                    showEmp_Data();//显示所有员工信息
                }
            }

        }

        //绑定数据到department_Ddl中
        private void departmentDdl_Data_Binding()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                string sql = "select dname from department";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(ds, "dname");

                this.department_Ddl.DataSource = ds.Tables[0].DefaultView;
                this.department_Ddl.DataTextField = "dname";
                this.department_Ddl.DataBind();
                //添加一个默认值
                ListItem item = new ListItem();
                item.Text = "所有";
                item.Value = "所有";
                department_Ddl.Items.Insert(0, item);
                cn.Close();
                ds.Clear();
            }
        }

        //绑定数据到employee_Ddl中
        private void employeeDdl_Data_Binding(int departID)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                string sql = "select ename from employee";
                if (departID != 0)
                {
                    sql = "select ename from employee where departID='" + departID + "'";
                }
                cn.ConnectionString = sqlconn;
                cn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(ds, "ename");
                this.employee_Ddl.DataSource = ds.Tables[0].DefaultView;
                this.employee_Ddl.DataTextField = "ename";
                this.employee_Ddl.DataBind();
                //添加一个默认值
                ListItem item = new ListItem();
                item.Text = "所有";
                item.Value = "所有";
                employee_Ddl.Items.Insert(0, item);
                cn.Close();
            }
        }

        //根据员工编号eid查询所属部门departID
        private int select_departID(int eid)
        {
            int did;
            using (SqlConnection cn = new SqlConnection(sqlconn))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select departID from employee where eid=" + eid, cn);
                did = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
            }
            return did;
        }


        ////显示部门员工信息
        private void show_Depdata(int departID)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from employee where departID=" + departID, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                cn.Close();
                dr.Close();
            }
        }

        //选择部门下拉列表，重新绑定部门员工
        protected void department_Ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int departID = department_Ddl.SelectedIndex; // 部门下拉列表索引值
            employeeDdl_Data_Binding(departID);
        }

        //“浏览”按钮点击事件，浏览员工信息
        protected void btn_Browse_Click(object sender, EventArgs e)
        {
            string str = "";//查询字符串
            //清空Gridview数据
            GridView1.DataSource = null;
            GridView1.DataBind();

            if (employee_Ddl.SelectedIndex == 0) //所有员工
            {
                if (department_Ddl.SelectedIndex == 0) //所有部门
                {
                    showEmp_Data(); //查询所有员工信息
                    Label2.Text = "浏览成功！";
                    return;
                }
                else
                {
                    str = "departID = " + department_Ddl.SelectedIndex;
                }
            }
            else
            {
                str = "ename = '" + employee_Ddl.Text.Trim() + "'";
            }
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = sqlconn;
                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand myCommand = new SqlCommand("select * from employee", cn);
                adapter.SelectCommand = myCommand;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "employees");//填充数据集
                DataTable myTable = ds.Tables["employees"];
                SqlCommandBuilder scb = new SqlCommandBuilder(adapter);

                DataRow[] dr = myTable.Select(str);//查询数据
                DataSet newds = new DataSet();
                newds = ds.Clone();
                foreach (DataRow row in dr)
                {
                    newds.Tables["employees"].NewRow();//创建与表具有相同架构的新DataRow
                    newds.Tables["employees"].Rows.Add(row.ItemArray);//ItemArray：获取或设置行中所有列的值。
                }
                ds.Tables["employees"].AcceptChanges();//应用更改
                GridView1.DataSource = newds.Tables["employees"].DefaultView;
                GridView1.DataBind();

                Label2.Text = "浏览成功！";

                cn.Close();
                adapter.Dispose();

            }
        }

        //显示所有员工信息
        public void showEmp_Data()
        {
            using (SqlConnection cn = new SqlConnection(sqlconn))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from employee", cn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                cn.Close();
                adapter.Dispose();
            }
        }

        //“报表”按钮单击事件
        //传递数据并重定向到“数据报表”页面
        protected void btn_Report_Click(object sender, EventArgs e)
        {
            //保存需要浏览的员工数据到客户端
            //员工姓名ename
            HttpCookie browseCookie1 = new HttpCookie("ename");
            browseCookie1.Value = HttpUtility.UrlEncode(employee_Ddl.Text);
            Response.Cookies.Add(browseCookie1);

            //department_Ddl下拉列表的索引，即did
            HttpCookie browseCookie2 = new HttpCookie("depDDL_Index");
            browseCookie2.Value = HttpUtility.UrlEncode(department_Ddl.SelectedIndex.ToString());
            Response.Cookies.Add(browseCookie2);

            //部门名称dname
            HttpCookie browseCookie3 = new HttpCookie("dname");
            browseCookie3.Value = HttpUtility.UrlEncode(department_Ddl.Text);
            Response.Cookies.Add(browseCookie3);

            //重定向到“数据报表”页面
            Response.Redirect("DataReport.aspx");
        }
    }
}