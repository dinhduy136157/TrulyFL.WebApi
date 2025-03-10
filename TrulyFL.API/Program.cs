using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TrulyFL.Application.Services.Implementations;
using TrulyFL.Application.Services.Interfaces;
using TrulyFL.Infrastructure.Context;
using TrulyFL.Infrastructure.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins", policy =>
        policy.WithOrigins("http://localhost:3000") // Chỉ cho phép React truy cập
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddDbContext<TrulyFLContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("TrulyFLConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserServices>();

//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JWT CONFIG

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Convert.FromBase64String(jwtSettings["Key"] ?? throw new InvalidOperationException("jwt key missing"));

if (key.Length < 32)
{
    throw new InvalidOperationException("Key must be 32 characters");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
        option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        }
    );

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Api",
        Version = "v1",
        Description = "API authentication with Jwt"
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Input token"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
         {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type  = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[]{}
         }
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Sử dụng CORS
app.UseCors("_myAllowSpecificOrigins");

//auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
