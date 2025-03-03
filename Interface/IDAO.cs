using CadastroAlunos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAlunos.Interface
{
    internal interface IDAO<T>
    {
        void Salvar(T entidade);
        void delete(int id);
        void Atualizar(T entidade);


    }
}   
        
