using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.DAL;
using MVCSeguranca.Ed109.DAL.DataSource;
using MVCSeguranca.Ed109.DAL.Persistencia;
using MVCSeguranca.Ed109.DAL.ControleTransacao;
using System.Data.Common;
using System.Configuration;
using System.Diagnostics;

namespace MVCSeguranca.Ed109.Testes.DAL
{   
    [TestFixture]
    public class TesteDAL
    {

        [Test]
        public void Teste_Integracao()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void Testa_ConnectionStrings()
        {
            Assert.IsTrue(ConfigurationManager.ConnectionStrings.Count > 0);
        }
    }
}
