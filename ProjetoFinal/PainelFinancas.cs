using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Necessário para usar o Chart

namespace ProjetoFinal
{
    public partial class PainelFinancas : Form
    {
        // Variáveis globais para carregar os dados
        private List<Cliente> listaClientes;
        private List<Servico> todosOsServicos;

        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo Administrador |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
            lbl_welcome.Text = textoFormatado;
        }


        public PainelFinancas() // Carrega dados e configura o estado inicial
        {
            InitializeComponent();
            DefinirDataAtual();

            listaClientes = GestorXML.CarregarClientesSimples(); // Carrega GestorXML

            // Cria a lista plana de serviços para facilitar consultas - SelectMany agrupa todos os HistoricoServicos numa só lista
            todosOsServicos = listaClientes.Where(c => c.HistoricoServicos.Any()).SelectMany(c => c.HistoricoServicos).ToList();

            ConfigurarDGVAnaliseClientes(); // Configura o DataGridView

            AtualizarPainelComTodosDados(); // Inicia o painel com tofdos os dados (sem filtros de data)

            dgv_analise_clientes.SelectionChanged += dgv_analise_clientes_SelectionChanged; // Configura o event para reagir à seleção de linha na dgv

        }



        // Métodos de inicialização e configuração
        private void ConfigurarDGVAnaliseClientes()
        {
            dgv_analise_clientes.AutoGenerateColumns = false;
            dgv_analise_clientes.MultiSelect = false;
            dgv_analise_clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_analise_clientes.ReadOnly = true;

            // Define o alinhamento do texto para o centro
            dgv_analise_clientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_analise_clientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Altera cor de selecao
            dgv_analise_clientes.DefaultCellStyle.SelectionBackColor = Color.DarkGreen; 
            // Fundo
            dgv_analise_clientes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Coluna Nome (Cliente)
            dgv_analise_clientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "NomeCliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Coluna Qtd. Serviços
            dgv_analise_clientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QtdServicos",
                HeaderText = "Qtd. Serviços",
                DataPropertyName = "QtdServicos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Coluna Total Gasto (Valor)
            dgv_analise_clientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalGasto",
                HeaderText = "Total Gasto",
                DataPropertyName = "TotalGasto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Formato de moeda
            });
        }




        // Atualiza todo o painel, usando a lista completa de serviços (sem filtros de data)
        private void AtualizarPainelComTodosDados()
        {
            // A lista de serviços a usar é a lista global
            List<Servico> servicosParaAnalise = todosOsServicos;

            // Preencher o gráfico com a faturação mensal
            DesenharGraficoReceitaMensal(servicosParaAnalise);

            // Preencher a dgv_analise_clientes com a lista COMPLETA
            PreencherDGVAnaliseClientes(servicosParaAnalise);

            // Limpa o detalhe do cliente
            LimparDetalheCliente();
        }



        // Preenche a dgv_analise_clientes com os dados de clientes e serviços
        private void PreencherDGVAnaliseClientes(List<Servico> servicosParaAnalise)
        {
            dgv_analise_clientes.DataSource = null; // Limpa a DGV

            // Mapear cada serviço de volta ao seu cliente original e consolidar. Agrupa os serviços pelo nome do cliente
            var analiseClientes = servicosParaAnalise
                .GroupBy(servico => listaClientes.First(c => c.HistoricoServicos.Contains(servico)).Nome)
                .Select(g => new
                {
                    NomeCliente = g.Key,
                    QtdServicos = g.Count(),
                    TotalGasto = g.Sum(s => s.Valor),
                    HistoricoFiltrado = g.ToList() // Guarda o histórico completo para poder usar no detalhe
                })
                .OrderByDescending(x => x.TotalGasto) // Ordena pelo total gasto (de maior para menor - para ranking clientes)
                .ToList();

            // Define a fonte de dados
            if (analiseClientes.Any())
            {
                dgv_analise_clientes.DataSource = analiseClientes;
            }
        }


        // Evento acionado quando a seleção de linha na DGV muda. Atualiza lb_detalhe_servicos
        private void dgv_analise_clientes_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada
            if (dgv_analise_clientes.SelectedRows.Count == 0)
            {
                LimparDetalheCliente();
                return;
            }

            DataGridViewRow linhaSelecionada = dgv_analise_clientes.SelectedRows[0];

            // Acessamos o objeto subjacente (anónimo) com 'dynamic'
            dynamic dadosCliente = linhaSelecionada.DataBoundItem;


            // Preencher a ListBox com o detalhe dos serviços (lb_detalhe_servicos)
            PreencherListBoxDetalheServicos(dadosCliente.HistoricoFiltrado);
        }


        //Limpa os campos de detalhe do cliente
        private void LimparDetalheCliente()
        {
            lb_detalhe_servicos.Items.Clear(); // Limpa a lista de serviços de detalhe
        }



        // Preenche a ListBox com os detalhes dos serviços para o cliente selecionado
        private void PreencherListBoxDetalheServicos(List<Servico> historicoServicos)
        {
            lb_detalhe_servicos.Items.Clear();

            // Formata cada serviço para exibição na ListBox
            foreach (Servico servico in historicoServicos.OrderByDescending(s => s.Data))
            {
                string linha = $"{servico.Data.ToShortDateString()} - {servico.Descricao} ({servico.Valor.ToString("C2")})";
                lb_detalhe_servicos.Items.Add(linha);
            }
        }



        // Métodos para Gráfico
        private void DesenharGraficoReceitaMensal(List<Servico> listaParaDesenhar)
        {
            chart_faturacao_mensal.Series.Clear(); // Configuração inicial do Chart

            chart_faturacao_mensal.Legends.Clear(); // Remove a legenda

            if (!listaParaDesenhar.Any())
            {
                // Se não houver dados, exibe uma mensagem no gráfico e sai
                chart_faturacao_mensal.Titles.Clear();
                chart_faturacao_mensal.Titles.Add("Sem Dados para Análise");
                return;
            }

            chart_faturacao_mensal.Titles.Clear(); // Limpa mensagens de erro

            var faturacaoMensal = listaParaDesenhar.GroupBy(s => new { s.Data.Year, s.Data.Month }).Select(g => new
            {
                // Usa o primeiro dia do mês para facilitar a ordenação e formatação no eixo X
                Data = new DateTime(g.Key.Year, g.Key.Month, 1),
                TotalReceita = g.Sum(s => s.Valor)
            })
                .OrderBy(x => x.Data) // Ordena por data
                .ToList();

            // Cor das linhas Eixo X e Y
            chart_faturacao_mensal.ChartAreas[0].AxisX.LineColor = Color.Gray;
            chart_faturacao_mensal.ChartAreas[0].AxisY.LineColor = Color.Gray;

            // Cor da Grid
            chart_faturacao_mensal.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chart_faturacao_mensal.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;

            chart_faturacao_mensal.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

            // Cor do texto Mês e Faturação
            chart_faturacao_mensal.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.DimGray;
            chart_faturacao_mensal.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Reduzir tamanho da letra Eixo X e Y
            chart_faturacao_mensal.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10f);
            //chart_faturacao_mensal.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10f);

            // Criar e Configurar a Série do Gráfico
            Series series = new Series("Faturação Total")
            {
                ChartType = SeriesChartType.Line, // Gráfico de linha
                BorderWidth = 3,
                Color = Color.DarkGreen,

                MarkerStyle = MarkerStyle.Circle, // Adiciona um círculo em cada ponto de dados
                MarkerColor = Color.Black, // Cor do marcador igual à linha
                IsValueShownAsLabel = true, // Mostra o valor em cima do ponto
                Font = new Font("Arial", 10f, FontStyle.Bold), // Altera a letra
                LabelFormat = "C2", // Formato de moeda para as etiquetas
                LabelForeColor = Color.Black // Cor do valor em cima do ponto
            };
            chart_faturacao_mensal.Series.Add(series);

            // Configurar Eixos para Datas
            chart_faturacao_mensal.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy"; // Exibe o mês abreviado e o ano
            chart_faturacao_mensal.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart_faturacao_mensal.ChartAreas[0].AxisX.Interval = 1; // Garante que todos os meses com dados são exibidos
            chart_faturacao_mensal.ChartAreas[0].AxisY.LabelStyle.Format = "C2"; // Formato de moeda para o eixo Y

            // Adicionar os dados ao Chart
            foreach (var item in faturacaoMensal)
            {
                series.Points.AddXY(item.Data, item.TotalReceita); // AddXY(DateTime, Valor) para o eixo de datas funcionar corretamente
            }
        }



        // Eventos UI
        private void lbl_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelAdmin paineladmin = new PainelAdmin();
            paineladmin.Show();
        }

        private void pb_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelAdmin paineladmin = new PainelAdmin();
            paineladmin.Show();
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

        private void tb_servicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelServicos painelservicos = new PainelServicos();
            painelservicos.Show();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}