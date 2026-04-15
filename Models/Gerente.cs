using Interfaces;
namespace Models
{
    public class Gerente : Pessoa, Interfaces.IGerente
    {
        public Gerente(string nome, string telefone, string cpf) : base(nome, cpf, telefone)
        {
            
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou o gerente do hotel!");
        }

        public void AtenderTelefone()
        {
            
        }

        public void FalarEmIngles()
        {
            
        }

        public void LimparQuarto()
        {
            
        }

        public void ArrumarCama()
        {
            
        }

        public void ConhecerHotel()
        {
            
        }
    }
}