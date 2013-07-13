using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using DAL.Persistencia;

namespace DAL.Util
{
    
    public class ImplementaIoC
    {
        #region Atributos

        //Método estático que irá implementar a Classe
        private static ImplementaIoC pegaContexto = new ImplementaIoC();
        private IApplicationContext contextoDI;
        private IContatoDAL dao;

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
            dao = (ContatoDAL)contextoDI.GetObject("ContatoDAL");
        }
        #endregion

        #region Propriedades

        public IApplicationContext ContextoDI
        {
            get { return contextoDI; }
        }
        //private IContatoDAL Dao;

        public static ImplementaIoC PegaContexto
        {
            get {
                             
                return pegaContexto;
            }
        }

        public IContatoDAL Dao
        {
            get { return dao; }
        }

        #endregion
    }
}
