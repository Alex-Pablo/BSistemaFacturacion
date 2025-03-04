using SistemaFacturacion.DAL;
using SistemaFacturacion.Repositories.Abstract;
using SistemaFacturacion.Repositories.Implementation;
using SistemaFacturacion.Services.Abstract;
using SistemaFacturacion.Services.Implementation;
using SistemaFacturacion.Utils.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<MyDbContext>(builder.Configuration.GetConnectionString("SqlConnectionString"));
builder.Services.AddScoped<IDTERepository, DTERepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDTEService, DTEService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.MapControllers();

app.Run();
