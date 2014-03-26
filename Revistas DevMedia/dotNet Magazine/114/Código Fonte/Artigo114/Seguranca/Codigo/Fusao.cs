namespace Seguranca.Codigo
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public sealed class Fusao
    {

        #region Constantes

        private const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.GetField;


        #endregion

        #region Construtores

        private Fusao()
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Copia todos os valores de um objeto para outro
        /// </summary>
        /// <param name="tipoOrigem">O tipo do objeto de Origem, pode ser também uma Interface.</param>
        /// <param name="objetoOrigem">O nome do objeto de Origem</param>
        /// <param name="tipoDestino">O nome do tipo de Destino/param>
        /// <param name="objetoDestino">O nome do objeto de Destino</param>
        public static void Copia(Type tipoOrigem, object objetoOrigem, Type tipoDestino, object objetoDestino)
        {
            if (tipoOrigem == null)
                throw new ArgumentNullException("tipoOrigem", "Nao pode ser nulo");

            if (objetoOrigem == null)
                throw new ArgumentNullException("objetoOrigem", "Nao pode ser nulo");

            if (tipoDestino == null)
                throw new ArgumentNullException("tipoDestino", "Nao pode ser nulo");

            if (objetoDestino == null)
                throw new ArgumentNullException("objetoDestino", "Nao pode ser nulo");
            //Não copia se for o mesmo objeto
            if (!ReferenceEquals(objetoOrigem, objetoDestino))
            {
                //Colhe todas os valores publicos em tipoDestino com getters e setters
                Dictionary<string, PropertyInfo> propsDestino = new Dictionary<string, PropertyInfo>();
                PropertyInfo[] propriedades = tipoDestino.GetProperties(flags);
                foreach (PropertyInfo propriedade in propriedades)
                {
                    propsDestino.Add(propriedade.Name, propriedade);
                }

                //Neste ponto, pega todas as propriedades públicas em tipoOrigem com Getters e Setters
                propriedades = tipoOrigem.GetProperties(flags);
                foreach (PropertyInfo propOrigem in propriedades)
                {
                    // If a propriedade matches in name and type, copy across
                    if (propsDestino.ContainsKey(propOrigem.Name))
                    {
                        PropertyInfo propDestino = propsDestino[propOrigem.Name];
                        if (propDestino.PropertyType == propOrigem.PropertyType)
                        {
                            object valor = propOrigem.GetValue(objetoOrigem, null);
                            propDestino.SetValue(objetoDestino, valor, null);
                        }
                    }
                }
            }
        }

        #endregion        
    }
}
