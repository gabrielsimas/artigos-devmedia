using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.FonteDeDados;

namespace DAL.Persistencia
{
    public class ContatoDAL: IContatoDAL
    {
        #region Atributos

        public Conexao Conexao { get; set; }

        #endregion

        #region Construtor

        public ContatoDAL(Conexao conexao)
        {
            this.Conexao = conexao;
        }

        #endregion

        #region Métodos

        public void Salvar(Contato entidade)
        {
            try
            {
                //Insere no Banco
                Conexao.Contato.InsertOnSubmit(entidade);

                //Salva as Alterações
                Conexao.SubmitChanges();
            }
            catch
            {

                throw;
            }
        }

        public List<Contato> listarTudo()
        {
            try
            {
                //É idêntico a
                //SELECT * FROM contato
                return Conexao.Contato.ToList();
            }
            catch
            {
                
                throw;
            }
        }

        public Contato listarPorId(int id)
        {
            try
            {
                //Para retornar apenas um valor
                //utilizamos a Expressao Lambda abaixo
                //que é parecida com a seguinte sintaxe SQL
                //SELECT * FROM contato
                //WHERE id = @id
                return Conexao.Contato.Where(c => c.Id == id).Single();
            }
            catch
            {
                
                throw;
            }
        }

        public void Atualizar(Contato contatoNovo)
        {
            try
            {
                //Busca na base de dados o registro antigo
                Contato contatoAntigo = listarPorId(contatoNovo.Id);

                //Atualiza os dados
                contatoAntigo.NomeCompleto = contatoNovo.NomeCompleto;
                contatoAntigo.Email = contatoNovo.Email;
                contatoAntigo.Linkedin = contatoNovo.Linkedin;
                contatoAntigo.Twitter = contatoNovo.Twitter;
                contatoAntigo.Facebook = contatoNovo.Facebook;

                //Salva
                Conexao.SubmitChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Apagar(Contato entidade)
        {
            try
            {
                Conexao.Contato.DeleteOnSubmit(entidade);
                Conexao.SubmitChanges();
            }
            catch
            {
                
                throw;
            }
        }

        #endregion
    }
}
