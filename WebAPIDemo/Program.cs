using IRepositoryLib;
using LoggerLib;
using ProductRepoLib;
using WebAPIDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddProducts();

//builder.Services.AddTransient<ILogger>(sp => sp.GetRequiredService())

foreach (var s in builder.Services)
{
    Console.WriteLine(s.ImplementationInstance);
}

//builder.Host.ConfigureLogging(logging =>
//{
//    logging.ClearProviders();
//    logging.AddConsole();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // The following endpoint will only be invoked if the exception occurs in one of your action methods
    // it will NOT apply if the exception occurs with Web API
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
