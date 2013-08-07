using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using NHibernate;

namespace DAL.Reuso
{
    public class NHibernateDAO
    {

        public void Gravar(Carro carro)
        {
            ISession sessao = NHibernateUtil.PegaSessaoEmUso();
            ITransaction transacao = sessao.BeginTransaction();

            sessao.Save(carro);
            transacao.Commit();

            NHibernateUtil.FecharSessao();
        }

    }
}
