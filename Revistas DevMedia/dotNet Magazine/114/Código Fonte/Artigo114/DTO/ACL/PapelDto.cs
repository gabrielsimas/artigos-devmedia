// -----------------------------------------------------------------------
// <copyright file="PapelDto.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DTO.ACL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// DTO para a Entidade Papel
    /// </summary>
    public class PapelDto
    {

        public enum SimNao : int { Nao = 0, Sim = 1 }

        public Nullable<long> Id { get; set; }
        public String Nome { get; set; }
        public SimNao IsAdministrador { get; set; }

        public IList<UsuarioDto> UsuariosDto { get; set; }

    }
}
