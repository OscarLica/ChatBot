using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Context
{
    public class Seeder
    {
        /// <summary>
        ///     Inicializa la data
        /// </summary>
        /// <param name="_Context"></param>
        /// <param name="services"></param>
        public static void InitData(ChatBotContext _Context, IServiceProvider services)
        {

            var intent = new List<IntentsReponse> {

                new IntentsReponse
                       {
                           intent = "Saludo",
                           response = "Buenos días en que lo podemos ayudar."

                       },
                       new IntentsReponse
                       {
                           intent = "Viajar",
                           response = "Le ofremos los siguientes destinos Mexico y la India, cual le gustaría visitar."

                       },
                      new IntentsReponse
                      {
                          intent = "India",
                          response = @"Excelente elección, Te mostramos algunos lugares <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://lh5.googleusercontent.com/proxy/HvUKFCgcE3j-nlTvQycRviSCLOix1std6b-bnJBxAmHpFNrjcHZr4ldoeP-V7DEw_1Z9Z87EBhkvNFy4WpRdUqfOMtHgJBP-1TY7oPLlnqcSTfW26ct39-P-G0-osmnOH2prX_p8BHgZRRmLKoFBWFj5bamH4meuT8hlGvvXO71b=w580-h325-n-k-no' data-iml='1890.8050000027288'> <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://lh5.googleusercontent.com/proxy/6bn2U7WQEgfE58LBMvIIaz-CCP8AnGYkCPjfdYulpo8B_z2aUCmzs3x_2vBAIXieaDlB2G9B13l0UAA0bpLWlpqeLcUcFsi7djYDzP8Oo_g0pmlZvdwckHrKv9gZ34qUjG5t476vP6p2toI27hhGOlk2oBxGuPKg6E6Q9UarVP-O=w580-h325-n-k-no' data-iml='1890.8050000027288'> <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://t2.gstatic.com/images?q=tbn:ANd9GcSRGUDYEJclxKi6K_7MVWRe_rVtCILKFYEY3H5FXLnid-8F0zF0TSzPIT0Z2IYk_qTh-dxdoswYD6dWm7KdwjCKpg' data-iml='1890.8050000027288'>"

                      },
                      new IntentsReponse
                      {
                          intent = "Mexico",
                          response = @"Excelente elección, Te mostramos algunos lugares <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://lh3.googleusercontent.com/proxy/7dz5GF4qBjadkr0GyAfHL3Bxj0_GXbbvgPar32_mdsyFo4V9ayO7b27BNdv57M2NnIpenu3D3WE5QX8B-D33-pTntshie7yzD8ly0LTUYayjiRRdmxUDl_7t1wgZLSiaKneO4vPqOX04GP7qF2F4D043IIOZTUMMmKdP47JpMGR5=w336-h190-n-k-no' data-iml='1890.8050000027288'> <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://lh3.googleusercontent.com/proxy/e0yys_wUx_YpRaaBbPNQl6gUIaU9Bbt5rlmTFgZcZMJMNmtOqqp_czwGtdF13hki5bg0QyT9oGaavgiT8PTzUpNTe7ALmFiBuTsZvn6w0Y0kSEmGuWoc_QMu7-qqp6nW8Z49b2i2K8l1Zphsaz5GHJKVCExl5BwWjQkMB3N36Kl2=w336-h190-n-k-no' data-iml='1890.8050000027288'> <img class='R1Ybne YH2pd' style='width: 30%;height: 30%;display: block;' alt='' src='https://lh5.googleusercontent.com/proxy/tWZvIDM06UHVsYMMkI_10ekAMIJ4HXt_7dA4eLHVSWbXnLYgZqyxHc56DYazHPO7g-Basz6XJDRIODPRQ-c5FJsB-R8ETXYGwyG5QhifnaCGngjwGzNPjbTmzzcfnzTXAOF1ckM5UAXjbnVcGHsAY27D__se1G3IavsRHfHr7Fpr=w336-h190-n-k-no' data-iml='1890.8050000027288'>"

                      },
                       new IntentsReponse
                      {
                          intent = "Despedida",
                          response = @"Fue un gusto poder atenderle, que tenga un feliz viaje."

                      }
            };


            intent.ForEach(x =>
            {
                var i = _Context.IntentsReponse.FirstOrDefault(y => y.intent == x.intent);
                if (i is null)
                    _Context.IntentsReponse.Add(x);
                else
                    i.response = x.response;
            });

            _Context.SaveChanges();
        }
    }
}
