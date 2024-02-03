using Library.InfraStuctureLayer.Persistent.EF;
using Library.InfraStuctureLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Options;
using Library.DomainLayer.User.Repository;
using Library.DomainLayer.Book.Repository;
using Library.ApplicationLayer.Book;
using Library.ApplicationLayer.User;
using TaavSystem.Library.Controllers;
using Library.QueryLayer.Book;
using Library.QueryLayer.User;
using Library.DomainLayer.Category.Repository;
using Library.DomainLayer.Author.Repository;
using Library.ApplicationLayer.Category;
using Library.ApplicationLayer.Author;
using Library.QueryLayer.Category;
using Library.QueryLayer.Author;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookCommand, BookCommand>();
builder.Services.AddScoped<IUserCommand, UserCommand>();
builder.Services.AddScoped<ICategoryCommand, CategoryCommand>();
builder.Services.AddScoped<IAuthorCommand, AuthorCommand>();
builder.Services.AddScoped<IBookQuery, BookQuery>();
builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<ICategoryQuery, CategoryQuery>();
builder.Services.AddScoped<IAuthorQuery, AuthorQuery>();
builder.Services.AddDbContext<EFDbContext>(option
    => option.UseSqlServer(builder.Configuration["ConnectionStrings:libraryDatabase"]));
var app = builder.Build();


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
