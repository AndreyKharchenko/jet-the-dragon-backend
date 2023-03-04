using ES.Application.Infrastructure;
using ES.Persistence;
using ES.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
services.AddDbContext<EsDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("EsDbContextConnection")));
services.AddScoped<IDispatcher, Dispatcher>();

// Add Services
services
    .AddHttpContextAccessor()
    .AddScoped<IImageService, ImageService>()
    .AddScoped<ILoginNameProvider, JwtLoginNameProvider>()
    .AddRepositories(configuration)
    .AddQueryHandlers(configuration)
    .AddServices(configuration)
    .AddCommandHandlers(configuration);



services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer("Bearer", options =>
            {
                options.RequireHttpsMetadata = false;
                //options.Authority = "http://es.identity-server";
                options.Authority = "https://localhost:7186";



                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddControllers();
services.AddEndpointsApiExplorer();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Es.Web", Version = "v1" });
});

services.AddAuthorization(options =>
{
    options.AddPolicy("EmailId", policy => policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"));
    options.AddPolicy("RoleAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "esapi");
    });
});

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Es.Web v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
    {
        var esContext = serviceScope.ServiceProvider.GetRequiredService<EsDbContext>();
        esContext.Database.Migrate();
    }
}



app.UseCors("default");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
