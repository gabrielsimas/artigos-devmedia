namespace Negocio.Interface
{

    using DTO.ACL;

    public enum ForcaDeSenha
    {
        Nula = 0,
        MuitoFraca = 1,
        Fraca = 2,
        Media = 3,
        Forte = 4,
        MuitoForte = 5
    }

    /// <summary>
    /// Interface para a Regra de Negócios de Usuário
    /// </summary>
    public interface IUsuarioNegocio : INegocioCadastrar<UsuarioDto>, INegocioAlterar<UsuarioDto>, INegocioApagar<UsuarioDto>, INegocioBuscar<UsuarioDto>
    {
        #region Regras Específicas
        bool validarSenha(string senha);
        bool senhaEstaNaListNegra(string senha);
        ForcaDeSenha validaForcaDeSenha(string senha);
        int calculaPlacarDaForcaDaSenha(string senha);
        int validaTamanhoDaSenha(string senha);
        int validaMinusculaDaSenha(string senha);
        int validaMaiusculasDaSenha(string senha);
        int validaNumerosDaSenha(string senha);
        int validaCaracteresEspeciaisDaSenha(string senha);
        int calculaPlacarDaForcaDaSenha(string senha);
        #endregion
    }
}
