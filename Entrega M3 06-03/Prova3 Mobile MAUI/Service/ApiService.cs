using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Prova3_Mobile_MAUI.Service
{
    public class ApiService
    {
        private readonly HttpClient cliente;

        public ApiService()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://10.0.2.2:5008/api/");
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T>(string end)
        {
            try
            {
                var r = await cliente.GetAsync(end);
                var json = await r.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public async Task<T> Post<T>(string end, object body)
        {
            try
            {
                var json = JsonConvert.SerializeObject(body);
                var con = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await cliente.PostAsync(end, con);
                var ret = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return default;
            }
        }
        public async Task<T> Put<T>(string end, object body)
        {
            try
            {
                var json = JsonConvert.SerializeObject(body);
                var con = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync(end, con);
                var ret = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return default;
            }
        }

        public async Task<bool> Delete(string end)
        {
            try
            {
                var res = await cliente.DeleteAsync(end);
                return res.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }



    }
}
