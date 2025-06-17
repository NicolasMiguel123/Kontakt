using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kontakt.Model;

namespace Kontakt
{
    public partial class TelaInicial : Form
    {
        Model.Usuario usuario;
        public TelaInicial(Model.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lblUsuario.Text = $"Olá,  {usuario.Nome}";
            AtualizarDgvContato();
        }

        public void AtualizarDgvContato()
        {
            Model.Contato contato = new Model.Contato();

            contato.Idresponsabel = usuario.Id;
            // Colocar o resultado do SELECT dentro do dgv
            dgvContatos.DataSource = contato.ListarTudo();
        }

        private void txbNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Verificar se os campos não estão vazios:
            if (txbNome.Text.Length < 3)
            {
                MessageBox.Show("O nome é obrigatorio!" , "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            else
            {
                // Instanciar um obj do tipo contato
                Model.Contato contato = new Model.Contato();
                contato.Name = txbNome.Text;
                contato.Email = txbEmail.Text;
                contato.Endereco = txbEdereco.Text;
                contato.Telefone = txbTelefone.Text;
                contato.Idresponsabel= usuario.Id;

                if (contato.Cadastrar() == 1)
                {
                    MessageBox.Show("Contato cadastrado!", "Sucesso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarDgvContato();

                    // Limpar os campos textbox:
                    txbNome.Clear();
                    txbEmail.Clear();
                    txbEdereco.Clear();
                    txbTelefone.Clear();
                }
                else
                {
                    MessageBox.Show("Falha ao cadastrar contato!", "Erro!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void dgvContatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obter o numero da linha que esta selecionada
            int ls = dgvContatos.SelectedCells[0].RowIndex;
            // Obter o valor (id) da primeira coluna (0) da linha selecionada (ls)
            int idSelecionado = int.Parse(dgvContatos.Rows[ls].Cells[0].Value.ToString());
            string nome = dgvContatos.Rows[ls].Cells[1].Value.ToString();

            // Confirmar exlusão:
            DialogResult r = MessageBox.Show($"Quer realmente deletar {idSelecionado} - {nome}?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                Model.Contato contato = new Model.Contato(); 
                contato.Id = idSelecionado;

                if(contato.Apagar() == 1)
                {
                    MessageBox.Show("Contato removido!", "SUCESOO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDgvContato();
                }
            }
        }
    }
}
