namespace Entidade.ACL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class Papel
    {
        public enum SimNao : int {Nao = 0, Sim = 1}

        #region Propriedades
        public virtual Nullable<long> Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual SimNao IsAdministrador { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
        #endregion

        #region Construtores
        public Papel()
        {

        }

        public Papel(Nullable<long> id, String nome, SimNao isAdministrador, IList<Usuario> Usuarios)
        {
            this.Id = id;
            this.Nome = nome.Trim().ToUpper();
            this.IsAdministrador = isAdministrador; 
        }
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
            return this.Id.HasValue ? this.Id.GetHashCode() : 0;
        }
        #endregion
    }
}
