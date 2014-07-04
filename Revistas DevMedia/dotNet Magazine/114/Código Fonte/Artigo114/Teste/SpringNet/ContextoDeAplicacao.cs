// -----------------------------------------------------------------------
// <copyright file="ContextoDeAplicacao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Teste.SpringNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spring.Context;
    using Spring.Context.Support;

    using IoC.SpringNet.Dal.Interface;

    
    public class ContextoDeAplicacao<E>
    {

        #region Atributos
        #endregion

        #region Construtores

        private ContextoDeAplicacao()
        {
                
        }

        #endregion

        #region Propriedades
        public static E PegaObjeto(string objetoGerenciado)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            E service = (E)ctx.GetObject(objetoGerenciado);
            return service;
        }
        #endregion

    }
}
