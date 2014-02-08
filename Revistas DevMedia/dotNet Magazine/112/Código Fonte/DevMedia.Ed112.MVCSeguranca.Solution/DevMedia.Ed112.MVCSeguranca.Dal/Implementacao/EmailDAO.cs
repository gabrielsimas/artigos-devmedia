// -----------------------------------------------------------------------
// <copyright file="EmailDAO.cs" company="CS Services Consultoria em Sistemas">
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
    /// TODO: Update summary.
    /// </summary>
    public class EmailDAO: GenericDao<Email>
    {
        public EmailDAO()
            : base(@"DevMedia.Ed112.MVCSeguranca.NHibernate", @"Data Source=ALLSPARK\SQLEXPRESS;Initial Catalog=MVCSeguranca112;Integrated Security=True")
        {

        }

    }
}
