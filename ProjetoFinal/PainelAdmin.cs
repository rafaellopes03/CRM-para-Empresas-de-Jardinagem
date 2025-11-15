using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class PainelAdmin : Form
    {
        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo Administrador |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
            lbl_welcome.Text = textoFormatado;
        }

        private List<Cliente> listaClientes;

        private void CarregarDadosEAtualizarHome()
        {
            // Carregar os dados do XML para a lista
            listaClientes = GestorXML.CarregarClientesSimples();

            // Chamar os métodos para calcular e preencher os paneis no Home
            CalcularEExibirTotalClientes();
            CalcularEExibirServicosTotal();
            CalcularEExibirReceitaTotal();
            CalcularEExibirCidades();
            ExibirUltimos5Servicos();
        }

        private void CalcularEExibirTotalClientes()
        {
            // Conta o número de clientes na lista
            int total = listaClientes.Count;
            lbl_totalclientes.Text = total.ToString();
        }

        private void CalcularEExibirServicosTotal()
        {
            // Usa o SelectMany para ver quantos Servicos existe no Historico de cada cliente
            int totalServicos = listaClientes.SelectMany(c => c.HistoricoServicos).Count();

            lbl_servicostotais.Text = totalServicos.ToString();
        }

        private void CalcularEExibirReceitaTotal()
        {
            // Soma o Valor de todos os serviços
            decimal receita = listaClientes.SelectMany(c => c.HistoricoServicos).Sum(s => s.Valor);

            lbl_receitatotal.Text = receita.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-PT"));
        }

        private void CalcularEExibirCidades()
        {
            // Conta quantas cidades existem (conta só 1 de cada)
            int totalCidades = listaClientes.Select(c => c.Cidade).Distinct().Count();

            lbl_cidades.Text = totalCidades.ToString();
        }

        private void ExibirUltimos5Servicos()
        {
            // Cria uma lista para aparecer no DataGridView
            var todosServicosComCliente = listaClientes.SelectMany(cliente => cliente.HistoricoServicos, (cliente, servico) => new
            {
                Cliente = cliente.Nome,
                Data = servico.Data,
                Descrição = servico.Descricao,
                Valor = servico.Valor 
            });

            // Fonte e tamanho
            Font novaFonte = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv_ultimos5servicos.DefaultCellStyle.Font = novaFonte;
            dgv_ultimos5servicos.ColumnHeadersDefaultCellStyle.Font = novaFonte;


            // FORMATAÇÃO DO DatagridView
            dgv_ultimos5servicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ordena e seleciona o primeiros 5
            var ultimos5 = todosServicosComCliente.OrderByDescending(s => s.Data).Take(5).ToList();

            // Coloco o resultado no DataGridView
            dgv_ultimos5servicos.DataSource = ultimos5;

            // Formatação da colunas
            dgv_ultimos5servicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgv_ultimos5servicos.Columns.Contains("Cliente"))
            {
 
                dgv_ultimos5servicos.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgv_ultimos5servicos.Columns.Contains("Data"))
            {
                dgv_ultimos5servicos.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Altera cor de selecao
            dgv_ultimos5servicos.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;

            // Formatação da DataGridView
            dgv_ultimos5servicos.Columns["Data"].DefaultCellStyle.Format = "dd-MM-yyyy";

            // Ocultar a coluna de Valor no painel Home
            dgv_ultimos5servicos.Columns["Valor"].Visible = false;
        }


        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////

        public PainelAdmin()
        {
            InitializeComponent();
            DefinirDataAtual();
            CarregarDadosEAtualizarHome();
        }

        private void lbl_clientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelClientes painelclientes = new PainelClientes();
            painelclientes.Show();
        }

        private void pb_clientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelClientes painelclientes = new PainelClientes();
            painelclientes.Show();
        }

        private void lbl_servicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelServicos painelservicos = new PainelServicos();
            painelservicos.Show();
        }

        private void pb_servicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelServicos painelservicos = new PainelServicos();
            painelservicos.Show();
        }

        private void lbl_financas_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelFinancas painelfinancas = new PainelFinancas();
            painelfinancas.Show();
        }

        private void pb_financas_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelFinancas painelfinancas = new PainelFinancas();
            painelfinancas.Show();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
