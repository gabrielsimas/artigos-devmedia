using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCSeguranca.Ed109.NH.DAL.Interface;
using System.Security.Cryptography;
using SHA3;

namespace MVCSeguranca.Ed109.NH.DAL.Implementacao
{
    public class Criptografia
    {

        //As contantes abaixo podem ser modificadas sem preocupação de quebrar os hashes existentes
        private const int TAMANHO_BYTE_SALT = 24;
        private const int TAMANHO_BYTE_HASH = 24;
        private const int ITERACOES_PBKDF2 = 1000;
        private const int INDICE_ITERACAO = 0;
        private const int INDICE_SALT = 1;
        private const int INDICE_PBKDF2 = 2;

        /// <summary>
        /// Cria um hash para senhas em MD5, este método também pode ser usado para 
        /// validar se a senha é ou não um hash MD5.
        /// </summary>
        /// <param name="senha">A senha para ser criado o hash</param>
        /// <returns>A senha convertida em Hash MD5</returns>
        public static string MD5(string senha)
        {
            MD5 messageDigest5 = new MD5CryptoServiceProvider();
            messageDigest5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(senha));

            byte[] hashSenha = messageDigest5.Hash;

            StringBuilder sb = new StringBuilder();
            sb.Append("0x");
            for (int i = 0; i < hashSenha.Length; i++)
            {
                sb.Append(hashSenha[i].ToString("X2"));
            }

            return sb.ToString();
            //return BitConverter.ToString(hashSenha);
        }

        /// <summary>
        /// Cria um hash salted em PBKDF2 hash da senha.
        /// </summary>
        /// <param name="password">A senha para o hash.</param>
        /// <returns>O hash da senha.</returns>
        public static string CriaHashSenhaSalt(string senha)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[TAMANHO_BYTE_SALT];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(senha, salt, ITERACOES_PBKDF2, TAMANHO_BYTE_HASH);
            return ITERACOES_PBKDF2 + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Valida uma senha dado o seu hash atual
        /// </summary>
        /// <param name="senha">The password to check.</param>
        /// <param name="hashSenha">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidaSenhaSalted(string senha, string hashSenha)
        {
            // Extrai os valores do hash
            char[] delimiter = { ':' };
            string[] split = hashSenha.Split(delimiter);
            int iterations = Int32.Parse(split[INDICE_ITERACAO]);
            byte[] salt = Convert.FromBase64String(split[INDICE_SALT]);
            byte[] hash = Convert.FromBase64String(split[INDICE_PBKDF2]);

            byte[] testHash = PBKDF2(senha, salt, iterations, hash.Length);
            return EqualsBaixoNivel(hash, testHash);
        }

        /// <summary>
        /// Compara dois arrays de bytes em tempo de tamanho-constante. Este método de
        /// comparação é usada, este hash de senha não pode ser roubado do sistema usando
        /// um ataque por tempo e então atacar o sistema capido
        /// </summary>
        /// <param name="a">O primeiro array de byte</param>
        /// <param name="b">O segundo array de byte</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool EqualsBaixoNivel(byte[] a, byte[] b)
        {
            uint diferenca = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diferenca |= (uint)(a[i] ^ b[i]);
            return diferenca == 0;
        }

