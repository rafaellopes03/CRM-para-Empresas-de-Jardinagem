using System.Xml.Serialization;

namespace ProjetoFinal
{
    [XmlInclude(typeof(Cliente))]
    [XmlInclude(typeof(Utilizador))]
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Contacto { get; set; }
        public string Morada { get; set; }

        public Pessoa() { }
   
        public Pessoa(string nome, string contacto, string morada)
        {
            Nome = nome;
            Contacto = contacto;
            Morada = morada;
        }
    }
}