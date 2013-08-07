using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Mapping.Attributes;

namespace DAL.Entidade
{
    [Serializable]
    [Class(Schema = "RevistaArtigo02", Table = "Carro")]
    public class Carro
    
    {
        #region atributos
        
        private Int32 id;
        private String modelo;
        private String motor;

        #endregion

        #region Propriedades
        [Id(Name="Id",Column="id"),Generator(1,Class="identity")]
        public virtual Int32 Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Property(Column="modelo")]
        public virtual String Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        [Property(Column="motor")]
        public virtual String Motor
        {
            get { return this.motor; }
            set { this.motor = value; }
        }

        #endregion

        #region Construtores

        public Carro()
        {

        }

        public Carro(String modelo, String motor)
        {
            this.Modelo = modelo;
            this.Motor = motor;
        }
        #endregion

        #region Sobrescritas
        public override string ToString()
        {
            return this.id + ", " + this.modelo + ", " + this.motor;
        }
        #endregion
    }
}
