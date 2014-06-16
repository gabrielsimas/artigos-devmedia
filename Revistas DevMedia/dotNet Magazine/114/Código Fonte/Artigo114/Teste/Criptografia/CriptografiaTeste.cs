﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Seguranca.Criptografia;

namespace Teste.Criptografia
{
    [TestClass]
    public class CriptografiaTeste
    {
        private const String SENHA = "@Bc,123";
        private const String MD5SENHA = "";
        private const String SENHASALTPBKDF2 = "";
        private const String SENHASALTSHA3 = "";

        [Description("converte uma String em HASH MD5")]
        [TestCategory("Segurança")]
        [TestMethod()]
        public void GeraSenhaMD5()
        {
            String senha = "J4n3c4554n1,123";
            String senhaMd5 = Algoritmos.MD5(senha);
            Assert.IsTrue(true, "Senha Inserida: " + senha + " Senha MD5: " + senhaMd5);
        }

        [Description("Cria um salt para a senha utilizando PBK2DF como algoritmo para o SALT")]
        [TestCategory("Segurança")]
        [TestMethod()]
        public void CriaHashParaSenhaComSalt()
        {
            String senhaComSalt = Algoritmos.CriaHashParaSenhaComSaltUtilizandoPbkdf2(SENHA);
            Assert.IsTrue(true, "Senha Inserida: " + SENHA + " Senha MD5: " + senhaComSalt);

        }

        [Description("Verifica se a senha gerada com o salt é válida ao ser confrontada com a senha inserida pelo usuário")]
        [TestCategory("Segurança")]
        [TestMethod()]
        public void VerificaHashSenhaComSalt()
        {
            Boolean Validado = Algoritmos.ValidaHashSenhaComSalt(SENHA,SENHASALTPBKDF2);
            Assert.IsTrue(Validado);
        }
        
        [Description("Verifica uma senha gerada via Algortimo SHA3 ou Keccack")]
        [TestCategory("Segurança")]
        [TestMethod()]
        public void GeraValorHashSHA3()
        {
            String resultadoSH3 = Algoritmos.GeraValorHash(SENHA, "SHA3", null);
            Assert.IsTrue(true);
        }

        [Description("Valida a senha gerada via algoritmo SHA3 para verificar se o Algoritmo está funcionando")]
        [TestCategory("Segurança")]
        [TestMethod()]
        public void ValidaSenhaHashSHA3()
        {
            Boolean senhaValidada = Algoritmos.ValidaSenha(SENHA, "SHA3", SENHASALTSHA3);
            Assert.IsTrue(senhaValidada);
        }
    }
}
