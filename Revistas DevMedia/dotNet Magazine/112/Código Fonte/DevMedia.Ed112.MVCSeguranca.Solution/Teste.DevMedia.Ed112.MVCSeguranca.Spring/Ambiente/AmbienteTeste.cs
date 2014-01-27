namespace Teste.DevMedia.Ed112.MVCSeguranca.SpringNet.Ambiente
{
    using System;
    using Spring.Testing.NUnit;
    using NUnit.Framework;
    
    /// <summary>
    /// Classe para testar se a arquitetura está íntegra
    /// ou seja: Mapeamento do NHibernate funcional e Objetos gerenciados do Spring
    /// </summary>
    
    [TestFixture]
    public class AmbienteTeste: AbstractTransactionalDbProviderSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get {
                return new String[] { "assembly://DevMedia.Ed112.MVCSeguranca.SpringNet/DevMedia.Ed112.MVCSeguranca.SpringNet.Configuracao/SpringEspinhaDorsal.xml" };
            }
        }

        [Test]
        public void Teste_Integracao()
        {
            
            Assert.IsTrue(true);
        }
    }
}
