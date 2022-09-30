<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationEgitimi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Burası web form ön yüzü</title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            Burası web form ön yüzü. HTML : web sitelerinin ortak dili html dir.
        </div>
        <asp:Button runat="server" Text="Button"></asp:Button>
        <asp:Calendar runat="server"></asp:Calendar>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Onaylıyorum" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Elektronik</asp:ListItem>
            <asp:ListItem>Bilgisayar</asp:ListItem>
            <asp:ListItem>Play Station</asp:ListItem>
            <asp:ListItem>Telefon</asp:ListItem>
            <asp:ListItem>Kitap</asp:ListItem>
            <asp:ListItem>Monit&#246;r</asp:ListItem>
            <asp:ListItem>Monitör</asp:ListItem>
        </asp:DropDownList>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="Gizli değer" />
        Site Bağlantısı<asp:HyperLink ID="HyperLink1" runat="server">Site Bağlantısı</asp:HyperLink>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/asus-laptop.jpg" Height="300" />
        <asp:Label ID="Label1" runat="server" Text="Label ile ekranda yazı gösteriyoruz"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Onaylıyorum" />

        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Kabul Ediyorum</asp:ListItem>
            <asp:ListItem Selected="True">Kabul Etmiyorum</asp:ListItem>
        </asp:RadioButtonList>
        Adınız :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
