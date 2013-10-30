using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.Negocio.Cliente.Interface;
using MVCSeguranca.Ed109.DTO;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.DTO.Util;
using MVCSeguranca.Ed109.NH.DAL.Interface;

namespace MVCSeguranca.Ed109.Negocio.Cliente.Implementacao
{
    public class ClienteNegocio: IClienteNegocio
    {
        #region Injeção de Dependências
        private IClienteDAO dao;
        private MVCSeguranca.Ed109.Entidade.Cliente cliente;

        public MVCSeguranca.Ed109.Entidade.Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        public IClienteDAO Dao {

            get
            {
                return this.dao;
            }

            set
            {
                this.dao = value;
            }
        
        }
            
        #endregion

        #region Regras de Negócio

        public Boolean CadastraCliente(ClienteDTO dto)
        {
            try
            {
                RoundRobin.Copy(typeof(ClienteDTO), dto, typeof(MVCSeguranca.Ed109.Entidade.Cliente), this.Cliente);
                dao.criar(this.Cliente);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        #endregion
        
    }
}
