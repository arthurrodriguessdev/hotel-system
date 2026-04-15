using Interfaces;
namespace Models
{
    public class Recepcionista : Pessoa, Interfaces.IRecepcionista{
        public Recepcionista(string nome, string cpf, string telefone) : base(nome, cpf, telefone)
        {
            
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou a recepcionsita do hotel");
        }

        public void AtenderTelefone()
        {
            
        }

        public void FalarEmIngles()
        {
            
        }
    }
}