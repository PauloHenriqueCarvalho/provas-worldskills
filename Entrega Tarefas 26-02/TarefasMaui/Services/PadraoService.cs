using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TarefasMaui.Helpers;
using TarefasMaui.Models;

namespace TarefasMaui.Services
{
    public class PadraoService
    {
        private HttpClient c;

        public PadraoService()
        {
            c = new HttpClient();
            c.BaseAddress = new Uri("http://10.0.2.2:5291/api/");
            c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public class LoginDTO
        {
            public string Login { get; set; }
            public string Senha { get; set; }

        }
        public class CreateUserDTO
        {
            public string Login { get; set; }
            public string Senha { get; set; }
            public string Nome { get; set; }

        }

        public async Task<Status> CreateStatus(Status dto)
        {
            var u = JsonConvert.SerializeObject(dto);
            var con = new StringContent(u, Encoding.UTF8, "application/json");
            var res = await c.PostAsync("Status", con);
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Status>(json);
        }

        public class UserUpdateStatusDTO
        {
            public int IdTarefa { get; set; }
            public int IdStatus { get; set; }

        }
        public async Task<Tarefa> AtualizarStatusTarefa(int idTarefa, int statusId)
        {
            try
            {
                var u = JsonConvert.SerializeObject(new UserUpdateStatusDTO { IdStatus = statusId, IdTarefa = idTarefa });
                var con = new StringContent(u, Encoding.UTF8, "application/json");

                // Verifique se a URL está correta e se a API está de pé
                var res = await c.PutAsync("Tarefas/update-status", con);

                if (!res.IsSuccessStatusCode)
                {
                    var erro = await res.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na API: {res.StatusCode} - {erro}"); // Verifique a aba 'Output' do Visual Studio
                    return null;
                }

                var json = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tarefa>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção crítica: {ex.Message}");
                return null;
            }
        }



        public async Task<Usuarios> Login(LoginDTO dto)
        {
            var u = JsonConvert.SerializeObject(dto);
            var con = new StringContent(u, Encoding.UTF8, "application/json");
            try
            {
                var res = await c.PostAsync("User/Login", con);
                if (!res.IsSuccessStatusCode)
                    return null;

                var json = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuarios>(json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }

        }

        public async Task<Usuarios> CadastrarUsuario(CreateUserDTO dto)
        {
            var u = JsonConvert.SerializeObject(dto);
            var con = new StringContent(u, Encoding.UTF8, "application/json");
            var res = await c.PostAsync("User", con);
            if (!res.IsSuccessStatusCode)
                return null;
            else if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuarios>(json);
        }

        public class CreateTarefasDTO
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public int UsuarioRemetente { get; set; }
            public int UsuarioDestinatario { get; set; }
            public DateTime DataVencimento { get; set; }
            public int Status { get; set; }


        }

        public async Task<Tarefa> CadastrarTarefas(CreateTarefasDTO dto)
        {
            var u = JsonConvert.SerializeObject(dto);
            var con = new StringContent(u, Encoding.UTF8, "application/json");
            var res = await c.PostAsync("Tarefas", con);
            if (!res.IsSuccessStatusCode)
                return null;
            else if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tarefa>(json);
        }

        public async Task AlterarTarefa(CreateTarefasDTO dto, int id)
        {
            var u = JsonConvert.SerializeObject(dto);
            var con = new StringContent(u, Encoding.UTF8, "application/json");
            var res = await c.PutAsync($"Tarefas/{id}", con);
       
            
        }



        public async Task<List<Tarefa>> GetTarefas()
        {
            var res = await c.GetAsync($"Tarefas/{Global.user.Id}");
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Tarefa>>(json);
        }
        public async Task<List<Tarefa>> GetTarefasAtribuidas()
        {
            var res = await c.GetAsync($"Tarefas/Enviadas/{Global.user.Id}");
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Tarefa>>(json);
        }

        public async Task<Tarefa> GetTarefasUma(int id)
        {
            var res = await c.GetAsync($"Tarefas/Get/{id}");
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tarefa>(json);
        }


        public async Task<List<Status>> GetStatus()
        {
            var res = await c.GetAsync($"Status");
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Status>>(json);
        }
        public async Task DeletarTarefa(int id)
        {
            var res = await c.DeleteAsync($"Tarefas/{id}");
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao excluir tarefa.");
            }
        }
        public async Task DeletarStatus(int id)
        {
            var res = await c.DeleteAsync($"Status/{id}");
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Existe tarefas com esse status!");
            }
        }
        public async Task<List<Usuarios>> GetUsuarios()
        {
            var res = await c.GetAsync($"User");
            if (!res.IsSuccessStatusCode)
                return null;

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Usuarios>>(json);
        }

    }
}
