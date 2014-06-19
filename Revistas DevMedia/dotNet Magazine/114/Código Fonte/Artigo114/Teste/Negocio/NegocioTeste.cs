using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;

using Seguranca.Codigo;
using Seguranca.Criptografia;
using DTO;
using DTO.ACL;
using Entidade.ACL;
using Entidade;

namespace Teste.Negocio
{
    /// <summary>
    /// Summary description for NegocioTeste
    /// </summary>
    [TestClass]
    public class NegocioTeste : AbstractDependencyInjectionSpringContextTests
    {

        #region Injeção de Dependências

        protected override string[] ConfigLocations
        {
            get 
            {
                return new String[] { "assembly://ArtigoSecurity.Teste/Teste.SpringNet/Ioc.xml" };
            }
        }

        #endregion

        #region Testes

        #endregion        
    }
}
