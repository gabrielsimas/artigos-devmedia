using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Spring.Testing.Microsoft;

namespace Teste.SpringNet
{
    /// <summary>
    /// Teste para o Ambiente do Spring.NET
    /// Verificar se as Injeções estão funcionando Corretamente
    /// </summary>
    [TestClass]
    public class AmbienteTeste: AbstractDependencyInjectionSpringContextTests
    {

        #region Atributos e Propriedades
        protected override string[] ConfigLocations
        {
            get {
                return new String[] { "assembly://ArtigoSecurity.Teste/Teste.SpringNet/Ioc.xml" };
            }
        }
        
        #endregion

        [TestMethod]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }
        
    }
}
