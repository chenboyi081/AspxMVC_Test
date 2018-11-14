<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getdata.aspx.cs" Inherits="C062CallAPI.getdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="rpdata" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="btget" runat="server" OnClick="btget_Click" Text="获取远程数据" />
    </div>
    </form>
</body>
</html>
