using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.AddUpdateBookingCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Commands.DeleteBookingCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.BookingAppSerices.Queries.GetAllBookingListQuery;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.CreateOrUpdateClientCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Commands.DeleteClientCommand;
using puzzle.backend.coding.callenge.NETCore.ApplicationServices.ClientAppServices.Queries.GetClientQueries;
using puzzle.backend.coding.callenge.NETCore.Domain.Services.BookingDomainServices;
using puzzle.backend.coding.callenge.NETCore.Infraestructure.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<ICreateOrUpdateBookingCommand, CreateOrUpdateBookingCommand>();
builder.Services.AddScoped<IGetAllBookingListQuery, GetAllBookingListQuery>();
builder.Services.AddScoped<IDeleteBookingCommand, DeleteBookingCommand>();
builder.Services.AddScoped<IDeleteClientCommand, DeleteClientCommand>();
builder.Services.AddScoped<ICreateOrUpdateClientCommand, CreateOrUpdateClientCommand>();
builder.Services.AddScoped<IGetClientQueries, GetClientQueries>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages().AddNewtonsoftJson();

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
