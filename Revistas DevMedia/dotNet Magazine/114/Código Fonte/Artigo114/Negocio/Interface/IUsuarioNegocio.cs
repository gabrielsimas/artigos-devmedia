// -----------------------------------------------------------------------
// <copyright file="IUsuarioNegocio.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DTO.ACL;
    using Negocio.Interface;
    using Entidade.ACL;
    using Dal.Projeto.SpringNet.Implementacao;
    

    /// <summary>
    /// Interface para a Regra de Negócios de Usuário
    /// </summary>
    public interface IUsuarioNegocio : INegocioGenerico<UsuarioDto,UsuarioDao,Usuario>
    {
    
        #region Regras Específicas

        #endregion
    }
}
