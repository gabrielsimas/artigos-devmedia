namespace Negocio.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Negocio.Interface;
    using DTO;
    using Entidade;
    using Dal.Projeto.SpringNet.Implementacao;
    using Seguranca.Codigo;
    using Dal.Projeto.SpringNet.Interface;

    /// <summary>
    /// Regra de Negócios para Necessidades de uma Ong
    /// </summary>
    public class NecessidadeNegocio : INecessidadeNegocio
    {

        #region Atributos
        private INecessidadeDao dao;
        private NecessidadeDto dto;
        private Necessidade entidade;
        #endregion

        #region Propriedades

        public INecessidadeDao Dao
        {
            get
            {
                return this.dao;
            }

            set
            {
                this.dao = value;
            }
        }

        private NecessidadeDto Dto
        {
            get
            {
                if (this.dto == null)
                {
                    this.dto = new NecessidadeDto();
                }
                return this.dto;
            }

            set
            {
                this.dto = value;
            }
        }

        private Necessidade Entidade
        {
            get
            {
                if (this.entidade == null){
                    this.entidade = new Necessidade();
                }

                return this.entidade;
            }

            set
            {
                this.entidade = value;
            }
        }

        #endregion

        #region Métodos de Negócio

        public bool cadastrar(NecessidadeDto dto)
        {
            
            try
            {
                Fusao.Copia(typeof(NecessidadeDto), dto, typeof(Necessidade), this.Entidade);
                Dao.salvar(Entidade);
                return true;
            }
            catch
            {
                
                throw;
                
            }
        }

        public bool alterar(NecessidadeDto dto)
        {
            try
            {
                Fusao.Copia(typeof(NecessidadeDto),dto,typeof(Necessidade),Entidade);
                Dao.atualizar(Entidade);

                return true;
            }
            catch 
            {
                
                throw;
            }
        }

        public NecessidadeDto buscarPorId(int id)
        {
            try
            {
                Entidade = Dao.listarPorId(id);
                Fusao.Copia(typeof(Necessidade),Entidade,typeof(NecessidadeDto),Dto);
                return Dto;
            }
            catch
            {
                
                throw;
            }
        }

        public IList<NecessidadeDto> buscarTudo()
        {
            try
            {
                IList<Necessidade> necessidades = new List<Necessidade>();
                IList<NecessidadeDto> dtos = new List<NecessidadeDto>();
                necessidades = Dao.listarTudo();

                foreach(Necessidade necessidade in necessidades){
                    NecessidadeDto dto = new NecessidadeDto();
                    Fusao.Copia(typeof(Necessidade),necessidade,typeof(NecessidadeDto),dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch
            {
                
                throw;
            }
        }

        public bool apagar(NecessidadeDto dto)
        {
            try
            {
                Fusao.Copia(typeof(NecessidadeDto),dto,typeof(Necessidade), Entidade);
                Dao.excluir(Entidade);
                return true;
            }
            catch
            {
                
                throw;
            }
        }

        #endregion
    }
}
