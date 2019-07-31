<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataReport.aspx.cs" Inherits="PMSystem.DataReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--AJAX End--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <%=TableText%>
            <a href="javascript:doPrint()">打印</a>
            <%--<asp:Button ID="Button1" runat="server" Text="打印" Width="50px" OnClick="Button1_Click" />--%>
        </div>
    </form>
    <script>
        function doPrint() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
  </script>
</body>
</html>
