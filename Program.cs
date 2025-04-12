using FastEndpoints;
using FastMinimalApi;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddFastEndpoints();

// Register services
builder.Services.AddSingleton<HelloEndpoint>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();


// Middleware Pipeline - ORDER MATTERS!
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // Apply CORS policy

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.MapGet("/hello", () => "Hello World!");

app.Run();