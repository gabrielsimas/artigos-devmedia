using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dal.Projeto.NHibernate;
using Entidade;

namespace Teste.NHibernate.Dao
{
    /// <summary>
    /// Summary description for OngDaoTeste
    /// </summary>
    [TestClass]
    public class OngDaoTeste
    {

        #region Propriedades
        #endregion

        #region Testes
        
        [TestMethod()]
        [Description("Testa a Inserção de uma ONG")]
        public void Insere()
        {
            
            Ong ong = new Ong();
            OngDao dao = new OngDao();
            //dao.setTeste(true);
            ong.NomeFantasia = "Teste teste";
            ong.RazaoSocial = "Teste Teste Teste";
            ong.Estado = "A";

            dao.salvar(ong);

            Assert.IsTrue(true);
        }

        #endregion

    }
}
