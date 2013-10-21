using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using MVCSeguranca.Ed109.DAL;
using MVCSeguranca.Ed109.DAL.DataSource;
using MVCSeguranca.Ed109.DAL.Persistencia;
using MVCSeguranca.Ed109.DAL.ControleTransacao;
using System.Data.Common;
using System.Configuration;
using System.Diagnostics;

namespace MVCSeguranca.Ed109.Testes.DAL
{   
    [TestFixture]
    public class TesteDAL
    {

        [SetUp]
        public void CriaConnectionString()
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
        }

        [Test]
        public void Teste_Integracao()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void Testa_ConnectionStrings()
        {
            Assert.IsTrue(ConfigurationManager.ConnectionStrings.Count > 0);
        }

        [Test]
        public void Testa_ConexaoBanco()
        {
            Conexao conexao = new Conexao();
            Assert.IsTrue(true);
        }

    }
}
