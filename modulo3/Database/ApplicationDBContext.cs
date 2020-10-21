using Microsoft.EntityFrameworkCore; // NÃO ESQUECE ISSO AQUI
using modulo3.Models;

namespace modulo3.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; } // Criando esse atributo o Entity vai entender que deve transformar essa entidade/class em tabela no banco de dados
        // se a entidade não for publc e tiver get e set da errado a criação das migrations

        public DbSet<Categoria> Categorias { get; set; }
        
        public DbSet<Produto> Produtos { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        // Tem que criar essa class de conexão para hedar e se conectar com o pacote do Identity

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Ativa o Lazy Loanding na aplicação
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Acessar a Fluent API com esse método
        {
            // modelBuilder.Entity<Produto>().ToTable("nomequevcquiser"); // Mudar nome da tabela
            // modelBuilder.Entity<Produto>().HasKey(p => p.CodigoDeBarras); // Altera a chave primaria que por padrão é o ID, porém lembra que tem de fazer esse campo na entidade de Produto, qual vc esteja mexendo
            // modelBuilder.Entity<Produto>().Property(p => p.Nome).IsRequired(); // Deixar NotNUll
            // modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100); // Definir tamanho
        }
    }
}