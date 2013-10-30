using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.DTO
{
    public class ClienteDTO
    {

        private Nullable<long> id;
        private String nome;
        private String email;
        private IList<ComprasDTO> comprasDTO;

        public virtual Nullable<long> Id
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

        public virtual String Nome
        {
            get
            {
                return this.nome;
            }

            set
            {
                this.nome = value;
            }
        }


        public virtual String Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }

        }

        public virtual IList<ComprasDTO> ComprasDTO
        {
            get
            {
                return this.comprasDTO;
            }

            set
            {
                this.comprasDTO = value;
            }
        }

    }
}
