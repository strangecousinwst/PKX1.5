namespace PKX.Models
{
    public class Tempo
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? Descritivo {  get; set; }
        public int Minutos { get; set; }
        public int AtividadeId {  get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        
    }
}
