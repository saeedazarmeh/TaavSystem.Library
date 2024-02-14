

using Microsoft.EntityFrameworkCore;
using Library.DomainLayer.User.Repository;
using Library.DomainLayer.Book.Repository;
using Library.CommonLayer.Exeption;
using Library.ApplicationLayer.Book;
using Library.ApplicationLayer.User;
using Library.QueryLayer.Book;
using Library.QueryLayer.User;
using Library.DomainLayer.Category.Repository;
using Library.DomainLayer.Author.Repository;
using Library.ApplicationLayer.Category;
using Library.ApplicationLayer.Author;
using Library.QueryLayer.Category;
using Library.QueryLayer.Author;
using Library.DomainLayer.User.Service;
using Library.CommonLayer.Exeption.ExceptionHandler;
using Library.CommonLayer.UnitOfWork;
using Library.InfraStuctureLayer.UnitOfWork;
using Library.InfraStuctureLayer.Repository;
using Library.Persistant.Repository;
using Library.InfraStuctureLayer.Service;
using Library.Persistant.Persistent.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
try
{
    builder.Services.AddControllers();
}
catch (NotFoundExeption notFoundEx)
{

}
catch (InvalidCastException invalidDataEx)
{

}
catch (Exception ex)
{

}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
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
builder.Services.AddScoped<IUserService, UserService>();
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

