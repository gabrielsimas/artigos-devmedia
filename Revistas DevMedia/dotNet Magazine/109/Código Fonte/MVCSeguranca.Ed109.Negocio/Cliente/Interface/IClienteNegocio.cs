using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO.Util;

namespace MVCSeguranca.Ed109.Negocio.Cliente.Interface
{
    public interface IClienteNegocio
    {

        Boolean CadastraCliente(IAcessoDTO dto);

    }
}
