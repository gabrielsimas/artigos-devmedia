using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using BusinessLayer.CasoDeUso;
using BusinessLayer.DTO;
using BusinessLayer.Facade;
using DAL.Reuso;
using DAL.Reuso.Spring;
using Spring.Context;
using Spring.Context.Support;
using System.Collections.Generic;

namespace TesteSpringNet
{
    
    
    /// <summary>
    ///This is a test class for ManterProdutoTest and is intended
    ///to contain all ManterProdutoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ManterProdutoTest
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


        /*
        /// <summary>
        ///A test for SalvarProduto
        ///</summary>
        [TestMethod()]
        
        public void SalvarProdutoTest()
        {
            try
            {
            //IApplicationContext di = ContextRegistry.GetContext();
            IProdutoFacade bll = FabricaDeObjeto.ObjetoSpringNet("ManterProduto") as ManterProduto;
            ProdutoDTO produto = new ProdutoDTO();
            produto.Nome = "Sabonete Vinólia Primavera";
            produto.Preco = 1.60;
            produto.PctLucro = 0.4;

            Assert.IsTrue(bll.salvar(produto));

            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.InnerException.ToString());
                throw;
            }
        }
        */
        [TestMethod]
        public void SalvarProdutoTest()
        {
            try
            {
                INotaFiscalFacade bll = FabricaDeObjeto.ObjetoSpringNet("ManterNotaFiscal") as ManterNotaFiscal;
                IProdutoFacade produtoBll = FabricaDeObjeto.ObjetoSpringNet("ManterProduto") as ManterProduto;
                IFornecedorFacade fornecedorBll = FabricaDeObjeto.ObjetoSpringNet("ManterFornecedor") as ManterFornecedor;

                NotaFiscalDTO notaFiscalDTO = new NotaFiscalDTO();
                FornecedorDTO fornecedorDTO = new FornecedorDTO();
                ProdutoDTO produtoDTO = new ProdutoDTO();
                IList<ItemNotaDTO> itemsNotaDTO = new List<ItemNotaDTO>();
                ItemNotaDTO item1 = new ItemNotaDTO();
                ItemNotaDTO item2 = new ItemNotaDTO();
                notaFiscalDTO.DtEntrega = DateTime.Now;
                notaFiscalDTO.DtNota = Convert.ToDateTime("2013/03/01");
                notaFiscalDTO.Tipo = "ENTRADA";
                //Localiza o Fornecedor selecionado e joga ro DTO.
                fornecedorDTO = fornecedorBll.buscaPorId(1);

                //Atualiza a Nota Fiscal
                notaFiscalDTO.IdFornecedor = fornecedorDTO.Id;
                notaFiscalDTO.NomeFornecedor = fornecedorDTO.Nome;

                //Localiza os Produtos
                ProdutoDTO produto1 = produtoBll.buscaPorId(5);
                ProdutoDTO produto2 = produtoBll.buscaPorId(6);

                //Adiciona os produtos para os Itens da Nota
                //Produto 1
                item1.IdProduto = produto1.Id;
                item1.NomeProduto = produto1.Nome;
                item1.PctLucro = produto1.PctLucro;
                item1.PrecoProduto = produto1.Preco;
                item1.PrecoUnitario = 1.20;
                item1.Quantidade = 100;
                item1.TotalLinha = item1.Quantidade * item1.PrecoUnitario;

                //Produto 2
                item2.IdProduto = produto2.Id;
                item2.NomeProduto = produto2.Nome;
                item2.PctLucro = produto2.PctLucro;
                item2.PrecoProduto = produto2.Preco;
                item1.PrecoUnitario = 1.70;
                item1.Quantidade = 600;
                item1.TotalLinha = item1.Quantidade * item1.PrecoUnitario;

                //Atualiza od Itens para compra
                itemsNotaDTO.Add(item1);
                itemsNotaDTO.Add(item2);

                //Atualiza a NotaFiscal
                notaFiscalDTO.itemsNotaDTO = itemsNotaDTO;

               Assert.IsTrue(bll.salvar(notaFiscalDTO));
                //Assert.IsNotNull(notaFiscalDTO.ToString());
            }
            catch (Exception ex)
            {

                Assert.Inconclusive(ex.InnerException.ToString());
            }
        }
        /// <summary>
        ///A test for salvar
        ///</summary>
        [TestMethod]
        public void salvarTest()
        {
            try
            {
                INotaFiscalFacade bll = FabricaDeObjeto.ObjetoSpringNet("ManterNotaFiscal") as ManterNotaFiscal;
                IProdutoFacade produtoBll = FabricaDeObjeto.ObjetoSpringNet("ManterProduto") as ManterProduto;
                IFornecedorFacade fornecedorBll = FabricaDeObjeto.ObjetoSpringNet("ManterFornecedor") as ManterFornecedor;

                NotaFiscalDTO notaFiscalDTO = new NotaFiscalDTO();
                FornecedorDTO fornecedorDTO = new FornecedorDTO();
                ProdutoDTO produtoDTO = new ProdutoDTO();
                IList<ItemNotaDTO> itemsNotaDTO = new List<ItemNotaDTO>();
                ItemNotaDTO item1 = new ItemNotaDTO();
                ItemNotaDTO item2 = new ItemNotaDTO();

                //Localiza o Fornecedor selecionado e joga ro DTO.
                fornecedorDTO = fornecedorBll.buscaPorId(1);

                //Atualiza a Nota Fiscal
                notaFiscalDTO.IdFornecedor = fornecedorDTO.Id;
                notaFiscalDTO.NomeFornecedor = fornecedorDTO.Nome;

                //Localiza os Produtos
                ProdutoDTO produto1 = produtoBll.buscaPorId(5);
                ProdutoDTO produto2 = produtoBll.buscaPorId(6);

                //Adiciona os produtos para os Itens da Nota
                //Produto 1
                item1.IdProduto = produto1.Id;
                item1.NomeProduto = produto1.Nome;
                item1.PctLucro = produto1.PctLucro;
                item1.PrecoProduto = produto1.Preco;
                item1.PrecoUnitario = 1.20;
                item1.Quantidade = 100;
                item1.TotalLinha = item1.Quantidade * item1.PrecoUnitario;

                //Produto 2
                item2.IdProduto = produto2.Id;
                item2.NomeProduto = produto2.Nome;
                item2.PctLucro = produto2.PctLucro;
                item2.PrecoProduto = produto2.Preco;
                item1.PrecoUnitario = 1.70;
                item1.Quantidade = 600;
                item1.TotalLinha = item1.Quantidade * item1.PrecoUnitario;

                //Atualiza od Itens para compra
                itemsNotaDTO.Add(item1);
                itemsNotaDTO.Add(item2);

                //Atualiza a NotaFiscal
                notaFiscalDTO.itemsNotaDTO = itemsNotaDTO;

                Assert.IsTrue(bll.salvar(notaFiscalDTO));
            }
            catch (Exception ex)
            {

                Assert.Inconclusive(ex.InnerException.ToString());
            }
        }
    }
}
