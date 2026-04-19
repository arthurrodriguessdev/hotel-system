using Enums;
namespace Models
{
    public class Quarto
    {
        public int Numero;
        public StatusQuarto Status {get; set;}
        public int NumeroMaximoPessoas;

        public Quarto(int numero, int quantidadeMaxima)
        {
            Numero = numero;
            NumeroMaximoPessoas = quantidadeMaxima;
            Status = StatusQuarto.Livre;
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