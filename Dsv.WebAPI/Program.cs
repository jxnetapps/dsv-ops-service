using Dsv.Services;
using Dsv.Services.Data;
using HybridModelBinding;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServiceInterfaces();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(s => s.FullName.Replace("+", "."));
});

builder.Services.AddMvc().AddHybridModelBinder(options =>
{
    options.FallbackBindingOrder = new[] { Source.QueryString, Source.Route };
});

builder.Services.AddCors(o => o.AddPolicy("CorsAllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// Add services to the container.

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(options => options.AllowAnyOrigin());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();