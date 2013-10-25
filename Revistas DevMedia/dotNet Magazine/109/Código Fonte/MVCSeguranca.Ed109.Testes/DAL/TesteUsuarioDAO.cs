using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.DAL.ControleTransacao;
using MVCSeguranca.Ed109.Entidade;

namespace MVCSeguranca.Ed109.Testes.DAL
{
    [TestFixture]
    public class TesteUsuarioDAO
    {

        [Test]
        public void Teste_Inserir()
        {
            Usuario usuario = new Usuario();
            UnitOfWork uow = new UnitOfWork();

            //uow.UsuarioDAO.salvar(usuario);
            
        }

    }
}
