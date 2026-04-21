using Enums;

namespace Models
{
    public class Reserva
    {
        internal Quarto QuartoReservado;
        internal List<Cliente> Clientes;
        private DateTime Inicio;
        private DateTime Fim;
        private double ValorTotal => CalcularValorTotal();
        internal StatusReserva Status;
        public Reserva(Quarto quarto, List<Cliente> clientes, DateTime inicio, DateTime fim)
        {
            QuartoReservado = quarto;
            Clientes = clientes;
            Inicio = inicio;
            Fim = fim;
            Status = StatusReserva.Ativa;
        }

        public double CalcularValorTotal()
        {
            return (Fim - Inicio).Days * QuartoReservado.ValorDiaria;
        }
    }
}