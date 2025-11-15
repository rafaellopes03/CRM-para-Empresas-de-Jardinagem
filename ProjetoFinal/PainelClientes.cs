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
    public partial class PainelClientes : Form
    {
        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo Administrador |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
            lbl_welcome.Text = textoFormatado;
        }
        
        private List<Cliente> listaClientes;

        // Variavel para guardar o cliente selecionado na ListBox
        private Cliente clienteSelecionado;

        private void PreencherListBoxClientes(List<Cliente> listaParaExibir)
        {
            lb_nomesClientes.Items.Clear();

            foreach (Cliente cliente in listaParaExibir.OrderBy(c => c.Nome))
            {
                lb_nomesClientes.Items.Add(cliente.Nome);
            }
        }

        private void LimparCamposDetalhe()
        {
            tb_nome.Clear();
            tb_contacto.Clear();
            tb_morada.Clear();
            tb_cidade.Clear();
            clienteSelecionado = null;
        }

        private Cliente ObterDadosDasTextBoxes(bool isNovoCliente)
        {
            Cliente clienteEmAcao;

            if (isNovoCliente)
            {
                clienteEmAcao = new Cliente
                {
                    HistoricoServicos = new List<Servico>()
                };
            }
            else // MODO EDITAR
            {
                clienteEmAcao = clienteSelecionado;
            }

            // Atualiza as propriedades
            clienteEmAcao.Nome = tb_nome.Text.Trim();
            clienteEmAcao.Contacto = tb_contacto.Text.Trim();
            clienteEmAcao.Morada = tb_morada.Text.Trim();
            clienteEmAcao.Cidade = tb_cidade.Text.Trim();

            return clienteEmAcao;
        }

        public PainelClientes()
        {
            InitializeComponent();
            DefinirDataAtual();
            listaClientes = GestorXML.CarregarClientesSimples();
            PreencherListBoxClientes(listaClientes);
        }

        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////

        private void lb_nomesClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_nomesClientes.SelectedIndex != -1)
            {
                // Obtém o nome selecionado
                string nomeSelecionado = lb_nomesClientes.SelectedItem.ToString();

                // Encontra o Cliente na listaClientes
                clienteSelecionado = listaClientes.FirstOrDefault(c => c.Nome == nomeSelecionado);

                if (clienteSelecionado != null)
                {
                    // Preenche as TextBoxes
                    tb_nome.Text = clienteSelecionado.Nome;
                    tb_contacto.Text = clienteSelecionado.Contacto;
                    tb_morada.Text = clienteSelecionado.Morada;
                    tb_cidade.Text = clienteSelecionado.Cidade;
                }
            }
            else
            {
                LimparCamposDetalhe();
            }
        }

        private void tb_pesquisar_TextChanged(object sender, EventArgs e)
        {
            string termoPesquisa = tb_pesquisar.Text.ToLower();

            // Variavel para pesquisar por Nome ou Cidade
            var clientesFiltrados = listaClientes.Where(c => c.Nome.ToLower().Contains(termoPesquisa) || c.Cidade.ToLower().Contains(termoPesquisa)).ToList();

            PreencherListBoxClientes(clientesFiltrados);
            LimparCamposDetalhe();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (clienteSelecionado != null)
            {
                DialogResult confirmacao = MessageBox.Show($"Tem certeza que deseja eliminar o cliente {clienteSelecionado.Nome}? Esta ação é irreversível.", "Confirmação de Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    listaClientes.Remove(clienteSelecionado);
                    GestorXML.GuardarClientes(listaClientes);

                    PreencherListBoxClientes(listaClientes);
                    LimparCamposDetalhe();

                    MessageBox.Show("Cliente eliminado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para eliminar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (clienteSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um cliente da lista para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guarda o nome atual do cliente (para mostrar na messagebox)
            string nomeClienteEditado = clienteSelecionado.Nome;

            // Obtém os dados das TextBoxes (atualiza os dados do cliente selcionado)
            ObterDadosDasTextBoxes(false);

            // Guarda a lista completa no XML
            GestorXML.GuardarClientes(listaClientes);

            PreencherListBoxClientes(listaClientes);
            LimparCamposDetalhe();

            MessageBox.Show($"O cliente {nomeClienteEditado} foi editado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_inserirnovo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_nome.Text) || string.IsNullOrWhiteSpace(tb_contacto.Text))
            {
                MessageBox.Show("O Nome e o Contacto são obrigatórios para inserir um novo cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listaClientes.Any(c => c.Nome.Equals(tb_nome.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Já existe um cliente com este nome. Use a função 'Editar'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tb_contacto.Text.Length < 9 || tb_contacto.Text.Length > 9)
            {
                MessageBox.Show("Insira 9 dígitos para adicionar o contacto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria o novo cliente a partir das TextBoxes
            Cliente novoCliente = ObterDadosDasTextBoxes(true);

            // Adiciona à lista
            listaClientes.Add(novoCliente);

            // Guarda a lista completa no XML
            GestorXML.GuardarClientes(listaClientes);

            // Atualiza o interface e limpa
            PreencherListBoxClientes(listaClientes);
            LimparCamposDetalhe();

            MessageBox.Show($"O cliente {novoCliente.Nome} foi adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCamposDetalhe();

            lb_nomesClientes.SelectedIndex = -1;
        }
    }
}
