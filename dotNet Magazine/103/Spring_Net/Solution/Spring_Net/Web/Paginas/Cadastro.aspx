<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Web.Cadastro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formCadastro" runat="server">
    <div>
        <label>Nome: </label>
        <asp:TextBox ID="txtNome" runat="server" />
        <asp:RequiredFieldValidator
            ID="requiredNome"
            runat="server"
            ControlToValidate="txtNome"
            ErrorMessage="Informe seu Nome."
            ForeColor="Red"
            ValidationGroup="Validador"
        />
        <br /><br />

        <label>E-mail: </label>
        <asp:TextBox ID="txtEmail" runat="server" />
        <asp:RequiredFieldValidator
            ID="requiredEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="Por favor, informe seu Email."
            ForeColor="Red"
            ValidationGroup="Validador"
        />
        <asp:RegularExpressionValidator
            ID="regexEmail"
            ControlToValidate="txtEmail"
            ErrorMessage="Entre um endereço de E-mail Válido"
            ForeColor="Red"
            ValidationExpression="^[a-z0-9.-_]+[@]+[a-z0-9]+[.]+[a-z.]{3,30}$"
            ValidationGroup="Validador"
            runat="server"
        />
        <br /><br />

        <label>Perfil Linkedin: </label>
        <asp:TextBox ID="txtLinkedin" runat="server" />

        <br /><br />

        <label>Perfil Twitter: </label>
        <asp:TextBox ID="txtTwitter" runat="server" />

        <br /><br />

        <label>E-mail: </label>
        <asp:TextBox ID="txtFacebook" runat="server" />

        <br /><br />

        <asp:Button ID="btnCadastro" runat="server"
            Text="Cadastrar" ValidationGroup="Validador"
            OnClick="CadastrarCliente"/>

        <p>
            <asp:Label ID="lblMensagem" runat="server" />
        </p>

        <p>Voltar para a <a href="Default.aspx">P&aacute;gina Inicial</a></p>

    </div>
    </form>
</body>
</html>
