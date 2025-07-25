using Assembly.Projecto.Final.IoC;
using Assembly.Projecto.Final.Services.Mappings;
using Assembly.Projecto.Final.WebAPI.Extensions;
using Assembly.Projecto.Final.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();

builder.Services.AddServices(config);

builder.Services.AddAuthenticationJwtBearer(config);

builder.Services.AddCors(options =>

   options.AddPolicy("appProjectoFinal", builder =>
   {
       builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
   })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.EnsureDatabaseMigration();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("appProjectoFinal");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
