using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Persistencia;
using DAL.Entidade;

namespace BLL.Negocio
{
   public class ManterContato : IManterContato
   {

       #region Atributos

       private IContatoDAL dao;

       #endregion

       #region Propriedades

       //Propriedade Setter para 
       //facilitar a Injeção de Dependências
       public IContatoDAL Dao
       {
           set { dao = value; }
       }

       #endregion

       #region Métodos

       public bool InserirContato(Contato contato)
       {
           try
           {
               dao.Salvar(contato);
               return true;
           }
           catch
           {
               throw;
               
           }
       }

       public bool AtualizarContato(Contato contatoNovo)
       {
           try
           {
               dao.Atualizar(contatoNovo);
               return true;
           }
           catch
           {
               
               throw;
           }
       }

       public bool ExcluirContato(Contato contato)
       {
           try
           {
               dao.Apagar(contato);
               return true;
           }
           catch
           {
               
               throw;
           }
       }

       public List<Contato> listarContatos()
       {
           return dao.listarTudo();
       }

       public Contato buscarContatoPorId(int id)
       {
           try
           {
               return dao.listarPorId(id);
           }
           catch
           {
               throw;
           }
       }

       #endregion
   }
}
