using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging.Abstractions;
using ProperNutrition.Application.Services.AccountService;
using ProperNutrition.DataAccess;
using Microsoft.EntityFrameworkCore;
using ProperNutrition.DataAccess.Repositories;
using FluentValidation;
using ProperNutrition.Application.Services;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Validator;
using System.Text.Json.Serialization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:7074", "http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

//auth
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

//repositories
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IArticlesRepository, ArticlesRepository>();
builder.Services.AddTransient<IDishesRepository, DishesRepository>();
builder.Services.AddTransient<IDishProductsRepository, DishProductsRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();

//services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IDishService, DishService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IFavouriteService, FavouriteService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

//validator
builder.Services.AddTransient<IValidator<LoginUserRequest>, LoginUserRequestValidator>();
builder.Services.AddTransient<IValidator<RegisterUserRequest>, RegisterUserRequestValidator>();
builder.Services.AddTransient<IValidator<ProductRequest>, ProductRequestValidator>();
builder.Services.AddTransient<IValidator<DishRequest>, DishRequestValidator>();
builder.Services.AddTransient<IValidator<ArticleRequest>, ArticleRequestValidator>();
builder.Services.AddTransient<IValidator<ParametrsRequest>, ParametrsRequestValidator>();

//db
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ProperNutritionDbContext>(options => options
    .UseLazyLoadingProxies().UseNpgsql(connectionString, b => b.MigrationsAssembly("ProperNutrition.API")));

//not cycling json converting
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
