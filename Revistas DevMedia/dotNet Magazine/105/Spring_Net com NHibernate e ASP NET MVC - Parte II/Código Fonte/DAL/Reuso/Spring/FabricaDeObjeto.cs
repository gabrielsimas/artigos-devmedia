using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using DAL.Entidade;
using DAL.Persistencia;
using DAL.Persistencia.Spring;
using DAL.Reuso;
using DAL.Reuso.Spring;

namespace DAL.Reuso.Spring
{
    public static class FabricaDeObjeto
    {
       private static IApplicationContext contexto;
        public static Object ObjetoSpringNet(String nomeObjeto){

            if (contexto == null){
                contexto = ContextRegistry.GetContext();
            }
            
            return contexto.GetObject(nomeObjeto);
        
        }
    }
}
