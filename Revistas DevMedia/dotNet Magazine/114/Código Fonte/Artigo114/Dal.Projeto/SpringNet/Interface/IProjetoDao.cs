// -----------------------------------------------------------------------
// <copyright file="IProjetoDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dal.Projeto.SpringNet.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using IoC.SpringNet.Dal.Interface;
    using Entidade;

    /// <summary>
    /// Interface para OCP de ProjetoDao
    /// OCP = Princípio do Aberto e Fechado, aberto para extensão e fechado para modificação
    /// Qualquer nova regra de Dao para Projeto, deve ser colocado nesta Classe
    /// </summary>
    public interface IProjetoDao: IGenericDao<Projeto>
    {
    }
}
