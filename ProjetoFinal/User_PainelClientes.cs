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
    public partial class User_PainelClientes : Form
    {
        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo User |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
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

        public User_PainelClientes()
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
            User_PainelHome paineladmin = new User_PainelHome();
            paineladmin.Show();
        }
        private void pb_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_PainelHome paineladmin = new User_PainelHome();
            paineladmin.Show();
        }

        private void lbl_servicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_PainelServicos painelservicos = new User_PainelServicos();
            painelservicos.Show();
        }

        private void pb_servicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_PainelServicos painelservicos = new User_PainelServicos();
            painelservicos.Show();
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

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCamposDetalhe();

            lb_nomesClientes.SelectedIndex = -1;
        }
    }
}
