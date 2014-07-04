// -----------------------------------------------------------------------
// <copyright file="IPapelNegocio.cs" company="CS Services Consultoria em Sistemas">
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
    using Dal.Projeto.SpringNet.Implementacao;
    using Entidade.ACL;

    /// <summary>
    /// Interface para a Regra de Negócios para Papel
    /// </summary>
    public interface IPapelNegocio: INegocioGenerico<PapelDto,PapelDao,Papel>
    {

        #region Regras Genéricas

        #endregion

        #region Regras Específicas

        #endregion

    }
}
