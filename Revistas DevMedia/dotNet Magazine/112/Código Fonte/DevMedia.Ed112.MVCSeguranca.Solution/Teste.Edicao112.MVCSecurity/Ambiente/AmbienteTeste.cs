// -----------------------------------------------------------------------
// <copyright file="AmbienteTeste.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Teste.Edicao112.MVCSecurity.Ambiente
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Spring.Testing.NUnit;
    using NHibernate;

    /// <summary>
    /// Classe de teste para o Ambiente
    /// Faz teste de Integração
    /// </summary>
    [TestFixture]
    public class AmbienteTeste: AbstractTransactionalSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://Teste.Edicao112.MVCSecurity/Teste.Edicao112.MVCSecurity.ConfiguracaoSpringNet/Spring.xml" };
            }
        }

        private ISessionFactory sessionFactory;
        public ISessionFactory SessionFactory { get; set; }
        

        #region Injeção de Dependências
        #endregion

        #region Testes Unitários

        [Test]
        public void TesteIntegracao(){
            Assert.IsTrue(true);
        }

        
        protected override void OnSetUpInTransaction()
        {
            base.OnSetUpInTransaction();
            Assert.IsNotNull(SessionFactory);
            SessionFactory.GetCurrentSession().FlushMode = FlushMode.Always;
            SessionFactory.GetCurrentSession().CacheMode = CacheMode.Ignore;
        }

        #endregion
    }
}
