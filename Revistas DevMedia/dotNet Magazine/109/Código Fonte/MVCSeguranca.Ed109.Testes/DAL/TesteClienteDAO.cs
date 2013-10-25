using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.DAL;
using MVCSeguranca.Ed109.DAL.ControleTransacao;
using System.Data.Linq;

namespace MVCSeguranca.Ed109.Testes.DAL
{
   [TestFixture]
    public  class TesteClienteDAO
    {

       [Test]
       public void Teste_ClienteDAOInserir()
       {
           Boolean isPersisted = false;
           Cliente cliente = new Cliente();
           UnitOfWork uow = new UnitOfWork();
           Compras compra = new Compras();

           cliente.Nome = "Luis Gabriel Nascimento Simas";
           cliente.Email = "gabrielsimas@gmail.com";
           cliente.Id = null;
           cliente.IdCompras = null;
           //cliente.Compras.Add(compra);

           isPersisted = uow.ClienteDAO.salvar(cliente);
           
           /*
           if (isPersisted)
           {
               uow.gravar();
           }
            * */

           Assert.IsTrue(isPersisted);
       }
    }
}
