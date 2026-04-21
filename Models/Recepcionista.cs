using Interfaces;
using Enums;
namespace Models
{
    public class Recepcionista : Pessoa, Interfaces.IRecepcionista{
        public int IdentificadorRecepcionista;
        public Recepcionista(string nome, string cpf, string telefone, int identificador) : base(nome, cpf, telefone)
        {
            IdentificadorRecepcionista = identificador;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou a recepcionsita do hotel");
        }

        public override string ToString()
        {
            return $"{IdentificadorRecepcionista} - {Nome}";
        }

        public void AtenderTelefone()
        {
            
        }

        public void FalarEmIngles()
        {
            
        }

        public bool RealizarCheckin(Cliente cliente, Reserva reservaCliente)
        {
            if(cliente == null || reservaCliente == null)
            {
                return false;
            }

            if(reservaCliente.Status == StatusReserva.Inativa) return false;
            if(reservaCliente.QuartoReservado.Status == StatusQuarto.Ocupado) return false;

            reservaCliente.QuartoReservado.Status = StatusQuarto.Ocupado;
            return true;
        }

        public bool RealizarCheckout(Quarto quartoDesocupar)
        {
            if(quartoDesocupar != null && quartoDesocupar.Status == StatusQuarto.Ocupado)
            {
                quartoDesocupar.Status = StatusQuarto.Livre;
                quartoDesocupar.EstadoLimpeza = EstadoLimpezaQuarto.Sujo;
                return true;
            }

            return false;
        }
    }
}