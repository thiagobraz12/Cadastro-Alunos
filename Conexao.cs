using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace CadastroAlunos
{
    internal class Conexao
    {
        public static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=123456;database=cadastroprofessor";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                //Console.WriteLine("Conectado!");
            }
            catch (Exception ex)
            {

                throw new Exception("erro ao conectar" + ex.Message);
            }
            return conexao;
        }
        public static void FecharConexao()
        {
            conexao.Clone();
        }
    }
}

