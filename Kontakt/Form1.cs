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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Instanciar um objeto do tipo usuario:
            Model.Usuario usuario = new Model.Usuario();  
            // Verificar se os campos estão vazios
            if(txbEmail.Text.Length < 6)
            {
                MessageBox.Show("E-mail ínvlaido!" , "ERROR!" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txbSenha.Text.Length == 0)
            {
                MessageBox.Show("O campo de senha não pode estar vazio!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                usuario.Email = txbEmail.Text;
                usuario.Senha = txbSenha.Text;
                // Tabela para receber o resultado da consulta de Login:
                DataTable resultado = usuario.Logar();

               // Verificar se a consulta teve resultado:
               if(resultado.Rows.Count == 1)
                {
                    MessageBox.Show($"Olá {resultado.Rows[0]["nome"]}");

                    // Atribuir no objeto, as infos vinda do bd:
                    usuario.Nome = resultado.Rows[0]["nome"].ToString();
                    usuario.Id = int.Parse(resultado.Rows[0]["id"].ToString());

                    // Abrir a nova janela
                    TelaInicial telaInicial = new TelaInicial(usuario);
                    this.Hide(); // Esconder a janela atual
                    telaInicial.ShowDialog(); // Mostrar a janela nova
                    this.Show(); // Mostrar a janela atual após a nova ser fechada
                }
                else
                {
                    MessageBox.Show("Usuario ou senha incorreto!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lblCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastrar cadastrar = new Cadastrar();
            cadastrar.ShowDialog();
        }
    }
}
