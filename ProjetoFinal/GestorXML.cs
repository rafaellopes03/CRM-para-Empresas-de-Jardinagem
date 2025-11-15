using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProjetoFinal
{
    public static class GestorXML
    {
        private const string NOME_FICHEIRO = "CRM.xml";

        private const string NOME_FICHEIRO_USERS = "Users.xml";



        // Métodos para Gerir a lista de Utilizadores
        public static void GuardarUtilizadores(List<Utilizador> utilizadores)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Utilizador>)); // Apenas para serialização

            using (TextWriter writer = new StreamWriter(NOME_FICHEIRO_USERS))
            {
                serializer.Serialize(writer, utilizadores);
            }
        }

        public static List<Utilizador> CarregarUtilizadores()
        {
            if (!File.Exists(NOME_FICHEIRO_USERS)) // Verifica se o ficheiro existe. Se não existir, cria um administrador padrão
            {
                // Cria utilizadores padrão (para começar)
                List<Utilizador> listaInicial = new List<Utilizador>
        {
            new Utilizador("Administrador", "999000000", "Rua do Admin, 1", "admin", "admin1234", "Admin"),
            new Utilizador("Funcionario", "999111222", "Rua do User, 2", "user", "user1234", "User")
        };
                GuardarUtilizadores(listaInicial);
                return listaInicial;
            }

            // Se o ficheiro existe, carrega com LINQ to XML:
            XDocument doc = XDocument.Load(NOME_FICHEIRO_USERS); // É preciso um 'using System.Xml.Linq;'
            List<Utilizador> utilizadores = new List<Utilizador>();

            foreach (XElement utilElement in doc.Root.Elements("Utilizador"))
            {
                Utilizador user = new Utilizador
                {
                    // Propriedades Herdadas (Pessoa)
                    Nome = utilElement.Element("Nome").Value,
                    Contacto = utilElement.Element("Contacto").Value,
                    Morada = utilElement.Element("Morada").Value,

                    // Propriedades Específicas (Utilizador)
                    Username = utilElement.Element("Username").Value,
                    Password = utilElement.Element("Password").Value,
                    TipoUtilizador = utilElement.Element("TipoUtilizador").Value
                };
                utilizadores.Add(user);
            }

            return utilizadores;
        }

        public static List<Cliente> CarregarClientesSimples()
        {
            List<Cliente> clientes = new List<Cliente>();

            XDocument doc = XDocument.Load(NOME_FICHEIRO);

            // Foreach percorre o xml e cria os dados do cliente
            foreach (XElement clienteElement in doc.Root.Elements("Cliente"))
            {
                Cliente cliente = new Cliente
                {
                    Nome = clienteElement.Element("Nome").Value,
                    Contacto = clienteElement.Element("Contacto").Value,
                    Morada = clienteElement.Element("Morada").Value,
                    Cidade = clienteElement.Element("Cidade").Value
                };

                XElement historicoElement = clienteElement.Element("HistoricoServicos");

                foreach (XElement servicoElement in historicoElement.Elements("Servico"))
                {
                    Servico servico = new Servico
                    {
                        DataString = servicoElement.Element("Data").Value,
                        Descricao = servicoElement.Element("Descricao").Value,
                        ValorString = servicoElement.Element("Valor").Value,
                        Notas = servicoElement.Element("Notas").Value,
                        LocalizacaoFotos = servicoElement.Element("LocalizacaoFotos").Value
                    };

                    cliente.HistoricoServicos.Add(servico);
                }

                clientes.Add(cliente);
            }

            return clientes;
        }

        public static void GuardarClientes(List<Cliente> listaClientesParaGuardar)
        {
            // Cria o elemento "Clientes"
            XElement raiz = new XElement("Clientes");

            // Foreach para criar o esqeueleto cliente e servicos
            foreach (Cliente clienteAtual in listaClientesParaGuardar)
            {
                // Cria o Cliente com os seus dados
                XElement elementoCliente = new XElement("Cliente",
                    new XElement("Nome", clienteAtual.Nome),
                    new XElement("Contacto", clienteAtual.Contacto),
                    new XElement("Morada", clienteAtual.Morada),
                    new XElement("Cidade", clienteAtual.Cidade)
                );

                // Cria o Histórico de Serviços
                XElement historico = new XElement("HistoricoServicos");

                // Foreach que percorre a lista do cliente criado
                foreach (Servico servicoAtual in clienteAtual.HistoricoServicos)
                {
                    // Cria o elementoServico com os seus dados
                    XElement elementoServico = new XElement("Servico",
                        new XElement("Data", servicoAtual.DataString),
                        new XElement("Descricao", servicoAtual.Descricao),
                        new XElement("Valor", servicoAtual.ValorString),
                        new XElement("Notas", servicoAtual.Notas),
                        new XElement("LocalizacaoFotos", servicoAtual.LocalizacaoFotos)
                    );
                    historico.Add(elementoServico);
                }

                // Adiciona o Histórico ao Cliente
                elementoCliente.Add(historico);

                // Adiciona o Cliente à raiz
                raiz.Add(elementoCliente);
            }

            // Cria o documento XML e guarda
            XDocument doc = new XDocument(raiz);
            doc.Save(NOME_FICHEIRO);
        }
    }
}

