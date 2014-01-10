using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;


namespace MVCSegurancaSiteInseguro.Paginas
{
    public partial class LoginXSS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void validaLogin(object sender, EventArgs e)
        {
            /*
            String nome = Server.HtmlEncode(txtNome.Text);
            String mensagem = "Obrigado pelo acesso " + nome;
            lblMensagem.Text = mensagem;
             */
            /*
            String nome = Server.HtmlEncode(txtNome.Text);
            String mensagem = "Obrigado pelo acesso " + nome;
            String caixaAlertaJavascript = "<script>alert('" + mensagem + "');</script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "Obrigado", caixaAlertaJavascript);
             */
            String nome = Encoder.JavaScriptEncode(txtNome.Text,false);
            String mensagem = "Obrigado pelo acesso " + nome;
            String caixaAlertaJavascript = "<script>alert('" + mensagem + "');</script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "Obrigado", caixaAlertaJavascript);
        }
    }
}
