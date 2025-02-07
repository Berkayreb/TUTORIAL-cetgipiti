using cetgipiti.Server.Services.Abstract;
using cetgipiti.Server.Services.Concrete;
using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped(sp =>
{
    var kernelBuilder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:1.5b", "http://localhost:11434");
    kernelBuilder.Services.AddHttpClient();
    return kernelBuilder.Build();
});
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
