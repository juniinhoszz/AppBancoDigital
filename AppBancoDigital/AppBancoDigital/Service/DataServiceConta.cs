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
        public static async Task<Conta> GetContaByIdCorrentista(int? id)
        {
            var json_to_send = JsonConvert.SerializeObject(id);

            string json = await DataService.PostDataToService(json_to_send, "/conta/vercontas");

            return JsonConvert.DeserializeObject<Conta>(json);
        }
    }
}
