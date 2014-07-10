namespace Negocio.Interface
{
    using DTO;

    /// <summary>
    /// Interface para a Regra de Negócios de Necessidade da Ong
    /// </summary>
    public interface INecessidadeNegocio : INegocioCadastrar<NecessidadeDto>, INegocioAlterar<NecessidadeDto>, INegocioBuscar<NecessidadeDto>, INegocioApagar<NecessidadeDto>
    {
        #region Regras Específicas

        #endregion
    }
}
