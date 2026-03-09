using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TarefasMauiv2.Services
{
    public class PadraoService
    {
        private HttpClient cliente;

        public PadraoService()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://10.0.2.2:5007/api/");
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T>(string end)
        {
            try
            {
                var res = await cliente.GetAsync(end);
                var ret = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }

        }
        public async Task<T> Post<T>(string end, object obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                var con = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await cliente.PostAsync(end, con);
                var ret = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(ret);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }

        }

        public async Task<T> Put<T>(string end, object obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                var con = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync(end, con);
                var ret = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default;
            }

        }

        public async Task Delete(string end)
        {
            try
            {
                var res = await cliente.DeleteAsync(end);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

}
