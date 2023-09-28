using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceConta : DataService
    {
        public static async Task<Conta> GetContaByTipoeIdCorrentista(Conta co)
        {
            var json_to_send = JsonConvert.SerializeObject(co);

            string json = await DataService.PostDataToService(json_to_send, "/conta/vercontabytipoeid");

            return JsonConvert.DeserializeObject<Conta>(json);
        }

        public static async Task<Conta> CriarPoupanca(int? id)
        {
            var json_to_send = JsonConvert.SerializeObject(id);

            string json = await DataService.PostDataToService(json_to_send, "/conta/criarpoupanca");

            return JsonConvert.DeserializeObject<Conta>(json);
        }
    }
}
