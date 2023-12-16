using PetPal.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// Support Versioning 
builder.Services.AddPetPalApiVersioning();

builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.CustomizeUseSwaggerUi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
