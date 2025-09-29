using BuildingBlocks.API.Startup;
using TenantIdentity.API.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.BaseRegister(builder.Configuration, builder.Host).Register(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.BaseAppUse(builder.Configuration).AppUse(builder.Configuration);

app.Run();
