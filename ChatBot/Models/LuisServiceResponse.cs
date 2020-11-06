using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Models
{
    public class LuisServiceResponse
    {
        /// <summary>
        ///     Consulta 
        /// </summary>
        public string query { get; set; }

        /// <summary>
        ///     Predicción
        /// </summary>
        public Prediction prediction { get; set; }


        public class Sentiment
        {
            public string label { get; set; }
            public double score { get; set; }
        }

        public class Prediction
        {
            public string topIntent { get; set; }
            public Sentiment sentiment { get; set; }
        }
    }
}
