using System;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;

namespace DevMedia.Artigo04.NHibernate.Generico
{
   class HibernateUtil
    {
       
        #region Atributos

        private static Boolean isJaAberta;
        private static ISessionFactory fabricaDeSessao;
        private static ISession sessao;
        private static String assemblyMapeamento;
        private static String stringDeConexao;

        #endregion


        #region Singleton

        private HibernateUtil()
        {

        }

        #endregion

        

        #region Propriedades
        public static String AssemblyMapeamento{

            get
            {
                return assemblyMapeamento;
            }

            set
            {
                assemblyMapeamento = value;
            }

        }

        public static String StringDeConexao
        {
            get
            {
                return stringDeConexao;
            }

            set
            {
                stringDeConexao = value;
            }

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica se a sessão está aberta
        /// </summary>
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
                        configuracao.Properties.Add("connection.connection_string",stringDeConexao );
                        configuracao.Properties.Add("dialect", "NHibernate.Dialect.MsSql2008Dialect");
                        configuracao.Properties.Add("show_sql", "true");
                        configuracao.Properties.Add("current_session_context_class", "thread");
                        configuracao.AddAssembly(assemblyMapeamento);
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

       /// <summary>
       /// Fecha qualquer sessão aberta
       /// </summary>
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
