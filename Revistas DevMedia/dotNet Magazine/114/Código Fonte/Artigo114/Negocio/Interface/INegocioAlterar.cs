// -----------------------------------------------------------------------
// <copyright file="INegocioAlterar.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// Interface para A Regra de Negócios para Alteração
    /// Princípios S.O.L.I.D. presentes
    /// ISP - Princípio da Segregação de Interfaces
    /// DIP - Princípio da Inversão de Dependências
    /// </summary>
    /// <typeparam name="DTO">Entidade DTO</typeparam>
    public interface INegocioAlterar<DTO> where DTO: class
    {
        void alterar(DTO dto);
    }
}
