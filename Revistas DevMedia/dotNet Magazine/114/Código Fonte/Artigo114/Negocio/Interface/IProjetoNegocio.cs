// -----------------------------------------------------------------------
// <copyright file="IProjetoNegocio.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DTO;
    using Dal.Projeto.SpringNet.Implementacao;
    using Entidade;

    /// <summary>
    /// Interface para a Regra de Negócios de Projetos da Ong
    /// </summary>
    public interface IProjetoNegocio : INegocioGenerico<ProjetoDto,ProjetoDao,Projeto>
    {

        #region Regras Genéricas

        #endregion

        #region Regras Específicas

        #endregion

    }
}
