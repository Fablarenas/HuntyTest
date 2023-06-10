using ChatIntegrationsHunty.Api.Exceptions;
using ExternalServicesInterfaces;
using HttpExternalServices.Interfaces;
using HttpExternalServices.Services;
using Interfaces;
using UsesCase;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Core;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence;
using MongoDB.Driver;
using Repository;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IExceptionHandler, ExceptionHandler>();
builder.Services.AddScoped<IWhatsappIntegration, WhatsappIntegration>();
builder.Services.AddScoped<IHttpServices, HttpServices>();


builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());


builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddSingleton<IMessageRepository, MessageRepository>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    var mapper = sp.GetRequiredService<IMapper>();
    return new MessageRepository(client, settings.DatabaseName, settings.MessageCollectionName, mapper);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
namespace ChatIntegrationsHunty.Api
{
    public partial class Program
    {
    }
}
