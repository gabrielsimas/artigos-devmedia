// -----------------------------------------------------------------------
// <copyright file="Contato.cs" company="CS Services Consultoria em Sistemas">
// Luís Gabriel Nascimento Simas
// Editora DevMedia
// 2014 - Todos os Direitos Reservados
// </copyright>
// -----------------------------------------------------------------------
namespace DevMedia.Ed112.MVCSeguranca.Entidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// Entidade representando o Contato no modelo de dados.
    /// </summary>
    public class Contato
    {
        #region Atributos
        private Nullable<long> id;
        private String nomeCompleto;
        private String apelido;
        #endregion

        #region Relacionamentos
        private IList<RedeSocial> redesSociais;
        private IList<Telefone> telefones;
        private IList<Email> emails;
        #endregion

        #region Construtor
        public Contato()
        {

        }

        public Contato(Nullable<long> id, String nome, String apelido, IList<RedeSocial> redesSociais, IList<Telefone> telefones, IList<Email> emails)
        {
            this.id = id;
            this.nomeCompleto = nome;
            this.apelido = apelido;
            this.redesSociais = redesSociais;
            this.telefones = telefones;
            this.emails = emails;
        }
        #endregion

        #region Propriedades

        public Nullable<long> Id
        {
            get
            {
                return this.id;
            }

            set{
                this.id = value;
            }
        }

        public String NomeCompleto
        {
            get
            {
                return this.nomeCompleto;
            }

            set
            {
                this.nomeCompleto = value;
            }
        }

        public String Apelido
        {
            get
            {
                return this.apelido;
            }

            set
            {
                this.apelido = value;
            }
        }

        public IList<RedeSocial> RedesSociais
        {
            get
            {
                return this.redesSociais;
            }

            set
            {
                this.redesSociais = value;
            }
        }

        public IList<Telefone> Telefones
        {
            get
            {
                return this.telefones;
            }

            set
            {
                this.telefones = value;
            }
        }


        public IList<Email> Emails
        {
            get
            {
                return this.emails;
            }

            set
            {
                this.emails = value;
            }
        }
        #endregion

        #region Complemento Classe Rica
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
