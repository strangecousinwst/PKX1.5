namespace PKX.Models
{
    public class Movimento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public string? Descritivo { get; set; }

        public float Valor { get; set; }

        public int TipoId  { get; set; }

        public int ClienteId { get; set; }

        public string? Marcador { get; set; }

    }
}
