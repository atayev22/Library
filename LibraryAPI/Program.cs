using AutoMapper;
using LibraryApi.BaseLog.Utilities.Mapper;
using LibraryAPI.Business.Utilities.DependencyResolvers;
using LibraryAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DB Connection
builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    )
                );
#endregion

#region AutoMapper

var mapConfiq = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

builder.Services.AddSingleton(mapConfiq.CreateMapper());

#endregion

#region Dependencies
builder.Services.AddProjectDependencies();
#endregion

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
