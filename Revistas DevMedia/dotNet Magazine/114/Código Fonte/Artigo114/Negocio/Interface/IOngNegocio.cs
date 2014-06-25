namespace Negocio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DTO;
    using Dal.Projeto.SpringNet;
    using Entidade;

    /// <summary>
    /// Interface para a Regra de Negócios da Ong
    /// </summary>
    public interface IOngNegocio: INegocioGenerico<OngDto,OngDao,Ong>
    {
        #region Regras Específicas

        #endregion
    }
}
