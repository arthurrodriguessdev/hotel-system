namespace Models
{
    public class Endereco
    {
        public string CEP {get; set;}
        public string Rua {get; set;}
        public string Bairro {get; set;}
        public string Complemento {get; set;}
        public string Cidade {get; set;}
        public int Numero {get; set;}

        public bool ValidarCep()
        {
            if(CEP.Length != 9)
            {
                return false;
            }

            return true;
        }
    }
}