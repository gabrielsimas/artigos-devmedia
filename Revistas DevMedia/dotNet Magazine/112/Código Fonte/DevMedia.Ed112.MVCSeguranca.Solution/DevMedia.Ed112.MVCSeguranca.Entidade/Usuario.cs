// -----------------------------------------------------------------------
// <copyright file="Usuario.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
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
    /// TODO: Update summary.
    /// </summary>
    public class Usuario
    {
        #region Atributos
        private Nullable<long> id;
        private string nome;
        private String email;
        private String conta;
        private String senha;
        private String salt;
        private String estado;

        private Responsabilidade responsabilidade;


        #endregion

        #region Construtores
        public Usuario()
        {

        }

        public Usuario(Nullable<long> id, String nome, String email, String conta, String senha, String salt, String estado, Responsabilidade responsabilidade)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.conta = conta;
            this.senha = senha;
            this.salt = salt;
            this.estado = estado;
            this.responsabilidade = responsabilidade;
        }
        #endregion

        #region Propriedades
        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        public virtual String Nome
        {
            get
            {
                return this.nome;
            }

            set
            {
                this.nome = value;
            }
        }

        public virtual String Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
            }
        }

        public virtual String Conta
        {
            get
            {
                return this.conta;
            }

            set
            {
                this.conta = value;
            }
        }

        public virtual String Senha
        {
            get
            {
                return this.senha;
            }

            set
            {
                this.senha = value;
            }
        }

        public virtual String Salt
        {
            get
            {
                return this.salt;
            }

            set
            {
                this.salt = value;
            }
        }

        public virtual String Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public virtual Responsabilidade Responsabilidade
        {
            get
            {
                return this.responsabilidade;
            }

            set
            {
                this.responsabilidade = value;
            }
        }
        #endregion

        #region Sobrescritas Classe Rica
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
