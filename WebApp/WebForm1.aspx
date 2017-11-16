<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tiesos bokalas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            čia galit susiskaičiuoti savo BAC levelį.</div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Svoris, kg"></asp:Label>
            <asp:TextBox ID="txt_weight" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Lytis"></asp:Label>
            <asp:DropDownList ID="DropDownListGender" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Vartojimo trukmė, h"></asp:Label>
        <asp:TextBox ID="txt_time" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Gėrimo tūris, ml"></asp:Label>
        <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label5" runat="server" Text="gėrimo laipsniai, %"></asp:Label>
            <asp:TextBox ID="txt_alcohol" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Porcijų kiekis, vnt"></asp:Label>
            <asp:TextBox ID="txt_servings" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Btn_save" runat="server" OnClick="Btn_save_Click()" Text="Save" />
        <asp:Button ID="Btn_calculate" runat="server" OnClick="Btn_calculate_Click()" Text="Calculate BAC" />
    </form>
</body>
</html>
