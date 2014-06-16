// -----------------------------------------------------------------------
// <copyright file="NecessidadeDto.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NecessidadeDto
    {

        public Nullable<long> Id { get; set; }
        public String Item { get; set; }
        public int Quantidade { get; set; }

        public OngDto Ong { get; set; }

    }
}
