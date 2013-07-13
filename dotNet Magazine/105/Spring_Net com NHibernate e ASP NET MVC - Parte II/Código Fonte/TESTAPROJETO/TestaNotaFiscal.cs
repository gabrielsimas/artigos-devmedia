using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Reuso;

namespace TESTAPROJETO
{
    public class TestaNotaFiscal
    {
        public void entradaEstoque(NotaFiscal nota)
        {
            try
            {
                NotaFiscalDAO NFdao = new NotaFiscalDAO();
                NFdao.Salvar(nota);

                Console.WriteLine("Nota Fiscal " + nota.Id + "Gravada com Sucesso");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.InnerException.ToString());
            }
        }
    }
}
