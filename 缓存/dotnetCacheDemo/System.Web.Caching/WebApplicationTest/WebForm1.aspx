<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationTest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="获取初始化的缓存值" OnClick="button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="设置缓存值" OnClick="button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="获取上面设置的缓存值" OnClick="button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="局部变量重新创建同名实例并获取全局实例的值" OnClick="button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="再进行设置全局变量的值，然后再次点击上面按钮获取" OnClick="button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="遍历key输出" OnClick="button6_Click" />
    </div>
    </form>
</body>
</html>
