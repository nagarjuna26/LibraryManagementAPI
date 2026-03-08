using LibraryManagementSystem.Data;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use InMemory Database
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseInMemoryDatabase("LibraryDB"));

// Register repositories and services
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();

// Seed demo data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    DataSeeder.Seed(context);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
