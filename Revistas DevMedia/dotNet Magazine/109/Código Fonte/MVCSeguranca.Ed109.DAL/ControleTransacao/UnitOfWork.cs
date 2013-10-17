using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DAL.DataSource;
using MVCSeguranca.Ed109.DAL.Persistencia;
using MVCSeguranca.Ed109.Generic.Interface;
using MVCSeguranca.Ed109.Generic.Implementacao;

namespace MVCSeguranca.Ed109.DAL.ControleTransacao
{
    public class UnitOfWork : IDisposable
    {
        #region Atributos

        private Conexao conexao = new Conexao();

        private UsuarioDAO usuarioDAO;
        private PerfilDAO perfilDAO;
        private ClienteDAO clienteDAO;
        private ComprasDAO comprasDAO;

        private bool disposed = false;

        #endregion

        #region Propriedades

        public UsuarioDAO UsuarioDAO
        {
            get
            {
                if (this.usuarioDAO == null){
                    this.usuarioDAO = new UsuarioDAO(conexao);
                }

                return this.usuarioDAO;
            }
        }

        public PerfilDAO PerfilDAO {

            get
            {
                if (this.perfilDAO == null){
                    this.perfilDAO = new PerfilDAO(conexao);
                }

                return this.perfilDAO;
            }
        }

        public ClienteDAO ClienteDAO
        {
            get
            {
                if (this.clienteDAO == null){
                    this.clienteDAO = new ClienteDAO(conexao);
                }

                return this.clienteDAO;
            }
        }

        public ComprasDAO ComprasDAO
        {
            get
            {
                if (this.comprasDAO == null){
                    this.comprasDAO = new ComprasDAO(conexao);
                }

                return this.comprasDAO;
            }
        }

        #endregion

        #region Transações

        public void gravar()
        {
            conexao.SubmitChanges();
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   this.conexao.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
