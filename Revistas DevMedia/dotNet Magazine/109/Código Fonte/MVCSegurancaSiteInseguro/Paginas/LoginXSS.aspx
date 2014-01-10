<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginXSS.aspx.cs" Inherits="MVCSegurancaSiteInseguro.Paginas.LoginXSS" %>

<!DOCTYPE html>

<html lang="pt-br">
<head runat="server">
    <title>Tela de login de exemplo</title>
</head>
<body>
    <fieldset runat="server">

        <legend>Identifica&ccedil;&atilde;o</legend>
        <form id="frmLogon" runat="server">
        <div>
            <p>
                <asp:Label runat="server" ID="lblNome" text="Nome: " />
                <asp:TextBox runat="server" ID="txtNome" />
            </p>
            <p>
                <asp:Label runat="server" ID="lblEmail" Text="E-mail: "/>
                <asp:TextBox runat="server" ID="txtEmail" type="email"/>
                
            </p>
            
            <asp:Button runat="server" ID="btnOK" OnClick="validaLogin" Text="Enviar"/>
        </div>
        </form>
    </fieldset>

    <p>
        <asp:Label ID="lblMensagem" runat="server" />
    </p>
</body>
</html>
