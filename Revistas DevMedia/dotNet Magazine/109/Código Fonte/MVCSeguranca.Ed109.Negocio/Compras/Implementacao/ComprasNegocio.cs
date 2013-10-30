using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;
using MVCSeguranca.Ed109.DTO.Util;
using MVCSeguranca.Ed109.Negocio.Compras.Interface;
using MVCSeguranca.Ed109.NH.DAL.Interface;
using MVCSeguranca.Ed109.Entidade;

namespace MVCSeguranca.Ed109.Negocio.Compras.Implementacao
{
    public class ComprasNegocio: IComprasNegocio
    {
        #region Injeção de Dependências
        private IComprasDAO dao;
        public IComprasDAO Dao
        {
            get
            {
                return this.dao;
            }

            set
            {
                this.dao = value;
            }
        }

        private MVCSeguranca.Ed109.Entidade.Compras compras;
        public MVCSeguranca.Ed109.Entidade.Compras Compras
        {
            get
            {
                return this.compras;
            }

            set
            {
                this.compras = value;
            }
        }
        #endregion

        #region Regras de Negócio
        public IList<ComprasDTO> listarCompras()
        {
            try
            {
                IList<MVCSeguranca.Ed109.Entidade.Compras> compras = new List<MVCSeguranca.Ed109.Entidade.Compras>();
                IList<ComprasDTO> dto = new List<ComprasDTO>();
                compras = Dao.ListarTudo();
                RoundRobin.Copy(typeof(IList<MVCSeguranca.Ed109.Entidade.Compras>), compras, typeof(IList<ComprasDTO>), dto);
                return dto;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void cadastrarCompras(ComprasDTO dto)
        {
            
        }
        #endregion
        
    }
}
