using InterviewTestAPISleekFlow.Database;
using InterviewTestAPISleekFlow.Interfaces;
using InterviewTestAPISleekFlow.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//begin: For DB connection
string connectionStringsleekflowdb = builder.Configuration.GetConnectionString("sleekflowdbConnection");
//if using tsql
//builder.Services.AddDbContext<SleekFlowDBContext>(options => options.UseSqlServer(connectionStringsleekflowdb));
//if using mysql
builder.Services.AddDbContext<SleekFlowDBContext>(options => options.UseMySql(connectionStringsleekflowdb, ServerVersion.AutoDetect(connectionStringsleekflowdb)));
///end: For DB Connection

builder.Services.AddScoped<ITodoService, TodoService>();


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
