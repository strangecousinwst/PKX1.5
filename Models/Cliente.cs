using System.ComponentModel.DataAnnotations;

namespace PKX.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome cliente")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string? NomeCliente { get; set; }


        [Display(Name = "Texto opcional (ex.: número interno do cliente)")]
        [StringLength(50, ErrorMessage = "Máximo 50 carateres.")] 
        public string? Referencia { get; set; }


        [Display(Name = "Marcador")]
        [StringLength(10, ErrorMessage = "Máximo 10 carateres.")]
        public string? Marcador { get; set; }

        //para a entidade item:
        public virtual ICollection<Item>? Items { get; set; }


    }
}
