using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using DataTable = System.Data.DataTable;

namespace PMSystem
{
    public partial class DataReport : System.Web.UI.Page
    {
        public string TableText = null;

        //连接数据库字符串
        string sqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;" + "AttachDbFilename='|DataDirectory|\\PMS.mdf';";

        DataSet myDs = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["permission"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string depDDL_Index = HttpUtility.UrlDecode(Request.Cookies["depDDL_Index"].Value.ToString());
            string dname = HttpUtility.UrlDecode(Request.Cookies["dname"].Value.ToString());
            string ename = HttpUtility.UrlDecode(Request.Cookies["ename"].Value.ToString());
            string str = ""; //查询字符串

            //查询员工信息
            if (ename == "所有") //所有员工
            {
                if (int.Parse(depDDL_Index) == 0) //所有部门
                {
                    using (SqlConnection cn = new SqlConnection(sqlconn))
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select * from employee", cn);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(myDs);
                        showData("所有", ename);//将数据显示到页面中
                        Response.Cookies["depDDL_Index"].Value = null;
                        Response.Cookies["dname"].Value = null;
                        Response.Cookies["ename"].Value = null;
                        cn.Close();
                        adapter.Dispose();
                    }
                    return;
                }
                else
                {
                    str = "departID = " + int.Parse(depDDL_Index);
                }
            }
            else
            {
                str = "ename = '" + ename + "'";
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

                myDs = ds.Clone();
                foreach (DataRow row in dr)
                {
                    myDs.Tables["employees"].NewRow();//创建与表具有相同架构的新DataRow
                    myDs.Tables["employees"].Rows.Add(row.ItemArray);//ItemArray：获取或设置行中所有列的值。
                }
                ds.Tables["employees"].AcceptChanges();//应用更改

                showData(dname, ename);//将数据显示到页面中
                //关闭数据库
                cn.Close();
                adapter.Dispose();
                Response.Cookies["depDDL_Index"].Value = null;
                Response.Cookies["dname"].Value = null;
                Response.Cookies["ename"].Value = null;
            }
        }

        //将数据显示到页面中
        private void showData(string dname, string ename)
        {
            TableText +="<!--startprint-->";
            TableText +="&nbsp;";
            TableText +="<h3>" + dname + "部门 " + ename + "员工的信息</h3>";
            TableText +="<table border=1, cellspacing=0, cellpadding=2>";
            DataTable myTable = myDs.Tables[0];
            TableText +="<tr bgcolor=#DAB4B4>";
            foreach (DataColumn myColumn in myTable.Columns)
            {
                TableText +="<td>" + myColumn.ColumnName + "</td>";
            }
            TableText +="</tr>";
            foreach (DataRow myRow in myTable.Rows)
            {
                TableText +="<tr>";
                foreach (DataColumn myColumn in myTable.Columns)
                {
                    TableText +="<td>" + myRow[myColumn] + "</td>";
                }
                TableText +="</tr>";
            }
            TableText +="</table>";
            TableText += "<!--endprint-->";
        }

        //“打印”按钮单击事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            DataSet2Excel(myDs);
        }

        public static void DataSet2Excel(DataSet ds)
        {
            int maxRow = ds.Tables[0].Rows.Count;
            string fileName = DateTime.Now.ToString("yyyyMMddhh") + ".xls";//设置导出文件的名称

            DataView dv = new DataView(ds.Tables[0]);//将DataSet转换成DataView
            string fileURL = string.Empty;

            //调用方法将文件写入服务器,并获取全部路径
            fileURL = DataView2ExcelBySheet(dv, System.Web.HttpUtility.UrlEncode(fileName));
            //获取路径后从服务器下载文件至本地
            HttpContext curContext = System.Web.HttpContext.Current;
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.Default;
            curContext.Response.AppendHeader("Content-Disposition", ("attachment;filename=" + fileName));
            curContext.Response.Charset = "";

            curContext.Response.WriteFile(fileURL);
            curContext.Response.Flush();
            curContext.Response.End();
        }

        /// <summary>
        /// 分Sheet导出Excel文件
        /// </summary>
        /// <param name="dv">需导出的DataView</param>
        /// <returns>导出文件的路径</returns>
        private static string DataView2ExcelBySheet(DataView dv, string fileName)
        {
            int sheetRows = 1000;
            int sheetCount = (dv.Table.Rows.Count - 1) / sheetRows + 1;//计算Sheet数

            GC.Collect();//垃圾回收

            Application excel = new Application();
            Workbook xBk = excel.Workbooks.Add(true);
            Worksheet xSt = null;

            //定义循环中要使用的变量
            int dvRowStart;
            int dvRowEnd;
            int rowIndex = 0;
            int colIndex = 0;
            //对全部Sheet进行操作
            for (int sheetIndex = 0; sheetIndex < sheetCount; sheetIndex++)
            {
                //初始化Sheet中的变量
                rowIndex = 1;
                colIndex = 1;
                //计算起始行
                dvRowStart = sheetIndex * sheetRows;
                dvRowEnd = dvRowStart + sheetRows - 1;
                if (dvRowEnd > dv.Table.Rows.Count - 1)
                {
                    dvRowEnd = dv.Table.Rows.Count - 1;
                }
                //创建一个Sheet
                if (null == xSt)
                {
                    xSt = (Worksheet)xBk.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                }
                else
                {
                    xSt = (Worksheet)xBk.Worksheets.Add(Type.Missing, xSt, 1, Type.Missing);
                }
                //设置Sheet的名称
                xSt.Name = "Expdata";
                if (sheetCount > 1)
                {
                    xSt.Name += ((int)(sheetIndex + 1)).ToString();
                }
                //取得标题
                foreach (DataColumn col in dv.Table.Columns)
                {
                    //设置标题格式
                    //xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = XlVAlign.xlVAlignCenter; //设置标题居中对齐
                    //xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).Font.Bold = true;//设置标题为粗体
                    //填值，并进行下一列
                    excel.Cells[rowIndex, colIndex++] = col.ColumnName;
                }
                //取得表格中数量
                int drvIndex;
                for (drvIndex = dvRowStart; drvIndex <= dvRowEnd; drvIndex++)
                {
                    DataRowView row = dv[drvIndex];
                    //新起一行，当前单元格移至行首
                    rowIndex++;
                    colIndex = 1;

                    foreach (DataColumn col in dv.Table.Columns)
                    {
                        if (col.DataType == System.Type.GetType("System.DateTime"))
                        {
                            excel.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                        }
                        else if (col.DataType == System.Type.GetType("System.String"))
                        {
                            excel.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                        }
                        else
                        {
                            excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                        }
                        colIndex++;
                    }
                }

            }
            //设置导出文件在服务器上的文件夹
            string exportDir = "~/Upload/";//注意:该文件夹您须事先在服务器上建好才行
                                           //设置文件在服务器上的路径
            string absFileName = HttpContext.Current.Server.MapPath(System.IO.Path.Combine(exportDir, fileName));
            xBk.SaveCopyAs(absFileName);
            xBk.Close(false, null, null);
            excel.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xBk);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xSt);

            xBk = null;
            excel = null;
            xSt = null;
            GC.Collect();
            //返回写入服务器Excel文件的路径
            return absFileName;
        }
    }
}