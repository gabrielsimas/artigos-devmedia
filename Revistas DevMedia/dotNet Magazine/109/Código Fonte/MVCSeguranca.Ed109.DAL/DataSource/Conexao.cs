using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using MVCSeguranca.Ed109.Entidade;


namespace MVCSeguranca.Ed109.DAL.DataSource
{
   [Database]
   public class Conexao : DataContext 
   {
       #region Construtor

        public Conexao():base(ConfigurationManager.ConnectionStrings["MVCSeguranca_BASE"].ConnectionString)
        {

        }
       #endregion

       #region Tabelas Mapeadas

        public Table<Usuario> Usuario;
        public Table<Perfil> Perfil;
        public Table<Compras> Compras;
        public Table<Cliente> Cliente;

       #endregion
   }
}
