// -----------------------------------------------------------------------
// <copyright file="ProjetoDto.cs" company="CS Services Consultoria em Sistemas">
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
    public class ProjetoDto
    {

        public Nullable<long> Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Double Custo { get; set; }

        public OngDto Ong { get; set; }

    }
}
