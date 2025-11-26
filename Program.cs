using Echeinbetter.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para aceitar todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar a política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.AddInventoryEndpoints();

app.Run();
