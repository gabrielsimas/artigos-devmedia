using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL.Negocio;
using Web.Utilitarios;

namespace Web
{
    public partial class Consulta : System.Web.UI.Page
    {

        private IManterContato negocio = (ManterContato)ImplementaIoC.PegaContexto.Bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                montaGridContatos();
            }
        }

        private void montaGridContatos()
        {   
            grdContatos.DataSource = negocio.listarContatos();
            grdContatos.DataBind();
        }
    }
}