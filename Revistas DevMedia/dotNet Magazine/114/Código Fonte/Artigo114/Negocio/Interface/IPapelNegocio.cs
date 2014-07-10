namespace Negocio.Interface
{
    using DTO.ACL;
    /// <summary>
    /// Interface para a Regra de Negócios para Papel
    /// </summary>
    public interface IPapelNegocio: INegocioCadastrar<PapelDto>, INegocioAlterar<PapelDto>, INegocioBuscar<PapelDto>, INegocioApagar<PapelDto>
    {
        #region Regras Específicas

        #endregion
    }
}
