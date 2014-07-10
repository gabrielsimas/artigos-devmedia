// -----------------------------------------------------------------------
// <copyright file="ProjetoNegocio.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

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
    /// Regrs de Negócios para os Projetos das ONGs
    /// </summary>
    public class ProjetoNegocio : IProjetoNegocio
    {
        #region Atributos
        private IProjetoDao dao;
        private ProjetoDto dto;
        private Projeto entidade;
        #endregion

        #region Propriedades

        public IProjetoDao Dao
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

        private ProjetoDto Dto
        {
            get
            {
                if (this.dto == null)
                {
                    this.dto = new ProjetoDto();
                }
                return this.dto;
            }

            set
            {
                this.dto = value;
            }
        }

        private Projeto Entidade
        {
            get
            {
                if (this.entidade == null)
                {
                    this.entidade = new Projeto();
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

        public bool cadastrar(ProjetoDto dto)
        {

            try
            {
                Fusao.Copia(typeof(ProjetoDto), dto, typeof(Projeto), this.Entidade);
                Dao.salvar(Entidade);
                return true;
            }
            catch
            {

                throw;

            }
        }

        public bool alterar(ProjetoDto dto)
        {
            try
            {
                Fusao.Copia(typeof(ProjetoDto), dto, typeof(Projeto), Entidade);
                Dao.atualizar(Entidade);

                return true;
            }
            catch
            {

                throw;
            }
        }

        public ProjetoDto buscarPorId(int id)
        {
            try
            {
                Entidade = Dao.listarPorId(id);
                Fusao.Copia(typeof(Projeto), Entidade, typeof(ProjetoDto), Dto);
                return Dto;
            }
            catch
            {

                throw;
            }
        }

        public IList<ProjetoDto> buscarTudo()
        {
            try
            {
                IList<Projeto> Projetos = new List<Projeto>();
                IList<ProjetoDto> dtos = new List<ProjetoDto>();
                Projetos = Dao.listarTudo();

                foreach (Projeto Projeto in Projetos)
                {
                    ProjetoDto dto = new ProjetoDto();
                    Fusao.Copia(typeof(Projeto), Projeto, typeof(ProjetoDto), dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch
            {

                throw;
            }
        }

        public bool apagar(ProjetoDto dto)
        {
            try
            {
                Fusao.Copia(typeof(ProjetoDto), dto, typeof(Projeto), Entidade);
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
