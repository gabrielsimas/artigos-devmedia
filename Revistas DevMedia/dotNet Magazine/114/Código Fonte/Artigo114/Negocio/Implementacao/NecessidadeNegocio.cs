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
    /// Regra de Negócios para Necessidades de uma Ong
    /// </summary>
    public class NecessidadeNegocio : NegocioGenericoAbstrato<NecessidadeDto,NecessidadeDao,Necessidade>, INecessidadeNegocio
    {

    }
}
