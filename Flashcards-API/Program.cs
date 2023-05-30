using Microsoft.EntityFrameworkCore;
using Flashcards_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {

            policy.WithOrigins("https://flashcardpsork.azurewebsites.net/", "http://localhost:4200", "https://localhost:7078", "https://thankful-sea-0218b6a10.2.azurestaticapps.net")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});
var connValue = builder.Configuration.GetValue<string>("ConnectionStrings:flashcardDB");
builder.Services.AddDbContext<FlashcardDBContext>(opts =>
    opts.UseSqlServer(connValue));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*(app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Configuration.AddUserSecrets<Program>();
//}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();


