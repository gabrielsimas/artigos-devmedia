using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using DevMedia.Artigo04.NHibernate.Generico;
using DevMedia.Artigo04.NHibernate.Generico.Implementacao;
using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using DevMedia.Artigo04.Dal.Interfaces;
using DevMedia.Artigo04.Dal.Implementacao;
using DevMedia.Artigo04.Entidade;
using NHibernate;

namespace Teste.DevMedia.Artigo04.NHibernate
{
    [TestFixture]
    public class TestaNHibernate
    {
        [Test]
        public void teste_Integracao()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void ConexaoBanco()
        {
            ISessionFactory session = HibernateUtil.FabricaDeSessao;

            Assert.IsTrue(!session.IsClosed);
        }
    }
}
