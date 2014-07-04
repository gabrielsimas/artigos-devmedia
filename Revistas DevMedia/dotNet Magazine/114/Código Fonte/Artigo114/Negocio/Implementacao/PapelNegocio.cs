// -----------------------------------------------------------------------
// <copyright file="PapelNegocio.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Negocio.Interface;
    using DTO.ACL;
    using Entidade.ACL;
    using Dal.Projeto.SpringNet.Implementacao;

    /// <summary>
    /// Regra de Negócio para Papel
    /// </summary>
    public class PapelNegocio: NegocioGenericoAbstrato<PapelDto,PapelDao,Papel> 
    {
    }
}
