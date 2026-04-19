namespace Models
{
    public class Reserva
    {
        internal Quarto QuartoReservado;
        internal List<Cliente> Clientes;

        public Reserva(Quarto quarto, List<Cliente> clientes)
        {
            QuartoReservado = quarto;
            Clientes = clientes;
        }
    }
}