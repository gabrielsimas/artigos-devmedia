namespace Negocio.Interface
{
    /// <summary>
    /// Interface para A Regra de Negócios de Exclusão em objetos de Negócios
    /// Princípios S.O.L.I.D. presentes
    /// ISP - Princípio da Segregação de Interfaces
    /// DIP - Princípio da Inversão de Dependências
    /// </summary>
    /// <typeparam name="DTO">Entidade DTO</typeparam>
    public interface INegocioApagar<DTO>
    {
        bool apagar(DTO dto);
    }
}
