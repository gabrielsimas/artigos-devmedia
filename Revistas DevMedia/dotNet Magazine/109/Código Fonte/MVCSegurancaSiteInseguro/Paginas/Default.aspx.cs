using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCSegurancaSiteInseguro.Paginas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validaUrl();
        }

        private void permiteXSS()
        {
            var url = Request.QueryString["Url"];
            var nome = Request.QueryString["nome"];
            var tag = "<a href=" + url + ">continuar</a>";
            if (url != null)
            {
                tagSaida.Text = tag;
            }
            else if (nome != "")
            {
                tagSaida.Text = nome;
            }
        }

        protected void validaUrl()
        {
            var urlEntrada = Request.QueryString["Url"];
            if (!Uri.IsWellFormedUriString(urlEntrada,UriKind.Absolute)){
                tagSaida.Text = "Uma URL inv&aacute;lida foi digitada. Favor corrigir";
            }
        }

    }
}