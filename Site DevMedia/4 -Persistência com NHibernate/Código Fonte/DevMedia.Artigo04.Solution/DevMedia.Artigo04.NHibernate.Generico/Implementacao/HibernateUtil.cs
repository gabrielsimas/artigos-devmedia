using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace DevMedia.Artigo04.NHibernate.Generico
{
   public class HibernateUtil
    {

        #region Atributos

        private static Boolean isJaAberta;
        private static ISessionFactory fabricaDeSessao;
        private static ISession sessao;
        private const String ASSEMBLYMAPEAMENTOS = "DevMedia.Artigo04.Da";
        private const String STRINGCONEXAO = @"Data Source=ALLSPARK\SQLEXPRESS;Initial Catalog=Artigo04;Integrated Security=True";

        #endregion


        #region Singleton

        private HibernateUtil()
        {

        }
        #endregion

        #region Métodos

        public static Boolean IsJaAberta
        {
            get { return isJaAberta; }
            set { isJaAberta = value; }
        }

        public static ISession Sessao
        {
            get
            {
                if (sessao == null)
                {

                    sessao = fabricaDeSessao.OpenSession();
                    IsJaAberta = false;
                }
                else if (sessao.IsOpen)
                {
                    sessao = fabricaDeSessao.GetCurrentSession();
                    IsJaAberta = true;
                }
                else
                {
                    sessao = fabricaDeSessao.OpenSession();
                    IsJaAberta = false;
                }
                return sessao;
            }
        }
        public static ISessionFactory FabricaDeSessao
        {
            get
            {

                if (fabricaDeSessao == null)
                {
                    try
                    {
                        Configuration configuracao = new Configuration();
                        //configuracao.Configure();
                        configuracao.Properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                        configuracao.Properties.Add("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                        configuracao.Properties.Add("connection.connection_string", STRINGCONEXAO);
                        configuracao.Properties.Add("dialect", "NHibernate.Dialect.MsSql2008Dialect");
                        configuracao.Properties.Add("show_sql", "true");
                        configuracao.Properties.Add("current_session_context_class", "thread");
                        configuracao.AddAssembly(ASSEMBLYMAPEAMENTOS);
                        fabricaDeSessao = configuracao.BuildSessionFactory();

                        return fabricaDeSessao;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message + "\n" + ex.InnerException);
                    }

                }

                return fabricaDeSessao;
            }
        }

        public static void fechaSessao()
        {
            if (sessao != null){
                if (sessao.IsOpen)
                {
                    sessao.Close();
                }
            }
            
        }

        public void Dispose()
        {
            HibernateUtil.fechaSessao();
        }

        #endregion

    }
}
