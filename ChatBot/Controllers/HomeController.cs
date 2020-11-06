using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChatBot.Models;
using Microsoft.Extensions.Options;
using ChatBot.Service;
using ChatBot.ServiceLuis;
using ChatBot.Context;

namespace ChatBot.Controllers
{
    public class HomeController : Controller
    {
        
        /// <summary>
        ///     Configuraciones de la aplicación
        /// </summary>
        public IOptions<Setting> _Settings;

        /// <summary>
        ///     Servicio de intenciones
        /// </summary>
        public IIntents _Intents;

        /// <summary>
        ///     Servicio de que consume el endpoint de azure luis
        /// </summary>
        public AzServicesLuis azServicesLuis;


        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="Settings"></param>
        /// <param name="Intents"></param>
        /// <param name="ChatBotContext"></param>
        public HomeController(
            IOptions<Setting> Settings, IIntents Intents, ChatBotContext ChatBotContext)
        {
            _Settings = Settings;
            _Intents = Intents;
            azServicesLuis = new AzServicesLuis(_Settings,Intents,ChatBotContext);
        }

        /// <summary>
        ///     Vista princiapl home
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Consume el endpoint de azure luis 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet("/Home/GetIntent/{message}")]
        public async Task<JsonResult> GetIntent(string message)
        {
            var result = await azServicesLuis.GetResponseIntent(message);
            return Json(result);
        }
        
    }
}
