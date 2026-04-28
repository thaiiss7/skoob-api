using Microsoft.EntityFrameworkCore;
using Skoob.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SkoobDbContext>(options =>
{
   var mybd = Environment.GetEnvironmentVariable("SkoobDB");
    options.UseInMemoryDatabase(mybd);
});

var app = builder.Build();

// Garantir que o banco (e as tabelas) sejam criados ao iniciar
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SkoobDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
