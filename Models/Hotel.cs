using Interfaces;
namespace Models
{
    public class Hotel
    {
        private string Nome {get; set;}
        public Endereco Endereco {get; set;}
        public List<IRecepcionista> Recepcionistas {get; private set;}
        public List<ICamareira> Camareiras {get; private set;}
        public IGerente Gerente {get; private set;}
        public List<Quarto> Quartos {get; set;}
    }
}