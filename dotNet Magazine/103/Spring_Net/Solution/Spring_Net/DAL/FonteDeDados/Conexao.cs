using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using DAL.Entidade;

namespace DAL.FonteDeDados
{   
    [Database] //Mapeia a Classe para conexão com o BD
    public class Conexao: DataContext
    {
        #region Construtor
        //Digitando ctor e pressionando a tecla TAB  duas vezes
        //O Visual Studio cria um construtor padrão
        //Neste construtor, chamamos o construtor da Classe Pai
        //neste caso DataContext para registrar a ConnectionString existente
        //em nosso arquivo App.Config
        public Conexao():base(ConfigurationManager.ConnectionStrings["contatoDB"].ConnectionString) 
        {

        }
        #endregion

        #region Registrar Classes de Persistência
        //Registra as Classes que refletem as Tabelas de Banco de Dados
        //E nela selecionam como tipo, o nome da Classe de Persistência.
        //Neste caso, criamo um método chamado Contato tendo como Tipo
        //a Classe Genérica Table contendo a Classe DAL.Entidade.Contato
        public Table<Contato> Contato;
        #endregion
    }
}
