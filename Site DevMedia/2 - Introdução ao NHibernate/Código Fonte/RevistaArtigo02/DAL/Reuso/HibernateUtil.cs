using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

namespace DAL.Reuso
{
    public class HibernateUtil
    {
            
        #region Atributos
        private static ISessionFactory fabricaDeSessao;
        private static ISession sessao;
        private static Boolean isJaAberta;
                
        #endregion

        #region Propriedades
        public static Boolean IsJaAberta {
            get { return isJaAberta; }
            set { isJaAberta = value; }
        }

        public static ISession Sessao
        {
            get
            {
                if (sessao == null){
                    
                    sessao = FabricaDeSessao.OpenSession();
                    IsJaAberta = false;
                } else if(sessao.IsOpen){
                    sessao = FabricaDeSessao.GetCurrentSession();
                    IsJaAberta = true;
                }
                return sessao;
            }
        }

        public static ISessionFactory FabricaDeSessao{
            get {

                if (fabricaDeSessao == null)
                {
                    fabricaDeSessao = new Configuration().Configure().AddAssembly("DAL").BuildSessionFactory();

                }

                return fabricaDeSessao;

            }
        }
        
        public static void fechaSessao(){
            if (sessao.IsOpen)
            {
                sessao.Close();
            }
        }

        #endregion

        #region Singleton
        private HibernateUtil()
        {
            

        }
        #endregion
    }
}
