// -----------------------------------------------------------------------
// <copyright file="ContatoDAO.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DevMedia.Ed112.MVCSeguranca.Dal.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DevMedia.Artigo04.NHibernate.Generico.Implementacao;
    using DevMedia.Ed112.MVCSeguranca.Entidade;

    /// <summary>
    /// Classe de Persistência para a Entidade Contato
    /// </summary>
    public class ContatoDAO : GenericDao<Contato>
    {
        public ContatoDAO()
            : base(@"DevMedia.Ed112.MVCSeguranca.NHibernate", @"Data Source=ALLSPARK\SQLEXPRESS;Initial Catalog=MVCSeguranca112;Integrated Security=True")
        {
            
        }

        #region Métodos do Domínio da Classe
        
        #endregion
    }
}
