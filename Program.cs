using Microsoft.OpenApi.Models;
using study_dot_net;
using study_dot_net.IRepositories;
using study_dot_net.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  c.EnableAnnotations();
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Super API", Version = "v1.0.1" });
});

// Injeção de dependências
builder.Services.AddDbContext<DbContexto>();
builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

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
