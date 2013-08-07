using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

using DAL.Generico;
using DAL.Entidade;


namespace DAL.Persistencia
{
    public class ClubeDAO : GenericDAO<Clube>
    {
        public IList<Clube> ListarElenco(int codClube)
        {
            

            try
            {
               ISession sessao = HibernateUtil.Sessao;

               IQuery consulta = sessao.GetNamedQuery("listarElenco");
               consulta.SetInt32("codClube", codClube);
               IList<Clube> clubes = consulta.List<Clube>();
               return clubes;
            }
            catch (Exception)
            {
                
                throw;
            } 

        }
    }
}
