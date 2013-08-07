using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

namespace DAL.Reuso
{
    public sealed class NHibernateUtil
    {
        #region Atributos

        private static readonly ISessionFactory fabricaDeSessao;
        private const String CodSessaoAtual = "nhibernate.current_session";

        #endregion

        #region Construtor

        static NHibernateUtil()
        {
            try
            {
                ISessionFactory fabrica = new Configuration().Configure().AddAssembly("DAL").BuildSessionFactory();
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

        #region Métodos de Controle

        public static ISession PegaSessaoEmUso()
        {
            ISession sessao = fabricaDeSessao.GetCurrentSession();

            if (sessao == null)
            {
                sessao = fabricaDeSessao.OpenSession();
            }

            return sessao;  
        }

        public static void FecharSessao()
        {
            ISession sessao = fabricaDeSessao.GetCurrentSession();

            if (sessao != null)
            {
                sessao.Close();
            }
        }

        public static void FecharFabricaDeSessao()
        {
            if (fabricaDeSessao != null || !fabricaDeSessao.IsClosed){
                fabricaDeSessao.Close();
            }
        }

        #endregion

    }
}
