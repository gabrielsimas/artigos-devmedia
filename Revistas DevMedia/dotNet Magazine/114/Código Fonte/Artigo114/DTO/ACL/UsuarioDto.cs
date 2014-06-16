// -----------------------------------------------------------------------
// <copyright file="UsuarioDto.cs" company="CS Services Consultoria em Sistemas">
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
    /// Dto para a entidade Usuario
    /// </summary>
    public class UsuarioDto
    {

        public Nullable<long> Id { get; set; }
        public String NomeCompleto { get; set; }
        public String Apelido { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String PerguntaSecreta { get; set; }
        public String RespostaSecreta { get; set; }
        public String Email { get; set; }

        public PapelDto Papel { get; set; }

    }
}
