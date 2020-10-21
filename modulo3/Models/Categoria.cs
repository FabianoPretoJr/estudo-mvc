namespace modulo3.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString() // debugar no console
        {
            return "Id: " + this.Id + "\nNome: " + this.Nome;
        }
    }
}