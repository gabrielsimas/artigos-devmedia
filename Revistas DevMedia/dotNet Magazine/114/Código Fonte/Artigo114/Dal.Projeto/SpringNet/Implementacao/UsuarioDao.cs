// -----------------------------------------------------------------------
// <copyright file="UsuarioDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dal.Projeto.SpringNet.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using IoC.SpringNet.Dal.Implementacao;
    using Entidade.ACL;
    using Dal.Projeto.SpringNet.Interface;

    /// <summary>
    /// Objeto de Acesso a Dados para Persistência da Entidade Usuario
    /// </summary>
    public class UsuarioDao : GenericSpringNetDao<Usuario>, IUsuarioDao
    {
    }
}
