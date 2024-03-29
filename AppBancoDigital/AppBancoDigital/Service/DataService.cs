﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppBancoDigital.Service
{
    public class DataService
    {
        private static readonly string server = "http://10.0.2.2:8000";
        public string DadosContaCorrentista = "";

        //Método que busca os Dados de um Serviço
        protected static async Task<string> GetDataFromService(string rota)
        {
            string json_response;

            string uri = server + rota;

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                throw new Exception("Por favor, conecte-se à Internet.");
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                Console.WriteLine("_____________________________");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("_______________________________");

                if (response.IsSuccessStatusCode)
                {
                    json_response = response.Content.ReadAsStringAsync().Result;
                }
                else
                    throw new Exception(DecodeServerError(response.StatusCode));
            }

            return json_response;
        }

        //Método que envia os dados para o servidor via post
        protected static async Task<string> PostDataToService(string json_object, string rota)
        {
            string json_response;

            string uri = server + rota;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new Exception("Por favor, conecte-se à Internet.");
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(
                    uri,
                    new StringContent(json_object, Encoding.UTF8, "application/json")
                );

                Console.WriteLine("DADOS_______________________________");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("_______________________________");

                if (response.IsSuccessStatusCode)
                {
                    json_response = response.Content.ReadAsStringAsync().Result;
                }
                else
                    throw new Exception(DecodeServerError(response.StatusCode));
            }

            return json_response;
        }



        //Método que decodifica os erros do servidor
        private static string DecodeServerError(System.Net.HttpStatusCode status_code)
        {
            string msg_erro;

            switch (status_code)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    msg_erro = "A requisição não pode ser atendida agora. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.NotFound:
                    msg_erro = "Recurso indisponível no momento. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.InternalServerError:
                    msg_erro = "Nosso banco de dados está indisponível. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.RequestTimeout:
                    msg_erro = "O servidor está demorando muito para responder. Tente novamente.";
                    break;

                case System.Net.HttpStatusCode.Forbidden:
                    msg_erro = "Recurso temporariamente indisponível. Tente mais tarde.";
                    break;

                default:
                    msg_erro = "Estamos com dificuldades para acessar nosso servidor, tente novamente.";
                    break;
            }

            return msg_erro;
        }
    }
}
