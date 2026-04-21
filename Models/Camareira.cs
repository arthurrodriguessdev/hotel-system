using Interfaces;
using Enums;
namespace Models
{
    public class Camareira : Pessoa, Interfaces.ICamareira
    {
        public int IdentificadorCamareira;
        public Camareira(string nome, string cpf, string telefone, int identificador) : base(nome, cpf, telefone)
        {
            IdentificadorCamareira = identificador;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou a camareira!");
        }

        public override string ToString()
        {
            return $"{IdentificadorCamareira} - {Nome}";
        }

        public void LimparQuarto(Quarto quartoLimpar)
        {
            if(quartoLimpar.EstadoLimpeza == EstadoLimpezaQuarto.Limpo)
            {
                Console.WriteLine($"O quarto: {quartoLimpar} já está limpo.");
                return;
            }

            if(quartoLimpar.Status == StatusQuarto.Ocupado)
            {
                Console.WriteLine($"Não é possível limpar o quarto: {quartoLimpar}.");
                return;
            }

            quartoLimpar.EstadoLimpeza = EstadoLimpezaQuarto.Limpo;
            Console.WriteLine($"O quarto: {quartoLimpar} foi limpo com sucesso!");
        }

        public void ArrumarCama()
        {
            
        }
    }
}