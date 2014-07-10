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
    /// Regra de Negócio para Ong
    /// </summary>
    public class OngNegocio : IOngNegocio
    {
        #region Atributos
        private IOngDao dao;
        private OngDto dto;
        private Ong entidade;
        #endregion

        #region Propriedades

        public IOngDao Dao
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

        private OngDto Dto
        {
            get
            {
                if (this.dto == null)
                {
                    this.dto = new OngDto();
                }
                return this.dto;
            }

            set
            {
                this.dto = value;
            }
        }

        private Ong Entidade
        {
            get
            {
                if (this.entidade == null)
                {
                    this.entidade = new Ong();
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

        public bool cadastrar(OngDto dto)
        {

            try
            {
                Fusao.Copia(typeof(OngDto), dto, typeof(Ong), this.Entidade);
                Dao.salvar(Entidade);
                return true;
            }
            catch
            {

                throw;

            }
        }

        public bool alterar(OngDto dto)
        {
            try
            {
                Fusao.Copia(typeof(OngDto), dto, typeof(Ong), Entidade);
                Dao.atualizar(Entidade);

                return true;
            }
            catch
            {

                throw;
            }
        }

        public OngDto buscarPorId(int id)
        {
            try
            {
                Entidade = Dao.listarPorId(id);
                Fusao.Copia(typeof(Ong), Entidade, typeof(OngDto), Dto);
                return Dto;
            }
            catch
            {

                throw;
            }
        }

        public IList<OngDto> buscarTudo()
        {
            try
            {
                IList<Ong> Ongs = new List<Ong>();
                IList<OngDto> dtos = new List<OngDto>();
                Ongs = Dao.listarTudo();

                foreach (Ong Ong in Ongs)
                {
                    OngDto dto = new OngDto();
                    Fusao.Copia(typeof(Ong), Ong, typeof(OngDto), dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch
            {

                throw;
            }
        }

        public bool apagar(OngDto dto)
        {
            try
            {
                Fusao.Copia(typeof(OngDto), dto, typeof(Ong), Entidade);
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
