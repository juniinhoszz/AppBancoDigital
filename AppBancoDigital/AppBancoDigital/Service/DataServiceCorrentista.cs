using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        /**
         * Realiza o login do correntista.
         */
        public static async Task<Correntista> LoginAsync(Correntista c)
        {
            var json_to_send = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_to_send, "/correntista/login");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }

        //Envia um Model em forma de JSON pra insert no banco.
        public static async Task<Correntista> CadastrarCorrentistas(Correntista c)
        {
            var json_to_send = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_to_send, "/correntista/save");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }
    }

    /**
    
         //Obtém a lista de correntistas
    public static async Task<List<Correntista>> GetCorrentistasAsync()
    {
        string json = await DataService.GetDataFromService("/correntista");

        List<Correntista> arr_correntista = JsonConvert.DeserializeObject<List<Correntista>>(json);

        return arr_correntista;
    }
    
        //Deleta uma pessoa do banco de dados.
    public static async Task<List<Correntista>> DeleteAsync(int id)
    {
        var json_a_enviar = JsonConvert.SerializeObject(id);

        string json = await DataService.PostDataToService(json_a_enviar, "/correntista/delete");

        List<Correntista> arr_correntista = JsonConvert.DeserializeObject<List<Correntista>>(json);

        return arr_correntista;
    }

    */
}
