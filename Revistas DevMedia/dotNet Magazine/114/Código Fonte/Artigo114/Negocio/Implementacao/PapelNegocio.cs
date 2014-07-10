namespace Negocio.Implementacao
{
    using System.Collections.Generic;

    using Negocio.Interface;
    using DTO.ACL;
    using Entidade.ACL;
    using Seguranca.Codigo;
    using Dal.Projeto.SpringNet.Interface;

    /// <summary>
    /// Regra de Negócio para Papel
    /// </summary>
    public class PapelNegocio: IPapelNegocio
    {
        #region Atributos
        private IPapelDao dao;
        private PapelDto dto;
        private Papel entidade;
        #endregion

        #region Propriedades

        public IPapelDao Dao
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

        private PapelDto Dto
        {
            get
            {
                if (this.dto == null)
                {
                    this.dto = new PapelDto();
                }
                return this.dto;
            }

            set
            {
                this.dto = value;
            }
        }

        private Papel Entidade
        {
            get
            {
                if (this.entidade == null)
                {
                    this.entidade = new Papel();
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

        public bool cadastrar(PapelDto dto)
        {

            try
            {
                Fusao.Copia(typeof(PapelDto), dto, typeof(Papel), this.Entidade);
                Dao.salvar(Entidade);
                return true;
            }
            catch
            {

                throw;

            }
        }

        public bool alterar(PapelDto dto)
        {
            try
            {
                Fusao.Copia(typeof(PapelDto), dto, typeof(Papel), Entidade);
                Dao.atualizar(Entidade);

                return true;
            }
            catch
            {

                throw;
            }
        }

        public PapelDto buscarPorId(int id)
        {
            try
            {
                Entidade = Dao.listarPorId(id);
                Fusao.Copia(typeof(Papel), Entidade, typeof(PapelDto), Dto);
                return Dto;
            }
            catch
            {

                throw;
            }
        }

        public IList<PapelDto> buscarTudo()
        {
            try
            {
                IList<Papel> Papels = new List<Papel>();
                IList<PapelDto> dtos = new List<PapelDto>();
                Papels = Dao.listarTudo();

                foreach (Papel Papel in Papels)
                {
                    PapelDto dto = new PapelDto();
                    Fusao.Copia(typeof(Papel), Papel, typeof(PapelDto), dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch
            {

                throw;
            }
        }

        public bool apagar(PapelDto dto)
        {
            try
            {
                Fusao.Copia(typeof(PapelDto), dto, typeof(Papel), Entidade);
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
