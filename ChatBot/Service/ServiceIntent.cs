using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatBot.Context;
using ChatBot.Models;

namespace ChatBot.Service
{
    public class ServiceIntent : IIntents
    {
        /// <summary>
        ///     Context de base de datos
        /// </summary>
        private readonly ChatBotContext _context;

        /// <summary>
        ///     Constructuro base inicializa el contexto de base de datos
        /// </summary>
        /// <param name="context"></param>
        public ServiceIntent(ChatBotContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Optione una intención por el intent
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        public IntentsReponse FindIntent(string intent)
        {
            return _context.IntentsReponse.FirstOrDefault( x => x.intent == intent);
        }
    }
}
