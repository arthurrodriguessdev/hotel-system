namespace Models
{
    public class Cliente : Pessoa
    {
        public Cliente(string nome, string cpf, string telefone) : base(nome, cpf, telefone)
        {
            
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {Nome} e eu sou o cliente!");
        }
    }
}