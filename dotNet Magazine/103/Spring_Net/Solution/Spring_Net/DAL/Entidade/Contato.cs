using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace DAL.Entidade
{   
    [Table(Name="contato")]
    public class Contato
    {
        #region Propriedades
        [Column(Name="id", IsPrimaryKey=true,IsDbGenerated=true)]
        public int Id { get; set; }

        [Column(Name="NomeCompleto")]
        public String NomeCompleto { get; set; }

        [Column(Name="Email")]
        public String Email { get; set; }

        [Column(Name="linkedin")]
        public String Linkedin { get; set; }

        [Column(Name="twitter")]
        public String Twitter {get; set;}

        [Column(Name="facebook")]
        public String Facebook { get; set; }

        #endregion

        #region Construtores
        public Contato()
        {

        }

        public Contato(int id, String nome, String email,String linkedin, String twitter, String facebook)
        {
            this.Id = id;
            this.NomeCompleto = nome;
            this.Email = email;
            this.Linkedin = linkedin;
            this.Facebook = facebook;

        }
        #endregion

        #region Sobrescritas

        public override string ToString()
        {
            return Convert.ToString(Id) + ", " + NomeCompleto + ", " + Email + ", " + Linkedin + ", " + Twitter + ", " + Facebook;
        }
        #endregion

    }
}
