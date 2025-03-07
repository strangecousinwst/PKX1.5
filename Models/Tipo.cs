using System.ComponentModel.DataAnnotations;

namespace PKX.Models
{
    public class Tipo
    {
        public int Id { get; set; }

        [Display(Name = "Designação")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string? Designacao { get; set; }

        public virtual ICollection<Item>? Items { get; set; }
    }
}


