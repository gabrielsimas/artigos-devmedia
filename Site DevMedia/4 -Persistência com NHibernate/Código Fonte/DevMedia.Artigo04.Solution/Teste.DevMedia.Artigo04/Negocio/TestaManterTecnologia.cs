using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.Negocio.RegraDeNegocio.Implementacao;
using DevMedia.Artigo04.Dto;
using NUnit.Framework;

namespace Teste.DevMedia.Artigo04.Negocio
{
    //[TestFixture]
    public class TestaManterTecnologia
    {
        //[Test]
        public void ListarTodos(){

            IList<TecnologiaDto> dtos = new List<TecnologiaDto>();
            ManterTecnologia negocio = new ManterTecnologia();
            dtos = negocio.listaTudo();

            Assert.IsTrue(dtos.Count > 0);

        }

        //[Test]
        public void Cadastrar()
        {
            TecnologiaDto dto = new TecnologiaDto();
            dto.Nome = "Java";

            ManterTecnologia negocio = new ManterTecnologia();
            negocio.cadastrar(dto);

            Assert.IsTrue(dto.Id.HasValue);
        }
    }
}
