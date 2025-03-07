using PKX.Models;
using Microsoft.EntityFrameworkCore;


namespace PKX.Data

{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        
        

        public DbSet<Atividade> Atividades { get; set; } = default!;
        public DbSet<Avenca> Avencas { get; set; } = default!;
        public DbSet<Cadastro> Cadastros { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Estado>? Estados { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; } = default!;
        public DbSet<Item> Itens { get; set; } = default!;
        public DbSet<LinhaProcesso> LinhasProcessos { get; set; } = default!;
        public DbSet<Movimento> Movimentos { get; set; } = default!;
        public DbSet<Prioridade> Prioridades { get; set; } = default!;
        public DbSet<Processo> Processos { get; set; } = default!;
        public DbSet<Tempo> Tempos { get; set; } = default!;
        public DbSet<Tipo> Tipos { get; set; } = default!;
        public DbSet<TipoMovimento> TiposMovimentos { get; set; } = default!;

        public DbSet<Utilizador> Utilizadores { get; set; } = default!;


    }
}
