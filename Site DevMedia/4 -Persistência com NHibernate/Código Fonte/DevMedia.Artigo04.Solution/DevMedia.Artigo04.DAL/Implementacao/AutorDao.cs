using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.NHibernate.Generico.Implementacao;
using DevMedia.Artigo04.Entidade;
using DevMedia.Artigo04.Dal.Interfaces;

namespace DevMedia.Artigo04.Dal.Implementacao
{
    public class AutorDao : GenericDao<Autor>, IAutorDao
    {
    }
}
