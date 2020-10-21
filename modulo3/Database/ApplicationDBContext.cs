using Microsoft.EntityFrameworkCore; // NÃO ESQUECE ISSO AQUI
using modulo3.Models;

namespace modulo3.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; } // Criando esse atributo o Entity vai entender que deve transformar essa entidade/class em tabela no banco de dados
        // se a entidade não for publc e tiver get e set da errado a criação das migrations

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        // Tem que criar essa class de conexão para hedar e se conectar com o pacote do Identity
    }
}