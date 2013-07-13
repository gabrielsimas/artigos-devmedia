using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLayer.DTO;
using BusinessLayer.Facade;
using BusinessLayer.CasoDeUso;
using Presentation.Models.Fornecedor;

namespace Presentation.Controllers
{
    public class FornecedorController : Controller {
    
        //Método da Business para Injeção de Dependências
        public IManterFornecedorFacade RegraFornecedor { get; set; }

        public ActionResult Index(){
            return View();
        }
        //
        // GET: /Fornecedor/
        public ActionResult CadastroFornecedor()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View(ListarFornecedores());
        }

        [HttpPost]
        public ActionResult CadastrarFornecedor(FornecedorModel Model)
        {
            try
            {
                if (ModelState.IsValid){
                    FornecedorDTO dto = new FornecedorDTO();
                    dto.Nome = Model.Nome;

                    //Grava os dados
                    if (RegraFornecedor.salvar(dto))
                    {
                        ViewData["Mensagem"] = "Fornecedor " + dto.Nome + " gravado com sucesso!";
                        ModelState.Clear(); //Limpa o conteúdo do Modelo/Formulário
                        if (ViewData["Fornecedores"] == null)
                        {
                            ViewData["Fornecedores"] = ListarFornecedores();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensagem"] = ex.InnerException.ToString();
                
            }
            return View("CadastroFornecedor");
        }

        public IList<FornecedorModel> ListarFornecedores()
        {
            //Lista Vazia
            IList<FornecedorModel> Model = new List<FornecedorModel>();
            try
            {
                foreach(FornecedorDTO f in RegraFornecedor.buscarTodos()){
                    FornecedorModel Item = new FornecedorModel();
                    Item.Nome = f.Nome;
                    Model.Add(Item);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = ex.InnerException.ToString();
            }

            return Model;
        }

    }
}
