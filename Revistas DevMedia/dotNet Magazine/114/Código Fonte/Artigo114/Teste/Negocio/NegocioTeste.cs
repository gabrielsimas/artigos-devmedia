using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;

using Seguranca.Codigo;
using Seguranca.Criptografia;
using DTO;
using DTO.ACL;
using Entidade.ACL;
using Entidade;
using Teste.SpringNet;
using Negocio.Interface;

namespace Teste.Negocio
{
    /// <summary>
    /// Summary description for NegocioTeste
    /// </summary>
    [TestClass]
    public class NegocioTeste : TesteEstavelComSpringNet
    {

        #region Injeção de Dependências
        private IUsuarioNegocio business;
        
        protected override string[] ConfigLocations
        {
            get 
            {
                return new String[] { "assembly://ArtigoSecurity.Teste/Teste.SpringNet/Ioc.xml" };
            }
        }

        public IUsuarioNegocio Business
        {
            get
            {
                if (this.business == null)
                {
                    this.business = ContextoDeAplicacao<IUsuarioNegocio>.PegaObjeto("UsuarioNegocio");
                }

                return this.business;

            }

            set
            {

                this.business = ContextoDeAplicacao<IUsuarioNegocio>.PegaObjeto("UsuarioNegocio");
            }
        }

        #endregion

        #region Testes
        [TestMethod()]
        [Description("Testa a força da senha e retorna o resultado")]
        [TestCategory("Teste de Regra de Negócio")]
        [TestCategory("UsuarioNegocio")]
        public void testaForcaDeSenha()
        {
            string senha = "j4n3c4554n1,123";
            ForcaDeSenha forca = this.Business.validaForcaDeSenha(senha);

            Assert.IsTrue(forca.HasFlag(ForcaDeSenha.MuitoForte) || forca.HasFlag(ForcaDeSenha.Forte));

        }
        #endregion        
    }
}
