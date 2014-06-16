// -----------------------------------------------------------------------
// <copyright file="Projeto.cs" company="CS Services Consultoria em Sistemas">
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
    /// Entidade Responsável pelo armazenamento dos Projetos das ONGs
    /// </summary>
    public class Projeto
    {
        #region Propriedades
        public virtual Nullable<long> Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual Double Custo { get; set; }

        public virtual Ong Ong { get; set; }

        #endregion

        #region Construtores

        public Projeto()
        {

        }

        public Projeto(Nullable<long> id, String nome, String descricao, Double custo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Custo = custo;
        }

        #endregion

        #region Classe Rica

        public override bool Equals(object obj)
        {
            if (obj is Projeto){
                Projeto projeto = (Projeto)obj;

                if (projeto.Id.HasValue && this.Id.HasValue){
                    return projeto.Id.Value.Equals(this.Id.Value);
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
