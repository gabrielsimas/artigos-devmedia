using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Persistencia.Spring;
using BusinessLayer.Facade;
using BusinessLayer.DTO;
using DAL.Reuso;

namespace BusinessLayer.CasoDeUso
{
   public class ManterProduto : IManterProdutoFacade
    {

       public IGenericDAO<Produto> DAO { get; set; }

        public bool salvar(ProdutoDTO dto)
        {
            try
            {
                Produto produto = new Produto();

                produto.Nome = dto.Nome;
                produto.Preco = dto.Preco;
                produto.PctLucro = dto.PctLucro;

                DAO.Salvar(produto);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool editar(ProdutoDTO dto)
        {
            try
            {
                Produto produto = new Produto();

                produto.Nome = dto.Nome;
                produto.Preco = dto.Preco;
                produto.PctLucro = dto.PctLucro;

                DAO.Atualizar(produto);
                return true;
            }
            catch 
            {
                
                throw;
            }
        }

        public bool excluir(ProdutoDTO dto)
        {
            try
            {
                Produto produto = new Produto();

                produto.Nome = dto.Nome;
                produto.Preco = dto.Preco;
                produto.PctLucro = dto.PctLucro;

                DAO.Excluir(produto);
                return true;
            }
            catch
            {
                
                throw;
            }
        }

        public ProdutoDTO buscaPorId(int id)
        {
            try
            {
                ProdutoDTO dto = new ProdutoDTO();
                Produto produto = DAO.listaPorId(id);
                dto.Nome = produto.Nome;
                dto.Preco = produto.Preco;
                dto.PctLucro = produto.PctLucro;

                return dto;

            }
            catch
            {
                
                throw;
            }
        }

        public IList<ProdutoDTO> buscarTodos()
        {
            IList<ProdutoDTO> dtos = new List<ProdutoDTO>();
            
            foreach(Produto produto in DAO.listarTudo()){
                ProdutoDTO dto = new ProdutoDTO();
                dto.Nome = produto.Nome;
                dto.Preco = produto.Preco;
                dto.PctLucro = produto.PctLucro;

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
