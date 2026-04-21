namespace Models
{
    public abstract class Pessoa
    {
        #region atributos
        protected string Nome {get; set;}
        protected DateTime DataNascimento {get; private set;}
        protected int Idade => CalcularIdade();
        internal string CPF {get;}
        protected string Telefone {get; set;}
        #endregion
        
        public Pessoa(string nome, string cpf, string telefone, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public abstract void Apresentar();
        public bool ValidarCpf()
        {
            if(CPF.Length != 11)
            {
                return false;
            }

            return true;
        }

        public int CalcularIdade()
        {   
            DateTime hoje = DateTime.Now;
            int idade = hoje.Year - DataNascimento.Year;

            if(hoje.Month < DataNascimento.Month || hoje.Month == DataNascimento.Month && hoje.Day < DataNascimento.Day)
            {
                idade--;
            }

            return idade;
        }
    }
}