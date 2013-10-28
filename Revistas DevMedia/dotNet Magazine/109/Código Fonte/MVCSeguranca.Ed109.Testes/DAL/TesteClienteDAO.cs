using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Spring.Testing.NUnit;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.NH.DAL.Implementacao;
using MVCSeguranca.Ed109.NH.DAL.Interface;

namespace MVCSeguranca.Ed109.Testes.DAL
{
    [TestFixture]//Usando AbstractTransactionalDbProviderSpringContextTests, ele dá um rollback ao final da operação
    public class TesteClienteDAO : AbstractTransactionalDbProviderSpringContextTests
    {
        #region Atributos

        private IClienteDAO clienteDAO;
        private Cliente cliente;

        #endregion

        #region propriedades

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.DAL/DAO.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.NHibernate/NHibernate.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Servico/Servico.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Web/Web.xml", "assembly://MVCSeguranca.Ed109.Testes/MVCSeguranca.Ed109.Testes/SpringTestes.xml" };
            }
        }

        public IClienteDAO ClienteDAO{
            get
            {
                return this.clienteDAO;
            }

            set
            {
                this.clienteDAO = value;
            }
        }

        public Cliente Cliente {
            get
            {
                return this.cliente;
            }

            set
            {
                this.cliente = value;
            } 
        }

        #endregion

        [Test]
        public void Teste_integracao()
        {

            Assert.IsTrue(true);
        }


        [Category("ClienteDAO")]
        [Test][Description("Testa a incrição de um Cliente")]
        public void testa_Cliente_Insercao()
        {
            
            Cliente.Nome = "Luís Gabriel Nascimento Simas";
            Cliente.Email = "gabrielsimas@gmail.com";

            ClienteDAO.criar(Cliente);

            Assert.IsTrue(ClienteDAO.ehSucesso());

        }
        [Category("ClienteDAO")]
        [Test][Description("Testa a edição de um Cliente selecionado por Id")]
        public void testa_Cliente_Edicao()
        {
            Cliente = ClienteDAO.listarPorId(10);
            Cliente.Nome = "Gabriel Simas";

            ClienteDAO.atualizar(Cliente);

            ClienteDAO.x9(Cliente);

            Assert.IsTrue(clienteDAO.ehSucesso());
        }
    }
}
