// -----------------------------------------------------------------------
// <copyright file="Necessidade.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Entidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Necessidade
    {

        #region Propriedades

        public virtual Nullable<long> Id { get; set; }
        public virtual String Item { get; set; }
        public virtual int Quantidade { get; set; }

        public virtual Ong Ong { get; set; }

        #endregion

        #region Construtores

        public Necessidade()
        {

        }

        public Necessidade(Nullable<long> id, String item, int quantidade, Ong ong)
        {
            this.Id = id;
            this.Item = item;
            this.Quantidade = quantidade;
            this.Ong = ong;    
        }

        #endregion

        #region Classe Rica

        public override bool Equals(object obj)
        {
            if (obj is Necessidade){
                Necessidade necessidade = (Necessidade)obj;

                if (necessidade.Id.HasValue && this.Id.HasValue){
                    return necessidade.Id.Value.Equals(this.Id.Value);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.HasValue ? this.Id.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            PropertyInfo[] propriedades;
            propriedades = GetType().GetProperties(BindingFlags.Public);
            return propriedades.ToString();
        }
        #endregion

    }
}
