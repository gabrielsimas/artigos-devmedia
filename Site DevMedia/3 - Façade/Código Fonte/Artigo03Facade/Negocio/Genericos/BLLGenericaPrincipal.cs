using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Generico;
using DAL.Persistencia;

namespace Negocio.Genericos
{
    /// <summary>
    /// Classe Abstrata que proverá serviços para Injeção de Dependências
    /// e persistência para a Regra de Negócios
    /// </summary>
    /// <typeparam name="E">Entidade DTO</typeparam>
    /// <typeparam name="D">Objeto DAO</typeparam>
    /// <typeparam name="C">Entidade da DAL</typeparam>
    public abstract class BLLGenericaPrincipal<E,D,C> : IBLLCRUD<E> where E: class,new() where D: class, IGenericDAO<C>, new() where C: class, new()
    {

        #region Atributos
        
        private static D dao;
        private static C entidade;
        private static E dto;

        #endregion

        #region Propriedades

        public D DAO
        {
            get
            {
                if (dao == null)
                {
                    throw new MemberAccessException("A Classe DAO não foi inicializada!");
                }
                else
                {
                    return dao;
                }
            }

            set
            {
                dao = value;
            }
        }

        public C Entidade
        {
            get
            {
                if (entidade == null)
                {

                    throw new MemberAccessException("A Entidade não foi inicializada!");

                }
                else
                {
                    return entidade;
                }
            }

            set
            {
                entidade = value;
            }
        }
        #endregion

        #region Métodos Estáticos de reuso

        public static D InstanciaDAO()
        {
            if (dao == null){

                dao = new D();               
                
            }

            return dao;
        }

        public static C InstanciaEntidade()
        {
            if (entidade == null){

                entidade = new C();

            }

            return entidade;
        }

        public static E InstaciaDTO()
        {
            if(dto == null){
                dto = new E();
            }

            return dto;
        }

        #endregion
        
        #region Construtores

        public BLLGenericaPrincipal()
        {
            InstanciaEntidade();
            
        }

        #endregion

        #region Regras de Negócio
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
                
        public virtual Boolean cadastrar(E dto)
        {
            try
            {
                D dal = InstanciaDAO();
                C entity = InstanciaEntidade();

                Utils.Copy(typeof(E),dto,typeof(C),entity);

                dal.salvar(entity);

                return true;

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual E listarPorId(int id)
        {
            try
            {
                D dal = InstanciaDAO();
                C entity = InstanciaEntidade();
                E dto = InstaciaDTO();

                entity = dal.listarPorId(id);

                Utils.Copy(typeof(C), entity, typeof(E), dto);

                return dto;   

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public virtual IList<E> listarTudo()
        {
            try
            {
                D dal = InstanciaDAO();
                IList<E> dtos = new List<E>();
                IList<C> entidades = dal.listarTudo();

                foreach(C entidade in entidades){
                    E dto = new E();
                    Utils.Copy(typeof(C), entidade, typeof(E), dto);
                    dtos.Add(dto); 
                }

                return dtos;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public virtual Boolean alterar(E dto)
        {
            try
            {
                D dal = InstanciaDAO();
                C entity = InstanciaEntidade();

                Utils.Copy(typeof(E),dto,typeof(C),entity);

                dal.atualizar(entity);

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public virtual Boolean excluir(E dto)
        {
            try
            {
                D dal = InstanciaDAO();
                C entity = InstanciaEntidade();

                Utils.Copy(typeof(E), dto, typeof(C), entity);

                dal.excluir(entity);

                return true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
