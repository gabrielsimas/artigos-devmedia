// -----------------------------------------------------------------------
// <copyright file="OngNegocio.cs" company="CS Services Consultoria em Sistemas">
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
    using DTO;
    using Entidade;
    using Dal.Projeto.SpringNet.Implementacao;

    /// <summary>
    /// Regra de Negócio para Ong
    /// </summary>
    public class OngNegocio : NegocioGenericoAbstrato<OngDto,OngDao,Ong>
    {
    }
}
