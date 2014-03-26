namespace Entidade.ACL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Usuario
    {
        #region Atributos
        private Nullable<long> id;
        private String nomeCompleto;
        private DateTime dataNascimento;
        private String apelido;
        private String email;
        private String perguntaSecreta;
        private String respostaSecreta;
        private long cpf;
        private long cnpj;
        private String login;
        private String senha;
        private String salt;
        private Boolean estaAtivo;

        private Papel papel;
        #endregion

        #region Construtores
        public Usuario()
        {

        }

        public Usuario(Nullable<long> id,String nomeCompleto, DateTime dataNascimento, String apelido, String email, String perguntaSecreta, String respostaSecreta, long cpf, long cnpj, String login, String senha, Boolean estaAtivo)
        {
            this.id = id;
            this.nomeCompleto = nomeCompleto;
            this.dataNascimento = dataNascimento;
            this.apelido = apelido;
            this.email = email;
            this.perguntaSecreta = perguntaSecreta;
            this.respostaSecreta = respostaSecreta;
            this.cpf = cpf;
            this.cnpj = cnpj;
            this.login = login;
            this.senha = senha;
            this.estaAtivo = estaAtivo;
        }
        #endregion

        #region Propriedades
        public int Id { get; set; }
        public String NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Apelido { get; set; }
        public String Email { get; set; }
        public String PerguntaSecreta { get; set; }
        public String RespostaSecreta { get; set; }
        public long Cpf { get; set; }
        public long Cnpj { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Salt { get; set; }
        public Boolean EstaAtivo { get; set; }
        public Papel Papel { get; set; }
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
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }
        #endregion
    }
}
