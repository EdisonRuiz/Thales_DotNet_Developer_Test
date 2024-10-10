using Thales_DotNet_Developer_Test.Server.BusinessLayer;
using Thales_DotNet_Developer_Test.Server.DataLayer;
using AutoMapper;
using Thales_DotNet_Developer_Test.Server.Models.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeDL, EmployeeDL>();
builder.Services.AddTransient<IEmployeeBL, EmployeeBL>();

builder.Services.AddAutoMapper(typeof(EmployeeProfile));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);
app.UseDefaultFiles();
app.UseStaticFiles();

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
