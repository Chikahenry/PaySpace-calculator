using Mapster;

using PaySpace.Calculator.Data;
using PaySpace.Calculator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMapster();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddCalculatorServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.InitializeDatabase();

app.Run();