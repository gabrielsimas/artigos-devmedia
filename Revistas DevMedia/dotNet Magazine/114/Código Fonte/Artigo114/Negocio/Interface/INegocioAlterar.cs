namespace Negocio.Interface
{

    /// <summary>
    /// Interface para A Regra de Negócios para Alteração
    /// Princípios S.O.L.I.D. presentes
    /// ISP - Princípio da Segregação de Interfaces
    /// DIP - Princípio da Inversão de Dependências
    /// </summary>
    /// <typeparam name="DTO">Entidade DTO</typeparam>
    public interface INegocioAlterar<DTO> where DTO: class
    {
        bool alterar(DTO dto);
    }
}
