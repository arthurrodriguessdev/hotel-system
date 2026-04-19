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

        public void AtenderTelefone()
        {
            
        }

        public void FalarEmIngles()
        {
            
        }

        public bool RealizarCheckin(Cliente cliente, List<Reserva> reservas)
        {
            if(cliente == null || (!reservas.Any()))
            {
                return false;
            }

            Reserva reservaCliente = null;
            foreach(var item in reservas)
            {
                foreach(var itemClientes in item.Clientes)
                {
                    if(itemClientes == cliente)
                        {
                            reservaCliente = item;
                            break;
                        } 
                    }
            }

            if(reservaCliente == null)
            {
                return false;
            }

            reservaCliente.QuartoReservado.Status = StatusQuarto.Ocupado;
            return true;
        }
    }
}