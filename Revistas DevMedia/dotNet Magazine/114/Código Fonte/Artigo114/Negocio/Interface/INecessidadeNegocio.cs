// -----------------------------------------------------------------------
// <copyright file="INecessidadeNegocio.cs" company="CS Services Consultoria em Sistemas">
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
    using Negocio.Interface;
    using Entidade;
    using Dal.Projeto.SpringNet;
    

    /// <summary>
    /// Interface para a Regra de Negócios de Necessidade da Ong
    /// </summary>
    public interface INecessidadeNegocio : INegocioGenerico<NecessidadeDto,NecessidadeDao,Necessidade>
    {
        #region Regras Específicas



        #endregion
    }
}
