<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Web.Consulta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formConsulta" runat="server">
    <div>
        <h4>Lista de Contatos</h4>
        <asp:GridView ID="grdContatos" runat="server" Width="100%">
        </asp:GridView>

        <p>Voltar a <a href="Default.aspx">P&aacute;gina Principal</a></p>
    </div>
    </form>
</body>
</html>
