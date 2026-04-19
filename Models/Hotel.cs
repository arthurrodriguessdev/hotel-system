using Enums;
using Interfaces;
namespace Models
{
    public class Hotel
    {
        private string Nome {get; set;}
        private int CapacidadeMaximaQuartos {get;}
        private static int ContadorQuartos {get; set;}
        public Endereco Endereco {get; set;}
        public List<Recepcionista> Recepcionistas {get; private set;}
        public List<ICamareira> Camareiras {get; private set;}
        public IGerente Gerente {get; private set;}
        public List<Quarto> Quartos {get; set;}
        public List<Reserva> Reservas {get; set;}


        public Hotel(string nome, Endereco endereco, int capacidadeMaxima)
        {
            Nome = nome;
            CapacidadeMaximaQuartos = capacidadeMaxima;
            ContadorQuartos = 0;
            Endereco = endereco;
            Gerente = null; 
            Recepcionistas = new List<Recepcionista>();
            Camareiras = new List<ICamareira>();
            Quartos = new List<Quarto>();
            Reservas = new List<Reserva>();
        }

        public bool EstaLotado()
        {
            if(ContadorQuartos >= CapacidadeMaximaQuartos)
            {
                return true; // Atingiu a capacidade máxima de quartos
            }

            return false;
        }

        public bool ExisteQuarto()
        {
            if(Hotel.ContadorQuartos >= 1)
            {
                return true;
            }

            return false;
        }

        public bool AdicionarQuarto(int numeroQuarto, int capacidadeMaximaPessoas)
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

                Quartos.Add(new Quarto(numeroQuarto, capacidadeMaximaPessoas));
                Hotel.ContadorQuartos++;
                return true;
            }

            return false;
        }

        public void ListarQuartosDisponveis()
        {
            if (!ExisteQuarto())
            {
                return;
            }
            
            var quartosDisponiveis = Quartos.Where(q => q.Status == StatusQuarto.Livre).ToList();
            foreach(Quarto item in quartosDisponiveis)
            {
                Console.WriteLine($"{item}");
            }

            return;
        }

        public void ListarQuartosOcupados()
        {
            if (!ExisteQuarto())
            {
                return;
            }

            var quartosOcupados = Quartos.Where(q => q.Status == StatusQuarto.Ocupado).ToList();
            foreach(Quarto item in quartosOcupados)
            {
                Console.WriteLine($"{item}");
            }
        }

        public Quarto BuscarQuarto(int numeroQuartoBuscado)
        {
            if (!ExisteQuarto())
            {
                return null;
            }

            return Quartos.SingleOrDefault(q => q.Numero == numeroQuartoBuscado);
        }

        public bool ReservarQuarto(Quarto quarto, List<Cliente> clientes)
        {
            if(quarto == null || clientes == null)
            {
                return false;
            }

            if(quarto.Status != StatusQuarto.Livre)
            {
                return false;
            }

            if(clientes.Count > quarto.NumeroMaximoPessoas)
            {
                return false;
            }

            Reservas.Add(new Reserva(quarto, clientes));
            quarto.Status = StatusQuarto.Reservado;
            return true;
        }

        public void ListarRecepcionistas()
        {
            if(Recepcionistas.Any())
            {
                foreach(var item in Recepcionistas)
                {
                    Console.WriteLine($"{item}");
                }
                return;
            }
            return;
        }

        public Recepcionista BuscarRecepcionista(int identificador)
        {
            return Recepcionistas.SingleOrDefault(r => r.IdentificadorRecepcionista == identificador);
        }

        public bool DirecionamentoCheckin(int identificadorRecepcionista, Cliente cliente)
        {   
            var  recepcionista = BuscarRecepcionista(identificadorRecepcionista);

            if(recepcionista == null)
            {
                return false;
            }

            return recepcionista.RealizarCheckin(cliente, Reservas);
        }
    }
}