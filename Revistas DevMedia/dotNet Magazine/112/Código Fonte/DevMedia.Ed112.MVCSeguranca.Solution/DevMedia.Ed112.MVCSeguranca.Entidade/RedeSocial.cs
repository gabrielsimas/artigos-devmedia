// ---------------------------------------------------------------------------
// <copyright file="Contato.cs" company="CS Services Consultoria em Sistemas">
// Luís Gabriel Nascimento Simas
// Editora DevMedia
// 2014 - Todos os Direitos Reservados
// </copyright>
// ---------------------------------------------------------------------------
namespace DevMedia.Ed112.MVCSeguranca.Entidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Classe RedeSocial, Representa a Entidade Rede Social dentro do modelo de dados do Sistema
    /// </summary>
    public class RedeSocial
    {
        #region Atributos
        private Nullable<long> id;
        private String urlPerfil;
        private String nomeRedeSocial;
        #endregion

        #region Relacionamentos
        private Contato contato;
        #endregion

        #region Construtores
        public RedeSocial()
        {

        }

        public RedeSocial(Nullable<long> id, String urlPerfil, String nomeRedeSocial, Contato contato)
        {
            this.id = id;
            this.urlPerfil = urlPerfil;
            this.nomeRedeSocial = nomeRedeSocial;
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

        public String UrlPerfil
        {
            get
            {
                return this.urlPerfil;
            }

            set
            {
                this.urlPerfil = value;
            }
        }

        public String NomeRedeSocial
        {
            get
            {
                return this.nomeRedeSocial;
            }

            set
            {
                this.nomeRedeSocial = value;
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

        #region Sobrescrita Classe Rica
        public override string ToString()
        {
            return this.id + "," + this.urlPerfil + "," + this.nomeRedeSocial;
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }
        #endregion
    }
}
