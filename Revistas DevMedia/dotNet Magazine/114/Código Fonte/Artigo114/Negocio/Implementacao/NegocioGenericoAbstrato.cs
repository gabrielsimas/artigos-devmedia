// -----------------------------------------------------------------------
// <copyright file="NegocioGenericoAbstrato.cs" company="CS Services Consultoria em Sistemas">
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
    using Seguranca.Codigo;
    using IoC.SpringNet.Dal.Interface;
    

    /// <summary>
    /// Classe Abstrata e Genérica de Regras de Negócio
    /// </summary>
    /// <typeparam name="D">Dto</typeparam>
    /// <typeparam name="DAO">Dao</typeparam>
    /// <typeparam name="E">Entidade</typeparam>
    public abstract class NegocioGenericoAbstrato<D,DAO,E>: INegocioGenerico<D,DAO,E>
        where D: class, new()
        where DAO: IGenericDao<E>
        where E: class
    {

        #region Injeção de Dependências

        protected E Entidade { get; set; }
        protected DAO Dao { get; set; }
        protected D Dto { get; set; }

        #endregion

        #region Métodos de Negócio

        public virtual bool cadastrar(D entidadeDTO)
        {
            try
            {
                //converte Dto em Dominio
                Fusao.Copia(typeof(E), this.Entidade, typeof(D), entidadeDTO);

                //Salva a Entidade
                this.Dao.salvar(this.Entidade);

                return true;

            } catch(Exception ex){
                return false;
            }
        }

        public D listarPorId(long? id)
        {
            try
            {
                this.Entidade = this.Dao.listarPorId(id);
                Fusao.Copia(typeof(E), this.Entidade, typeof(D), this.Dto);

                return this.Dto;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public virtual IList<D> listaTudo()
        {
            try
            {
                IList<E> entidades = new List<E>();
                IList<D> dtos = new List<D>();

                entidades = this.Dao.listarTudo();

                foreach (E entidade in entidades)
                {
                    D dto = new D();
                    Fusao.Copia(typeof(E), entidade, typeof(D), dto);
                    dtos.Add(dto);
                }

                return dtos;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public virtual bool editar(D entidadeDTO)
        {
            try
            {
                Fusao.Copia(typeof(D), entidadeDTO, typeof(E), this.Entidade);
                this.Dao.atualizar(this.Entidade);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool excluir(D entidadeDTO)
        {
            try
            {
                Fusao.Copia(typeof(D), entidadeDTO, typeof(E),this.Entidade);
                this.Dao.excluir(this.Entidade);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
