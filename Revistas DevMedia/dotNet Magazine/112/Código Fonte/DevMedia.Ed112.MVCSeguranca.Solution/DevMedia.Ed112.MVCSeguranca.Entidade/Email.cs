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
    /// Classe que representa a Persistência dos endereços de E-mails dos contatos
    /// </summary>
    public class Email
    {
        #region Atributos
        private Nullable<long> id;
        private String endereco;
        #endregion

        #region Relacionamentos
        private Contato contato;
        #endregion

        #region Construtores
        public Email()
        {

        }

        public Email(Nullable<long> id, String endereco, Contato contato)
        {
            this.id = id;
            this.endereco = endereco;
            this.contato = contato;
        }
        #endregion

        #region Propriedades
        public Nullable<long> Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public String Endereco
        {
            get
            {
                return this.endereco;
            }

            set
            {
                this.endereco = value;
            }
        }

        public Contato Contato
        {
            get
            {
                return this.contato;
            }

            set
            {
                this.contato = value;
            }
        }
        #endregion

        #region Sobrescrita classe Rica
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
