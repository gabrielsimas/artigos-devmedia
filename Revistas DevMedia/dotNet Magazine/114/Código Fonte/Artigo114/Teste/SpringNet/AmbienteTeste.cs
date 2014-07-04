using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Spring.Testing.Microsoft;
using Dal.Projeto.SpringNet.Interface;
using Dal.Projeto.SpringNet.Implementacao;
using IoC.SpringNet.Dal.Interface;
using Spring.Context;
using Spring.Context.Support;
using Entidade.ACL;

namespace Teste.SpringNet
{
    /// <summary>
    /// Teste para o Ambiente do Spring.NET
    /// Verificar se as Injeções estão funcionando Corretamente
    /// </summary>
    [TestClass]
    public class AmbienteTeste: AbstractDependencyInjectionSpringContextTests
    {

        #region Atributos e Propriedades
        protected override string[] ConfigLocations
        {
            get {
                return new String[] { "assembly://ArtigoSecurity.Teste/Teste.SpringNet/Ioc.xml" };
            }
        }

        private IGenericDao<Usuario> usuarioDao;

        public IGenericDao<Usuario> UsuarioDao
        {
            get
            {
                return ContextoDeAplicacao<IGenericDao<Usuario>>.PegaObjeto("UsuarioDao");
            }

            set
            {
                this.usuarioDao = ContextoDeAplicacao<IGenericDao<Usuario>>.PegaObjeto("UsuarioDao");
            }
        }
        
        
        #endregion

        [TestMethod]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void testaContextoSpringNet()
        {
            IList<Usuario> usuarios = this.usuarioDao.listarTudo();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestaApplicationContext()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            Assert.IsTrue(true);
        }
        
    }
}
