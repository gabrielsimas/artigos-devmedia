using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using Orm.Nhibernate.Dal;
using Orm.Nhibernate.Dal.Implementacao;
using Orm.Nhibernate.Dal.Interface;


namespace Teste.NHibernate
{
    /// <summary>
    /// Summary description for AmbienteTeste
    /// </summary>
    [TestClass]
    public class AmbienteTeste
    {

        #region Propriedades e Métodos

        #endregion

        #region Testes

        [Description("Teste para verificar a confiabilidade do Ambiente como NHibernate: Mapeamentos e conexão com o Banco")]
        [TestMethod()]
        public void Integracao()
        {
            ISessionFactory factory = NHibernateUtils.FabricaDeSessao;

            Assert.IsNotNull(factory);
        }

        #endregion
    }
}
