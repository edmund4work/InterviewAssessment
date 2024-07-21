using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InterviewTestAPISleekFlow.Interfaces;
using InterviewTestAPISleekFlow.Services;

namespace InterviewTestAPISleekFlow
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();

            // Other service registrations
            services.AddScoped<ITodoService, TodoService>();
            services.AddTransient<ILoggerFactory, LoggerFactory>();
            services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // In a production environment, you might want to configure error handling differently.
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enable Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
            });

            // Enable CORS if needed
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            // Enable routing and endpoints
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
