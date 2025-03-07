using System.ComponentModel.DataAnnotations;

namespace PKX.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Display(Name = "#Cli")]
        public int ClienteId { get; set; }
        public virtual Cliente? ClienteVirtual { get; set; }

        [Display(Name = "#Tipo")]
        public int TipoId { get; set; }
        public virtual Tipo? TipoVirtual { get; set; }


        [Display(Name = "Item 1")]
        public string? Item1 { get; set; }

        [Display(Name = "Item 2")]
        public string? Item2 { get; set; }

        [Display(Name = "Texto complementar opcional")]
        public string? Texto { get; set; }


    }
}
