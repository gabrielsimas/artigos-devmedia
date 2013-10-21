using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DAL.Entidade
{
    public abstract class EntidadeGenerica : IEntidade
    {

        #region Atributo
        private Int32 id;

        #endregion

        #region Propriedade
        [Column(Storage="id",Name="Id",IsPrimaryKey= true,IsDbGenerated=true,IsDiscriminator = true)]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }        
        #endregion
        
    }
}
