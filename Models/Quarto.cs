namespace Models
{
    public class Quarto
    {
        public int Numero;
        public bool Reservado;
        public int NumeroMaximoPessoas;

        public Quarto(int numero, int quantidadeMaxima)
        {
            Numero = numero;
            NumeroMaximoPessoas = quantidadeMaxima;
            Reservado = false;
        }

        public bool EstaReservado()
        {
            if (Reservado)
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