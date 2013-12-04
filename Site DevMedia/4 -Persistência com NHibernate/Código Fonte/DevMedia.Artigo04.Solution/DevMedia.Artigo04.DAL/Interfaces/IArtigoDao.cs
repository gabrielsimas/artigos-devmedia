using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using DevMedia.Artigo04.Entidade;

namespace DevMedia.Artigo04.Dal.Interfaces
{
    public interface IArtigoDao : IGenericDao<Artigo>
    {
    }
}
