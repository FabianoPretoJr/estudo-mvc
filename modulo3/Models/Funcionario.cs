namespace modulo3.Models
{
    public class Funcionario // Isso é uma entidade que será convertida em tabela no banco de dados
    {
        public int Id { get; set; } // Esse atributo de class vão virar atributos de banco da dados

        public string Nome { get; set; } // Os atributos precisam estar sem com a primeira letra maiuscula e ser public

        public float Salario { get; set; }

        public string Cpf { get; set; }

        // Usa as migrations para dizer ao Entity que essa entidade será transformada em tabela
        // Caso seja feito mudanças, é só fazer uma nova migration, igual no Node com o Knex
    }
}