using DAL.Persistencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DAL.FonteDeDados;
using DAL.Entidade;
using DAL.Util;

namespace TestDALPratico
{
    
    
    /// <summary>
    ///This is a test class for ContatoDALTest and is intended
    ///to contain all ContatoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContatoDALTest
    {


        private TestContext testContextInstance;

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Salvar
        ///</summary>
        [TestMethod()]
        public void SalvarTest()
        {
            try
            {
                //Cadastro
                Contato contato = new Contato();
                contato.NomeCompleto = "Luis Gabriel Nascimento Simas";
                contato.Email = "gabrielsimas@gmail.com";
                contato.Linkedin = "http://br.linkedin.com/in/gabrielsimas/";
                contato.Twitter = "@gabnascimento";
                contato.Facebook = "http://www.facebook.com/luisgabrielsimas";

                //Injeção de Dependência

                //IApplicationContext di = ContextRegistry.GetContext();
                //IContatoDAL dal = (ContatoDAL)di.GetObject("ContatoDAL");

                IContatoDAL dal = (ContatoDAL)ImplementaIoC.PegaContexto.Dao;

                dal.Salvar(contato);
            }
            catch (Exception e)
            {

                //Informa se houve falha
                Assert.Fail(e.Message);
            } 
        }
    }
}
