using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Model
{
    public class Contato
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Idresponsabel { get; set; }
    

    public int Cadastrar()
        {
            // Instanciar e conectar ao banco:
            Banco banco = new Banco();
            banco.Conectar();

            // Criar o objeto SQLiteCommand:
            var cmd = banco.conexao.CreateCommand();

            // Definir o comando SQL com parâmetros:
            cmd.CommandText = "INSERT INTO Contatos (nome, email, telefone, id_Responsavel, endereco) VALUES (@email, @telefone, @nome, @id_responsavel, @endereco)";

            // Adicionar valores aos parâmetros:
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@nome", this.Name);
            cmd.Parameters.AddWithValue("@telefone", this.Telefone);
            cmd.Parameters.AddWithValue("@endereco", this.Endereco);
            cmd.Parameters.AddWithValue("@id_responsavel", this.Idresponsabel);

            // Executar e capturar a quantidade de linhas inseridas/removidas:
            int linhasAfetadas = cmd.ExecuteNonQuery();

            // Desconectar
            banco.Desconectar();

            // Retornar a quantidade de linhas inseridas
            return linhasAfetadas;
        }   

        public DataTable ListarTudo()
        {
            DataTable tabela = new DataTable();
            Banco banco = new Banco();
            banco.Conectar();
            var cmd = banco.conexao.CreateCommand();
            cmd.CommandText = "SELECT id, nome, email, telefone, endereco FROM contatos " +
            " WHERE id_responsavel=@id_responsavel";
            cmd.Parameters.AddWithValue("@id_responsavel", this.Idresponsabel);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(tabela);
            banco.Desconectar();
            return tabela;
        }

        public int Apagar()
        {
            Banco banco = new Banco();
            banco.Conectar();

            // Criar o objeto SQLiteCommand:
            var cmd = banco.conexao.CreateCommand();

            // Definir o comando SQL com parâmetros:
            cmd.CommandText = "DELETE FROM contatos WHERE id = @id";
            // Adicionar valores aos parâmetros:
            cmd.Parameters.AddWithValue("@id", this.Id);
            // Executar e capturar a quantidade de linhas inseridas/removidas:
            int linhasAfetadas = cmd.ExecuteNonQuery();

            // Desconectar
            banco.Desconectar();

            // Retornar a quantidade de linhas inseridas
            return linhasAfetadas;
        }
    }
}
