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
    public class Responsabilidade
    {
        #region Atributos
        private Nullable<long> id;
        private String nome;
        private String estado;

        private Usuario usuario;
        #endregion

        #region Construtores
        public Responsabilidade()
        {

        }

        public Responsabilidade(Nullable<long> id, String nome, String estado, Usuario usuario)
        {
            this.id = id;
            this.nome = nome;
            this.estado = estado;
            this.usuario = usuario;
        }
        #endregion

        #region Propriedades
        public virtual Nullable<long> Id
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

        public virtual Usuario Usuario
        {
            get
            {
                return this.usuario;
            }

            set
            {
                this.usuario = value;
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
