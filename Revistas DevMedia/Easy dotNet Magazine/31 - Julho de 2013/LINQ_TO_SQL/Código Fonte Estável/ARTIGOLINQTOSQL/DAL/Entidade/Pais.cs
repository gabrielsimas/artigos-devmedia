using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace DAL.Entidade
{
    [Table(Name="Pais")]
    public class Pais
    {

        #region Atributos
        private Int32 id;
        private String nome;

        #endregion

        #region Propriedades
        [Column(Name="Id",IsPrimaryKey = true, IsDbGenerated = true)]
        public Int32 Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        [Column(Name="Nome")]
        public String Nome
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



        #endregion

        #region Construtores
        public Pais()
        {

        }


        public Pais(int id, String nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        #endregion

        #region Sobrescrita
        public override string ToString()
        {
            return this.Id + ", " + this.Nome;
        }


        #endregion

    }
}
