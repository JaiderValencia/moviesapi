using Microsoft.EntityFrameworkCore;
using moviesapi.DAL.Models;
using moviesapi.MoviesMapper;
using moviesapi.Repository;
using moviesapi.Repository.Irepository;
using moviesapi.Services;
using moviesapi.Services.IServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);
builder.Services.AddAutoMapper(config => config.AddProfile<Mapper>());

// inject services
builder.Services.AddScoped<IcategoryService, CategoryService>();

// inject repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "moviesapi v1"));

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
