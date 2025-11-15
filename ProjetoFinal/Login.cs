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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_user.Text;
            string password = tb_password.Text;

            List<Utilizador> listaUtilizadores = GestorXML.CarregarUtilizadores(); // Carregar a lista de Utilizadores do XML

            // Usar LINQ para encontrar o utilizador
            Utilizador userValidado = listaUtilizadores.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (userValidado != null)
            {
                
                if (userValidado.TipoUtilizador == "Admin") // Verifica o TipoUtilizador
                {
                    // Manda para o Admin
                    this.Hide();
                    PainelAdmin paineladmin = new PainelAdmin();
                    paineladmin.Show();

                }
                else if (userValidado.TipoUtilizador == "User")
                {
                    // Manda para o User
                    this.Hide();
                    User_PainelHome paineluser = new User_PainelHome();
                    paineluser.Show();
                }
            }
            else // Credenciais incorretas (userValidado é null)
            {
                MessageBox.Show("Nome de utilizador ou palavra-passe incorretos.", "Erro de Login",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                tb_password.Clear();
                tb_user.Clear();
                tb_user.Focus();
            }
        }

        private void lbl_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_limpar_Click(object sender, EventArgs e)
        {
            tb_user.Clear();
            tb_password.Clear();
        }

        private void cb_mostrar_password_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mostrar_password.Checked)
            {
                tb_password.PasswordChar = '\0';
            }
            else
            {
                tb_password.PasswordChar = '*';
            }
        }
    }
}
