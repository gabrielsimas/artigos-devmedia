using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using DAL.Entidade;

namespace DAL.FonteDeDados
{
    [Database(Name = "ARTIGOGABRIEL_01")]
    public class ConexaoBD : DataContext
    {

        #region Atributos
        #endregion

        #region Propriedades
        
        #endregion

        #region Construtores
        
        public ConexaoBD()
            :base(ConfigurationManager.ConnectionStrings["LINQTOSQL"].ConnectionString)
        {

        }

        #endregion

        #region Tabelas Mapeadas
        public Table<Cliente> Cliente;
        public Table<Pais> Pais;
        public Table<Pedido> Pedido;
        
        #endregion
    }
}
