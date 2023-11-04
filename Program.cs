using System.Text.Json.Serialization;
using Api_Cadastro_Tarefas.Context;

using Api_Cadastro_Tarefas.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adiciona a conexão com o banco de dados
builder.Services.AddDbContext<TarefaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));




/*
Um serviço transitório significa que uma nova instância do serviço será criada toda vez que ele for solicitado. Isso é útil para serviços leves que não têm estado duradouro. Cada vez que você injetar TarefaService em uma classe, uma nova instância dele será fornecida.
*/
builder.Services.AddTransient<TarefaService>();


/*
É uma parte da configuração do ASP.NET Core que está adicionando opções de formatação de JSON aos controladores da sua aplicação. Especificamente, você está configurando como o JSON é serializado e desserializado em sua aplicação.

*/
builder.Services.AddControllers().AddJsonOptions(options =>
{
     
    options.JsonSerializerOptions.WriteIndented = true; //Torna o JSON gerado mais legível para humanos, com recuo e quebras de linha.

   

    options.JsonSerializerOptions.Converters.Add(new JsonDateFormatConverter());//Converte datas no formato "yyyy-MM-dd".

    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); //Serializa enumerações como strings.
});




//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


