using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.DAL;
using MVCSeguranca.Ed109.DAL.DataSource;
using MVCSeguranca.Ed109.DAL.Persistencia;
using MVCSeguranca.Ed109.DAL.ControleTransacao;

namespace MVCSeguranca.Ed109.Testes.DAL
{   
    [TestFixture]
    public class TesteDAL
    {

        [Test]
        public void Teste_Integracao()
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();     
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            
            //Assert.IsTrue(true);
        }

    }
}
