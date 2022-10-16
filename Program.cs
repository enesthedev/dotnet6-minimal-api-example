using Microsoft.OpenApi.Models;
using PizzaStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title="Pizza Store API", Description = "Making the Pizzas you love", Version = "v1"});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Store API v1");
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/pizzas/{id}", Db.GetPizza);
app.MapGet("/pizzas", Db.GetPizzas);
app.MapPost("/pizzas", Db.CreatePizza);
app.MapPut("/pizzas", Db.UpdatePizza);
app.MapDelete("/pizzas/{id}", Db.DeletePizza);

app.Run();
