using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.ArtigoMSMQ.Mocks
{
    [Serializable]
    public class Pessoa
    {

        public virtual Nullable<long> Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }

        public Pessoa()
        {

        }

        public override string ToString()
        {
            return Id + "," + FirstName + "," + LastName + "," + Email;
        }

    }
}
