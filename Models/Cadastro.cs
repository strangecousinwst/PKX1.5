using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX.Models
{
    public class Cadastro
    {
        public int Id { get; set; }

        [Display(Name = "Data da reunião")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Descritivo")]
        public string? Texto { get; set; }

        // chave estrangeira para Cliente:
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

    }
}




//2023:
//[Display(Name = "Data da reunião")]
//[DataType(DataType.Date)]
//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//public DateTime DataRegisto { get; set; }

//public string? Descritivo { get; set; }

//public int ClienteId { get; set; }
//public virtual Cliente? Cliente { get; set; }
//public int FuncionarioId { get; set; }
//public virtual Funcionario? Funcionario { get; set; }