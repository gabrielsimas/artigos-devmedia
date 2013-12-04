using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Negocio.RegraDeNegocio.Interface
{
    //internal = visível apenas dentro do seu próprio Assembly
    //E = classes DTO
    //TODO: tentar colocar as constraints como DTOs
    internal interface INegocioGenerico<E> where E: class
    {
        //Aqui já começamos o uso dos DTOs
        Boolean cadastrar(E entidadeDTO);
        E listarPorId(Nullable<long> id);
        IList<E> listaTudo();
        Boolean editar(E entidadeDTO);
        Boolean excluir(E entidadeDTO);
    }
}
