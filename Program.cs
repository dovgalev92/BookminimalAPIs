using BookMinAPIs.Data;
using BookMinAPIs.Data.Interface;
using Microsoft.EntityFrameworkCore;
using BookMinAPIs.DTO;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));
builder.Services.AddScoped<IActionDbContext<CreateBookDtos>, ActionDbContext>();
builder.Services.AddScoped<ICommandRead<ReadBooksDtos>, ActionDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/commands", async (IActionDbContext<CreateBookDtos> command, [FromBody] CreateBookDtos book) =>
{
   await command.CommandBookCreate(book);

   return Results.Content("Данные успешно добавлены");
});
app.MapGet("api/commands", async(ICommandRead<ReadBooksDtos> commad) =>
{
    await commad.CommandAllBookRead();
    return Results.Ok();
});
app.Run();

