using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Spring.Testing.Microsoft;
using IoC.SpringNet.Dal.Interface;
using Entidade.ACL;
using Seguranca.Criptografia;
using Spring.Transaction.Support;
using Spring.Transaction;
using Teste.SpringNet;
using Spring.Context;

namespace Teste.SpringNet.Dao
{
    /// <summary>
    /// Teste Unitário de Daos do Spring.NET
    /// </summary>
    [TestClass]
    public class SpringNetDaoTeste: TesteEstavelComSpringNet
    {

        #region Atributos e Propriedades e Injeção de Dependências
        protected override string[] ConfigLocations
        {
            get
            {
                //this.AutowireMode = Spring.Objects.Factory.Config.AutoWiringMode.ByName;
                                
                return new String[] { "assembly://ArtigoSecurity.Teste/Teste.SpringNet/Ioc.xml" };
            }
        }
        
        
        protected IGenericDao<Usuario> dao;

        public IGenericDao<Usuario> Dao {
            get {
            
                return ContextoDeAplicacao<IGenericDao<Usuario>>.PegaObjeto("UsuarioDao");

            }

            set {
            
                this.dao = ContextoDeAplicacao<IGenericDao<Usuario>>.PegaObjeto("UsuarioDao");
            }
        }

        #endregion

        #region Testes
        [TestMethod()]
        [Description("Teste de Inserção de Usuário como Teste")]
        [TestCategory("Spring.Net")]
        [TestCategory("Dao")]
        public void InsereUsuario(){
            
            //this.EntidadeUsuario.Apelido = "gabrielsimas";
            //this.EntidadeUsuario.Email = "gabrielsimas@gmail.com";
            //this.EntidadeUsuario.Estado = Entidade.ACL.Usuario.EstadoUsuario.Liberado;
            //this.EntidadeUsuario.Login = "gabrielsimas";
            //this.EntidadeUsuario.NomeCompleto = "Luís Gabriel N. Simas";
            //this.EntidadeUsuario.PerguntaSecreta = "Quem descobriu o Brasil";
            //this.EntidadeUsuario.RespostaSecreta = "Pedro Alvares Cabral";
            //this.EntidadeUsuario.Senha = Algoritmos.GeraValorHash("J4n3c4554n1,123", "SHA3", null);
            
            //this.Dao.salvar(EntidadeUsuario);        

            //Assert.IsTrue(EntidadeUsuario.Id.HasValue);
        }

        [TestMethod]
        [Description("Teste de Listagem de Usuário como Teste")]
        [TestCategory("Spring.Net")]
        [TestCategory("Dao")]
        public void listarUsuarios()
        {
            IList<Usuario> usuarios = this.Dao.listarTudo();
            Assert.IsTrue(true);
        }

        #endregion
    }
}
