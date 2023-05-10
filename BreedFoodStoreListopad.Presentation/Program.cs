using BreedFoodStoreListopad.Persistence.Abstractions;
using BreedFoodStoreListopad.Persistence.Repositories;
using BreedFoodStoreListopad.Service.Abstractions;
using BreedFoodStoreListopad.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IRepositoryManager, FakeRepositoryManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
