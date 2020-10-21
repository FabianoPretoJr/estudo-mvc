namespace modulo3.Models
{
    public class Produto
    {
        public int Id { get; set; }

        // public int CodigoDeBarras { get; set; } // Criei para ser a nova chave primaria, recurso do Fluent API

        public string Nome { get; set; }

        public virtual Categoria Categoria { get; set; } // O Entity Framework vai entender que produto pertence a Categoria, a chave estrageira
        // Foi adicionado o Virtual para poder se trabalhar com Lazy Loading

        public override string ToString()
        {
            return "Id: " + this.Id + "\nNome: " + this.Nome + "\nCategoria: [" + this.Categoria.ToString() + "]";
        }
    }
}