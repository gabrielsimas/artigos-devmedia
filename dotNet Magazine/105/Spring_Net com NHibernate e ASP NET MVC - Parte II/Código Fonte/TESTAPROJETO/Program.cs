using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;
using DAL.Entidade;
using DAL.Util;
using NHibernate;
using DAL.Reuso;
using DAL.Reuso.Spring;
using DAL.Persistencia.Spring;

namespace TESTAPROJETO
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ISessionFactory factory = HibernateUtil.FabricaDeSessao;
            ISession sessao = HibernateUtil.Sessao;

            try
            {
              

              if (factory.IsClosed)
              {

                  Console.WriteLine("Factory Fechada!");

              }
              else
              {
                  Console.WriteLine("Factory Aberta!");
                  
                  if (sessao.IsOpen)
                  {
                      Console.WriteLine("Sessao Aberta com Sucesso!!");
                  }
                  else
                  {
                      Console.WriteLine("Sessao Fechada!!");
                  }

                  /*
                  Console.WriteLine("Estatísticas da Factory: \n" + factory.Statistics + "\n");
                  Console.WriteLine("Estatísticas da Sessão: \n" + sessao.Statistics + "\n");
                  */

              }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException.ToString());
                throw;
            }
            finally
            {
                HibernateUtil.fechaSessao();
                factory.Close();
            }

            if (sessao.IsOpen)
            {
                Console.WriteLine("Sessao ainda Aberta");
            }
            else
            {
                Console.WriteLine("Sessão Fechada com sucesso!!");
            }

            if (factory.IsClosed)
            {
                Console.WriteLine("Factory também Fechada");
            }
            else
            {
                Console.WriteLine("Factory ainda Aberta");
            }

            //Testa o Cadastro de Fornecedores
            //TestaFornecedor testeFornecedor = new TestaFornecedor();
            //Fornecedor fornecedor = testeFornecedor.listarPorId(7);
            //testeFornecedor.ExcluiFornecedor(fornecedor);
            //Fornecedor fornecedor = testeFornecedor.listarPorId(7);
            //fornecedor.Nome = "Empresa Abano de Distribuição";
            //testeFornecedor.AtualizaFornecedor(fornecedor);
            //Fornecedor fornecedor = testeFornecedor.listarPorId(5);
            /*
            foreach(Fornecedor fornecedor in testeFornecedor.listaFornecedor()){
                Console.WriteLine(fornecedor);    
            }
            */
            
            //Console.WriteLine(fornecedor);
            //Console.WriteLine("Resultado " + testeFornecedor.GravaFornecedor());

            /*Lançamento de Nota Fiscal para teste */
            
            NotaFiscal notaFiscal = new NotaFiscal();
            ProdutoDAO produtoDAO = new ProdutoDAO();
            //FornecedorDAO fornecedorDAO = new FornecedorDAO();
            //Dados da Nota
            notaFiscal.Fornecedor = new FornecedorDAO().listaPorId(4) as Fornecedor;
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

            ItemNota item3 = new ItemNota();
            item3.NotaFiscal = notaFiscal;
            item3.Produto = produtoDAO.listaPorId(3);
            item3.PrecoUnitario = 1.50;
            item3.Quantidade = 30;

            IList<ItemNota> items = new List<ItemNota>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            notaFiscal.ItemsNota = items;

            TestaNotaFiscal testaNotaFiscal = new TestaNotaFiscal();
            testaNotaFiscal.entradaEstoque(notaFiscal);
            /*Fim Lançamento*/
            

            Console.ReadKey();

        }
    }
}
