namespace Negocio.Interface
{
    using DTO;

    /// <summary>
    /// Interface para a Regra de Negócios de Projetos da Ong
    /// </summary>
    public interface IProjetoNegocio : INegocioCadastrar<ProjetoDto>, INegocioAlterar<ProjetoDto>, INegocioBuscar<ProjetoDto>, INegocioApagar<ProjetoDto>
    {    
        #region Regras Específicas

        #endregion
    }
}
