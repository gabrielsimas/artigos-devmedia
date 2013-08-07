using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Reuso;
using DAL.Entidade;

namespace TESTAPROJETO
{
    public class TestaFornecedor
    {
        public String Resultado { get; set; }

        public String GravaFornecedor()
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                FornecedorDAO dao = new FornecedorDAO();

                fornecedor.Nome = "Granja Martha Regina";

                dao.Salvar(fornecedor);

                this.Resultado = "Fornecedor " + fornecedor.Nome + " gravado com sucesso!";

                return Resultado;
            }
            catch (Exception ex)
            {
                this.Resultado = "Erro: " + ex.InnerException.ToString();
                return Resultado;
            }
        }

        public Fornecedor listarPorId(int id)
        {
            try
            {
                FornecedorDAO dao = new FornecedorDAO();
                Fornecedor fornecedor = dao.listaPorId(id);
                if (fornecedor != null)
                {
                    Console.WriteLine("Dados Encontrados");
                    return fornecedor;
                }
                else
                {
                    throw new Exception("Dados não encontrados");
                }
            }
            catch
            {
                
                throw;
            }
        }

        public IList<Fornecedor> listaFornecedor()
        {
            try
            {
                FornecedorDAO dao = new FornecedorDAO();
                IList<Fornecedor> fornecedores = dao.listarTudo();
                return fornecedores;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                throw;
            }
        }

        public void AtualizaFornecedor(Fornecedor fornecedor)
        {
            try
            {
                FornecedorDAO dao = new FornecedorDAO();
                dao.Atualizar(fornecedor);

                Console.WriteLine("Fornecedor Atualizado com sucesso!");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            
            }
        }

        public void ExcluiFornecedor(Fornecedor fornecedor)
        {
            try
            {
                FornecedorDAO dao = new FornecedorDAO();
                dao.Excluir(fornecedor);
                Console.WriteLine("Fornecedor " + fornecedor.Nome + " Excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
        }
                
    }
}
