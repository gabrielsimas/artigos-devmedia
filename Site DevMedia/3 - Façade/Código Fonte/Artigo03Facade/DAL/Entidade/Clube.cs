using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Clube
    {
        #region Atributos

        private Int32 id;
        private String nomeCompleto;
        private String apelido;
        private DateTime dataFundacao;
        private String distintivo;
        private String cidade;
        private String estado;
        private IList<Jogador> elenco;

        #endregion 

        #region Propriedades
        public virtual Int32 Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public virtual String NomeCompleto
        {
            get
            {
                return this.nomeCompleto;
            }

            set
            {
                this.nomeCompleto = value;
            }
        }

        public virtual String Apelido
        {
            get
            {
                return this.apelido;
            }

            set
            {
                this.apelido = value;
            }

        }

        public virtual DateTime DataFundacao
        {
            get
            {
                return this.dataFundacao;
            }

            set
            {
                this.dataFundacao = value;
            }
        }

        public virtual IList<Jogador> Elenco
        {
            get
            {
                return this.elenco;
            }

            set
            {
                this.elenco = value;
            }

        }

        public virtual String Distintivo
        {

            get
            {
                return this.distintivo;
            }

            set
            {
                this.distintivo = value;
            }

        }

        public virtual String Cidade
        {
            get
            {
                return this.cidade;
            }

            set
            {
                this.cidade = value;
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

        #endregion

        #region Construtores

        public Clube()
        {

        }

        public Clube (Int32 id, String nomeCompleto, String apelido, DateTime fundacao, String distintivo,String cidade, String estado,List<Jogador> elenco)
        {
            this.Id = id;
            this.NomeCompleto = nomeCompleto;
            this.Apelido = apelido;
            this.DataFundacao = fundacao;
            this.Distintivo = distintivo;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Elenco = elenco;
        }

        public Clube (String nomeCompleto, String apelido, DateTime fundacao)
        {
            this.NomeCompleto = nomeCompleto;
            this.Apelido = apelido;
            this.DataFundacao = fundacao;
        }

        #endregion

        #region Sobrescritas
        
        public override bool Equals(object obj)
        {
            if (obj is Clube){

                Clube clube = (Clube)obj;

                if (clube.Id != null && this.id != null)
                {
                    return clube.Id.Equals(this.id);
                }
                    
            }

            return false;
        }

        public override string ToString()
        {
            return this.id + ", " + this.nomeCompleto + ", " + this.apelido + ", " + this.dataFundacao + ", " + this.elenco.ToString();
        }

        public override int GetHashCode()
        {
            return this.id != null ? this.id.GetHashCode() : 0;
        }
        
        #endregion
    }

    
}
