using Microsoft.EntityFrameworkCore;
using Rocs.Application.Services;
using Rocs.Domain.Repository;
using Rocs.Infraestructure;
using Rocs.Infraestructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RocsContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("strConnRocsTest"))
    );
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerAppService, WorkerAppService>();

builder.Services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
builder.Services.AddScoped<IActivityAppService, ActivityAppService>();

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
