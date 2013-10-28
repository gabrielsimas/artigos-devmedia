using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Spring.Testing.NUnit;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.NH.DAL.Implementacao;
using MVCSeguranca.Ed109.NH.DAL.Interface;

namespace MVCSeguranca.Ed109.Testes.Util
{
    public class AbstractSpringTeste : AbstractTransactionalDbProviderSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get { return new String[] { "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.DAL/DAO.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.NHibernate/NHibernate.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Servico/Servico.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Web/Web.xml", "assembly://MVCSeguranca.Ed109.Testes/MVCSeguranca.Ed109.Testes/SpringTestes.xml" }; }
        }
    }
}
