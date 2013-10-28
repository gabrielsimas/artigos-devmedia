using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Spring.Testing.NUnit;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.NH.DAL.Implementacao;
using MVCSeguranca.Ed109.NH.DAL.Interface;
using System.Security.Cryptography;

namespace MVCSeguranca.Ed109.Testes.DAL
{   
    [TestFixture]
    public class TesteCriptografia : AbstractTransactionalDbProviderSpringContextTests
    {
        #region Ambiente

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.DAL/DAO.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.NHibernate/NHibernate.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Servico/Servico.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Web/Web.xml", "assembly://MVCSeguranca.Ed109.Testes/MVCSeguranca.Ed109.Testes/SpringTestes.xml" };
            }
        }

        #endregion

        #region Atributos

        private IUsuarioDAO usuarioDAO;
        private Usuario usuario;

        #endregion

        #region Propriedades
        public IUsuarioDAO UsuarioDAO
        {
            get
            {
                return this.usuarioDAO;
            }

            set
            {
                this.usuarioDAO = value;
            }
        }

        public Usuario Usuario
        {

            get
            {
                return this.usuario;
            }

            set
            {
                this.usuario = value;
            }
        }
        
        #endregion

        [Test][Description("Testa a saída da Senha gerada para MD5")]
        public void Testa_senha_MD5()
        {
            String senha = "J4n3c4554n1";
            String senhaMD5 = Criptografia.MD5(senha);

            Assert.AreEqual(Criptografia.MD5(senha),senhaMD5 );
        }

        public void Testa_Senha_MD5()
        {
            String senha = "J4n3c4554n1";
            
        }

        [Test]
        public void Testa_GeraSenha_Salted()
        {
            String senha = "J4n3c4554n1";
            String senhaSalt = Criptografia.CriaHashSenhaSalt(senha);

            Assert.IsTrue(senhaSalt.Length > 0);

        }

        [Test]
        public void Testa_Senhas_Usuario()
        {
            IList<Usuario> usuarios = new ArrayList().Cast<Usuario>().ToList();
            usuarios = UsuarioDAO.ListarTudo();
            int contador = 0;

            foreach(Usuario usuario in usuarios){
                if (Criptografia.ValidaSenhaSalted(usuario.Senha,usuario.SenhaPBKDF2)){
                    contador++;
                }
            }

            Assert.IsTrue(contador < 5);
        }

    }
}
