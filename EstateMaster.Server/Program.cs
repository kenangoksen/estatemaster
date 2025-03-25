using EstateMaster;
using EstateMaster.Server;
using EstateMaster.Server.Core;
using EstateMaster.Server.Core.Configurators;
using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.AspNetCore.Http.Features;

IConfiguration appSettings = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

AppSettings settings = new AppSettings();
settings.Database.ConnectionString = appSettings["Database:ConnectionString"];

var builder = WebApplication.CreateBuilder(args);

List<Type> configurators = new List<Type>()
{
    typeof(MigrationConfigurator),
    typeof(DependencyConfigurator)
};

foreach (Type type in configurators)
{
    IConfigurator starter = (IConfigurator)Activator.CreateInstance(type);
    starter.Configure(builder.Services, settings);
}

builder.Services.Configure<FormOptions>(o => {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddSingleton<IRijEncryptionService, RijEncryptionService>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));

var serverVersion = new MySqlServerVersion(new Version(8, 4, 2));
builder.Services.AddDbContext<EMDBContext>(dbContextOptions => dbContextOptions.UseMySql(appSettings["Database:ConnectionString"], serverVersion));
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EMDBContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("MsSQLConnection")));

// builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                builder =>
                {
                    builder.WithOrigins(
                        "https://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(_ => true)
                                .AllowCredentials();
                });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("CorsPolicy");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
