using DevMedia.Artigo04.Dal.Interfaces;
using DevMedia.Artigo04.Dal.Implementacao;
using DevMedia.Artigo04.Entidade;
using NUnit.Framework;

namespace Teste.DevMedia.Artigo04.NHibernate
{
    [TestFixture]
    public class TesteTecnologiaDao
    {

        [Test]
        public void inserir()
        {

            ITecnologiaDao dao = new TecnologiaDao();
            Tecnologia objeto = new Tecnologia();
            objeto.Nome = ".NET";
            dao.salvar(objeto);
            Assert.IsTrue(objeto.Id.HasValue);
        }
    }
}
