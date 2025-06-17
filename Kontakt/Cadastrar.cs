using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontakt
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txbNome.Text.Length < 3)
            {
                MessageBox.Show("Verifique o nome informado!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txbEmail.Text.Length < 3)
            {
                MessageBox.Show("Verifique o email informado!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txbSenha.Text.Length < 3)
            {
                MessageBox.Show("Verifique a senha informado!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Model.Usuario usuario = new Model.Usuario();
                usuario.Nome =txbNome.Text;
                usuario.Email =txbEmail.Text;
                usuario.Senha =txbSenha.Text;

                if(usuario.Cadastrar() == 1)
                {
                    MessageBox.Show("Show, você foi cadastrado com sucesso!!", "SUCESSO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Falha ao cadastrar novo usuario!!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
