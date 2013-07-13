using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using BLL.Negocio;

namespace Web.Utilitarios
{
    
    public class ImplementaIoC
    {
        #region Atributos

        //Método estático que irá implementar a Classe
        private static ImplementaIoC pegaContexto = new ImplementaIoC();
        private IApplicationContext contextoDI;
        private IManterContato bll;

        #endregion

        #region Propriedades

        public IManterContato Bll
        {
            get { return bll; }
        }

        public IApplicationContext ContextoDI
        {
            get { return contextoDI; }
        }

        public static ImplementaIoC PegaContexto
        {
            get
            {
                return pegaContexto;
            }
        }

        #endregion

        #region Construtor

        /// <summary>
        ///Construtor privado (Singleton) contendo a execução da Injeção de Dependência
        ///para dentro da Classe DAO
        /// </summary>
        /// <param name="txtObjeto">Nome do Objeto para DI do arquivo App.Config.xml</param>
        private ImplementaIoC()
        {
            contextoDI = ContextRegistry.GetContext();
            bll = (ManterContato)contextoDI.GetObject("ManterContato");
        }
        #endregion
    }
}
