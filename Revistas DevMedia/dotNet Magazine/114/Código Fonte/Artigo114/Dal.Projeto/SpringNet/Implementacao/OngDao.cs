﻿// -----------------------------------------------------------------------
// <copyright file="OngDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dal.Projeto.SpringNet.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using IoC.SpringNet.Dal.Implementacao;
    using Dal.Projeto.SpringNet.Interface;
    using Entidade;

    /// <summary>
    /// Objeto de Acesso a Dados para Persistência da Entidade Ong
    /// </summary>
    public class OngDao : GenericSpringNetDao<Ong>, IOngDao
    {
    }
}
