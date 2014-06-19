// -----------------------------------------------------------------------
// <copyright file="NHibernateUtils.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Orm.Nhibernate.Dal.Implementacao
{
    using System;
    using NHibernate;
    using NHibernate.Cfg;

    /// <summary>
    /// Classe para gerencimento de Persistência do NHibernate
    /// </summary>
    public class NHibernateUtils
    {

        #region Atributos

        private static Boolean isJaAberta;
        private static ISessionFactory fabricaDeSessao;
        private static ISession sessao;
        private const String ASSEMBLYMAPEAMENTOS = "ArtigoSecurity.Dal.Projeto";
        private const String STRINGCONEXAO = @"Data Source=ALLSPARK\SQLEXPRESS;Initial Catalog=OWASPNIST;Integrated Security=True;Persist Security Info=True;Asynchronous Processing=True;MultipleActiveResultSets=True";

        #endregion


        #region Singleton

        private NHibernateUtils()
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
                        
                        configuracao.Properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                        configuracao.Properties.Add("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                        configuracao.Properties.Add("connection.connection_string", STRINGCONEXAO);
                        configuracao.Properties.Add("dialect", "NHibernate.Dialect.MsSql2008Dialect");
                        configuracao.Properties.Add("show_sql", "true");
                        configuracao.Properties.Add("current_session_context_class", "thread");
                        configuracao.Properties.Add("adonet.batch_size","100");
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
            NHibernateUtils.fechaSessao();
        }

        #endregion

    }
}
