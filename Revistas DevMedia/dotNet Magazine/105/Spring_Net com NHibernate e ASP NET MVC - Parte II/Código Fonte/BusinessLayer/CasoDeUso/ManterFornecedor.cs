using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Persistencia.Spring;
using DAL.Reuso.Spring;
using DAL.Reuso;
using BusinessLayer.DTO;
using BusinessLayer.Facade;

namespace BusinessLayer.CasoDeUso
{
    public class ManterFornecedor : IManterFornecedorFacade
    {

        public IGenericDAO<Fornecedor> DAO { get; set; }

        public bool salvar(FornecedorDTO dto)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = dto.Nome;

                DAO.Salvar(fornecedor);
                
                return true;
            }
            catch
            {
                
                throw;
            }
        }

        public bool editar(FornecedorDTO dto)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = dto.Nome;

                DAO.Atualizar(fornecedor);

                return true;
            }
            catch
            {
                
                throw;
            }
        }

        public bool excluir(FornecedorDTO dto)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = dto.Nome;
                DAO.Excluir(fornecedor);
                return true;
            }
            catch
            {
                
                throw;
            }
        }

        public FornecedorDTO buscaPorId(int id)
        {
            try
            {
                FornecedorDTO dto = new FornecedorDTO();
                Fornecedor fornecedor = new Fornecedor();
                fornecedor = DAO.listaPorId(id);

                dto.Nome = fornecedor.Nome;
                return dto;

            }
            catch
            {
                
                throw;
            }
        }

        public IList<FornecedorDTO> buscarTodos()
        {
            IList<FornecedorDTO> dtos = new List<FornecedorDTO>();
            
            foreach(Fornecedor fornecedor in DAO.listarTudo()){
                FornecedorDTO dto = new FornecedorDTO();
                dto.Nome = fornecedor.Nome;
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
