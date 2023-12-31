using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using study_dot_net;
using study_dot_net.IRepositories;
using study_dot_net.Repositories;
using study_dot_net.Services.DbLogger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  c.EnableAnnotations();
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Super API", Version = "v1.0.1" });
});

// Contexto banco de dados
builder.Services.AddDbContext<DbContexto>(options => {
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Inje��o de depend�ncias
builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Adicionar logger do SQL Server
builder.Logging.AddDbLogger();

// Build app
WebApplication app = builder.Build();

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
