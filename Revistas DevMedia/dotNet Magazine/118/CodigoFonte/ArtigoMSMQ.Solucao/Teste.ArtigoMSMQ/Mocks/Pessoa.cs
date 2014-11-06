using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.EnterpriseServices;
using System.Runtime.InteropServices;


[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(false)]
namespace Teste.ArtigoMSMQ.Mocks
{
    [Transaction(TransactionOption.Required)]
    [ComVisible(true)]
    [Guid("A944E1CB-CC43-4042-8E33-BA442174670D")]
    [Serializable]
    public class Pessoa : ServicedComponent
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
