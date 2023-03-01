using COMMANDER.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommanderRepo,MockCommanderRepo>();
builder.Services.AddDbContext<CommanderContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("CommanderContext")));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CommanderContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}



app.MapControllers();

app.Run();