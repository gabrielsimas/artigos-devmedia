using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.Negocio.Compras.Interface
{
    public interface IComprasNegocio
    {
        IList<ComprasDTO> listarCompras();
        void cadastrarCompras(ComprasDTO dto);
    }
}
