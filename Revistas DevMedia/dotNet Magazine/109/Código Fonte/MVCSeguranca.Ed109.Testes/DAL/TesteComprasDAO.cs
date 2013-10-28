using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.Testes.Util;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.NH.DAL.Interface;


namespace MVCSeguranca.Ed109.Testes.DAL
{
    public class TesteComprasDAO : AbstractSpringTeste
    {
        #region Atributos
        private IComprasDAO comprasDAO;
        private IClienteDAO clienteDAO;
        private Compras compras;
        private Cliente cliente;
        #endregion

        #region Propriedades
        public IComprasDAO ComprasDAO { get; set; }
        public IClienteDAO ClienteDAO { get; set; }
        public Compras Compras { get; set; }
        public Cliente Cliente { get; set; }
        #endregion

        #region Testes Unitários
        #endregion

        [Test]
        public void Teste_Integracao()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void Teste_Compras_Inserir()
        {
            Cliente = ClienteDAO.listarPorId(10);
            Compras.Cliente = Cliente;

            Compras.Total = 15000;

            ComprasDAO.criar(Compras);

            Assert.IsTrue(ComprasDAO.ehSucesso());
        }

        [Test]
        public void Teste_Compras_Editar()
        {

        }

    }
}
