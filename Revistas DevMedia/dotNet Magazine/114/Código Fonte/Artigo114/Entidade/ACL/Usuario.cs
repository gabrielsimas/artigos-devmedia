namespace Entidade.ACL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// Entidade representando o Usuário
    /// </summary>
    public class Usuario
    {

        public enum EstadoUsuario: int {Bloqueado = 0, Liberado = 1}

        #region Propriedades
        public virtual Nullable<long> Id { get; set; }
        public virtual String NomeCompleto { get; set; }
        public virtual String Apelido { get; set; }
        public virtual String Login { get; set; }
        public virtual String Senha { get; set; }
        public virtual String PerguntaSecreta { get; set; }
        public virtual String RespostaSecreta { get; set; }
        public virtual String Email { get; set; }
        public virtual EstadoUsuario Estado { get; set; }

        public virtual Papel Papel { get; set; }
        #endregion

        #region Construtores
        public Usuario()
        {

        }

        public Usuario(Nullable<long> id, String nomeCompleto, String apelido, String login, String senha, String perguntaSecreta, String respostaSecreta, String email, EstadoUsuario estado,Papel papel)
        {
            this.Id = id;
            this.NomeCompleto = nomeCompleto.Trim().ToUpper();
            this.Apelido = apelido.Trim().ToUpper();
            this.Login = login.Trim().ToUpper();
            this.Senha = senha;
            this.PerguntaSecreta = perguntaSecreta.Trim().ToUpper();
            this.RespostaSecreta = respostaSecreta.Trim().ToUpper();
            this.Email = email.Trim().ToLower();
            this.Estado = estado;
            this.Papel = papel;
        }
        #endregion

        #region Classe Rica

        public override string ToString()
        {
            FieldInfo[] atributos;
            atributos = GetType().GetFields(BindingFlags.NonPublic);
            return atributos.ToString();
        }

        public override int GetHashCode()
        {
            return this.Id.HasValue ? this.Id.GetHashCode() : 0;
        }

        #endregion
    }
}
