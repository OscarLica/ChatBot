using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Service
{
    /// <summary>
    ///     Interfaz de intenst
    /// </summary>
    public interface IIntents
    {
        /// <summary>
        ///     Méetodo que consulta una intención
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        IntentsReponse FindIntent(string intent);
    }
}
