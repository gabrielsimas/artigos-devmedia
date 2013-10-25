using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using MVCSeguranca.Ed109.Entidade;
using System;


namespace MVCSeguranca.Ed109.DAL.DataSource
{
   [Database]
   public class Conexao : DataContext
   {
       #region atributo
       private DateTime criacao;
       #endregion

       #region Propriedades
       public DateTime Criacao
       {
           get
           {
               return this.criacao;
           }

           set
           {
               this.criacao = value;
           }
       }
       #endregion
       #region Construtor

       public Conexao():base(ConfigurationManager.ConnectionStrings["MVCSeguranca_BASE"].ConnectionString)
        {
            this.criacao = new DateTime();
            this.criacao = DateTime.Now;
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
