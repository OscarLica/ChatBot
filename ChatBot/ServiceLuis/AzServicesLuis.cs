﻿using ChatBot.Context;
using ChatBot.Models;
using ChatBot.Service;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatBot.ServiceLuis
{
    public class AzServicesLuis
    {
        /// <summary>
        ///     Ocpciones de configuraciones de la app
        /// </summary>
        public IOptions<Setting> _options;

        /// <summary>
        ///     Servicio de la entidad de intents
        /// </summary>
        private IIntents ServiceIntent;

        /// <summary>
        ///     Cliente http
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="intents"></param>
        /// <param name="ChatBotContext"></param>
        public AzServicesLuis(IOptions<Setting> settings,IIntents intents, ChatBotContext ChatBotContext)
        {
            _options = settings;
            ServiceIntent = intents;
            httpClient = new HttpClient();
        }

        /// <summary>
        ///     Obtiene la intención en base al mensaje
        ///     y respondemos lo configurado en base de datos
        ///     por el intent
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<IntentsReponse> GetResponseIntent(string message) {

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _options.Value.PrimaryKey);

            var url = string.Format(
                _options.Value.FullEndpoint, 
                _options.Value.EndPoint,
                _options.Value.AppId, 
                message);

            var response = await httpClient.GetAsync(url);

            var strResponseContent = await response.Content.ReadAsStringAsync();

            var respuesta = JsonConvert.DeserializeObject<LuisServiceResponse>(strResponseContent);

            var result = ServiceIntent.FindIntent(respuesta.prediction.topIntent);
            if (result is null) return new IntentsReponse { response = ConstantMessages.NoComprendoMensaje };

            return result;
        }
    }
}
