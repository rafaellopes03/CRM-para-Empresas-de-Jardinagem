using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    // HERANÇA: Cliente herda de Pessoa
    public class Cliente : Pessoa
    {
        // Propriedades herdadas (Nome, Contacto, Morada)
        public string Cidade { get; set; }

        // Cria uma lista com a Class Servico
        public List<Servico> HistoricoServicos { get; set; }

        public Cliente()
        {
            // Cria a lista
            HistoricoServicos = new List<Servico>();
        }

        public Cliente(string nome, string contacto, string morada, string cidade) : base(nome, contacto, morada)
        {
            this.Cidade = cidade;
            HistoricoServicos = new List<Servico>();
        }
    }
}