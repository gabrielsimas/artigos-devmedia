namespace Negocio.Interface
{
    using DTO;

    /// <summary>
    /// Interface para a Regra de Negócios da Ong
    /// </summary>
    public interface IOngNegocio: INegocioCadastrar<OngDto>, INegocioAlterar<OngDto>, INegocioBuscar<OngDto>, INegocioApagar<OngDto>
    {
        #region Regras Específicas

        #endregion
    }
}
