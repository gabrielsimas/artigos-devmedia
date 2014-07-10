namespace Negocio.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Negocio.Interface;
    using DTO.ACL;
    using Entidade.ACL;
    using Dal.Projeto.SpringNet.Interface;
    using Seguranca.Codigo;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Regra de Negócios para os Usuários do Sistema
    /// </summary>
    public class UsuarioNegocio: IUsuarioNegocio 
    {
        #region Atributos
        private IUsuarioDao dao;
        private UsuarioDto dto;
        private Usuario entidade;
        #endregion

        #region Propriedades

        public IUsuarioDao Dao
        {
            get
            {
                return this.dao;
            }

            set
            {
                this.dao = value;
            }
        }

        private UsuarioDto Dto
        {
            get
            {
                if (this.dto == null)
                {
                    this.dto = new UsuarioDto();
                }
                return this.dto;
            }

            set
            {
                this.dto = value;
            }
        }

        private Usuario Entidade
        {
            get
            {
                if (this.entidade == null)
                {
                    this.entidade = new Usuario();
                }

                return this.entidade;
            }

            set
            {
                this.entidade = value;
            }
        }

        #endregion

        #region Métodos de Negócio

        public bool cadastrar(UsuarioDto dto)
        {

            try
            {
                Fusao.Copia(typeof(UsuarioDto), dto, typeof(Usuario), this.Entidade);
                /*Tratamento do cadastro do usuário
                 * - Criptografar a senha do usuário
                 * - Validar a senha com as senhas na lista negra selecionada
                 * - Colocar no Papel de Usuario
                 */

                Dao.salvar(Entidade);
                return true;
            }
            catch
            {

                throw;

            }
        }

        public bool alterar(UsuarioDto dto)
        {
            try
            {
                Fusao.Copia(typeof(UsuarioDto), dto, typeof(Usuario), Entidade);
                Dao.atualizar(Entidade);

                return true;
            }
            catch
            {

                throw;
            }
        }

        public UsuarioDto buscarPorId(int id)
        {
            try
            {
                Entidade = Dao.listarPorId(id);
                Fusao.Copia(typeof(Usuario), Entidade, typeof(UsuarioDto), Dto);
                return Dto;
            }
            catch
            {

                throw;
            }
        }

        public IList<UsuarioDto> buscarTudo()
        {
            try
            {
                IList<Usuario> Usuarios = new List<Usuario>();
                IList<UsuarioDto> dtos = new List<UsuarioDto>();
                Usuarios = Dao.listarTudo();

                foreach (Usuario Usuario in Usuarios)
                {
                    UsuarioDto dto = new UsuarioDto();
                    Fusao.Copia(typeof(Usuario), Usuario, typeof(UsuarioDto), dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch
            {

                throw;
            }
        }

        public bool apagar(UsuarioDto dto)
        {
            try
            {
                Fusao.Copia(typeof(UsuarioDto), dto, typeof(Usuario), Entidade);
                Dao.excluir(Entidade);
                return true;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// Verifica a força da senha
        /// Verifica se a senha é proibida
        /// Verifica se o tamanho da senha é o mínimo
        /// Verifica se a senha é diferente de nula
        /// </summary>
        /// <returns></returns>
        public bool validarSenha(string senha)
        {
            string hashSenha = Seguranca.Criptografia.Algoritmos.GeraValorHash(senha,"SHA3",null);

            if (!validaForcaDeSenha(senha).HasFlag(ForcaDeSenha.Forte) || !validaForcaDeSenha(senha).HasFlag(ForcaDeSenha.MuitoForte)){
                throw new Exception("Senha não é Forte. Tente novamente.");
            }

            return true;
        }

        public ForcaDeSenha validaForcaDeSenha(string senha)
        {

            int score = calculaPlacarDaForcaDaSenha(senha);

            if (score < 50)
                return ForcaDeSenha.Nula;
            else if (score < 60)
                return ForcaDeSenha.Fraca;
            else if (score < 80)
                return ForcaDeSenha.Media;
            else if (score < 100)
                return ForcaDeSenha.Forte;
            else
                return ForcaDeSenha.MuitoForte;
        }

        private int validaTamanhoDaSenha(string senha)
        {
            return Math.Min(10, senha.Length) * 6;
        }

        private int validaMinusculaDaSenha(string senha)
        {
            int resultado = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return Math.Min(2, resultado) * 5;
        }

        private int validaMaiusculasDaSenha(string senha)
        {
            int resultado = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(2, resultado) * 5;
        }

        private int validaNumerosDaSenha(string senha)
        {
            int resultado = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(2, resultado) * 5;
        }

        private int validaCaracteresEspeciaisDaSenha(string senha)
        {
            int resultado = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, resultado) * 5;
        }

        private int calculaPlacarDaForcaDaSenha(string senha)
        {
            if (senha == null) return 0;
            int tamanhoMaximo = validaTamanhoDaSenha(senha);
            int minuscula = validaMinusculaDaSenha(senha);
            int maiuscula = validaMaiusculasDaSenha(senha);
            int numeros = validaNumerosDaSenha(senha);
            int caracteres = validaCaracteresEspeciaisDaSenha(senha);
            return tamanhoMaximo + minuscula + maiuscula + numeros + caracteres;
        }

        /// <summary>
        /// Confronta a senha que foi digitada e verifica se a mesma está 
        /// na lista negra
        /// </summary>
        /// <param name="senha">Senha do usuário</param>
        /// <returns></returns>
        public bool senhaEstaNaListNegra(string senha)
        {
            
        }

        #endregion
    }
}