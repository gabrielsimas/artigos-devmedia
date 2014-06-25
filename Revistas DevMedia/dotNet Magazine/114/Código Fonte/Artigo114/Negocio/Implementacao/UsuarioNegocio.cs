// -----------------------------------------------------------------------
// <copyright file="UsuarioNegocio.cs" company="CS Services Consultoria em Sistemas">
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
    using Dal.Projeto.SpringNet;

    /// <summary>
    /// Regra de Negócios para os Usuários do Sistema
    /// </summary>
    public class UsuarioNegocio: NegocioGenericoAbstrato<UsuarioDto,UsuarioDao,Usuario>
    {
    }
}
