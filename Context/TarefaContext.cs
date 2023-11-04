using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Cadastro_Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Cadastro_Tarefas.Context
{

    /*
    TarefaContext é uma classe que desempenha um papel central ao usar o Entity Framework Core. Ela serve para se comunicar com um banco de dados a partir de um aplicativo C#.

    */
    public class TarefaContext:DbContext
    {



/*
        O construtor TarefaContext recebe informações (opções) que ajudam a configurar como o Entity Framework Core se conecta ao banco de dados, como a cadeia de conexão, o tipo de banco de dados, etc.

*/
        public TarefaContext(DbContextOptions<TarefaContext> options):base(options){

        }


       
        /*
        DbSet<Tarefa> Tarefas é uma propriedade que representa uma tabela chamada "Tarefas" no banco de dados. Isso permite que você consulte e modifique os dados nesta tabela usando métodos fornecidos pelo Entity Framework Core.
        */
        public DbSet<Tarefa> Tarefas { get; set;} 
        
    }
}