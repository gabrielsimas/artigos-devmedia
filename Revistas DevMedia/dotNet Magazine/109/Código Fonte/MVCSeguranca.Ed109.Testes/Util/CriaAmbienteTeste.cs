using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using System.Configuration;
using MVCSeguranca.Ed109.DAL.DataSource;

namespace MVCSeguranca.Ed109.Testes.Util
{
    [SetUpFixture]
    public class CriaAmbienteTeste
    {
        #region Atributos

        private Conexao conexao;

        #endregion

        #region Propriedades

        public Conexao Conexao {
            get
            {
                return this.conexao;
            }

            set
            {
                this.conexao = value;
            }
        }
            
        #endregion

        

        #region Métodos SetUp e TearDown
        [SetUp]
        public void criaConnectionString()
        {

            Configuration configuracao = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Criando o elemento da ConnectionString no arquivo de configuração
            ConnectionStringSettings connectionStringSettings = new
            ConnectionStringSettings(
            "MVCSeguranca_BASE",
            "Data Source=ALLSPARK\\SQLEXPRESS;Initial Catalog=MVCSeguranca;Integrated Security=True",
            "System.Data.Linq"
            );

            //Acessa a seção de Strings de Conexão
            ConnectionStringsSection connectionStringsSection = configuracao.ConnectionStrings;

            //Adiciona o novo elemento criado
            connectionStringsSection.ConnectionStrings.Clear();
            connectionStringsSection.ConnectionStrings.Add(connectionStringSettings);

            configuracao.Save(ConfigurationSaveMode.Modified);

            //Linha muito importante, grava no arquivo e o executa
            ConfigurationManager.RefreshSection(connectionStringsSection.SectionInformation.Name);


            if (this.conexao == null)
            {
                this.conexao = new Conexao();
            }
        }

        [TearDown]
        public void Destrutor()
        {
            if (this.conexao !=null ){
                this.conexao.Dispose();
            }
        }
        #endregion
        
    }
}
