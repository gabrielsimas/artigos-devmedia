namespace Negocio.Interface
{
    /// <summary>
    /// Interface para A Regra de Negócios de Cadastros
    /// Princípios S.O.L.I.D. presentes
    /// ISP - Princípio da Segregação de Interfaces
    /// DIP - Princípio da Inversão de Dependências
    /// </summary>
    /// <typeparam name="DTO">Entidade como DTO</typeparam>
    public interface INegocioCadastrar<DTO> where DTO: class
    {
        bool cadastrar(DTO dto);
    }
}
