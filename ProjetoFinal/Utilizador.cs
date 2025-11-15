namespace ProjetoFinal
{
    public class Utilizador : Pessoa // HERANÇA 
    {
        // Propriedades específicas do Utilizador
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipoUtilizador { get; set; } // Admin ou User

        public Utilizador() { } // Construtor padrão (necessário para XML)

        public Utilizador(string nome, string contacto, string morada, string username, string password, string tipo) : base(nome, contacto, morada)
        {
            Username = username;
            Password = password;
            TipoUtilizador = tipo;
        }
    }
}