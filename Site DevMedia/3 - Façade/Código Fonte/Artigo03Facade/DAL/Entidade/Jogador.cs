using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Jogador
    {
        #region Atributos

        private Int32 id;
        private Int32 idConf;
        private String nomeCompleto;
        private String apelido;
        private DateTime dataNascimento;
        private String estadoNatal;
        private String paisNatal;
        private Posicao posicao;
        private Clube clube;

        #endregion

        #region Propriedades

        public virtual Int32 Id
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

        public Int32 IdConf
        {
            get
            {
                return this.idConf;
            }

            set
            {
                this.idConf = value;
            }
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

        public virtual DateTime DataNascimento
        {
            get
            {
                return this.dataNascimento;
            }

            set
            {
                this.dataNascimento = value;
            }
        }

        public virtual String EstadoNatal
        {
            get
            {
                return this.estadoNatal;
            }

            set
            {
                this.estadoNatal = value;
            }
        }

        public virtual String PaisNatal {
            get
            {
                return this.paisNatal;
            }

            set
            {
                this.paisNatal = value;
            }
        }

        public virtual Posicao Posicao
        {
            get
            {
                return this.posicao;
            }

            set
            {
                this.posicao = value;
            }
        }

        public virtual Clube Clube
        {
            get
            {
                return this.clube;
            }

            set
            {
                this.clube = value;
            }
        }

        #endregion

        #region Construtores

        public Jogador()
        {

        }

        public Jogador(Int32 id, String nomeCompleto, String apelido, DateTime dataNascimento, String estado, String pais, Posicao posicao, Clube clube)
        {
            this.Id = id;
            this.NomeCompleto = nomeCompleto;
            this.Apelido = apelido;
            this.DataNascimento = dataNascimento;
            this.EstadoNatal = estado;
            this.PaisNatal = pais;
            this.Posicao = posicao;
            this.Clube = clube;
        }

        public Jogador(String nomeCompleto, String apelido, DateTime dataNascimento, String estado, String pais, Posicao posicao, Clube clube)
        {
            this.NomeCompleto = nomeCompleto;
            this.Apelido = apelido;
            this.DataNascimento = dataNascimento;
            this.EstadoNatal = estado;
            this.PaisNatal = pais;
            this.Posicao = posicao;
            this.Clube = clube;
        }

        #endregion

        #region Sobrescrita
        
        public override bool Equals(object obj)
        {
            if (obj is Jogador){

                Jogador jogador = (Jogador)obj;

                if (jogador.Id != null && this.id != null){
                    return jogador.Id.Equals(this.id);
                }
                
            }

            return false;
        }

        public override string ToString()
        {
            return this.id + ", "+ this.idConf + ", "  + this.nomeCompleto + ", " + this.apelido + ", " + this.dataNascimento + ", " + this.estadoNatal + ", " + this.paisNatal;
                
        }
        
        public override int GetHashCode()
        {
            return this.id != null ? this.id.GetHashCode() : 0;
        }
        
        #endregion
    }
}
