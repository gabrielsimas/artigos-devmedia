namespace Entidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// Entidade responsável pelo armazenamento das Organizações Não Governamentais
    /// </summary>
    public class Ong
    {
        #region Propriedades
        public virtual Nullable<long> Id { get; set; }
        public virtual String Cnpj { get; set; }
        public virtual String Cpf { get; set; }
        public virtual String NomeFantasia { get; set; }
        public virtual String RazaoSocial { get; set; }
        public virtual String Estado { get; set; }

        public virtual IList<Projeto> Projetos { get; set; }
        public virtual IList<Necessidade> Necessidades { get; set; }

        #endregion

        #region Construtores

        public Ong()
        {

        }

        public Ong(Nullable<long> id, String cnpj, String cpf, String nomeFantasia, String razaoSocial, String estado, IList<Projeto> projetos, IList<Necessidade> necessidades)
        {
            this.Id = id;
            this.Cnpj = cnpj;
            this.Cpf = cpf;
            this.NomeFantasia = nomeFantasia;
            this.RazaoSocial = razaoSocial;
            this.Estado = estado;
            this.Projetos = projetos;
            this.Necessidades = necessidades;
        }

        #endregion

        #region Classe Rica

        public override bool Equals(object obj)
        {
            if (obj is Ong)
            {
                Ong ong = (Ong)obj;
                if (ong.Id.HasValue && this.Id.HasValue)
                {
                    return ong.Id.Value.Equals(this.Id.Value);
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
