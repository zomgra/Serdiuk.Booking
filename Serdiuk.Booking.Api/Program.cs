using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serdiuk.Booking.Application;
using Serdiuk.Booking.Infrastructure;
using Serdiuk.Booking.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddResponseCaching();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false
        };
        // URL of our identity server
        options.Authority = "https://localhost:10001";
        options.RequireHttpsMetadata = false;
        options.Audience = "BookingApi";
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();

app.MapControllers();

var scope = app.Services.CreateScope();
ApplicationDbContextSeed.Initialize(scope.ServiceProvider.GetService<ApplicationDbContext>());

app.Run();
