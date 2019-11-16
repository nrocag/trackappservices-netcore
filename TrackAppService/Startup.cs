using Bussiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TrackAppService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        readonly string nombreAplicacionSwagger = "TrackApp";

        readonly string nombrePoliticaCors = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(this.nombrePoliticaCors,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3001", "http://localhost:3000", "http://localhost:8200", "http://localhost:8100")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = nombreAplicacionSwagger, Version = "v1" });
            });

            services.AddScoped<IBussinessDevice, BussinessDevice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(this.nombrePoliticaCors);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", this.nombreAplicacionSwagger);
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            new WebHostBuilder().UseKestrel(c => c.AddServerHeader = false);
        }
    }
}