        /// <summary>
        /// Cria um hash PBKDF2-SHA1 de uma senha
        /// </summary>
        /// <param name="senha">A senha para a geração do hash.</param>
        /// <param name="salt">O salt.</param>
        /// <param name="iteracoes">A contagem de iteracao do PBKDF2.</param>
        /// <param name="bytesSaida">O tamanho do hash a ser gerado, em bytes</param>
        /// <returns>O hash da senha.</returns>
        private static byte[] PBKDF2(string senha, byte[] salt, int iteracoes, int bytesSaida)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(senha, salt);
            pbkdf2.IterationCount = iteracoes;
            return pbkdf2.GetBytes(bytesSaida);
        }

        /// <summary>
        /// Gera um Hash para o valor em texto puro e retorna um resultado
        /// base64. Antes o hash é calculado, um salt aleatório é gerado e adicionado o texto puro. Este salt
        /// é armazenado no fim do valor do hash gerado, então pode ser usado depois para verificações.
        /// </summary>
        /// <param name="senha">
        /// A senha em texto puro que será converida em hash. Este método não verifica
        /// se o parâmetro é nulo.
        /// </param>
        /// <param name="algoritmoHash">
        /// Nome do algoritmo do hash. Até o momento, temos: "MD5", "SHA1",
        /// "SHA256", "SHA384", e "SHA512" (Se outro valor diferente destes
        /// o hashing do MD5 será utilizado). Estes valores são case insensitive.
        /// </param>
        /// <param name="saltBytes">
        /// Bytes para o Salta hash. Este parâMetro pode ser nulo, neste caso um salt gerado aleatóriamnte
        /// será gerado
        /// </param>
        /// <returns>
        /// Valor de hash formatado como uma string base64.
        /// </returns>
        public static string GeraValorHash(string senha,
                                         string algoritmoHash,
                                         byte[] saltBytes)
        {
            // Se o salta não é informado, gera um na hora.
            if (saltBytes == null)
            {
                //define o valor máximo e o mínino de salts
                // Define min and max salt sizes.
                int tamanhoMinSalt = 4;
                int tamanhoMaxSalt = 8;

                // Generate a random number for the size of the salt.
                //Gera um número aleatório para o tamaho do salt
                Random random = new Random();
                int tamanhoSalt = random.Next(tamanhoMinSalt, tamanhoMaxSalt);

                //Aloca o array de byte, que armzena o salta.
                saltBytes = new byte[tamanhoSalt];

                //Inicia o gerado de números aleatórios.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                //Preenche o hash do salta de forma criptográfica forte.
                rng.GetNonZeroBytes(saltBytes);
            }

            //Converte a senha em texto puro dentro do array de bytes.
            byte[] TextoPuroBytes = Encoding.UTF8.GetBytes(senha);

            //Aloca o array, que armazena o texto puro e o salt.
            byte[] textoPuroComBytesSalt = new byte[TextoPuroBytes.Length + saltBytes.Length];

            //Copia os bytes em texto puro dentro do array resultante.
            for (int i = 0; i < TextoPuroBytes.Length; i++)
                textoPuroComBytesSalt[i] = TextoPuroBytes[i];
            //anexa os bytes do hash salt para o array resultante.
            for (int i = 0; i < saltBytes.Length; i++)
                textoPuroComBytesSalt[TextoPuroBytes.Length + i] = saltBytes[i];

            //Como este método pode suportar multiplos algoritmos de hash, precisamos definir
            //os objetos de hashing com uma classe (abstrata) comum. 
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (algoritmoHash == null)
                algoritmoHash  = "";

            // Initialize appropriate hashing algorithm class.
            switch (algoritmoHash.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                case "SHA3":
                    hash = new SHA3Managed(TAMANHO_BYTE_HASH);
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            //Calcula o valor do hash baseado em nossa senha em texto puro com o salt anexado.
            byte[] hashBytes = hash.ComputeHash(textoPuroComBytesSalt);

            //Cria um array que armazena o hash e os bytes Salts originais
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            //Copia os bytes hash dentro do array resultante;
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            //Anexa bytes salta para o resultado
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            //Converte o resultaado dentro de uma string base64.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            //Retorna o resultado.
            return hashValue;
        }

        /// <summary>
        /// Compara um hash de uma senha em texto puro de um hash dado.
        /// A senha em texto puro é convetida em hash com o mesmo valor salta do hash original
        /// </summary>
        /// <param name="senha">
        /// A senha em texto puro que será verificada com o hash informado. O método
        /// não valida se o parâmetro é nulo.
        /// </param>
        /// <param name="algoritmoHash">
        /// Nome do algoritmo do hash. Até o momento, temos: "MD5", "SHA1",
        /// "SHA256", "SHA384", e "SHA512" (Se outro valor diferente destes
        /// o hashing do MD5 será utilizado). Estes valores são case insensitive.
        /// </param>
        /// <param name="valorHash">
        /// Um valor de hash produzido pelo método GeraSenhaHash. Este valor inclui o valor de salta original
        /// anexado a ele.
        /// </param>
        /// <returns>
        /// Se o hash bater, o hash informado retornará true, caso contrário retornará false
        /// </returns>
        public static bool ValidaSenha(string senha,
                                      string algoritmoHash,
                                      string valorHash)
        {
            //Converte o valor de hash de base64 em um array de byte.
            byte[] hashComBytesSalt = Convert.FromBase64String(valorHash);

            //Precisamos saber o tamanho do hash (sem salt).
            int hashTamanhoEmBits, hashSizeEmBytes;

            //Forçe o nome do algoritmo de hash.
            if (algoritmoHash == null)
                algoritmoHash = "";

            //Tamanho do hash é baseado no algoritmo escolhido.
            switch (algoritmoHash.ToUpper())
            {
                case "SHA1":
                    hashTamanhoEmBits = 160;
                    break;

                case "SHA256":
                    hashTamanhoEmBits = 256;
                    break;

                case "SHA384":
                    hashTamanhoEmBits = 384;
                    break;

                case "SHA512":
                    hashTamanhoEmBits = 512;
                    break;

                case "SHA3":
                    hashTamanhoEmBits = TAMANHO_BYTE_HASH;
                    break;

                default: // precisa ser MD5
                    hashTamanhoEmBits = 128;
                    break;
            }

            //Converte o tamanho do hash de bits para bytes.
            hashSizeEmBytes = hashTamanhoEmBits / 8;

            //Force o valor de hash especificado ser longo o suficiente.
            if (hashComBytesSalt.Length < hashSizeEmBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            //Aloque o array para armazenar os bytes originais do Salt.
            byte[] saltBytes = new byte[hashComBytesSalt.Length -
                                        hashSizeEmBytes];

            //Copie o salt do fim do hash para um novo array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashComBytesSalt[hashSizeEmBytes + i];

            //Calcule o novo string de hash.
            string expectedHashString =
                        GeraValorHash(senha, algoritmoHash, saltBytes);

            //Se o hash calculado é idêntico ao hash informado,
            //A senha em texto puro está correta.
            return (valorHash == expectedHashString);
        }
    }
}