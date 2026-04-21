using Enums;
namespace Models
{
    public class Quarto
    {
        public int Numero;
        public StatusQuarto Status {get; set;}
        public EstadoLimpezaQuarto EstadoLimpeza {get; set;}
        public double ValorDiaria {get; private set;}
        public int NumeroMaximoPessoas;

        public Quarto(int numero, int quantidadeMaxima, double valorDiaria)
        {
            Numero = numero;
            NumeroMaximoPessoas = quantidadeMaxima;
            Status = StatusQuarto.Livre;
            EstadoLimpeza = EstadoLimpezaQuarto.Limpo;
            ValorDiaria = valorDiaria;
        }

        public bool EstaDisponivel()
        {
            if (Status == StatusQuarto.Livre)
            {
                return true;
            }

            return false;
        }

        // public void AlugarQuarto(int quantidadePessoas)
        // {
        //     if(quantidadePessoas > NumeroMaximoPessoas || EstaReservado())
        //     {
        //         return;
        //     }

        //     Reservado = true;
        // }
    }
}