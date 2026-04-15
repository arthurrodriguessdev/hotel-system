using Interfaces;
namespace Models
{
    public class Camareira : Pessoa, Interfaces.ICamareira
    {
        public Camareira(string nome, string cpf, string telefone) : base(nome, cpf, telefone)
        {
            
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou a camareira!");
        }

        public void LimparQuarto()
        {
            
        }

        public void ArrumarCama()
        {
            
        }
    }
}