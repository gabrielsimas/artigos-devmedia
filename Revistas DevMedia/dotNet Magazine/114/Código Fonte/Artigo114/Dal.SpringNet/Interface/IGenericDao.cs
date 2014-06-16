// -----------------------------------------------------------------------
// <copyright file="IGenericDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace IoC.SpringNet.Dal.Interface
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para o CRUD
    /// </summary>
    public interface IGenericDao<E> where E : class
    {
        IList<E> listarTudo();
        E listarPorId(Nullable<long> id);
        void salvar(E entidade);
        void atualizar(E entidade);
        void excluir(E entidade);
    }
}
