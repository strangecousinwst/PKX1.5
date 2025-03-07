using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX.Models
{
    public class Processo
    {
        //para a tabela de registo de tarefas: um registo = uma tarefa
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        // chave estrangeira para funcionário:
        [Display(Name = "Funcionário")]
        public int? FuncionarioId { get; set; }

        // chave estrangeira para cliente:
        [Display(Name = "Cliente?")]
        public int? ClienteId { get; set; }

        [Display(Name = "Data criação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataCriacao { get; set; }

        [Display(Name = "Data limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataLimite { get; set; }

        [Display(Name = "Coima?")]
        public bool? TemCoima { get; set; }

        // chave estrangeira para supervisor:
        [Display(Name = "Supervisor")]
        public int? SupervisorId { get; set; }

        // chave estrangeira para categoria:
        [Display(Name = "Categoria de tarefa")]
        public int? CategoriaId { get; set; }


        // chave estrangeira para tipo de prioridade:
        [Display(Name = "Tipo prioridade?")]
        public int? TipoPrioridadeId { get; set; }

        [Display(Name = "Estado")]
        public int? EstadoId { get; set; }

    }
}
