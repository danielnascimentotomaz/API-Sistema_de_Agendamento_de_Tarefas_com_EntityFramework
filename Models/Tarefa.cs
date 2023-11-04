using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;



namespace Api_Cadastro_Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set;}
        public string Titulo { get; set;}

        public string Descricao { get; set;}

         [DataType(DataType.Date)]//para indicar que uma propriedade deve ser interpretada como uma data no Swagger:
         public DateTime Data { get; set; }

        public EnumStatusTarefa  Status { get; set;}


  


        public Tarefa(){
        }

        public Tarefa(int id ,string titulo,string descricao,DateTime date, EnumStatusTarefa enumStatusTarefa){
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            
            this.Data = date;
            this.Status = enumStatusTarefa;

        }

    
      


    }
}