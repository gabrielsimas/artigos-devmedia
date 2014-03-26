namespace Entidade.ACL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class Papel
    {

        #region Atributos
        private Nullable<long> id;
        private string nomePapel;
        private Boolean administrativo;
        private Boolean ativo;
        private IList<Usuario> usuarios;
        #endregion

        #region Construtores
        public Papel()
        {

        }

        public Papel(int id, String nomePapel, Boolean administrativo, Boolean ativo, IList<Usuario> usuarios)
        {
            this.id = id;
            this.nomePapel = nomePapel;
            this.administrativo = administrativo;
            this.ativo = ativo;
            this.usuarios = usuarios;
        }
        #endregion

        #region Propriedades
        public int Id { get; set; }
        public String NomePapel { get; set; }
        public Boolean Administrativo { get; set; }
        public Boolean Ativo { get; set; }
        public IList<Usuario> Usuarios { get; set; }
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
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }
        #endregion
    }
}
