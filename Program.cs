using BookMinAPIs.Data;
using BookMinAPIs.Data.Interface;
using Microsoft.EntityFrameworkCore;
using BookMinAPIs.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookMinAPIs.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));
builder.Services.AddScoped<IActionDbContext<Book, Author>, ActionDbContext>();
builder.Services.AddScoped<ICommandRead_Id<Book>, ActionDbContext>();
builder.Services.AddScoped<ICommandRead<Book>, ActionDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/commands", async(IActionDbContext<Book, Author> command, [FromBody] Author author) =>
{
    await command.CommandCreateAuthor(author);
    return Results.Content("Автор успешно создан");
});

app.MapPost("api/commands/{id}", async (IActionDbContext<Book, Author> command, IMapper _mapper, int id, [FromBody] CreateBookDtos book) =>
{
    var element = _mapper.Map<Book>(book);
    await command.CommandBookCreate(id, element);
    return Results.Content("Данные успешно добавлены");
});

app.MapGet("api/commands", async (ICommandRead<Book> command, IMapper _mapper) =>
{
    var allBooks = await command.CommandAllBookRead();
   
    return Results.Ok(_mapper.Map<IEnumerable<ReadBooksDtos>>(allBooks));

});
app.MapGet("api/commands/{id}", (ICommandRead_Id<Book> command, IMapper _mapper, int id) =>
{
    var bookid = command.CommandReadById(id);
    return Results.Ok(_mapper.Map<ReadBookDto_Id>(bookid));
});
app.MapPut("api/commands/{id}", async(IActionDbContext<Book, Author> command, ICommandRead_Id<Book> book, IMapper _mapper, int id, [FromBody] UpdateBookDtos dto) => 
{
    var bookId = book.CommandReadById(id);
    _mapper.Map(dto, bookId);
    await command.CommandUpdate(bookId);

    return Results.Content("Данные успешно обновлены");
});
app.MapDelete("api/commands/{id}", async (IActionDbContext<Book, Author> command, int id) =>
{
    await command.CommandDeleteBook(id);
    return Results.Content("Данные успешно удалены");
});

app.Run();

