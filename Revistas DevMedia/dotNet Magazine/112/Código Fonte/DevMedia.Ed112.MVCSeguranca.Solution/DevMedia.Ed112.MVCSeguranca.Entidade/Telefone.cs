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
    /// Classe Telefone representando a Entidade responsável
    /// por persistir os Telefones do Contato
    /// </summary>
    public class Telefone
    {
        #region Atributos

        private Nullable<long> id;
        private int ddd;
        private int ddi;
        private int numero;
        private String tipoTelefone;

        #endregion
        #region Relacionamentos
        private Contato contato;        
        #endregion

        #region Construtores
        public Telefone()
        {

        }

        public Telefone(int id, int ddd, int ddi, int numero, String tipoTelefone, Contato contato)
        {
            this.id = id;
            this.ddd = ddd;
            this.ddi = ddi;
            this.numero = numero;
            this.tipoTelefone = tipoTelefone;
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

        public int DDD
        {
            get
            {
                return this.ddd;
            }

            set
            {
                this.ddd = value;
            }
        }

        public int DDI
        {
            get
            {
                return this.ddi;
            }

            set
            {
                this.ddi = value;
            }
        }

        public int Numero
        {
            get
            {
                return this.numero;
            }

            set
            {
                this.numero = value;
            }
        }

        public String TipoTelefone
        {
            get
            {
                return this.tipoTelefone;
            }

            set
            {
                this.tipoTelefone = value;
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
