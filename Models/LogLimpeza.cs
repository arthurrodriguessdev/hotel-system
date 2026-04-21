namespace Models
{
    public class LogLimpeza
    {
        private Camareira CamareiraResponsavel {get;}
        private DateTime DataLimpeza {get;}
        internal Quarto Quarto {get;}

        public LogLimpeza(Camareira camareira, DateTime data, Quarto quartoLimpado)
        {
            CamareiraResponsavel = camareira;
            DataLimpeza = data;
            Quarto = quartoLimpado;
        }

        public override string ToString()
        {
            return $"Limpeza realizada na data: {DataLimpeza} pela camareira {CamareiraResponsavel}";
        }
    }
}