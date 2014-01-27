// -----------------------------------------------------------------------
// <copyright file="ContatoDAOTeste.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Teste.Edicao112.MVCSecurity.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Spring.Testing.NUnit;
    using DevMedia.Ed112.MVCSeguranca.Dal.Interface;
    using DevMedia.Ed112.MVCSeguranca.Entidade;
    using Spring.Core;
    using Spring.Context;
    using NHibernate;
    using Spring.Context.Support;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
   [TestFixture]
    public class ContatoDAOTeste: AbstractTransactionalDbProviderSpringContextTests
    {

        #region Injeção de Dependências

       private IApplicationContext contexto;
       public IApplicationContext Contexto
       {
           get
           {
               this.contexto = ContextRegistry.GetContext();
               return this.contexto;
           }

           set
           {
               this.contexto = value;
           }
       }

        private IContatoDAO contatoDAO;
        public IContatoDAO ContatoDAO
        {
            get
            {
                return (IContatoDAO)this.contexto.GetObject("ContatoDAO");
            }
        }
        #endregion

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://Teste.Edicao112.MVCSecurity/Teste.Edicao112.MVCSecurity.ConfiguracaoSpringNet/Spring.xml" };
            }
        }

        #region Testes Unitários
        [SetUp]
        public void init()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
        }

        [Test]
        public void Inserir()
        {
            Contato contato = new Contato();
            contato.NomeCompleto = "Luís Gabriel Nascimento Simas";
            contato.Apelido = "Gabriel Simas";

            this.ContatoDAO.Criar(contato);

            Assert.IsTrue(contato.Id.HasValue);
            
        }

        #endregion
    }
}
