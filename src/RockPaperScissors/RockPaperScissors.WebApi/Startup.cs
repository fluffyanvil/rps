using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using RockPaperScissors.WebApi.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RockPaperScissors.WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseProblemDetails();
            app.UseCors(builder => builder
                    .WithOrigins()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.ConfigObject = new ConfigObject
                    {
                        ShowCommonExtensions = true
                    };
                    options.EnableDeepLinking();
                })
                .UseStaticFiles()
                .UseRouting()
                .UseHttpsRedirection()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Startup).Assembly));
            services.AddFluentValidation(new[] { typeof(Startup).Assembly });
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddValidatorsFromAssemblyContaining(typeof(Startup));
            services.AddProblemDetails();

            services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                });

            services
                .AddDbContext<GameDbInMemoryContext>();
        }
    }
}
