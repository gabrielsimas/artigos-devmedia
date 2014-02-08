using System;

using NUnit.Framework;
using DevMedia.Ed112.MVCSeguranca.Entidade;
using DevMedia.Ed112.MVCSeguranca.Dal.Implementacao;
using DevMedia.Ed112.MVCSeguranca.Dal;

namespace Teste.DevMedia.Ed112.MVCSeguranca.Nunit.DAO
{
    [TestFixture]
    public class ContatoDAOTeste
    {

        const String CONNECTIONSTRING = @"Data Source=ALLSPARK\SQLEXPRESS;Initial Catalog=MVCSeguranca112;Integrated Security=True";
        const String ASSEMBLY = @"DevMedia.Ed112.MVCSeguranca.NHibernate";

        [Test]
        public void Conecta()
        {
            Contato contato;
            ContatoDAO dao = new ContatoDAO();
            dao.setAssembly(ASSEMBLY);
            dao.setStringDeConexao(CONNECTIONSTRING);
            contato = dao.listarPorId(1);
            Assert.IsTrue(true);
        }
    }
}
