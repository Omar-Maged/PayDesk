using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayDesk.Infrastructure.Data;

var builder = Host.CreateApplicationBuilder(args);

string? connectionString = Environment.GetEnvironmentVariable("PAYDESK_CONNECTION_STRING");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("PAYDESK_CONNECTION_STRING is not configured.");
}

builder.Services.AddDbContext<PayDeskDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();