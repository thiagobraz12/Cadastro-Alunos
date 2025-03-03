using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CadastroAlunos.Models
{
    internal class Aluno
    {

        public int idAluno { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string sexo { get; set; }
        public string formacao { get; set; }
    }
}
