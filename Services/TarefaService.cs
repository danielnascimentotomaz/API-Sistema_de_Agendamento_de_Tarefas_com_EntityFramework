using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Cadastro_Tarefas.Context;
using Api_Cadastro_Tarefas.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Api_Cadastro_Tarefas.Services
{
    public class TarefaService
    {

    

        private readonly TarefaContext _tarefaContext;

        public TarefaService(TarefaContext tarefaContext)
        {
            _tarefaContext = tarefaContext;
        }

        public List<Tarefa> ListarTarefas()
        {
            return _tarefaContext.Tarefas.ToList();
        }

        public Tarefa AdicionarTarefa(Tarefa tarefa)
        {
            _tarefaContext.Tarefas.Add(tarefa);
            _tarefaContext.SaveChanges();
            return tarefa;
        }

        public Tarefa AtualizarTarefa(int id ,Tarefa tarefa){

            var tarefaBanco = _tarefaContext.Tarefas.Find(id);

            if(tarefaBanco == null){
                 throw new InvalidOperationException("Tarefa não encontrada");
            }
              

            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;

            tarefaBanco.Status = tarefa.Status;

            tarefaBanco.Titulo = tarefa.Titulo;
            _tarefaContext.Tarefas.Update(tarefaBanco);

            _tarefaContext.SaveChanges();

            return tarefaBanco;

     
        }
        public void DeletarTarefa(int id){

            var tarefaBanco = _tarefaContext.Tarefas.Find(id);

            if(tarefaBanco == null){

                 throw new InvalidOperationException("Tarefa não encontrada");

            }

            _tarefaContext.Tarefas.Remove(tarefaBanco);
            _tarefaContext.SaveChanges();


        }

        public Tarefa BuscarTarefaId(int id){
            var tarefaBanco = _tarefaContext.Tarefas.Find(id);

            if(tarefaBanco == null){

                 throw new InvalidOperationException("Tarefa não encontrada");

            }

            return tarefaBanco;

        }

 public Tarefa BuscarTarefaTitulo(string titulo)
{
    var tarefaBanco = _tarefaContext.Tarefas.FirstOrDefault(t => t.Titulo == titulo);

    if (tarefaBanco == null)
    {
        throw new InvalidCastException("Tarefa não encontrada");
    }

    return tarefaBanco;
}


public IEnumerable<Tarefa> BuscarTarefasPorData(DateTime dateTime)
{
    var tarefas = _tarefaContext.Tarefas.Where(t => t.Data.Date == dateTime.Date).ToList();

    if (tarefas == null || !tarefas.Any())
    {
        throw new InvalidOperationException("Nenhuma tarefa encontrada para a data especificada");
    }

    return tarefas;
}


}    
    }
