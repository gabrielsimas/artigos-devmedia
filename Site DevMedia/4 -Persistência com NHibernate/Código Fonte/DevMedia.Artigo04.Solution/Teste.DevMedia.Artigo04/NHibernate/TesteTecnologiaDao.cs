using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.NHibernate.Generico;
using DevMedia.Artigo04.NHibernate.Generico.Implementacao;
using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using DevMedia.Artigo04.Dal.Interfaces;
using DevMedia.Artigo04.Dal.Implementacao;
using DevMedia.Artigo04.Entidade;
using NUnit.Framework;

namespace Teste.DevMedia.Artigo04.NHibernate
{
    //[TestFixture]
    public class TesteTecnologiaDao
    {

       // [SetUp]
        public void setUp()
        {

        }

        //[Test]
        public void inserir()
        {

            ITecnologiaDao dao = new TecnologiaDao();
            Tecnologia objeto = new Tecnologia();
            objeto.Nome = ".NET";
            dao.salvar(objeto);
            Assert.IsTrue(dao != null);
        }
    }
}
