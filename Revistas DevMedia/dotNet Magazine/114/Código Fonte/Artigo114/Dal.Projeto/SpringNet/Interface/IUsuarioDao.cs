// -----------------------------------------------------------------------
// <copyright file="IUsuarioDao.cs" company="CS Services Consultoria em Sistemas">
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
    using Entidade.ACL;

    /// <summary>
    /// Interface para OCP de UsuarioDao
    /// OCP = Princípio do Aberto e Fechado, aberto para extensão e fechado para modificação
    /// Qualquer nova regra de Dao para Usuario, deve ser colocado nesta Classe
    /// </summary>
    public interface IUsuarioDao: IGenericDao<Usuario>
    {
    }
}
