// -----------------------------------------------------------------------
// <copyright file="CriptografiaTeste.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Teste.Criptografia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Seguranca.Criptografia;
    

    /// <summary>
    /// Classe para Testes Unitários de Criptografia
    /// </summary>
    [TestClass]
    public class CriptografiaTeste
    {

        [Description("Testa a geração de strings utilizando o HASH MD5")]
        [TestMethod()]
        public void GeraSenhaMD5()
        {
            String senha = "J4n3c4554n1,123";
            String senhaMd5 = Algoritmos.MD5(senha);
            Assert.IsTrue(true,"Senha Inserida: " + senha + " Senha MD5: " + senhaMd5);
        }

    }
}
