using Domain.Contracts;
using EfcData;
using FileData.DataAccess;

using (TodoContext ctx = new())
{
    ctx.Seed();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoHome, TodoSqliteDAO>();
//builder.Services.AddScoped<IUserSerivice, InMemoryUserService>();
builder.Services.AddDbContext<TodoContext>();

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