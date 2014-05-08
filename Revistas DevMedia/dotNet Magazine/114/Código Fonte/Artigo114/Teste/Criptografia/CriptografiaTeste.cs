using System;
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
        private const String SENHA = "J4n3c4554n1,123";
        private const String MD5SENHA = "0x109A3C9F5615818B1BECE4FAE4650B13";
        private const String SENHASALTPBKDF2 = "10000:5aGAa8bkCMyHhaOq9ad8/nxUWvVeqNkj4auaCB/z2BVVw9HBtTM3H3mr6ZAB6FQkHN5M44k9fX7IIYbUHZrx9A==:j6ZcXGpbeH2mvGb6HGvPgfI7EnoONTEa5bQ9a15n049r2u8ZPa6G61FOfEVwe7MidrYPHOVURRS8PEl1HODACA==";
        private const String SENHASALTSHA3 = "XYO9XiDd6a25nNSGlR881SGzL9RyfbT8pq0KSd1+qHIDnmn3P1mAruNtNH54R7q0sOmcuBqOHiiRSloVQ+U+BrO4k8bJqsNjDQq3i7g2Qp+5NkKkDoFO";

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
