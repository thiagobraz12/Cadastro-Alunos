using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroAlunos;
using CadastroAlunos.Interface;
using CadastroAlunos.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Sql;

namespace CadastroAlunos.DAO
{
    internal class AlunoDAO: IDAO<Aluno>
    {
        public void Salvar(Aluno aluno)
        {
            try
            {
                string dataNascimento = aluno.dataNascimento.ToString("yy-MM-dd");
                string sql = "INSERT INTO aluno (nome,cpf,email,telefone,dataNascimento,sexo,formacao) VALUES(@nome,@cpf,@email,@telefone,@dataNascimento,@sexo,@formacao)";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@cpf", aluno.cpf);
                comando.Parameters.AddWithValue("@email", aluno.email);
                comando.Parameters.AddWithValue("@telefone", aluno.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@sexo", aluno.sexo);
                comando.Parameters.AddWithValue("@formacao", aluno.formacao);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Aluno cadastrado --");
                Conexao.FecharConexao();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void delete(int id)
        {
            try
            {
                string sql = " DELETE FROM Aluno WHERE id_Aluno = @id_Aluno";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_Aluno", id);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Aluno excluido --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"erro: {ex.Message}");
            }


        }
        public void Atualizar(Aluno aluno)
        {
            try
            {
                string dataNascimento = aluno.dataNascimento.ToString("yy-MM-dd");
                string sql = "UPDATE aluno SET nome = @nome, cpf = @cpf, email = @email, telefone = @telefone, dataNascimento = @dataNascimento, sexo = @sexo, formacao = @formacao WHERE id_Aluno = @id_Aluno";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@cpf", aluno.cpf);
                comando.Parameters.AddWithValue("@email", aluno.email);
                comando.Parameters.AddWithValue("@telefone", aluno.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@sexo", aluno.sexo);
                comando.Parameters.AddWithValue("@formacao", aluno.formacao);
                comando.Parameters.AddWithValue("@id_Aluno", aluno.idAluno);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Aluno atualizado --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"erro: {ex.Message}");
            }
        }
        public List<Aluno> List()
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                string sql = "SELECT * FROM aluno";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.idAluno = dr.GetInt32("id_Aluno");
                        aluno.nome = dr.GetString("nome");
                        aluno.cpf = dr.GetString("cpf");
                        aluno.email = dr.GetString("email");
                        aluno.telefone = dr.GetString("telefone");
                        aluno.dataNascimento = DateOnly.FromDateTime(dr.GetDateTime("dataNascimento"));
                        aluno.sexo = dr.GetString("sexo");
                        aluno.formacao = dr.GetString("formacao");
                        alunos.Add(aluno);
                    }
                }
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"erro: {ex.Message}");
            }
            return alunos;
        }
}   }

