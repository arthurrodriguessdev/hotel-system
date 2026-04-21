using System.Reflection.Metadata.Ecma335;
using Enums;
using Interfaces;
namespace Models
{
    public class Hotel
    {
        private string Nome {get; set;}
        private int CapacidadeMaximaQuartos {get;}
        public Endereco Endereco {get; set;}
        public List<Recepcionista> Recepcionistas {get; private set;}
        public List<Camareira> Camareiras {get; private set;}
        public IGerente Gerente {get; private set;}
        public List<Quarto> Quartos {get; private set;}
        public List<Reserva> Reservas {get; private set;}
        public List<LogLimpeza> HistoricoLimpezas {get; private set;}


        public Hotel(string nome, Endereco endereco, int capacidadeMaxima)
        {
            Nome = nome;
            CapacidadeMaximaQuartos = capacidadeMaxima;
            Endereco = endereco;
            Gerente = null; 
            Recepcionistas = new List<Recepcionista>();
            Camareiras = new List<Camareira>();
            Quartos = new List<Quarto>();
            Reservas = new List<Reserva>();
        }

        public bool EstaLotado()
        {
            return Quartos.Count >= CapacidadeMaximaQuartos;
        }

        public bool AdicionarQuarto(int numeroQuarto, int capacidadeMaximaPessoas, double valorDiaria)
        {
            if (!EstaLotado())
            {
                // Cria e adiciona o novo quarto ao hotel
                for(int i = 0; i < Quartos.Count; i++)
                {
                    if(Quartos[i].Numero == numeroQuarto)
                    {
                        return false;
                    }
                }

                Quartos.Add(new Quarto(numeroQuarto, capacidadeMaximaPessoas, valorDiaria));
                return true;
            }

            return false;
        }

        public void AdicionarRecepcionista(Recepcionista recepcionista)
        {
            if (Recepcionistas.Contains(recepcionista))
            {
                Console.WriteLine($"Recepcionista: {recepcionista} já faz parte da equipe.");
                return;
            }

            Recepcionistas.Add(recepcionista);
            return;
        }

        public void AdicionarCamareira(Camareira camareira)
        {
            if (Camareiras.Contains(camareira))
            {
                Console.WriteLine($"Camareira: {camareira} já faz parte da equipe.");
                return;
            }

            Camareiras.Add(camareira);
            return;
        }

        public void DefinirGerente(Gerente gerente)
        {
            if(Gerente == gerente)
            {
                Console.WriteLine($"O gerente: {gerente} já está com essa função.");
                return;
            }

            Gerente = gerente;
            Console.WriteLine($"Gerente: {gerente} definido com sucesso.");
            return;
        }

        public List<Quarto> ListarQuartosDisponveis() => Quartos.Where(q => q.Status == StatusQuarto.Livre).ToList();

        public List<Quarto> ListarQuartosOcupados() => Quartos.Where(q => q.Status == StatusQuarto.Ocupado).ToList();

        public List<Quarto> ListarQuartosSujos() => Quartos.Where(q => q.EstadoLimpeza == EstadoLimpezaQuarto.Sujo).ToList();

        public Quarto BuscarQuarto(int numeroQuartoBuscado) => Quartos.SingleOrDefault(q => q.Numero == numeroQuartoBuscado);

        public bool ReservarQuarto(int numeroQuarto, List<Cliente> clientes, DateTime inicioReserva, DateTime fimReserva)
        {
            var quarto = BuscarQuarto(numeroQuarto);
            if(quarto == null || clientes == null)
            {
                return false;
            }

            if(inicioReserva >= fimReserva) return false;
            if(quarto.Status != StatusQuarto.Livre) return false;
            if(quarto.EstadoLimpeza == EstadoLimpezaQuarto.Sujo) return false;
            if(clientes.Count > quarto.NumeroMaximoPessoas) return false;

            Reservas.Add(new Reserva(quarto, clientes, inicioReserva, fimReserva));
            quarto.Status = StatusQuarto.Reservado;
            return true;
        }

        public IReadOnlyList<Recepcionista> ListarRecepcionistas() => Recepcionistas;

        public IReadOnlyList<Camareira> ListarCamareiras() => Camareiras;

        public Camareira BuscarCamareira(int identificador)
        {
            return Camareiras.SingleOrDefault(c => c.IdentificadorCamareira == identificador);
        }

        public bool DirecionamentoLimpeza(int identificadorCamareira, int numeroQuarto)
        {
            var camareiraSelecionada = BuscarCamareira(identificadorCamareira);
            var quartoLimpar = BuscarQuarto(numeroQuarto);
            if(camareiraSelecionada == null || quartoLimpar == null)
            {
                return false;
            }

            camareiraSelecionada.LimparQuarto(quartoLimpar);
            return true;

        }

        public Recepcionista BuscarRecepcionista(int identificador)
        {
            return Recepcionistas.SingleOrDefault(r => r.IdentificadorRecepcionista == identificador);
        }

        public bool DirecionamentoCheckin(int identificadorRecepcionista, Cliente cliente)
        {   
            var  recepcionista = BuscarRecepcionista(identificadorRecepcionista);
            if(recepcionista == null) return false;

            var reservaCliente = Reservas.FirstOrDefault(r => r.Clientes.Any(c => c.CPF == cliente.CPF));
            return recepcionista.RealizarCheckin(cliente, reservaCliente);
        }

        public bool DirecionamentoCheckout(int identificadorRecepcionista, int numeroQuarto)
        {   
            var quarto = BuscarQuarto(numeroQuarto);
            var  recepcionista = BuscarRecepcionista(identificadorRecepcionista);
            if(quarto == null || recepcionista == null)
            {
                return false;
            }

            return recepcionista.RealizarCheckout(quarto);
        }

        public List<LogLimpeza> ListarHistoricoLimpezaQuarto(int numeroQuarto)
        {
            return HistoricoLimpezas.Where(h => h.Quarto == BuscarQuarto(numeroQuarto)).ToList();
        }
    }
}