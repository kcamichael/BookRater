using BookRater.Data.BookRaterContext;
using BookRater.Data.Entities;
using BookRater.Models.MappingConfigurations;
using BookRater.Services.GenreServices;
using BookRater.Services.ReviewServices;
using BookRater.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookRater.WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using Bearer scheme. \n\n Enter 'Berarer' [space] and then your token in the text input below.\n\nExample: \"Bearer 12345abcdef\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<BookRaterDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityCore<UserEntity>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookRaterDBContext>();

builder.Services.AddScoped<IReviewService, ReviewService>();
<<<<<<< HEAD
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

=======
builder.Services.AddScoped<IBookService, BookService>();
>>>>>>> 363c8a8599c3fba68b1261b261293e22dbda9914
builder.Services.AddAutoMapper(typeof(MappingConfiguration));

builder.Services.AddHttpContextAccessor();

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
