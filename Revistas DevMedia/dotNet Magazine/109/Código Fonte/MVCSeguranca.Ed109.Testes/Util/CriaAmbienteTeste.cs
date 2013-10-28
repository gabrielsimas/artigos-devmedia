using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Spring.Testing.NUnit;
using NUnit.Framework;

namespace MVCSeguranca.Ed109.Testes.Util
{
    
    [SetUpFixture]
    public class CriaAmbienteTeste : AbstractDependencyInjectionSpringContextTests
    {
        #region Configuração do Spring.NET

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.DAL/DAO.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.NHibernate/NHibernate.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Servico/Servico.xml", "assembly://MVCSeguranca.Ed109.DI.Spring/MVCSeguranca.Ed109.DI.Spring.Config.Web/Web.xml", "file://SpringTestes.xml" };
            }
        }

        

        #endregion
    }
}
