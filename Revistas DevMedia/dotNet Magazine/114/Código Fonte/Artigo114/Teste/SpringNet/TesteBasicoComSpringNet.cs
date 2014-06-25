using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;
using Spring.Testing.Microsoft;


namespace Teste.SpringNet
{
    /// <summary>
    /// Summary description for TesteBasicoComSpringNet
    /// </summary>
    [TestClass]
    public abstract class TesteBasicoComSpringNet : AbstractDependencyInjectionSpringContextTests
    {
        #region Atributos

        private TestContext testContextInstance;

        #endregion

        #region Construtores

        public TesteBasicoComSpringNet()
        {
            DependencyCheck = false;
        }

        #endregion

        #region Propriedades

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        #region Métodos

        [TestInitialize]
        public virtual void Inicializacao()
        {

            this.applicationContext = GetContext(ContextKey);
            InjectDependencies();

            try
            {
                OnTestInitialize();
            }
            catch (Exception ex)
            {
                logger.Error("Erro na Inicializacao do Teste: ", ex);
                throw;
            }
        }

        [TestCleanup]
        public virtual void Finalizacao()
        {
            try
            {
                OnTestCleanup();

            }
            catch (Exception ex)
            {
                logger.Error("Erro na Finalizacao do Teste:", ex);
            }
        }

        #endregion

    }
}
