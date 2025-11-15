using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; // Usado para manipulação de strings
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class User_PainelServicos : Form
    {
        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo User |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
            lbl_welcome.Text = textoFormatado;
        }

        // Variáveis de nível de classe (campos) para armazenar dados e o estado atual da UI
        private List<Cliente> listaClientes;
        private Cliente clienteSelecionado;
        private Servico servicoSelecionado;

        // Função para preencher a ComboBox (cb_clientes) com os nomes dos clientes
        private void CarregarClientesComboBox()
        {
            cb_clientes.Items.Clear();
            foreach (Cliente c in listaClientes.OrderBy(c => c.Nome))
            {
                cb_clientes.Items.Add(c.Nome);
            }
        }

        // Função para preencher a ListBox (lb_servicos) com os serviços de um cliente selecionado
        private void CarregarServicosListBox(List<Servico> listaServicos)
        {
            lb_servicos.Items.Clear(); // Limpa quaisquer itens antigos da ListBox

            // Ordena do mais recente para o mais antigo
            foreach (Servico s in listaServicos.OrderByDescending(s => s.Data))
            {
                lb_servicos.Items.Add($"[{s.DataString}] - {s.Descricao}");
            }
        }

        private void LimparCamposDetalheServico()
        {
            tb_descricao.Clear();  
            tb_data.Clear();       
            //tb_valor.Clear();      
            //tb_locfoto.Clear();    
            rtb_notas.Clear();     
            pb_foto.Image = null;  
            servicoSelecionado = null;
        }

        // Função para verificar se formata da Data está correto
        private bool ValidarFormatoData(string data)
        {
            string dataLimpa = data.Trim();

            // Verifica se o comprimento é 10
            if (dataLimpa.Length != 10)
            {
                return false;
            }

            // Verifica se os ('-') estão nas posições corretas
            if (dataLimpa[2] != '-' || dataLimpa[5] != '-')
            {
                return false;
            }

            // Recolhe os dados inseridos
            string diaString = dataLimpa.Substring(0, 2);
            string mesString = dataLimpa.Substring(3, 2);
            string anoString = dataLimpa.Substring(6, 4);

            // Garante que todas os dados inseridos são dígitos
            if (!diaString.All(char.IsDigit) || !mesString.All(char.IsDigit) || !anoString.All(char.IsDigit))
            {
                return false;
            }

            // Converte para inteiro
            int dia = Convert.ToInt32(diaString);
            int mes = Convert.ToInt32(mesString);
            int ano = Convert.ToInt32(anoString);

            // Verifica o dia
            if (dia < 1 || dia > 31)
            {
                return false;
            }

            // Verifica o mês
            if (mes < 1 || mes > 12)
            {
                return false;
            }

            // Verifica o ano
            if (ano < 2000 || ano > 2100)
            {
                return false;
            }

            // Se passar todas as verificações, aceita é modifica
            return true;
        }

        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////

        public User_PainelServicos()
        {
            InitializeComponent();
            DefinirDataAtual(); 
            listaClientes = GestorXML.CarregarClientesSimples();   
            CarregarClientesComboBox();
        }

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

        private void lbl_clientes_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            User_PainelClientes painelclientes = new User_PainelClientes();
            painelclientes.Show();
        }

        private void pb_clientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_PainelClientes painelclientes = new User_PainelClientes();
            painelclientes.Show();
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

        private void cb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_servicos.Items.Clear();
            LimparCamposDetalheServico();

            // Verifica se algo foi selecionado
            if (cb_clientes.SelectedIndex != -1)
            {
                string nomeSelecionado = cb_clientes.SelectedItem.ToString();

                clienteSelecionado = listaClientes.FirstOrDefault(c => c.Nome == nomeSelecionado);

                if (clienteSelecionado != null)
                {
                    CarregarServicosListBox(clienteSelecionado.HistoricoServicos);
                }
            }
        }

        private void lb_servicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCamposDetalheServico();


            if (lb_servicos.SelectedIndex != -1 && clienteSelecionado != null)
            {
                string itemSelecionado = lb_servicos.SelectedItem.ToString();
                string dataServicoStr = itemSelecionado.Substring(1, 10);

                servicoSelecionado = clienteSelecionado.HistoricoServicos.FirstOrDefault(s => s.DataString == dataServicoStr);

                if (servicoSelecionado != null)
                {
                    tb_descricao.Text = servicoSelecionado.Descricao;
                    tb_data.Text = servicoSelecionado.DataString;
                    rtb_notas.Text = servicoSelecionado.Notas;

                    string caminhoFoto = servicoSelecionado.LocalizacaoFotos;

                    // Verifica se o caminho da foto existe e não está vazio
                    if (!string.IsNullOrEmpty(caminhoFoto) && System.IO.File.Exists(caminhoFoto))
                    {
                        pb_foto.Image = Image.FromFile(caminhoFoto);
                        pb_foto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pb_foto.Image = null;
                    }
                }
            }
        }
    }
}