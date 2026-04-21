using Enums;

namespace Models
{
    public class Reserva
    {
        internal Quarto QuartoReservado;
        internal List<Cliente> Clientes;
        private DateTime Inicio;
        private DateTime Fim;
        internal StatusReserva Status;
        public Reserva(Quarto quarto, List<Cliente> clientes, DateTime inicio, DateTime fim)
        {
            QuartoReservado = quarto;
            Clientes = clientes;
            Inicio = inicio;
            Fim = fim;
            Status = StatusReserva.Ativa;
        }
    }
}