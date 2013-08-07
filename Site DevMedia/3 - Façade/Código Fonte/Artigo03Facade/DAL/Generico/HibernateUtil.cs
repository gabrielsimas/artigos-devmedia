using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

using DAL.Entidade;

namespace DAL.Generico
{
    internal class HibernateUtil
    {
        #region Atributos

        private static Boolean isJaAberta;
        private static ISessionFactory fabricaDeSessao;
        private static ISession sessao;
                
        #endregion


        #region Singleton

        private HibernateUtil()
        {
            
        }
        #endregion

        #region Métodos

        public static Boolean IsJaAberta {
            get { return isJaAberta; }
            set { isJaAberta = value; }
        }

        public static ISession Sessao
        {
            get
            {
                if (sessao == null){

                    sessao = fabricaDeSessao.OpenSession();
                    IsJaAberta = false;
                } else if(sessao.IsOpen){
                    sessao = fabricaDeSessao.GetCurrentSession();
                    IsJaAberta = true;
                }
                return sessao;
            }
        }
        public static ISessionFactory FabricaDeSessao{
            get {

                if (fabricaDeSessao == null)
                {
                    try
                    {
                        Configuration configuracao = new Configuration();
                        configuracao.Configure();
                        configuracao.AddAssembly(typeof(Clube).Assembly);                   
                        fabricaDeSessao = configuracao.BuildSessionFactory();

                        return fabricaDeSessao;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message + "\n" + ex.InnerException);
                    }

                    
                    //fabricaDeSessao = new Configuration().Configure().AddAssembly("DAL").BuildSessionFactory();
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
    }
}
