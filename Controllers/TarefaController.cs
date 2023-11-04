using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Cadastro_Tarefas.Context;
using Api_Cadastro_Tarefas.Models;
using Api_Cadastro_Tarefas.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cadastro_Tarefas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefaController: ControllerBase
    {
       
       // injeção dependência do service
       private readonly TarefaService _tarefaService;

       public TarefaController(TarefaService tarefaService){

        this._tarefaService = tarefaService;
       }
      



        [HttpPost]
        public IActionResult criar([FromBody] Tarefa tarefa){

           _tarefaService.AdicionarTarefa(tarefa);

            return Ok(tarefa);   
        }

        [HttpGet("obterTodos")]
        public IActionResult listar(){
            
            return Ok(_tarefaService.ListarTarefas());}



        [HttpPut("{id}")]
        public IActionResult atualizar(int id ,Tarefa tarefa){  

          try{
            var Tarefa = _tarefaService.AtualizarTarefa(id,tarefa);
            return Ok(Tarefa);

          }catch (InvalidOperationException ex){

            return NotFound(ex.Message); 
          
          }

            
   
    }


      
      [HttpDelete("{id}")]

      public IActionResult deletar(int id){

        try
        {
         _tarefaService.DeletarTarefa(id);

        return NoContent(); 
        }catch (InvalidOperationException ex)
    {
        return NotFound(ex.Message); 
    }
        
        

      }


      [HttpGet("{id}")]
      public IActionResult obterTarefaId(int id){

           try
    {
        var tarefa = _tarefaService.BuscarTarefaId(id);
        return Ok(tarefa);
    }catch (InvalidOperationException ex)
    {
        return NotFound(ex.Message); 
    }

      }


    [HttpGet("obterTarefaPorTitulo/{titulo}")]
    public IActionResult obterTarefaTitulo(string titulo){

      try{
        var tarefa = _tarefaService.BuscarTarefaTitulo(titulo);
        return Ok(tarefa);
      
      }catch (InvalidOperationException ex){
        return NotFound(ex.Message); 
      
      }
    }

    [HttpGet("obterTarefaPorData/{data}")]

    public IActionResult obterTarefaData(DateTime data){

      try{
        var tarefa = _tarefaService.BuscarTarefasPorData(data);
        return Ok(tarefa);
      
      

      }catch (InvalidOperationException ex){

        return NotFound(ex.Message);

      }
    }

   

      
}}
