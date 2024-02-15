
using Library.Services.User.Contract;
using Microsoft.EntityFrameworkCore;
using Library.Persistant.Persistent.EF;
using Library.Persistant.Persistent.EF.Authors;
using Library.Persistant.Persistent.EF.Books;
using Library.Persistant.Persistent.EF.Categories;
using Library.Persistant.Persistent.EF.Users;
using Library.Contract.UnitOfWork;
using Library.Services.Authors.Contracts.Repository;
using Library.Services.Categories.Contract;
using Library.Services.Books.Contract;
using Library.Services.Authors.Contracts;
using Library.Services.User;
using Library.Services.Categories.Contract.Repository;
using Library.Services.User.Contract.Repository;
using Library.Services.Books.Contract.Repository;
using Library.Persistant.UnitOfWork;
using TaavSystem.Library.Utilities.ExceptionHandler;
using Library.Services.Authors;
using Library.Services.Books;
using Library.Services.Categories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
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

app.UseApiCustomExceptionHandler();

app.MapControllers();

app.Run();

