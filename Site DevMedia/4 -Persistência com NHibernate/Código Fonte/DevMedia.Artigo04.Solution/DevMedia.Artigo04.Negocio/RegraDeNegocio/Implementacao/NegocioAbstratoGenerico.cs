using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.Negocio.RegraDeNegocio.Interface;
using DevMedia.Artigo04.Dal;
using DevMedia.Artigo04.Dal.Interfaces;
using DevMedia.Artigo04.Dal.Implementacao;
using DevMedia.Artigo04.Dto;
using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using DevMedia.Artigo04.Utilitarios;

namespace DevMedia.Artigo04.Negocio.RegraDeNegocio.Implementacao
{
    //E = DTO
    //D = Dao
   public abstract class NegocioAbstratoGenerico<E,DAO,D> : INegocioGenerico<E>
        where E: class, new() //DTO
        where DAO: IGenericDao<D> , new() //Dao
        where D:  class, new() //Dominio
    {

        #region Atributos

        private D entidade;
        private DAO objetoDao;

        #endregion

        #region Propriedades
        protected D Entidade
        {
            get
            {
                return this.entidade;
            }

            set
            {
                this.entidade = value;
            }
        }

        protected DAO ObjetoDao
        {
            get
            {
                return this.objetoDao;
            }

            set
            {
                this.objetoDao = value;
            }
        }
        #endregion

        #region Métodos de Negócio

        public bool cadastrar(E entidadeDTO)
        {
            try
            {
                
                //produz o Processo de gravação
                this.entidade = new D();

                //Converte o DTO em Dominio
                Utils.Copia(typeof(E), entidadeDTO, typeof(D), Entidade);

                ObjetoDao = new DAO();

                ObjetoDao.salvar(Entidade);

                return true;
            }
            catch
            {
                throw;
            }

        }

        public E listarPorId(Nullable<long> id)
        {
            try
            {
                //Inicia o processo de busca
                ObjetoDao  = new DAO();
                this.entidade = new D();
                Entidade = objetoDao.listarPorId(id);
                E dto = new E();

                //Faz a fusão entre o domínio e o DTO
                //Uma regra: quando retorna, retorna DTO, o que implica em inverter a fusão
                Utils.Copia(typeof(D), Entidade, typeof(E), dto);

                return dto;
            }
            catch
            {
                
                throw;
            }
        }

        public IList<E> listaTudo()
        {
            try
            {
                //Inicia o processo de localização
                ObjetoDao = new DAO();
                IList<D> entidades = new List<D>();
                entidades = objetoDao.listarTudo();

                IList<E> dtos = new List<E>();

                //Faz a iteração para o DTO
                foreach (D entidade in entidades)
                {
                    //Faz a fusão e adiciona à lista de DTOs
                    E dto = new E();
                    Utils.Copia(typeof(D), entidade, typeof(E), dto);
                    //Adiciona a lista de DTOs
                    dtos.Add(dto);
                }

                //Retorna a Lista de DTOs
                return dtos;
            }
            catch
            {
                
                throw;
            }
        }

        public bool editar(E entidadeDTO)
        {
            try
            {
                this.entidade = new D();
                //Converte o DTO em Dominio
                Utils.Copia(typeof(E), entidadeDTO, typeof(D), Entidade);
                //produz o Processo de gravação
                ObjetoDao = new DAO();

                ObjetoDao.atualizar(Entidade);

                return true;
            }
            catch
            {
                
                throw;
            }
        }

        public bool excluir(E entidadeDTO)
        {
            try
            {
                
                //produz o Processo de gravação
                this.entidade = new D();

                //Converte o DTO em Dominio
                Utils.Copia(typeof(E), entidadeDTO, typeof(D), Entidade);

                ObjetoDao = new DAO();
                ObjetoDao.excluir(Entidade);

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


