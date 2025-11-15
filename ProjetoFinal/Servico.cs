using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Servico
    {
        public string DataString { get; set; }
        public string Descricao { get; set; }
        public string ValorString { get; set; }
        public string Notas { get; set; }
        public string LocalizacaoFotos { get; set; }

        
        // Propriedades Calculadas
        public DateTime Data => DateTime.Parse(DataString);
        public decimal Valor => decimal.Parse(ValorString);

        
        public Servico() { } // Construtor Padrão (necessário para XML)

       
        public Servico(string data, string descricao, string valor, string notas, string localizacao) // Construtor Sobrecarga (Requisito POO)
        {
            this.DataString = data;
            this.Descricao = descricao;
            this.ValorString = valor;
            this.Notas = notas;
            this.LocalizacaoFotos = localizacao;
        }
    }
}
