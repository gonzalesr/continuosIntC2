using Microsoft.EntityFrameworkCore;
using PatientManagement.Infrastructure;
using PatientManagement.Infrastructure.DomainModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
//    options.HttpsPort = 3001;
//});

// Agregar servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//    var application = app.Services.CreateScope().ServiceProvider.GetRequiredService<DomainDbContext>();

//    var pendingMigrations = await application.Database.GetPendingMigrationsAsync();
//    if (pendingMigrations != null)
//        await application.Database.MigrateAsync();
//}
app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.UseCors("AllowAll");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

// Esto permite que WebApplicationFactory lo use sin que la app se cierre
public partial class Program { }