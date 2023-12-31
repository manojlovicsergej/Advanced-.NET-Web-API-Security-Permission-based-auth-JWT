using Application;
using Infrastructure;
using WebApi;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddIndentitySettings();
builder.Services.AddApplicationService();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddIdentityServices();
builder.Services.AddEmployeeService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfractureDependencies();
builder.Services.RegisterSwagger();

var app = builder.Build();
app.SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();