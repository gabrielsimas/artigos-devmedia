using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL.Negocio;
using DAL.Entidade;
using Web.Utilitarios;


namespace Web
{
    public partial class Cadastro : System.Web.UI.Page
    {
        IManterContato negocio = (ManterContato)ImplementaIoC.PegaContexto.Bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CadastrarCliente(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new Contato();
                
                contato.NomeCompleto = txtNome.Text;
                contato.Email = txtEmail.Text;
                contato.Linkedin = txtLinkedin.Text;
                contato.Twitter = txtTwitter.Text;
                contato.Facebook = txtFacebook.Text;

                if (negocio.InserirContato(contato))
                {
                    lblMensagem.Text = contato.NomeCompleto + " cadastrado com sucesso.";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro: " + ex.Message;
            }
        }

    }
}