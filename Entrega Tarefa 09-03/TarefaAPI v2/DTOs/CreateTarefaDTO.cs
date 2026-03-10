namespace TarefaAPI_v2.DTOs
{
    public class CreateTarefaDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int BoardId { get; set; }
        public int ColunaId { get; set; }
        public int UsuarioCriadorId { get; set; }
        public int UsuarioDestinoId { get; set; }

    }
}
