namespace Models
{
    public abstract class Pessoa
    {
        #region atributos
        protected string Nome {get; set;}
        internal string CPF {get;}
        protected string Telefone {get; set;}
        #endregion
        
        public Pessoa(string nome, string cpf, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
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
    }
}