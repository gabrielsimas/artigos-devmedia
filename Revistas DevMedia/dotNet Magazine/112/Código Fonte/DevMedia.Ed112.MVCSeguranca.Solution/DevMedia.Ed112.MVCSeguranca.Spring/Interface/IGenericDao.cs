// -----------------------------------------------------------------------
// <copyright file="IGenericDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace DevMedia.Ed112.MVCSeguranca.SpringNet.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IGenericDao<E>
    {
        void Criar(E entidade);
        IList<E> listarTudo();
        E listaPorId(int id);
        void Atualizar(E entidade);
        void Excluir(E entidade);
    }
}
