using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class PainelServicos : Form
    {
        private void DefinirDataAtual()
        {
            DateTime dataatual = DateTime.Now;
            string textoFormatado = dataatual.ToString("'Bem-Vindo Administrador |' 'Hoje é 'dd 'de' MMMM 'de' yyyy");
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
            tb_valor.Clear();      
            tb_locfoto.Clear();    
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

        public PainelServicos()
        {
            InitializeComponent();
            DefinirDataAtual(); 
            listaClientes = GestorXML.CarregarClientesSimples();   
            CarregarClientesComboBox();
        }

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

        private void lbl_financas_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelFinancas painelFinancas = new PainelFinancas();
            painelFinancas.Show();
        }

        private void pb_financas_Click(object sender, EventArgs e)
        {
            this.Hide();
            PainelFinancas painelFinancas = new PainelFinancas();
            painelFinancas.Show();
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
                    tb_valor.Text = servicoSelecionado.ValorString;
                    tb_locfoto.Text = servicoSelecionado.LocalizacaoFotos;
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

        private void btn_inserirnovo_Click(object sender, EventArgs e)
        {
            // Verifica se foi selecionado um cliente
            if (clienteSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um cliente na lista antes de adicionar um novo serviço.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Pára a execução
            }

            // Verificação de campos inseridos
            // Campos obrigatorios -> descricao, valor e data
            if (string.IsNullOrWhiteSpace(tb_descricao.Text))
            {
                MessageBox.Show("A Descrição do serviço é obrigatória.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_valor.Text))
            {
                MessageBox.Show("O Valor do serviço é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_data.Text))
            {
                MessageBox.Show("A Data do serviço é obrigatória.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Valida o formato da data
            if (!ValidarFormatoData(tb_data.Text.Trim()))
            {
                MessageBox.Show("O formato da Data está incorreto. Por favor, use o formato DD-MM-AAAA (ex: 01-11-2025).", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria um novo servico
            Servico novoServico = new Servico
            {
                // Adiciona os valores da textboxs ao novo servico
                DataString = tb_data.Text.Trim(),
                Descricao = tb_descricao.Text.Trim(),
                ValorString = tb_valor.Text.Trim(),
                Notas = rtb_notas.Text.Trim(),
                LocalizacaoFotos = tb_locfoto.Text.Trim()
            };

            // Adiciona o novo serviço ao cliente selecionado
            clienteSelecionado.HistoricoServicos.Add(novoServico);

            // Guarda tudo no XML
            GestorXML.GuardarClientes(listaClientes); 

            // Mostra uma messagebox que foi adicionado e salvo
            MessageBox.Show($"O novo serviço [{novoServico.Descricao}] foi adicionado a {clienteSelecionado.Nome} e salvo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarServicosListBox(clienteSelecionado.HistoricoServicos);
            LimparCamposDetalheServico();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCamposDetalheServico();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            // Verifica se um serviço está selecionado
            if (servicoSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um serviço na lista para editar.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificação de campos editados
            if (string.IsNullOrWhiteSpace(tb_descricao.Text) || string.IsNullOrWhiteSpace(tb_valor.Text) || string.IsNullOrWhiteSpace(tb_data.Text))
            {
                MessageBox.Show("A Descrição, o Valor e a Data do serviço são obrigatórios.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação do formato da data
            if (!ValidarFormatoData(tb_data.Text.Trim()))
            {
                MessageBox.Show("O formato da Data está incorreto. Por favor, use o formato DD-MM-AAAA (ex: 01-11-2025).", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guarda a descrição antiga para a mensagem
            string descricaoAntiga = servicoSelecionado.Descricao; 

            // Atualiza o servicoSelecionado
            servicoSelecionado.DataString = tb_data.Text.Trim();
            servicoSelecionado.Descricao = tb_descricao.Text.Trim();
            servicoSelecionado.ValorString = tb_valor.Text.Trim();
            servicoSelecionado.Notas = rtb_notas.Text.Trim();
            servicoSelecionado.LocalizacaoFotos = tb_locfoto.Text.Trim();

            // Guarda no XML
            GestorXML.GuardarClientes(listaClientes); // Grava a lista atualizada no XML

            // Mostra uma messagebox que foi editado
            MessageBox.Show($"O serviço '{descricaoAntiga}' foi atualizado com sucesso.", "Edição Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarServicosListBox(clienteSelecionado.HistoricoServicos);
            LimparCamposDetalheServico();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Verifica se um serviço está selecionado 
            if (servicoSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um serviço na lista para eliminar.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pedido Confirmação
            DialogResult confirmacao = MessageBox.Show($"Tem certeza que deseja eliminar o serviço:{servicoSelecionado.Descricao} ({servicoSelecionado.DataString})?", "Confirmação de Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                clienteSelecionado.HistoricoServicos.Remove(servicoSelecionado);

                // Guarda no XML
                GestorXML.GuardarClientes(listaClientes);

                // Atualiza a interface e mostra MessageBox de eliminação
                MessageBox.Show("Serviço eliminado com sucesso e alterações salvas.", "Eliminação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarServicosListBox(clienteSelecionado.HistoricoServicos);
                LimparCamposDetalheServico();
            }
        }
    }
}