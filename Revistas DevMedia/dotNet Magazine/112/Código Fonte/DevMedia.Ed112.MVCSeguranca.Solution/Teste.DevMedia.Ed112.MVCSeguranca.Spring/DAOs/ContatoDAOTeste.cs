// -----------------------------------------------------------------------
// <copyright file="ContatoDAOTeste.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Teste.SpringNet
{
    using System;
    using Spring.Testing.NUnit;
    using NUnit.Framework;

    
    
    
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ContatoDAOTeste : AbstractTransactionalDbProviderSpringContextTests
    {
        #region ConfigLocations do Spring.NET

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://DevMedia.Ed112.MVCSeguranca.SpringNet/DevMedia.Ed112.MVCSeguranca.SpringNet.Configuracao/SpringEspinhaDorsal.xml" };
            }
        }

        #endregion

        #region Injeção de Dependências
        
        

        #endregion


    }
}
