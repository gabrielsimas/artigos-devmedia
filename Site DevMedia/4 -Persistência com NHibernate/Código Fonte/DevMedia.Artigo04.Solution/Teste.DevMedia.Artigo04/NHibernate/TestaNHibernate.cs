
using NUnit.Framework;
using DevMedia.Artigo04.NHibernate.Generico;
using NHibernate;

namespace Teste.DevMedia.Artigo04.NHibernate
{
    [TestFixture]
    public class TestaNHibernate
    {

        [Test]
        public void ConexaoBanco()
        {
            ISessionFactory session = HibernateUtil.FabricaDeSessao;

            Assert.IsTrue(!session.IsClosed);
        }
    }
}
