
using CadastroAlunos.Models;
using CadastroAlunos.DAO;
using Mysqlx.Crud;
using CadastroAlunos;
using MySql.Data.MySqlClient;
using System;
using ZstdSharp.Unsafe;


class Program
{
    static void Main(string[] args)
    {
        
        AlunoDAO alunoDAO = new AlunoDAO();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\r\nMENU DE OPÇÕES:");
            Console.WriteLine("");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Listar Alunos");
            Console.WriteLine("3. Atualizar Aluno");
            Console.WriteLine("4. Deletar Aluno");
            Console.WriteLine("5. Sair");
            Console.Write("\r\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAluno(alunoDAO);
                    break;
                case "2":
                    ListarAlunos(alunoDAO);
                    break;
                case "3":
                    AtualizarAluno(alunoDAO);
                    break;
                case "4":
                    DeletarAluno(alunoDAO);
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("\r\nOpção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    
    static void CadastrarAluno(AlunoDAO alunoDAO)
    {
        Console.WriteLine("\r\nCadastro de Aluno:");

        Aluno aluno = new Aluno();

        Console.Write("Nome: ");
        aluno.nome = Console.ReadLine();

        Console.Write("CPF: ");
        aluno.cpf = Console.ReadLine();

        Console.Write("Email: ");
        aluno.email = Console.ReadLine();

        Console.Write("Telefone: ");
        aluno.telefone = Console.ReadLine();

        Console.Write("Data de Nascimento (yy-MM-dd): ");
        aluno.dataNascimento = DateOnly.Parse(Console.ReadLine());

        Console.Write("Sexo: ");
        aluno.sexo = Console.ReadLine();

        Console.Write("Formação: ");
        aluno.formacao = Console.ReadLine();

        alunoDAO.Salvar(aluno); 
        Console.WriteLine("\r\nAluno cadastrado com sucesso! Pressione Enter para continuar.");
        Console.ReadLine();
    }

    
    static void ListarAlunos(AlunoDAO alunoDAO)
    {
        Console.WriteLine("\r\nLista de Alunos:");
        Console.WriteLine("");

        List<Aluno> alunos = alunoDAO.List();
        if (alunos.Count > 0)
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.idAluno}, Nome: {aluno.nome}, CPF: {aluno.cpf}, Email: {aluno.email}, Telefone: {aluno.telefone}, Data de Nascimento: {aluno.dataNascimento}, Sexo: {aluno.sexo}, Formação: {aluno.formacao}");

            }
        }
        else
        {
            Console.WriteLine("\r\nNenhum aluno cadastrado.");
        }
        Console.WriteLine("\r\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    
    static void AtualizarAluno(AlunoDAO alunoDAO)
    {
        Console.WriteLine("\r\nAtualizar Aluno:");

        Console.Write("ID do Aluno a ser atualizado: ");
        int id = int.Parse(Console.ReadLine());

        Aluno aluno = new Aluno
        {
            idAluno = id
        };

        Console.Write("Novo Nome: ");
        aluno.nome = Console.ReadLine();

        Console.Write("Novo CPF: ");
        aluno.cpf = Console.ReadLine();

        Console.Write("Novo Email: ");
        aluno.email = Console.ReadLine();

        Console.Write("Novo Telefone: ");
        aluno.telefone = Console.ReadLine();

        Console.Write("Nova Data Nascimento: ");
        aluno.dataNascimento = DateOnly.Parse(Console.ReadLine());

        Console.Write("Novo Sexo: ");
        aluno.sexo = Console.ReadLine();

        Console.Write("Nova Formação: ");
        aluno.formacao = Console.ReadLine();

        alunoDAO.Atualizar(aluno);
        Console.WriteLine("\r\nAluno atualizado com sucesso! Pressione Enter para continuar.");
        Console.ReadLine();
    }

    
    static void DeletarAluno(AlunoDAO alunoDAO)
    {
        Console.WriteLine("\r\nDeletar Aluno:");

        Console.Write("ID do Aluno a ser deletado: ");
        int id = int.Parse(Console.ReadLine());

        Aluno aluno = new Aluno { idAluno = id };
        alunoDAO.delete(id);
        Console.WriteLine("\r\nAluno deletado com sucesso! Pressione Enter para continuar.");
        Console.ReadLine();
    }
}


