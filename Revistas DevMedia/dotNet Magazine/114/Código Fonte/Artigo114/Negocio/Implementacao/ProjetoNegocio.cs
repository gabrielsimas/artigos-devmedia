// -----------------------------------------------------------------------
// <copyright file="ProjetoNegocio.cs" company="CS Services Consultoria em Sistemas">
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
    /// Regrs de Negócios para os Projetos das ONGs
    /// </summary>
    public class ProjetoNegocio : NegocioGenericoAbstrato<ProjetoDto,ProjetoDao,Projeto>
    {
    }
}
