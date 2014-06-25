using System;
using System.Collections.Generic;

using IoC.SpringNet.Dal.Interface;

namespace Negocio.Interface
{
    /// <summary>
    /// Interface para Métodos Padrão para Regra de Negócios
    /// </summary>
    /// <typeparam name="D">Dto</typeparam>
    /// <typeparam name="DAO">Dao</typeparam>
    /// <typeparam name="E">Entidade</typeparam>
    public interface INegocioGenerico<D,DAO,E>
        where D: class
        where DAO: IGenericDao<E>
        where E: class
    {
        #region Regras Genéricas

        Boolean cadastrar(D entidadeDTO);
        D listarPorId(Nullable<long> id);
        IList<D> listaTudo();
        Boolean editar(D entidadeDTO);
        Boolean excluir(D entidadeDTO);

        #endregion

    }
}
