using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.DTO
{
    public class ComprasDTO
    {

        private Nullable<long> id;
        private Double total;
        private ClienteDTO clientDTO;
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

        public virtual Double Total
        {
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
            }
        }

        public virtual ClienteDTO ClienteDTO
        {
            get
            {
                return this.clientDTO;
            }

            set
            {
                this.clientDTO = value;
            }
        }

    }
}
