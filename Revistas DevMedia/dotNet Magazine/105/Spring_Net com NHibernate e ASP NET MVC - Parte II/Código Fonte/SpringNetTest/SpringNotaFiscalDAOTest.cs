using DAL.Persistencia.Spring;
using DAL.Entidade;
using DAL.Reuso;
using DAL.Reuso.Spring;
using Spring.Context;
using Spring.Context.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SpringNetTest


{
    
    
    /// <summary>
    ///This is a test class for SpringNotaFiscalDAOTest and is intended
    ///to contain all SpringNotaFiscalDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpringNotaFiscalDAOTest
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
        ///A test for SpringNotaFiscalDAO Constructor
        ///</summary>
        [TestMethod()]
        public void SpringNotaFiscalDAOConstructorTest()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            NotaFiscal notaFiscal = new NotaFiscal();
            //ProdutoDAO produtoDAO = new ProdutoDAO();
             //IGenericDAO<Produto> produtoDAO = FabricaDeObjeto.ObjetoSpringNet("ProdutoDAO") as SpringProdutoDAO;
            IGenericDAO<Produto> produtoDAO = ctx.GetObject("ProdutoDAO") as SpringProdutoDAO;
            //IGenericDAO<Fornecedor> fornecedorDAO = FabricaDeObjeto.ObjetoSpringNet("FornecedorDAO") as SpringFornecedorDAO;
            IGenericDAO<Fornecedor> fornecedorDAO = ctx.GetObject("FornecedorDAO") as SpringFornecedorDAO;
            //IGenericDAO<NotaFiscal> nfDAO = FabricaDeObjeto.ObjetoSpringNet("NotaFiscalDAO") as SpringNotaFiscalDAO;
            IGenericDAO<NotaFiscal> nfDAO =ctx.GetObject("NotaFiscalDAO") as SpringNotaFiscalDAO;
            //FornecedorDAO fornecedorDAO = new FornecedorDAO();
            //Dados da Nota
            notaFiscal.Fornecedor = fornecedorDAO.listaPorId(4);
            notaFiscal.Tipo = "ENTRADA";
            notaFiscal.DtEntrega = DateTime.Today;
            notaFiscal.DtNota = Convert.ToDateTime("2013/03/01");

            ItemNota item1 = new ItemNota();
            item1.NotaFiscal = notaFiscal;
            item1.Produto = produtoDAO.listaPorId(1);
            item1.PrecoUnitario = 30.00;
            item1.Quantidade = 100;

            ItemNota item2 = new ItemNota();
            item2.NotaFiscal = notaFiscal;
            item2.Produto = produtoDAO.listaPorId(2);
            item2.PrecoUnitario = 20.00;
            item2.Quantidade = 500;

            IList<ItemNota> items = new List<ItemNota>();
            items.Add(item1);
            items.Add(item2);

            notaFiscal.ItemsNota = items;

            nfDAO.Salvar(notaFiscal);

            /* Fim Spring.NET */
        }
    }
}
